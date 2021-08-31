using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Bishop : Figure
    {
        public string Name { get; set; }

        public Bishop(Color color, Field field, string mark) : base(color, field, mark)
        {         
        }

               

        public override bool CheckMove(Field destinationField)
        {
            return this.Field.CheckDiagonal(destinationField);
        }
        public bool BishopCheckDistance(Field FigureInWay,Field destinationField) {
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
                foreach (IFigure f1 in myBoard.FiguresList)
                {
                    if (this.CheckMove( f1.Field) && this.BishopCheckDistance(f1.Field,destinationField))
                    {
                        Console.WriteLine("Figure is on the way");
                        return;
                    }

                }
                string eatenFigure;
                IFigure elementToRemoveB = null;
                myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = false;

                if (myBoard.TheGrid[destinationField.RowNumber, destinationField.ColumnNumber].CurrentlyOccupied == true)
                {
                    foreach (IFigure f1 in myBoard.FiguresList)
                    {
                        if (f1.Field.RowNumber == destinationField.RowNumber && f1.Field.ColumnNumber == destinationField.ColumnNumber)
                        {
                            elementToRemoveB = f1;
                        }
                    }
                    if (this.Color == elementToRemoveB.Color)
                    {
                        Console.WriteLine("Figure can't eat same color figure");
                        myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = true;

                    }
                    else
                    {
                        myBoard.FiguresList.Remove(elementToRemoveB);
                        eatenFigure = elementToRemoveB.Name;
                        Console.WriteLine("Eaten figure: " + $"{ eatenFigure}");
                        Console.WriteLine("by:" + $"{ this.Name}");

                        this.SetCoorinates(destinationField.RowNumber, destinationField.ColumnNumber);
                        myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = true;
                        myBoard.ChangeMoveTurn();

                    }
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
