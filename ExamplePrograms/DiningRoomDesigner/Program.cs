using CreationalPatterns.Prototype;
using CreationalPatterns.Prototype.DiningRoomIcons.Chairs;
using CreationalPatterns.Prototype.DiningRoomIcons.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiningRoomDesigner {
    class Program {
        /// <summary>
        /// This example uses the Prototype creational pattern to help build a hypothetical Dining Room Designer.
        /// Users of the application can copy icons representing furniture to compose collections of objects at runtime.
        /// This Console Application is a mock example of some steps that might be part of client-side code for
        /// generating these shapes by deep-copying them from a prototype as a means of construction.
        /// It might also be the case that our client application does not have anything to work with except
        /// the roomDesigner instance - we might not be have the ability to __construct__ any of the objects, including the
        /// IChairIcon, ITableIcon, or PrototypeFactory instances.  In such cases, the ability for the PrototypeFactory
        /// to expose a public API for creating complex underlying objects is crucial to our being able to use these objects
        /// in our client-side code.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Construct prototype instances of furniture icons and a PrototypeFactory.
            var chairPrototype = new OakChairIcon();
            var tablePrototype = new OakTableIcon();
            var roomDesigner = new PrototypeFactory(tablePrototype, chairPrototype);

            // Use the RoomDesigner to create instances of furniture icons.
            IChairIcon chair_1 = roomDesigner.CloneChair();
            IChairIcon chair_2 = roomDesigner.CloneChair();
            IChairIcon chair_3 = roomDesigner.CloneChair();
            IChairIcon chair_4 = roomDesigner.CloneChair();
            ITableIcon table_1 = roomDesigner.CloneTable();

            var chairs = new List<IChairIcon>() { chair_1, chair_2, chair_3, chair_4 };

            var numberOfSeatCushionsToOrder = chairs.Count(chair => chair.HasSeatCushions);
            var numberOfTableLegs = table_1.GetTableNumberOfLegs();
            var tableShape = table_1.GetTableTopShape();

            Console.WriteLine($"Current room design state includes a {tableShape}-shaped " +
                $"table with {numberOfTableLegs} legs.");

            if (numberOfSeatCushionsToOrder == 0) {
                Console.WriteLine("No chairs in the design take seat cushions.");
            }
        }
    }
}
