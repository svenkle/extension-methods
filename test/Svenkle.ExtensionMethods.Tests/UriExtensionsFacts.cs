using System;
using Xunit;

namespace Svenkle.ExtensionMethods.Tests
{
    public class UriExtensionsFacts
    {
        public class TheGetBaseUriMethod
        {
            private const string QueryString = "?myquerystring=1";
            private const string Path = "/myvalue/";
            private const string Port = "8080";
            private const string Protocol = "http://";
            private static readonly Uri Uri = new Uri($"{Protocol}www.google.com:{Port}/{Path}{QueryString}");


            [Fact]
            public void ReturnsStringWithProtocol()
            {
                // Prepare & Act
                var urlString = Uri.GetBaseUri();

                // Assert
                Assert.StartsWith(Protocol, urlString);
            }

            [Fact]
            public void ReturnsStringWithPort()
            {
                // Prepare & Act
                var urlString = Uri.GetBaseUri();

                // Assert
                Assert.Contains(Port, urlString);
            }

            [Fact]
            public void ReturnsStringWithoutPath()
            {
                // Prepare & Act
                var urlString = Uri.GetBaseUri();

                // Assert
                Assert.DoesNotContain(Path, urlString);
            }

            [Fact]
            public void ReturnsStringWithoutQueryString()
            {
                // Prepare & Act
                var urlString = Uri.GetBaseUri();

                // Assert
                Assert.DoesNotContain(QueryString, urlString);
            }

            [Fact]
            public void ReturnsStringWithTrailingSlash()
            {
                // Prepare & Act
                var urlString = Uri.GetBaseUri();

                // Assert
                Assert.False(urlString.EndsWith("/"));
            }
        }
    }
}
