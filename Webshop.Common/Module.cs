using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Webshop.Common.DAL;

namespace Webshop.Common
{
    public class Module : Autofac.Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            base.Load(builder);

            builder
                .RegisterType<BL.BL>()
                .As<BL.IBL>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<BL.BLProdukt>()
                .As<BL.IBLProdukt>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<BL.BLBestellung>()
                .As<BL.IBLBestellung>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<BL.BLUser>()
                .As<BL.IBLUser>()
                .InstancePerLifetimeScope();
             
            /* builder
                .RegisterType<BL.BLAuthentication>()
                .As<BL.IBLAuthentication>()
                .InstancePerLifetimeScope();
             */

            builder
                .RegisterType<DAL.WebshopDataContext>()
                .As<IDAL>()
                .InstancePerLifetimeScope();

           


        }
    }
}
