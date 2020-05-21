namespace API
{
    using Base.IC.Configuracion;
    using System.Web.Http;

    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.EnableCors(new AccessPolicyCors());
            config.EnableCors();
            config.MapHttpAttributeRoutes();
     

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}