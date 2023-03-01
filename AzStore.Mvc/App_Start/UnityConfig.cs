using System;
using Unity;
using AzStore.Common;
using AzStore.DataAccess;
using AzStore.Services;
using AzStore.DataAccess.Model;
using AzStore.DataAccess.Model.Mappers;
using AzStore.Common.Model;
using Unity.AspNet.Mvc;

namespace AzStore.Mvc
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();
            
            container.RegisterSingleton<IValidator<IShopping<IProduct>>, ProductShoppingCartValidator>();
            container.RegisterSingleton<IFilter<ProductEntity>, ProductNameFilter>();
            container.RegisterSingleton<IEntityMapper<IProduct, ProductEntity>, ProductEntityMapper>();
            container.RegisterSingleton<IEntityCollectionMapper<IProduct, ProductEntity>, ProductEntityCollectionMapper>();
            container.RegisterSingleton<IEntityCollectionMapper<IProductCategory, ProductCategoryEntity>, ProductCategoryEntityCollectionMapper>();
            container.RegisterType<IProductService, ProductService>(new PerRequestLifetimeManager());
            container.RegisterType<IShoppingCartService, ShoppingCartService>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository, EntityFrameworkRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IAzStoreDbContext, AzStoreDbContext>(new PerRequestLifetimeManager());
        }
    }
}