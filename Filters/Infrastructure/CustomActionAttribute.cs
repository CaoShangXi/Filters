using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    /// <summary>
    /// 定义动作过滤器
    /// </summary>
    public class CustomActionAttribute : FilterAttribute, IActionFilter
    {
        /// <summary>
        /// 在动作方法被调用之后执行
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 在动作方法被调用之前执行
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result = new HttpNotFoundResult();
            }
        }
    }
}