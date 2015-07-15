using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drupal_WebCrawlerLib.Extensions
{
   public static class StringExtensions
    {
       public static string GetAbsoluteUrl(this string href, string baseUri)
       {
           var uri = new Uri(href, UriKind.RelativeOrAbsolute);

           if (!uri.IsAbsoluteUri)
           {
               uri = new Uri(new Uri(baseUri), uri);
           }

           return uri.ToString();
       }

       public static bool IsWebUri(this string uri)
       {
           Uri uriResult;
           return System.Uri.TryCreate(uri, UriKind.Absolute, out uriResult) && uriResult.Scheme == System.Uri.UriSchemeHttp;
       }
    }
}
