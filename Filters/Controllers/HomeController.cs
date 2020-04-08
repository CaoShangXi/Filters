using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filters.Infrastructure;
using System.Diagnostics;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        private Stopwatch timer;
        //[CustomAuth(true)]
        //public string Index()
        //{
        //    return "This is the Index action on the Home controller";
        //}
        [Authorize(Users ="admin")]
        public string Index()
        {
            return "This is the Index action on the Home controller";
        }

        [GoogleAuth]
        [Authorize(Users ="bob@google.com")]
        public string List()
        {
            return "This is the List action on the Home controller";
        }

        //[RangeException]//异常过滤器，处理动作方法发生的异常
        //public string RangeTest(int id)
        //{
        //    if (id>100)
        //    {
        //        return string.Format("The id value is:{0}",id);
        //    }
        //    else
        //    {
        //        throw new ArgumentOutOfRangeException("id",id,"");//抛出异常
        //    }
        //}

        [HandleError(ExceptionType =typeof(ArgumentOutOfRangeException),View ="RangeError")]//使用内置过滤器，必须在Web.config文件添加customErrors节点
        public string RangeTest(int id)
        {
            if (id > 100)
            {
                return string.Format("The id value is:{0}", id);
            }
            else
            {
                throw new ArgumentOutOfRangeException("id", id, "");//抛出异常
            }
        }

        //[CustomAction]//动作过滤器，动作方法之前或之后执行
        //public string FilterTest()
        //{
        //    return "This is the FilterTest action";
        //}

        //[ProfileAction]//动作过滤器，演示动作方法执行完后执行过滤器方法
        //[ProfileResult]//结果过滤器
        //[ProfileAll]//动作过滤器和结果过滤器
        //public string FilterTest()
        //{
        //    return "This is the ActionFilterTest action";
        //}

        /// <summary>
        /// 使用无注解的过滤器方法，会调用下方的OnActionExcuting和OnResultExecuted方法
        /// </summary>
        /// <returns></returns>
        public string FilterTest()
        {
            return "This is the ActionFilterTest action";
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            timer.Stop();
            filterContext.HttpContext.Response.Write(string.Format("<div>Total elapsed time：{0:F6}</div>", timer.Elapsed.TotalSeconds));
        }
    }
}