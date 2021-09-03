using System;

namespace ClassLibrary
{
    public class Knight:Figure
    {
        public Knight(Color color, Field field, string mark) :base(color,field,mark)
        { 
        }
        public override bool CheckMove(Field destinationField)
        {
            return destinationField.CheckDistance(this.Field) == 3 && !destinationField.CheckRow(this.Field) && !destinationField.CheckColumn(this.Field);
        }
        public override void Move(Field destinationField, Board myBoard)
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
    }
}
