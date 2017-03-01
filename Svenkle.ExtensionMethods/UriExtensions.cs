using System;

namespace Svenkle.ExtensionMethods
{
    public static class UriExtensions
    {
        public static string GetBaseUri(this Uri uri)
        {
            return uri.GetLeftPart(UriPartial.Authority);
        }
    }
}
