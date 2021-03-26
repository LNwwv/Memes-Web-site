using System.Web;
using System.Web.Mvc;

namespace MemesProject
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //Odpowiada za dostęp jedynie dla zalogowanych
            filters.Add(new AuthorizeAttribute());

            //Wyłącza adres strony bez SSL
            filters.Add(new RequireHttpsAttribute());

        }
    }
}
