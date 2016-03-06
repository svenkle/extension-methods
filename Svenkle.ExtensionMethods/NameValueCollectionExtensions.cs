using System.Collections.Generic;
using System.Collections.Specialized;

namespace Svenkle.ExtensionMethods
{
    public static class NameValueCollectionExtensions
    {
        public static NameValueCollection AsWriteable(this NameValueCollection collection)
        {
            if (collection != null && collection.Count > 0)
                return new NameValueCollection(collection.Count, collection);

            return new NameValueCollection();
        }

        public static Dictionary<string, string> ToDictionary(this NameValueCollection collection)
        {
            var dictionary = new Dictionary<string, string>();

            foreach (var nv in collection.AllKeys)
            {
                var value = collection[nv];
                if (!string.IsNullOrEmpty(value))
                    dictionary.Add(nv, value);
            }

            return dictionary;
        }
    }
}