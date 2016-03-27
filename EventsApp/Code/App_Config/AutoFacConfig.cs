using Autofac;
using Autofac.Integration.Mvc;
using EventsApp.Services;
using GogoKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace EventsApp.Code.App_Config
{
    public class AutoFacConfig
    {
        private static string ClientId = Config.ViagogoClientId;
        private static string ClientSecret = Config.ViagogoClientSecretKey;

        public static void Init() {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(Global).Assembly);
            builder.RegisterFilterProvider();

            builder.Register(c => new ViagogoClient(ClientId,
                                                    ClientSecret,
                                                    new ProductHeaderValue("EventsApp"),
                                                    new GogoKitConfiguration() { CurrencyCode = "eur" }
                                                    )
                            )
                    .As<IViagogoClient>()
                    .InstancePerRequest();

            var container = builder.Build();

            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}