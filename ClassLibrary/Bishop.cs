using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Bishop :IFigure
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Field Field { get; set; }
        public char Mark { get; set; }

        public Bishop(Color color, Field field, FigureSide figureSide, FigureNames figureNames)
        {
            Color = color;
            Field = field;
            if (color == Color.WHITE)
            {
                Mark = 'b';
            }
            else 
            {
                Mark = 'B';
            }
            Name = $"{Color}{figureSide}{figureNames}";
        }

        public void Move(int row, int column) {
            Console.WriteLine("Im bishop");
            this.Field.RowNumber = row;
            this.Field.ColumnNumber = column;
        }
    }
}
