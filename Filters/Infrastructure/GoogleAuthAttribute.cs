using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Security.Principal;
using System.Web.Security;

namespace Filters.Infrastructure
{
    /// <summary>
    /// 自定义认证过滤器
    /// </summary>
    public class GoogleAuthAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext context)
        {
            IIdentity ident=context.Principal.Identity;//当前主体的标识
            if (!ident.IsAuthenticated||!ident.Name.EndsWith("@google.com"))
            {
                context.Result=new HttpUnauthorizedResult();//为Result属性设置了一个值，那么MVC框架将调用OnAuthenticationChallenge方法
            }
        }

        /// <summary>
        /// 无论对认证的请求或对动作方法授权策略的请求失败，MVC框架都调用OnAuthenticationChallenge方法
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthenticationChallenge(AuthenticationChallengeContext context)
        {
            if (context.Result == null ||context.Result is HttpUnauthorizedResult)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller","GoogleAccount"},
                        { "action","Login"},
                        { "returnUrl",context.HttpContext.Request.RawUrl}
                    }
                    );
            }
            else
            {
                FormsAuthentication.SignOut();
            }
        }
    }
}