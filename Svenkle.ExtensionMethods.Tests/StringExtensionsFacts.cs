using System;
using Xunit;

namespace Svenkle.ExtensionMethods.Tests
{
    public class StringExtensionsFacts
    {
        public class TheToHashSHA1Method
        {
            [Fact]
            public void HashesAString()
            {
                // Prepare
                const string stringValue = "SHA1";
                const string expected = "e1744a525099d9a53c0460ef9cb7ab0e4c4fc939";

                // Act & Assert
                Assert.True(stringValue.ToSHA1Hash().Equals(expected, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public class TheToHashSHA256Method
        {
            [Fact]
            public void HashesAString()
            {
                // Prepare
                const string stringValue = "SHA256";
                const string expected = "b3abe5d8c69b38733ad57ea75e83bcae42bbbbac75e3a5445862ed2f8a2cd677";

                // Act & Assert
                Assert.True(stringValue.ToSHA256Hash().Equals(expected, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public class TheToHashHMACSHA256Method
        {
            [Fact]
            public void HashesAString()
            {
                // Prepare
                const string stringValue = "HMACSHA256";
                const string secret = "SECRETKEY";
                const string expected = "7AD9D0C6D5D3DE8FD15C37DC650C45E784B563F1837BB4B516209FB0059711B6";

                // Act & Assert
                Assert.True(stringValue.ToHMACSHA256Hash(secret).Equals(expected, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public class TheToHashMD5Method
        {
            [Fact]
            public void HashesAString()
            {
                // Prepare
                const string stringValue = "MD5";
                const string expected = "7f138a09169b250e9dcb378140907378";

                // Act & Assert
                Assert.True(stringValue.ToMD5Hash().Equals(expected, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public class TheRemoveWhiteSpaceMethod
        {
            [Fact]
            public void RemovesWhiteSpaceFromAString()
            {
                // Prepare
                const string stringValue = "A B C  D E     F    ";
                const string expected = "ABCDEF";

                // Act & Assert
                Assert.Equal(stringValue.RemoveWhitespace(), expected);
            }
        }

        public class TheToGuidMethod
        {
            [Fact]
            public void ReturnsADeterministicGuidFromAString()
            {
                // Prepare
                const string stringValue = "ABCDEF";
                const string expected = "11a42788-a522-8b02-9808-c7bf84b9fcf6";

                // Act & Assert
                Assert.Equal(stringValue.ToGuid().ToString(), expected);
            }
        }

        public class TheToByteArrayMethod
        {
            [Fact]
            public void ReturnsAByteArrayForAString()
            {
                // Prepare
                const string stringValue = "A";

                // Act
                var result = stringValue.ToByteArray();

                // Assert
                Assert.Equal(result, new byte[] { 65, 0 });
            }

            [Fact]
            public void ThrowsNullReferenceExceptionForNullStrings()
            {
                // Prepare & Act
                var exception = Record.Exception(() => ((string)null).ToByteArray());

                // Assert
                Assert.NotNull(exception);
                Assert.IsType<NullReferenceException>(exception);
            }
        }
    }
}
