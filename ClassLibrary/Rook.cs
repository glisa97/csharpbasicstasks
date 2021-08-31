using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary
{
    public class Rook : Figure
    {
        public string Name { get; set; }

        public Rook(Color color, Field field, string mark) : base(color, field, mark)
        { 
        }



        private bool CheckFigureInWay(IFigure FigureInWay, Field destinationField)
        {
            if (this.Field.CheckDistance(FigureInWay.Field) < this.Field.CheckDistance(destinationField) &&
                destinationField.CheckDistance(FigureInWay.Field) < destinationField.CheckDistance(this.Field))
            {

                return true;
            }
            return false;
        }

        private void IsAnotherFigureInMovePath(Field destinationField, Board myBoard)
        {
            foreach (IFigure f1 in myBoard.FiguresList)
            {
                if (this.CheckMove(f1.Field) && this.CheckFigureInWay(f1, destinationField))
                {
                    Console.WriteLine("Figure is on the way");
                    return;

                }

            }

        }

        private Figure GetFigureFromDestionationField(Field destinationField, Board myBoard) 
        {
            Figure elementToRemoveR = null;
            foreach (Figure f1 in myBoard.FiguresList)
            {
                if (f1.Field.RowNumber == destinationField.RowNumber && f1.Field.ColumnNumber == destinationField.ColumnNumber)
                {
                    elementToRemoveR = f1;

                }

            }
            return elementToRemoveR;
        }

        private void IsDestinationFigureSameColorLikeSource(Figure elementToRemoveR, Board myBoard) 
        {
            if (this.Color == elementToRemoveR.Color)
            {
                Console.WriteLine("Figure can't eat same color figure");
                myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = true;

            }
        }

        private void IsDestinationFigureDifferentColorLikeSource(Figure elementToRemoveR,Field destinationField, Board myBoard)
        {
            string eatenFigure;

            if (this.Color != elementToRemoveR.Color)
            {
                myBoard.FiguresList.Remove(elementToRemoveR);
                eatenFigure = elementToRemoveR.Name;
                Console.WriteLine("Eaten figure: " + $"{ eatenFigure}");
                Console.WriteLine("by:" + $"{ this.Name}");

                this.SetCoorinates(destinationField.RowNumber, destinationField.ColumnNumber);
                myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = true;
                myBoard.ChangeMoveTurn();

            }
        }



        #region Public methods

        public override void Move(Field destinationField, Board myBoard)
        {
            IFigure elementToRemoveR = null;
            string eatenFigure;

            if (this.CheckMove(destinationField))
            {
                IsAnotherFigureInMovePath(destinationField, myBoard);


                myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = false;


                if (myBoard.TheGrid[destinationField.RowNumber, destinationField.ColumnNumber].CurrentlyOccupied == true)
                {

                    Figure destinationFigure = GetFigureFromDestionationField(destinationField, myBoard);

                    IsDestinationFigureSameColorLikeSource(destinationFigure, myBoard);

                    IsDestinationFigureDifferentColorLikeSource(destinationFigure, destinationField, myBoard);
                
                }
                else
                {
                    this.SetCoorinates(destinationField.RowNumber, destinationField.ColumnNumber);
                    myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = true;
                    myBoard.ChangeMoveTurn();

                }
            }
            else Console.WriteLine("Ilegal move enter correct coordinates");



        }

        public override bool CheckMove(Field field) {
            if (this.Field.RowNumber == field.RowNumber || this.Field.ColumnNumber == field.ColumnNumber)
            {
                return true;
            }
            return false;
        }

        #endregion

    }
}
