using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace Filters.Infrastructure
{
    /// <summary>
    /// 定义动作过滤器，演示OnActionExecuted方法的使用
    /// </summary>
    public class ProfileActionAttribute : FilterAttribute, IActionFilter
    {
        private Stopwatch timer;

        /// <summary>
        /// 在动作方法被调用之后执行
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            timer.Stop();
            if (filterContext.Exception==null)
            {
                filterContext.HttpContext.Response.Write(
                    string.Format("<div>Action method slapsed time：{0:F6}</div>",timer.Elapsed.TotalSeconds)
                    );//响应html代码给浏览器
            }
        }

        /// <summary>
        /// 在动作方法被调用之前执行
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();
        }
    }
}