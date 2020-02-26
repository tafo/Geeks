using System;

namespace Geeks.Practices.School
{
    public class SumOfArrayElements
    {
        /// <summary>
        /// Without displaying "incorrect input" warnings
        /// </summary>
        public static void Run()
        {
            int numberOfTestCases;

            do
            {
                int.TryParse(Console.ReadLine(), out numberOfTestCases);
            } while (numberOfTestCases < 1 || numberOfTestCases > 100);

            var input = new int[numberOfTestCases][];

            for (var i = 0; i < numberOfTestCases; i++)
            {
                int numberOfElements;

                do
                {
                    int.TryParse(Console.ReadLine(), out numberOfElements);
                } while (numberOfElements < 1 || numberOfElements > 100);

                int elementIndex;
                var elements = new int[numberOfElements];

                do
                {
                    elementIndex = 0;

                    var elementListLine = Console.ReadLine();

                    if (string.IsNullOrEmpty(elementListLine)) continue;

                    var elementList = elementListLine.Trim().Split(' ');

                    if (elementList.Length != numberOfElements) continue;

                    foreach (var element in elementList)
                    {
                        if (int.TryParse(element, out var backup) && backup >= 1 && backup <= 100)
                        {
                            elements[elementIndex++] = backup;
                        }
                        else
                        {
                            break;
                        }
                    }
                } while (elementIndex < numberOfElements);

                input[i] = elements;
            }

            // Without converting into LINQ-Expression
            foreach (var elements in input)
            {
                var sum = 0;

                foreach (var element in elements)
                {
                    sum += element;
                }

                Console.WriteLine(sum);
            }

            Console.ReadKey();
        }
    }
}