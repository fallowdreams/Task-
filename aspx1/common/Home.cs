using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace TaskSystem
{
    public class BC_Home
    {
        // 页面跳转实现
        public static async Task ProcessRequest(HttpContext context, IApplicationBuilder builder)
        {
            string returnStr = "";
            // 获取DashboardID
            string DashboardID = context.Request.Query["DashboardID"];

            switch (DashboardID)
            {
                case "0":
                    {
                        returnStr = LoadHTML("system/login"); 
                        break;
                    }
                case "1":
                    {
                        returnStr = LoadHTML("task/TaskList");
                        break;
                    }
                case "2":
                    {
                        returnStr = LoadHTML("system/Register"); 
                        break;
                    }

                default:
                    {
                        returnStr = LoadHTML("system/login");
                        break;
                    }
            }
            await context.Response.WriteAsync(returnStr);
        }
        
        // 跳转页面方法
        private static string LoadHTML(string HtmlName)
        {
            StringBuilder HtmlB = new StringBuilder();
            string HtmlPath = Startup.ApplicationBasePath + "/wwwroot/html/" + HtmlName + ".html";

            using (StreamReader sr = new StreamReader(HtmlPath))
            {
                 string line;
                 while ((line = sr.ReadLine()) != null)
                 {
                      HtmlB.AppendLine(line);
                 }
            }
            return HtmlB.ToString();
        }
    }
}