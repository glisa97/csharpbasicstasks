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
        #region Public methods
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
