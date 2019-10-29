using System.Web;
using System.Web.Mvc;
using Tasks.Filters;

namespace Tasks
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ExceptionHandlerFilter());
        }
    }
}
