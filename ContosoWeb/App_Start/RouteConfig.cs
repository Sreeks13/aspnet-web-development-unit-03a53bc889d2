routes.MapRoute(
    name: "ServiceJobDetails",
    url: "service/{make}/{id}",
    defaults: new
    {
        controller = "ServiceJobs",
        action = "ServiceJobDetails"
    }
);

routes.MapRoute(
    name: "Default",
    url: "{controller}/{action}/{id}",
    defaults: new
    {
        controller = "Home",
        action = "Index",
        id = UrlParameter.Optional
    }
);
