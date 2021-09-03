using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class King : Figure
    {

        public King(Color color, Field field, string mark) : base(color,field,mark)
        {  
        }

      
        private void IsDestinationFigureSameColorLikeSource(Figure elementToRemoveQ, Board myBoard)
        {
            if (this.Color == elementToRemoveQ.Color)
            {
                Console.WriteLine("Figure can't eat same color figure");
                myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = true;

            }
        }

        private void IsDestinationFigureDifferentColorLikeSource(Figure elementToRemoveK, Field destinationField, Board myBoard)
        {


            if (this.Color != elementToRemoveK.Color)
            {
                myBoard.FiguresList.Remove(elementToRemoveK);


                this.SetCoorinates(destinationField.RowNumber, destinationField.ColumnNumber);
                myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = true;
                myBoard.ChangeMoveTurn();
            }
        }

        public override void Move(Field destinationField,Board myBoard)
        {
            if (this.CheckMove(destinationField))
            {
        
                myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = false;

                if (myBoard.TheGrid[destinationField.RowNumber, destinationField.ColumnNumber].CurrentlyOccupied == true)
                {
                    Figure destinationFigure = GetFigureFromDestionationField(destinationField, myBoard);
                    IsDestinationFigureSameColorLikeSource(destinationFigure, myBoard);
                    IsDestinationFigureDifferentColorLikeSource(destinationFigure,destinationField,myBoard);

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

        public override bool CheckMove(Field destinationField)
        {
            if (destinationField.CheckDiagonal(this.Field) == true && destinationField.CheckDistance(this.Field) == 2) {
                return true;
            } else if ((destinationField.CheckRow(this.Field) == true || destinationField.CheckColumn(this.Field)) == true && destinationField.CheckDistance(this.Field) == 1) {
                return true;
            } else return false;
            
        }
    }
}
