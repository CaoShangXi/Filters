using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    /// <summary>
    /// 自定义异常过滤器
    /// </summary>
    public class RangeExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            /*如果该异常未被其他过滤器处理，并且异常是ArgumentOutOfRangeException*/
            if (!filterContext.ExceptionHandled&&filterContext.Exception is ArgumentOutOfRangeException)
            {
                //filterContext.Result = new RedirectResult("~/Content/RangeErrorPage.html");//设置动作方法的结果
                int val=(int)(((ArgumentOutOfRangeException)filterContext.Exception).ActualValue);
                filterContext.Result = new ViewResult { ViewName="RangeError",ViewData=new ViewDataDictionary<int>(val)};
                filterContext.ExceptionHandled = true;//表示过滤器已处理该异常
            }
        }
    }
}