using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    /// <summary>
    /// 自定义授权过滤器
    /// </summary>
    public class CustomAuthAttribute:AuthorizeAttribute
    {
        private bool localAllowed;
        public CustomAuthAttribute(bool allowedParam)
        {
            localAllowed = allowedParam;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            /*如果是本地请求，即浏览器与应用程序服务器在同一设备上运行而形成的请求*/
            if (httpContext.Request.IsLocal)
            {
                return localAllowed;
            }
            else
            {
                return true;
            }
        }
    }
}