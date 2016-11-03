using System.Web;
using System.Web.Mvc;

namespace IdeallyConnected_SPA_template
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
