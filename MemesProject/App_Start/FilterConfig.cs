using System.Web;
using System.Web.Mvc;

namespace MemesProject
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //Uncomment to allow access only for registered users
            filters.Add(new AuthorizeAttribute());

        }
    }
}
