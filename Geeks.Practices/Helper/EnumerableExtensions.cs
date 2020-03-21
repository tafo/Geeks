using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Helper
{
    [SuppressMessage("ReSharper", "ConvertToUsingDeclaration")]
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Interleave<T>(this IEnumerable<T> first, IEnumerable<T> second)
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
    }
}