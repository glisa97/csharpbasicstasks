using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary
{
    public class Rook : IFigure
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Field Field { get; set; }
        public char Mark { get; set; }

        public Rook(Color color, Field field, FigureSide figureSide, FigureNames figureNames)
        {
            Color = color;
            Field = field;
            //Mark = mark;
            if (color == Color.WHITE)
            {
                Mark = 'r';
            }
            else
            {
                Mark = 'R';
            }
            Name = $"{color}{figureSide}{figureNames}";
        }

        public void Move(Field destinationField, Board myBoard) {
            IFigure elementToRemoveR = null;
            string eatenFigure;

            if (this.CheckMove(destinationField))
            {
                foreach (IFigure f1 in myBoard.FiguresList)
                {
                    if (this.CheckMove(f1.Field) && this.CheckFigureInWay(f1, destinationField))
                    {
                        Console.WriteLine("Figure is on the way");
                        return;
                    }

                }
                myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = false;


                if (myBoard.TheGrid[destinationField.RowNumber, destinationField.ColumnNumber].CurrentlyOccupied == true)
                {
                    foreach (IFigure f1 in myBoard.FiguresList)
                    {
                        if (f1.Field.RowNumber == destinationField.RowNumber && f1.Field.ColumnNumber == destinationField.ColumnNumber)
                        {
                            elementToRemoveR = f1;

                        }

                    }
                    if (this.Color == elementToRemoveR.Color)
                    {
                        Console.WriteLine("Figure can't eat same color figure");
                        myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = true;

                    }
                    else
                    {
                        myBoard.FiguresList.Remove(elementToRemoveR);
                        eatenFigure = elementToRemoveR.Name;
                        Console.WriteLine("Eaten figure: " + $"{ eatenFigure}");
                        Console.WriteLine("by:" + $"{ this.Name}");

                        this.SetCoordinates(destinationField.RowNumber, destinationField.ColumnNumber);
                        myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = true;
                        myBoard.ChangeMoveTurn();

                    }
                }
                else
                {
                    this.SetCoordinates(destinationField.RowNumber, destinationField.ColumnNumber);
                    myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = true;
                    myBoard.ChangeMoveTurn();

                }
            }
            else Console.WriteLine("Ilegal move enter correct coordinates");
            


        }

       

        private void SetCoordinates(int row, int column)
        {
            this.Field.RowNumber = row;
            this.Field.ColumnNumber = column;
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

        public bool CheckMove(Field field) {
            if (this.Field.RowNumber == field.RowNumber || this.Field.ColumnNumber == field.ColumnNumber)
            {
                return true;
            }
            return false;
        }
        
    }
}
