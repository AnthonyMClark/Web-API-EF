using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Cors;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CIP {
  public static class WebApiConfig {
    public static void Register(HttpConfiguration config) {
      // Web API configuration and services
      config.EnableCors(new EnableCorsAttribute("*", "*", "*") { SupportsCredentials = true });
      // Web API routes
      config.MapHttpAttributeRoutes();
      //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
      GlobalConfiguration.Configuration.Formatters.Clear();
      GlobalConfiguration.Configuration.Formatters.Add(new System.Net.Http.Formatting.JsonMediaTypeFormatter());
      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
    }
  }
}
