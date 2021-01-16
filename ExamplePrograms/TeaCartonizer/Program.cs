using System;
using System.Collections.Generic;
using StructuralPatterns.Composite;
using StructuralPatterns.Composite.IndividualCartons;

namespace TeaCartonizer
{
    internal class Program {
        /// <summary>
        /// This example uses the Composite Pattern to bundle and calculate mix-and-match
        /// orders of cartons of tea. Customers can order individual cartons of tea or
        /// create mix-and-match bundles, which contain sub-cartons of tea.
        /// We use an abstraction TeaCarton to represent an object that can contain
        /// sub-cartons, or be an individual product itself.  The Composite Pattern allows
        /// us to treat the tree of products (a carton of cartons and individual products)
        /// as a single logical entity for the purposes of calculating the number of servings
        /// in the parent carton.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("🍵  Welcome to the Tea Cartonizer");

            try {
                Console.WriteLine("How many cartons of Green Tea would you like to add?");
                var greenCartonsQty = int.Parse(Console.ReadLine() ?? "0");

                Console.WriteLine("How many cartons of White Tea would you like to add?");
                var whiteCartonsQty = int.Parse(Console.ReadLine() ?? "0");

                // Our Composite
                var customerBundle = new MixAndMatchBundle();

                // Customer Order is represented as a Dictionary of TeaCartons and their quantity.
                var customerOrder = new Dictionary<TeaCarton, int> {
                    { new GreenTeaCarton(), greenCartonsQty },
                    { new WhiteTeaCarton(), whiteCartonsQty },
                };

                customerBundle.BuildBundle(customerOrder);

                var bundleServings = customerBundle.GetNumberOfServings();

                Console.WriteLine($"Your Mix and Match Bundle Contains {bundleServings} servings.");

            } catch (Exception) {
                Console.WriteLine("Error cartonizing order. Please try again.");
            }

        }
    }
}
