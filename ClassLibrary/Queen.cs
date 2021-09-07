using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Queen : Figure
    {
        public Queen(Color color, Field field, string mark) : base(color, field, mark)
        {
        }
        protected bool QueenFigureDiagonal(Field destinationField, Board myBoard)
        {
            foreach (IFigure f1 in myBoard.FiguresList)
            {
                if (CheckFigureInWay(f1, destinationField) && MoveQueenCheckDiagonal(this, destinationField) && MoveQueenCheckDiagonal(this, f1.Field))
                {
                    Console.WriteLine("Figure is on the way");
                    return true;
                }
            }
            return false;
        }

        protected bool QueenFigureDiagonalCheck(Field destinationField, Board myBoard)
        {
            foreach (IFigure f1 in myBoard.FiguresList)
            {
                if (CheckFigureInWay(f1, destinationField) && MoveQueenCheckDiagonal(this, destinationField) && MoveQueenCheckDiagonal(this, f1.Field))
                {
                    Console.WriteLine("Figure is on the way");
                    return true;
                }
            }
            return false;
        }

        protected bool QueenFigureRowCheck(Field destinationField, Board myBoard)
        {
            foreach (IFigure f1 in myBoard.FiguresList)
            {
                if (CheckFigureInWay(f1, destinationField) && MoveQueenCheckRow(this, destinationField) && MoveQueenCheckRow(this, f1.Field))
                {
                    Console.WriteLine("Figure is on the way");
                    return true;
                }
            }

            return false;
        }
        protected bool QueenFigureColumnCheck(Field destinationField, Board myBoard)
        {
            foreach (IFigure f1 in myBoard.FiguresList)
            {
                if (CheckFigureInWay(f1, destinationField) && MoveQueenCheckColumn(this, destinationField) && MoveQueenCheckColumn(this, f1.Field))
                {
                    Console.WriteLine("Figure is on the way");
                    return true;
                }
            }

            return false;
        }

        protected override bool IsAnotherFigureInMovePath(Field destinationField, Board myBoard)
        {
            if (QueenFigureDiagonalCheck(destinationField, myBoard) == true ||
                QueenFigureRowCheck(destinationField, myBoard) == true ||
                QueenFigureColumnCheck(destinationField, myBoard) == true) {
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
        public override bool CheckMove(Field destinationField)
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
        
    }
}
