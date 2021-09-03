using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Pawn : Figure 
    {
        public Pawn(Color color, Field field, string mark) : base(color, field, mark)
        {            
        }
        
        public override bool CheckMove(Field destinationField)
        {
            if (this.Color == Color.WHITE && this.Field.RowNumber < destinationField.RowNumber ||
                this.Color == Color.BLACK && this.Field.RowNumber > destinationField.RowNumber)
            {
                if((this.Color == Color.WHITE && this.Field.RowNumber == 1 && destinationField.CheckDistance(this.Field) <= 2) ||
                    (this.Color == Color.BLACK && this.Field.RowNumber == 6 && destinationField.CheckDistance(this.Field) <= 2) ||
                    destinationField.CheckDistance(this.Field) == 1) 
                {
                    return this.Field.CheckColumn(destinationField);
                }
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
