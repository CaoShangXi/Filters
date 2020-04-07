using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace Filters.Infrastructure
{
    /// <summary>
    /// 定义结果过滤器，能对动作方法产生的结果进行操作
    /// </summary>
    public class ProfileResultAttribute : FilterAttribute, IResultFilter
    {
        private Stopwatch timer;
        /// <summary>
        /// 在动作结果执行之后被调用
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            timer.Stop();
            filterContext.HttpContext.Response.Write(
                    string.Format("<div>Result method slapsed time：{0:F6}</div>", timer.Elapsed.TotalSeconds)
                    );//响应html代码给浏览器
        }

        /// <summary>
        /// 在动作结果执行之前被调用
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();
        }
    }
}