using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class King : IFigure
    {
        public Color Color { get; set; }
        public Field Field { get; set ; }
        public char Mark { get; set; }

        public King(Color color, Field field, char mark)
        {
            Color = color;
            Field = field;
            Mark = mark;
        }

        public void Move(int row, int column) {
            Console.WriteLine("Im King");
            this.Field.RowNumber = row;
            this.Field.ColumnNumber = column;
        }
    }
}
