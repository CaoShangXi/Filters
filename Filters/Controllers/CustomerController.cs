using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filters.Infrastructure;

namespace Filters.Controllers
{
    /// <summary>
    /// 定义控制器，演示过滤器的优先级
    /// </summary>
    public class CustomerController : Controller
    {
        //public string Index()
        //{
        //    return "This is the Customer controller";
        //}

        //[SimpleMessage(Message = "A")]//如果不指定Order属性的值，那么值默认为-1，因为值最小，所以最先被执行
        //[SimpleMessage(Message = "C")]
        [SimpleMessage(Message = "A", Order = 1)]//Order表示过滤器的优先级，数字越小优先级越高
        [SimpleMessage(Message = "C", Order = 2)]
        public string Index()
        {
            return "This is the Customer controller";
        }
    }
}