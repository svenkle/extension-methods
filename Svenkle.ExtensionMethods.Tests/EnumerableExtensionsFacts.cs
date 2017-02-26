using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Svenkle.ExtensionMethods.Tests
{
    public class EnumerableExtensionsFacts
    {
        public class TheShuffleMethod
        {
            [Fact]
            public void ReturnsAShuffledListOfElementsUsingDeterminedSeed()
            {
                // Prepare
                var elements = new[] { "a", "b", "c", "d", "e" };
                var expected = new[] { "b", "a", "d", "e", "c" };

                // Act & Assert
                Assert.Equal(expected, elements.Shuffle(new Random(1)).ToArray());
            }

            [Fact]
            public void ReturnsAShuffledListOfElementsWithNonDeterminedSeed()
            {
                // Prepare
                var random = new Random();
                var elements = new List<int>();
                for (var i = 0; i < 5000; i++)
                    elements.Add(random.Next());

                // Act & Assert
                Assert.NotEqual(elements, elements.Shuffle(random));
            }
        }

        public class TheChooseMethod
        {
            [Fact]
            public void HandlesSingleElementLists()
            {
                // Prepare
                const string expected = "a";
                var elements = new[] { "a" };

                // Act & Assert
                Assert.Equal(expected, elements.Choose());
            }

            [Fact]
            public void DoesntHaveAOffByOneError()
            {
                // Prepare
                var elements = new List<string>();
                var expected = new[] { "a", "b", "c", "d", "e" };
                var random = new Random();

                // Act
                for (var i = 0; i < 50; i++)
                    elements.Add(expected.Choose(random));

                //Assert
                Assert.Equal(expected, elements.Distinct().OrderBy(x => x).ToList());
            }

            [Fact]
            public void ReturnsASingleElementOfElementsUsingDeterminedSeed()
            {
                // Prepare
                const string expected = "b";
                var elements = new[] { "a", "b", "c", "d", "e" };

                // Act & Assert
                Assert.Equal(expected, elements.Choose(new Random(1)));
            }
        }

        public class GetPermutationsMethod
        {
            [Fact]
            public void ReturnsAListOfAllPossiblePermutations()
            {
                // Prepare
                var elements = new[] { "a", "b", "c" };
                var expected = new[]
                {
                    new [] { "a", "b", "c"},
                    new [] { "a", "c", "b"},
                    new [] { "b", "a", "c"},
                    new [] { "b", "c", "a"},
                    new [] { "c", "b", "a"},
                    new [] { "c", "a", "b"}
                };

                // Act & Assert
                Assert.Equal(string.Join(string.Empty, elements.GetPermutations().ToArray().SelectMany(x => x)), string.Join(string.Empty, expected.SelectMany(x => x)));
            }

            [Fact]
            public void CreatesTheCorrectNumberOfPermuationsBasedOnInput()
            {
                // Prepare
                var random = new Random();
                var elements = new List<string>();
                for (var i = 0; i < 5; i++)
                    elements.Add(random.Next().ToString());

                // Act & Assert
                Assert.Equal(120, elements.GetPermutations().ToArray().Length);
            }
        }
    }
}
