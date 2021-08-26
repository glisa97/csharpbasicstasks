using System;

namespace ClassLibrary
{
    public class Knight:IFigure
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Field Field { get; set; }
        public char Mark { get; set; }

        public Knight(Color color, Field field, FigureSide figureSide, FigureNames figureNames)
        {
            Color = color;
            Field = field;
            //Mark = mark;
            if (color == Color.WHITE)
            {
                Mark = 'n';
            }
            else
            {
                Mark = 'N';
            }
            Name = $"{color}{figureSide}{figureNames}";
        }

        public void Move(int row, int column) {
            
            this.Field.RowNumber = row;
            this.Field.ColumnNumber = column;
        }


        public bool CheckMove(Field destinationField)
        {
            return destinationField.CheckDistance(this.Field) == 3 && !destinationField.CheckRow(this.Field) && !destinationField.CheckColumn(this.Field);
        }

        public void Move(Field destinationField, Board myBoard)
        {
            if (this.CheckMove(destinationField))
            {
                
                string eatenFigure;
                IFigure elementToRemoveN = null;
                myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = false;

                if (myBoard.TheGrid[destinationField.RowNumber, destinationField.ColumnNumber].CurrentlyOccupied == true)
                {
                    foreach (IFigure f1 in myBoard.FiguresList)
                    {
                        if (f1.Field.RowNumber == destinationField.RowNumber && f1.Field.ColumnNumber == destinationField.ColumnNumber)
                        {
                            elementToRemoveN = f1;

                        }

                    }
                    if (this.Color == elementToRemoveN.Color)
                    {
                        Console.WriteLine("Figure can't eat same color figure");
                        myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = true;

                    }
                    else
                    {
                        myBoard.FiguresList.Remove(elementToRemoveN);
                        eatenFigure = elementToRemoveN.Name;
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
    }
}
