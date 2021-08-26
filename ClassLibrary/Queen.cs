using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Queen : IFigure
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Field Field { get; set; }
        public char Mark { get; set; }

        public Queen(Color color, Field field, FigureSide figureSide, FigureNames figureNames)
        {
            Color = color;
            Field = field;
            //Mark = mark;
            if (color == Color.WHITE)
            {
                Mark = 'q';
            }
            else
            {
                Mark = 'Q';
            }
            Name = $"{color}{figureSide}{figureNames}";
        }

        public void Move(int row, int column) {
            
            this.Field.RowNumber = row;
            this.Field.ColumnNumber = column;
        }

        public void Move(Field destinationField, Board myBoard)
        {
            if (this.CheckMove(destinationField))
            {
                foreach (IFigure f1 in myBoard.FiguresList)
                {
                    if (checkQueenWay(this, f1, destinationField) && MoveQueenCheckDiagonal(this, destinationField) && MoveQueenCheckDiagonal(this, f1.Field))
                    {
                        Console.WriteLine("Figure is on the way");
                        return;

                    }
                    else if (checkQueenWay(this, f1, destinationField) && MoveQueenCheckRow(this, destinationField) && MoveQueenCheckRow(this, f1.Field))
                    {
                        Console.WriteLine("Figure is on the way");
                        return;
                    }
                    else if (checkQueenWay(this, f1, destinationField) && MoveQueenCheckColumn(this, destinationField) && MoveQueenCheckColumn(this, f1.Field))
                    {
                        Console.WriteLine("Figure is on the way");
                        return;
                    }

                }
                string eatenFigure;
                IFigure elementToRemoveQ = null;
                myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = false;

                if (myBoard.TheGrid[destinationField.RowNumber, destinationField.ColumnNumber].CurrentlyOccupied == true)
                {
                    foreach (IFigure f1 in myBoard.FiguresList)
                    {
                        if (f1.Field.RowNumber == destinationField.RowNumber && f1.Field.ColumnNumber == destinationField.ColumnNumber)
                        {
                            elementToRemoveQ = f1;

                        }

                    }
                    if (this.Color == elementToRemoveQ.Color)
                    {
                        Console.WriteLine("Figure can't eat same color figure");
                        myBoard.TheGrid[this.Field.RowNumber, this.Field.ColumnNumber].CurrentlyOccupied = true;

                    }
                    else
                    {
                        myBoard.FiguresList.Remove(elementToRemoveQ);
                        eatenFigure = elementToRemoveQ.Name;
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
            return MoveQueenCheckDiagonal(this, destinationField) || MoveQueenCheckRow(this, destinationField) || MoveQueenCheckColumn(this, destinationField);
        }
        private static bool MoveQueenCheckDiagonal(IFigure figure, Field destinationField)
        {
            return destinationField.CheckDiagonal(figure.Field) == true;

        }
        private static bool MoveQueenCheckRow(IFigure figure, Field destinationField)
        {
            return destinationField.CheckRow(figure.Field) == true;

        }
        private static bool MoveQueenCheckColumn(IFigure figure, Field destinationField)
        {
            return destinationField.CheckColumn(figure.Field) == true;

        }
        private static bool checkQueenWay(IFigure FigureToMove, IFigure FigureInWay, Field destinationField)
        {
            if (FigureToMove.Field.CheckDistance(FigureInWay.Field) < FigureToMove.Field.CheckDistance(destinationField) &&
                destinationField.CheckDistance(FigureInWay.Field) < destinationField.CheckDistance(FigureToMove.Field))
            {

                return true;
            }
            return false;
        }

    }
}
