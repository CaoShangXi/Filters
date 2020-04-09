using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Filters.Infrastructure
{
    /// <summary>
    /// 定义过滤器重载，忽略定义在更高级别（如，控制器级或全局）的过滤器
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class CustomOverrideActionFiltersAttribute : FilterAttribute, IOverrideFilter
    {
        public Type FiltersToOverride
        {
            get { return typeof(IActionFilter); }
        }
    }
}