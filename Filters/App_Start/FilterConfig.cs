using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filters.Infrastructure;

namespace Filters
{
    /// <summary>
    /// 定义全局过滤器，要使过滤器生效必须在Global.asax文件设置
    /// </summary>
    public class FilterConfig
    {
        public static void GegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());//添加异常过滤器
            filters.Add(new ProfileAllAttribute());//添加动作和结果过滤器
        }
    }
}