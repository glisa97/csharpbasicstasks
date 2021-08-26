using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class King : IFigure
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Field Field { get; set ; }
        public char Mark { get; set; }

        public King(Color color, Field field,FigureSide figureSide, FigureNames figureNames)
        {
            Color = color;
            Field = field;
            //Mark = mark;
            if (color == Color.WHITE)
            {
                Mark = 'k';
            }
            else 
            { 
                Mark = 'K';
            }
            Name = $"{color}{figureSide}{figureNames}";
        }

        public void Move(int row, int column) {
            
            this.Field.RowNumber = row;
            this.Field.ColumnNumber = column;
        }

        public void Move(Field destinationField,Board myBoard)
        {
            if (this.CheckMove(destinationField))
            {
               
                string eatenFigure;
                IFigure elementToRemoveK = null;
                myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = false;

                if (myBoard.TheGrid[destinationField.RowNumber, destinationField.ColumnNumber].CurrentlyOccupied == true)
                {
                    foreach (IFigure f1 in myBoard.FiguresList)
                    {
                        if (f1.Field.RowNumber == destinationField.RowNumber && f1.Field.ColumnNumber == destinationField.ColumnNumber)
                        {
                            elementToRemoveK = f1;

                        }

                    }
                    if (this.Color == elementToRemoveK.Color)
                    {
                        Console.WriteLine("Figure can't eat same color figure");
                        myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = true;

                    }
                    else
                    {
                        myBoard.FiguresList.Remove(elementToRemoveK);
                        eatenFigure = elementToRemoveK.Name;
                        Console.WriteLine("Eaten figure: " + $"{ eatenFigure}");
                        Console.WriteLine("by:" + $"{ this.Name}");

                        this.Move(destinationField.RowNumber, destinationField.ColumnNumber);
                        myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = true;
                        myBoard.ChangeMoveTurn();

                    }
                }
                else
                {
                    this.Move(destinationField.RowNumber, destinationField.ColumnNumber);
                    myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = true;
                    myBoard.ChangeMoveTurn();

                }
            }
            else Console.WriteLine("Ilegal move enter correct coordinates");
        }

        public bool CheckMove(Field destinationField)
        {
            if (destinationField.CheckDiagonal(this.Field) == true && destinationField.CheckDistance(this.Field) == 2) {
                return true;
            } else if ((destinationField.CheckRow(this.Field) == true || destinationField.CheckColumn(this.Field)) == true && destinationField.CheckDistance(this.Field) == 1) {
                return true;
            } else return false;
            
        }
    }
}
