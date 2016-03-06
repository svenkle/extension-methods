using System;
using System.Collections.Generic;
using System.Linq;

namespace Svenkle.ExtensionMethods
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Shuffle(new Random());
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable, Random random)
        {
            return enumerable.ShuffleIterator(random);
        }

        private static IEnumerable<T> ShuffleIterator<T>(this IEnumerable<T> enumerable, Random random)
        {
            var buffer = enumerable.ToList();
            for (var i = 0; i < buffer.Count; i++)
            {
                var j = random.Next(i, buffer.Count);
                yield return buffer[j];
                buffer[j] = buffer[i];
            }
        }

        public static string Join(this IEnumerable<string> values, char separator)
        {
            return string.Join(new string(new[] { separator }), values);
        }

        public static IEnumerable<IEnumerable<T>> CrossJoin<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
            return sequences.Aggregate(
                emptyProduct,
                (accumulator, sequence) =>
                    from accseq in accumulator
                    from item in sequence
                    select accseq.Concat(new[] { item })
                );
        }
    }
}
