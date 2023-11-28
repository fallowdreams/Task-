using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
namespace TaskSystem;

public class BC_Tasks
{
    static StringBuilder sqlB = new StringBuilder();
    //查询sql
    public static object GetTaskList(string TaskID, string Task, string AssignTo)
    {
        //拼接sql
        sqlB.Length = 0;
        sqlB.AppendLine("SELECT ");
        sqlB.AppendLine("   TaskID");
        sqlB.AppendLine(" ，Task");
        sqlB.AppendLine(" , AssignedToUserID");
        sqlB.AppendLine(" , TaskTypeID");
        sqlB.AppendLine(" , TaskStatusID");
        sqlB.AppendLine(" , ProjectID");
        sqlB.AppendLine(" , UpdatedBy");
        sqlB.AppendLine(" , TimeUpdated");
        sqlB.AppendLine(" , CreatedBy");
        sqlB.AppendLine(" , TimeCreated");
        sqlB.AppendLine("FROM taskdb1.tasks");
        sqlB.AppendLine("WHERE 1=1");
        if (TaskID != "")
        {
            sqlB.AppendLine($"AND TaskID ={TaskID}");
        }
        if (Task != "")
        {
            sqlB.AppendLine($"AND Task LIKE '%{Task}%' ");
        }
        if (AssignTo != "")
        {
            sqlB.AppendLine($"AND AssignedToUserID ={AssignTo}");
        }
        sqlB.AppendLine("; ");

        MySqlDataReader reader = BC_MySqlUtils.ExecuteSQLGetRS(sqlB.ToString(), BC_MySqlUtils.GetMysqlConnection());

        List<Dictionary<string, string>> taskList = new List<Dictionary<string, string>>();
        while (reader.Read())
        {
            Dictionary<string, string> taskListDic = new Dictionary<string, string>();
            taskListDic.Add("TaskID", reader["TaskID"].ToString());
            taskListDic.Add("Task", reader["Task"].ToString());
            taskListDic.Add("AssignedToUserID", reader["AssignedToUserID"].ToString());
            taskListDic.Add("TaskTypeID", reader["TaskTypeID"].ToString());
            taskListDic.Add("TaskStatusID", reader["TaskStatusID"].ToString());
            taskListDic.Add("ProjectID", reader["ProjectID"].ToString());
            taskListDic.Add("UpdatedBy", reader["UpdatedBy"].ToString());
            taskListDic.Add("TimeUpdated", reader["TimeUpdated"].ToString());
            taskListDic.Add("CreatedBy", reader["CreatedBy"].ToString());
            taskListDic.Add("TimeCreated", reader["TimeCreated"].ToString());

            taskList.Add(taskListDic);
        }
        return new
        {
            TaskList = taskList
        };
    }

    //添加add
    public static object AddTask(string taskTitle, string assignTo, string taskType, string taskStatus, string project, string updatedBy, string createdBy)
    {
        sqlB.Length = 0;
        sqlB.AppendLine("INSERT INTO `taskdb1`.`tasks` (");
        sqlB.AppendLine("   `Task`");
        sqlB.AppendLine(" , `AssignedToUserID`");
        sqlB.AppendLine(" , `TaskTypeID`");
        sqlB.AppendLine(" , `TaskStatusID`");
        sqlB.AppendLine(" , `ProjectID`");
        sqlB.AppendLine(" , `UpdatedBy`");
        sqlB.AppendLine(" , `TimeUpdated`");
        sqlB.AppendLine(" , `CreatedBy`");
        sqlB.AppendLine(" , `TimeCreated`");
        sqlB.AppendLine(") VALUES ( ");
        sqlB.AppendLine($"   '{taskTitle}'");
        sqlB.AppendLine($" , '{assignTo}'");
        sqlB.AppendLine($" , '{taskType}'");
        sqlB.AppendLine($" , '{taskStatus}'");
        sqlB.AppendLine($" , '{project}'");
        sqlB.AppendLine($" , '{updatedBy}'");
        sqlB.AppendLine(" , now()");
        sqlB.AppendLine($" , '{createdBy}'");
        sqlB.AppendLine(" , now()");
        sqlB.AppendLine(")");
        sqlB.AppendLine(";");

        int affectedRow = BC_MySqlUtils.ExecuteSQL(sqlB.ToString());

        bool addMessage = false;
        if (affectedRow > 0)
        {
            addMessage = true;
        }
        return new
        {
            AddMessage = addMessage
        };
    }

    //修改Task
    public static object EditTask(string taskID, string taskTitle, string assignTo, string taskType, string taskStatus, string project, string updatedBy)
    {
        sqlB.Length = 0;

        sqlB.AppendLine("UPDATE `taskdb1`.`tasks`");
        sqlB.AppendLine("SET");
        sqlB.AppendLine($"   `Task` = '{taskTitle}' ");
        sqlB.AppendLine($" , `AssignedToUserID` = {assignTo} ");
        sqlB.AppendLine($" , `TaskTypeID` = {taskType} ");
        sqlB.AppendLine($" , `TaskStatusID` = {taskStatus} ");
        sqlB.AppendLine($" , `ProjectID` = {project} ");
        sqlB.AppendLine($" , `UpdatedBy` = {updatedBy} ");
        sqlB.AppendLine(" , `TimeUpdated` = NOW()");
        sqlB.AppendLine("WHERE ");
        sqlB.AppendLine($"   `TaskID` ={taskID} ");
        sqlB.AppendLine("; ");

        int affectedRow = BC_MySqlUtils.ExecuteSQL(sqlB.ToString());

        bool editMessage = false;
        if (affectedRow > 0)
        {
            editMessage = true;
        }
        return new
        {
            EditMessage = editMessage
        };

    }

    //删除Task
    public static object DeleteTask(string taskID)
    {
        sqlB.Length = 0;

        sqlB.AppendLine("DELETE FROM taskdb1.tasks");
        sqlB.AppendLine("WHERE");
        sqlB.AppendLine($" `TaskID`={taskID};");

        int affectedRow = BC_MySqlUtils.ExecuteSQL(sqlB.ToString());

        bool deleteMessage = false;
        if (affectedRow > 0)
        {
            deleteMessage = true;
        }
        return new
        {
            DeleteMessage = deleteMessage
        };

    }
}