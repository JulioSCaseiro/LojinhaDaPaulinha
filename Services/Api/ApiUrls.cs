using LojinhaDaPaulinha.Utils;

namespace LojinhaDaPaulinha.Services.Api
{
    public static class ApiUrls
    {
        // API base address + controllers.
        private const string _apiProducts = "api/Products";

        // Actions (except Get).
        private const string _create = "/Create";
        private const string _delete = "/Delete/";
        private const string _update = "/Update";


        // -- Create --
        public static string CreateProduct => _apiProducts + _create;

        // -- Delete --
        public static string DeleteProduct => _apiProducts + _delete;


        // -- Get --

        // Product.
        public static string GetAllProducts => _apiProducts + "/All";
        public static string GetProductDisplay => _apiProducts + "/Display/";
        public static string GetProductExists => _apiProducts + "/Exists/";
        public static string GetProductEditModel => _apiProducts + "/EditModel/";
        public static string GetProductsCombo => _apiProducts + "/Combo";


        // -- Update --
        public static string UpdateProduct => _apiProducts + _update;


        // -- Index --
        public static string Index(string entityName) => entityName switch
        {
            EntityNames.Product => GetAllProducts,

            _ => throw new NotImplementedException()
        };
    }
}
