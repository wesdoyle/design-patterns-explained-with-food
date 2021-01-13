using CreationalPatterns.Prototype.DiningRoomIcons.Chairs;
using CreationalPatterns.Prototype.DiningRoomIcons.Tables;
using System;

namespace CreationalPatterns.Prototype {
    public class PrototypeFactory {
        private readonly ITableIcon _table;
        private readonly IChairIcon _chair;

        public PrototypeFactory(ITableIcon table, IChairIcon chair) {
            _table = table;
            _chair = chair;
        }

        public IChairIcon CloneChair() {
            Console.WriteLine("Creating a clone of a Chair.");
            return (IChairIcon) _chair.DeepClone();
        }

        public ITableIcon CloneTable() {
            Console.WriteLine("Creating a clone of a Table.");
            return (ITableIcon) _table.DeepClone();
        }
    }
}
