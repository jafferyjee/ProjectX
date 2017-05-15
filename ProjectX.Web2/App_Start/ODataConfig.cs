using ProjectX.Entities.Models;
using System.Web.Http;
using System.Web.Http.OData.Builder;

namespace ProjectX.Web
{
    public static class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapODataRoute("odata", "odata", GetEdmModel());

            config.EnableQuerySupport();

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling
                = Newtonsoft.Json.PreserveReferencesHandling.Objects;
        }

        private static Microsoft.Data.Edm.IEdmModel GetEdmModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();

            var itemBuilder = builder.EntitySet<Entities.Models.Item>(typeof(Entities.Models.Item).Name);
            itemBuilder.EntityType.HasKey(x => x.SubInvCode);
            //itemBuilder.EntityType.HasOptional(x => x.SupplierCode);
            //itemBuilder.EntityType.HasMany(x => x.ItemColorSizes);

            //ActionConfiguration mainCategories = builder.Entity<Entities.Models.Item>().Collection.Action("MainCategories");
            //mainCategories.ReturnsCollectionFromEntitySet<Entities.Models.Item>(typeof(Entities.Models.Item).Name);

            //ActionConfiguration subCategories = builder.Entity<Entities.Models.Item>().Collection.Action("SubCategories");
            //subCategories.ReturnsCollectionFromEntitySet<Entities.Models.Item>(typeof(Entities.Models.Item).Name);

            builder.EntitySet<Entities.Models.ItemMainCategory>(typeof(Entities.Models.ItemMainCategory).Name);
            builder.EntitySet<Entities.Models.ItemSubCategory>(typeof(Entities.Models.ItemSubCategory).Name);
            builder.EntitySet<Entities.Models.SubInventory>(typeof(Entities.Models.SubInventory).Name);
            builder.EntitySet<Entities.Models.Branch>(typeof(Entities.Models.Branch).Name);
            builder.EntitySet<Entities.Models.Color>(typeof(Entities.Models.Color).Name);
            builder.EntitySet<Entities.Models.Company>(typeof(Entities.Models.Company).Name);
            builder.EntitySet<Entities.Models.Contact>(typeof(Entities.Models.Contact).Name);
            builder.EntitySet<Entities.Models.ContactType>(typeof(Entities.Models.ContactType).Name);
            builder.EntitySet<Entities.Models.ContactCategory>(typeof(Entities.Models.ContactCategory).Name);
            builder.EntitySet<Entities.Models.DocumentData>(typeof(Entities.Models.DocumentData).Name);
            builder.EntitySet<Entities.Models.DocumentNumber>(typeof(Entities.Models.DocumentNumber).Name);
            builder.EntitySet<Entities.Models.DocumentSize>(typeof(Entities.Models.DocumentSize).Name);
            builder.EntitySet<Entities.Models.DocumentType>(typeof(Entities.Models.DocumentType).Name);
            builder.EntitySet<Entities.Models.ItemColorSize>(typeof(Entities.Models.ItemColorSize).Name);
            builder.EntitySet<Entities.Models.ItemPrice>(typeof(Entities.Models.ItemPrice).Name);
            builder.EntitySet<Entities.Models.ItemStock>(typeof(Entities.Models.ItemStock).Name);
            builder.EntitySet<Entities.Models.PaymentTerm>(typeof(Entities.Models.PaymentTerm).Name);
            builder.EntitySet<Entities.Models.Range>(typeof(Entities.Models.Range).Name);
            builder.EntitySet<Entities.Models.SeasonalSale>(typeof(Entities.Models.SeasonalSale).Name);
            builder.EntitySet<Entities.Models.SeasonalSaleDetail>(typeof(Entities.Models.SeasonalSaleDetail).Name);
            builder.EntitySet<Entities.Models.Session>(typeof(Entities.Models.Session).Name);
            builder.EntitySet<Entities.Models.Size>(typeof(Entities.Models.Size).Name);
            builder.EntitySet<Entities.Models.SubInventorySizeRange>(typeof(Entities.Models.SubInventorySizeRange).Name);
            builder.EntitySet<Entities.Models.Photo>(typeof(Entities.Models.Photo).Name);
            builder.EntitySet<Entities.Models.ExceptionLog>(typeof(Entities.Models.ExceptionLog).Name);

            return builder.GetEdmModel();
        }
    }
}