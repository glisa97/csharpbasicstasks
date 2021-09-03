using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Bishop : Figure
    {
        public Bishop(Color color, Field field, string mark) : base(color, field, mark)
        {         
        }
 
        public override bool CheckMove(Field destinationField)
        {
            return this.Field.CheckDiagonal(destinationField);
        }
        public bool CheckFigureInWay(Field FigureInWay,Field destinationField) {
            if (this.Field.CheckDistance(destinationField) > this.Field.CheckDistance(FigureInWay)
                    && destinationField.CheckDistance(FigureInWay) < destinationField.CheckDistance(this.Field))
            {
                return true;
            }
            return false;
        }
        public override void Move(Field destinationField, Board myBoard)
        {
            if (this.CheckMove(destinationField))
            {
                if (IsAnotherFigureInMovePath(destinationField, myBoard))
                {
                    return;
                }
                else
                {
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
            }
            else Console.WriteLine("Ilegal move enter correct coordinates");
        }
    } 
}
