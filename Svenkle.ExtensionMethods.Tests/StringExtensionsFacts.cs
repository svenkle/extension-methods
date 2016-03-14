using System;
using Xunit;

namespace Svenkle.ExtensionMethods.Tests
{
    public class StringExtensionsFacts
    {
        public class TheToHashMethod
        {
            [Fact]
            public void HashesAString()
            {
                // Prepare
                const string stringValue = "213";
                const string expected = "19187DC98DCE52FA4C4E8E05B341A9B77A51FD26";

                // Act & Assert
                Assert.Equal(stringValue.ToHash(), expected);
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
