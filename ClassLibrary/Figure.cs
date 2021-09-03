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
        protected bool CheckFigureInWay(IFigure FigureInWay, Field destinationField)
        {
            if (this.Field.CheckDistance(FigureInWay.Field) < this.Field.CheckDistance(destinationField) &&
                destinationField.CheckDistance(FigureInWay.Field) < destinationField.CheckDistance(this.Field))
            {
                return true;
            }
            return false;
        }

        protected virtual bool IsAnotherFigureInMovePath(Field destinationField, Board myBoard)
        {
            foreach (IFigure f1 in myBoard.FiguresList)
            {
                if (this.CheckMove(f1.Field) && this.CheckFigureInWay(f1, destinationField))
                {
                    Console.WriteLine("Figure is on the way");
                    return true;
                }
            }
            return false;
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

        protected void IsDestinationFigureSameColorLikeSource(Figure elementToRemoveR, Board myBoard)
        {
            if (this.Color == elementToRemoveR.Color)
            {
                Console.WriteLine("Figure can't eat same color figure");
                myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = true;
            }
        }
        protected void IsDestinationFigureDifferentColorLikeSource(Figure elementToRemoveR, Field destinationField, Board myBoard)
        {

            if (this.Color != elementToRemoveR.Color)
            {
                myBoard.FiguresList.Remove(elementToRemoveR);

                this.SetCoorinates(destinationField.RowNumber, destinationField.ColumnNumber);
                myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = true;
                myBoard.ChangeMoveTurn();
            }
        }
        public abstract void Move(Field destinationField, Board myBoard);

        public abstract bool CheckMove(Field destinationField);
    }
}
