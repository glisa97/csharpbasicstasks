using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public abstract class Figure : IFigure
    {
        
        public Color Color { get; set; }
        public Field Field { get; set; }
        public char Mark { get; set; }

        

        public Figure(Color color, Field field, string mark)
        {
            Color = color;
            Field = field;
            if (color == Color.WHITE)
            {
                Mark = mark.ToLower().First();
            }
            else
            {
                Mark = mark.ToUpper().First();
            }
        }

        protected void SetCoorinates(int row, int column)
        {

            this.Field.RowNumber = row;
            this.Field.ColumnNumber = column;
        }

        protected Figure GetFigureFromDestionationField(Field destinationField, Board myBoard)
        {
            Figure elementToRemoveQ = null;
            foreach (Figure f1 in myBoard.FiguresList)
            {
                if (f1.Field.RowNumber == destinationField.RowNumber && f1.Field.ColumnNumber == destinationField.ColumnNumber)
                {
                    elementToRemoveQ = f1;

                }

            }
            return elementToRemoveQ;
        }


        public abstract void Move(Field destinationField, Board myBoard);

        public abstract bool CheckMove(Field destinationField);
    }
}
