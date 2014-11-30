using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.UI.WebControls;
using System.Web.UI;


namespace RetailSystem.Common
{
    public class DynamicCaller
    {
        public static void InvokeStringMethod(string FunctionName, Type ClassType, object ob)
        {
            MethodInfo mi = ClassType.GetMethod(FunctionName);
            string result = (string)mi.Invoke(ob, null);
        }

        public static void ShowMessage(Page page,string Message) 
        {
            

        }

        public static decimal ConvertToDouble(string Value)
        {
            return decimal.Parse(Value, System.Globalization.NumberStyles.Float);

        }
    }
}