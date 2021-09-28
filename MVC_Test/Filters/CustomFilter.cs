using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test.Filters
{
    public class CustomFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //base.OnActionExecuted(filterContext);
            string messages = string.Format(@"測試自訂ActionFilter顯示訊息在輸出視窗, 進入{0}的{1}Action", filterContext.Controller, filterContext.RouteData.Values["action"]);
            System.Diagnostics.Debug.WriteLine(messages, "Action Filter Log");
        }
    }
}