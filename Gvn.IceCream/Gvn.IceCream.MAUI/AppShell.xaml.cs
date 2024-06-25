using Gvn.IceCream.MAUI.Pages;

namespace Gvn.IceCream.MAUI
{
    public partial class AppShell : Shell
    {
        private static Type[] _routeAblePageTypes = [
            typeof(SigningPage),
            typeof(SignupPage),
            typeof(MyOrdersPage),
            typeof(OrderDetailsPage),
            typeof(DetailsPage)
            ];
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute("route", "Page_Type");
            RegisterRoutes();
        }
        private static void RegisterRoutes()
        {
            foreach (var item in _routeAblePageTypes)
            {
                Routing.RegisterRoute(item.Name, item);
            }
        }
    }
}
