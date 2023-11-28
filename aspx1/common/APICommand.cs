using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace TaskSystem
{
    public class BC_APICommand
    {
        private static JObject PostData;
        // 实现方法
        public static async Task ProcessAPIResult(HttpContext content, IApplicationBuilder builder)
        {
            string returnStr = "";
            // 获取POST参数
            string parameters = "{}";
            using (StreamReader sr = new StreamReader(content.Request.Body, Encoding.UTF8))
            {
                //string content = sr.ReadToEnd();  //.Net Core 3.0 默认不再支持
                parameters = sr.ReadToEndAsync().Result;
            }
            PostData = JObject.Parse(parameters);
            // 获取APICommand
            string APICommand = GetParameterByName("APICommand");
            switch (APICommand)
            {
                case "demo":
                    {
                        returnStr = BC_APIResult.GetAPIResult("", (int)BC_APIResultStatus.UN_KNOW, "示例请求");
                        break;
                    }

                case "Login":
                    {
                        string userName = GetParameterByName("UserName");
                        string userPwd = GetParameterByName("UserPwd");
                        string sqlStr = $"SELECT UserID from `taskdb1`.`users` where UserName = '{userName}' and EncryptedPassword = '{userPwd}';";

                        object userID = BC_MySqlUtils.ExecuteSQLGetScalar(sqlStr);

                        string message = "";
                        if (userID != null)
                        {
                            message = userID.ToString();
                        }
                        returnStr = BC_APIResult.GetAPIResult(message, (int)BC_APIResultStatus.UN_KNOW, "示例请求");
                        break;
                    }

                case "Register":
                    {
                        string userName = GetParameterByName("UserName");
                        string nickName = GetParameterByName("NickName");
                        string email = GetParameterByName("Email");
                        string phone = GetParameterByName("Phone");
                        string userPwd = GetParameterByName("UserPwd");
                        string sqlStr = $"INSERT INTO `taskdb1`.`users` ( `UserName`, `NickName`, `RoleID`, `Email`, `Phone`, `EncryptedPassword`, `Status`, `UpdatedBy`, `TimeUpdated`, `CreatedBy`, `TimeCreated`) VALUES ('{userName}', '{nickName}', '1' ,'{email}', '{phone}', '{userPwd}', '1', '1', Now(), '1', Now())";

                        int affectedRow = BC_MySqlUtils.ExecuteSQL(sqlStr);

                        string message = "";
                        if (affectedRow > 0)
                        {
                            message = affectedRow.ToString();
                        }
                        returnStr = BC_APIResult.GetAPIResult(message, (int)BC_APIResultStatus.UN_KNOW, "login");
                        break;
                    }

                case "TaskList":
                    {
                        string TaskID = GetParameterByName("TaskID");
                        string Task = GetParameterByName("Task");
                        string AssignTo = GetParameterByName("AssignTo");

                        object message = BC_Tasks.GetTaskList(TaskID, Task, AssignTo);

                        returnStr = BC_APIResult.GetAPIResult(message, (int)BC_APIResultStatus.UN_KNOW, "示例请求");
                        break;
                    }

                case "AddTask":
                    {
                        string taskTitle = GetParameterByName("TaskTitle");
                        string assignTo = GetParameterByName("AssignTo");
                        string taskType = GetParameterByName("TaskType");
                        string taskStatus = GetParameterByName("TaskStatus");
                        string project = GetParameterByName("Project");
                        string updatedBy = GetParameterByName("UpdatedBy");
                        string createdBy = GetParameterByName("CreatedBy");

                        object message = BC_Tasks.AddTask(taskTitle, assignTo, taskType, taskStatus, project, updatedBy, createdBy);

                        returnStr = BC_APIResult.GetAPIResult(message, (int)BC_APIResultStatus.UN_KNOW, "示例请求");
                        break;
                    }

                case "EditTask":
                    {
                        string taskID = GetParameterByName("TaskID");
                        string taskTitle = GetParameterByName("TaskTitle");
                        string assignTo = GetParameterByName("AssignTo");
                        string taskType = GetParameterByName("TaskType");
                        string taskStatus = GetParameterByName("TaskStatus");
                        string project = GetParameterByName("Project");
                        string updatedBy = GetParameterByName("UpdatedBy");

                        object message = BC_Tasks.EditTask(taskID, taskTitle, assignTo, taskType, taskStatus, project, updatedBy);

                        returnStr = BC_APIResult.GetAPIResult(message, (int)BC_APIResultStatus.UN_KNOW, "Login");
                        break;
                    }
                case "DeleteTask":
                    {
                        string taskID = GetParameterByName("TaskID");

                        object message = BC_Tasks.DeleteTask(taskID);

                        returnStr = BC_APIResult.GetAPIResult(message, (int)BC_APIResultStatus.UN_KNOW, "Login");
                        break;
                    }
                default:
                    {
                        returnStr = BC_APIResult.GetAPIResult("", (int)BC_APIResultStatus.FAIL, "请检查APICommand名称是否正确!");
                        break;
                    }
            }
            await content.Response.WriteAsync(returnStr);
        }
        // 根据名称获取string类型参数
        private static string GetParameterByName(string ParameterName)
        {
            return PostData[ParameterName].ToString();
        }
    }
}