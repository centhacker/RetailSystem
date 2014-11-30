using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace RetailSystem.Common
{
    public class Logger
    {
        public static String ClassName = string.Empty;

        public  void Print(string ClassName, string Type, string Message)
        {
            //if (File.Exists(HttpContext.Current.Server.MapPath("/") + "\\logs\\" + ClassName + GetDayOfDate() + ".txt"))
            //{
            //    string path = HttpContext.Current.Server.MapPath("/") + "\\logs\\" + ClassName + GetDayOfDate() + ".txt";

            //     File.AppendAllText(path, DateTime.Now.ToString() + "::" + ClassName + "::" + Type + "-->" + Message + Environment.NewLine);
            //}
            //else
            //{
            //    File.Create(HttpContext.Current.Server.MapPath("/") + "\\logs\\" + ClassName + GetDayOfDate() + ".txt");
                
            //    Print(ClassName, Type, Message);
            //}


        }


        public string GetDayOfDate()
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            string[] day = Convert.ToString(dateTime.ToString("d")).Split('/');
            string returnDay = string.Empty;
            for (int i = 0; i < day.Length; i++)
            {
                returnDay += day[i];
            }
            return returnDay;
        }
    }

  public enum LogPointer
    {
        Info = 1,
        Error = -1,
        Debug = 0
    }
}