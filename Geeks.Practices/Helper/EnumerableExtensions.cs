using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Helper
{
    [SuppressMessage("ReSharper", "ConvertToUsingDeclaration")]
    public static class EnumerableExtensions
    {
        public static IEnumerable<int> Interleave(this IEnumerable<int> first, IEnumerable<int> second)
        {
            using (var e1 = first.GetEnumerator())
            using (var e2 = second.GetEnumerator())
            {
                while (e1.MoveNext())
                {
                    yield return e1.Current;
                    if (e2.MoveNext())
                    {
                        yield return e2.Current;
                    }
                }

                while (e2.MoveNext())
                {
                    yield return e2.Current;
                }
            }
        }

        public static IEnumerable<TSource> First<TSource>(IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            var index = -1;
            foreach (var element in source)
            {
                checked
                {
                    index++;
                }

                if (!predicate(element, index)) continue;

                yield return element;
                yield break;
            }
        }
    }
}