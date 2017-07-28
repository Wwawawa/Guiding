[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(App_Start.test), "Prestart")]
[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(App_Start.test), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(App_Start.test), "End")]

namespace App_Start
{
    public static class test
    {
        public static IUnityContainer Container { get; private set; }

        public static void Prestart()
        {
            CreateContainer();
        }

        public static void Start()
        {
            ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory(Container));

            RouteTable.Routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
        }

        public static void End()
        {
            if (Container != null)
            {
                Container.Dispose();
            }
        }

        private static void CreateContainer()
        {
            var container = new UnityContainer();
            var section = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;
            if (section != null && section.Containers.Count > 0)
            {
                section.Configure(container);
            }

            Container = container;
        }
    }
}
