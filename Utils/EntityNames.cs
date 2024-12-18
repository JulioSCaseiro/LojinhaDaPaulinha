namespace LojinhaDaPaulinha.Utils
{
    public class EntityNames
    {
        //TODO: Add Categories etc
        public const string Product = "Product";


        public static string Spaced(string entityName)
        {
            return entityName switch
            {
                //TODO: Add Categories etc
                Product => "Product",
                _ => throw new NotImplementedException()
            };
        }

        public static string Plural(string entityName)
        {
            return entityName switch
            {
                //TODO: Add Categories etc
                Product => "Products",
                _ => throw new NotImplementedException()
            };
        }

        public static string PluralSpaced(string entityName)
        {
            return entityName switch
            {
                //TODO: Add Categories etc
                Product => "Products",
                _ => throw new NotImplementedException()
            };
        }
    }
}
