using System;

namespace ClassLibrary
{
    public class Knight:IFigure
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Field Field { get; set; }
        public char Mark { get; set; }

        public Knight(Color color, Field field, FigureSide figureSide, FigureNames figureNames)
        {
            Color = color;
            Field = field;
            //Mark = mark;
            if (color == Color.WHITE)
            {
                Mark = 'n';
            }
            else
            {
                Mark = 'N';
            }
            Name = $"{color}{figureSide}{figureNames}";
        }

        public void Move(int row, int column) {
            
            this.Field.RowNumber = row;
            this.Field.ColumnNumber = column;
        }

        public void Move(Field destinationField)
        {
            throw new NotImplementedException();
        }

        public bool CheckMove(Field destinationField)
        {
            throw new NotImplementedException();
        }
    }
}
