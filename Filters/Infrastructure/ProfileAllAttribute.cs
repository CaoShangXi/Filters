using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace Filters.Infrastructure
{
    /// <summary>
    /// 定义内置的动作过滤器和结果过滤器
    /// </summary>
    public class ProfileAllAttribute:ActionFilterAttribute
    {
        private Stopwatch timer;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            timer.Stop();
            filterContext.HttpContext.Response.Write(string.Format("<div>Total elapsed time：{0:F6}</div>",timer.Elapsed.TotalSeconds));
        }
    }
}