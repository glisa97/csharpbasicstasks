using ClassLibrary;
using System;
using System.Collections.Generic;

namespace ChessProblem
{
    public class Program
    {
        static Board myBoard = new Board(8);
        //private static bool IsWhiteTurn;
        public static void Main(string[] args)
        {
            myBoard.IsWhiteTurn = true;
           
            Rook r = new Rook(Color.WHITE, new Field(0, 7), FigureSide.LEFT, FigureNames.ROOK);
            Knight n = new Knight(Color.WHITE, new Field(0, 6), FigureSide.LEFT, FigureNames.KNIGHT);
            Bishop b = new Bishop(Color.WHITE, new Field(0, 5), FigureSide.LEFT, FigureNames.BISHOP);
            Queen q = new Queen(Color.WHITE, new Field(0, 3), FigureSide.NONE, FigureNames.QUEEN);
            King k = new King(Color.WHITE, new Field(0, 4), FigureSide.NONE, FigureNames.KING);
            Bishop b1 = new Bishop(Color.WHITE, new Field(0, 2), FigureSide.RIGHT,FigureNames.BISHOP);
            Knight n1 = new Knight(Color.WHITE, new Field(0, 1), FigureSide.RIGHT, FigureNames.KNIGHT);
            Rook r1 = new Rook(Color.WHITE, new Field(0, 0), FigureSide.RIGHT, FigureNames.ROOK);

            Rook r2 = new Rook(Color.BLACK, new Field(7, 0), FigureSide.LEFT, FigureNames.ROOK);
            Knight n2 = new Knight(Color.BLACK, new Field(7, 1), FigureSide.LEFT, FigureNames.KNIGHT);
            Bishop b2 = new Bishop(Color.BLACK, new Field(7, 2), FigureSide.LEFT, FigureNames.BISHOP);
            Queen q1 = new Queen(Color.BLACK, new Field(7, 3), FigureSide.NONE, FigureNames.QUEEN);
            King k1 = new King(Color.BLACK, new Field(7, 4), FigureSide.NONE, FigureNames.KING);
            Bishop b3 = new Bishop(Color.BLACK, new Field(7, 5), FigureSide.RIGHT, FigureNames.BISHOP);
            Knight n3 = new Knight(Color.BLACK, new Field(7, 6), FigureSide.RIGHT, FigureNames.KNIGHT);
            Rook r3 = new Rook(Color.BLACK, new Field(7, 7), FigureSide.RIGHT, FigureNames.ROOK);

            myBoard.FiguresList.Add(r);
            myBoard.FiguresList.Add(n);
            myBoard.FiguresList.Add(b);
            myBoard.FiguresList.Add(k);
            myBoard.FiguresList.Add(q);
            myBoard.FiguresList.Add(b1);
            myBoard.FiguresList.Add(n1);
            myBoard.FiguresList.Add(r1);
            myBoard.FiguresList.Add(r2);
            myBoard.FiguresList.Add(n2);
            myBoard.FiguresList.Add(b2);
            myBoard.FiguresList.Add(k1);
            myBoard.FiguresList.Add(q1);
            myBoard.FiguresList.Add(b3);
            myBoard.FiguresList.Add(n3);
            myBoard.FiguresList.Add(r3);

            foreach (IFigure f in myBoard.FiguresList) {
                Field currentField = setCurrentField(f.Field);
                currentField.CurrentlyOccupied = true;
            }
            

            
            while (true)
            {
                
                printBoard(myBoard);
                choseFigure();
            }
            Console.WriteLine();
            
        }
        private static Field setCurrentField(Field f)
        {
            return myBoard.TheGrid[f.RowNumber, f.ColumnNumber];
        }
        private static void choseFigure() {
            
            
            

            string message = myBoard.IsWhiteTurn ? "WHITE figure field row:" :
                                           "BLACK figure field row:";
            Console.WriteLine(message);
            int PositionRow = int.Parse(Console.ReadLine());
            message = myBoard.IsWhiteTurn ? "WHITE figure field column:" :
                                            "BLACK figure field column:";

            Console.WriteLine(message);
            int PositionColumn = int.Parse(Console.ReadLine());

            IFigure tempFig = null;
            foreach (IFigure f1 in myBoard.FiguresList)
            {

                if (f1.Field.RowNumber == PositionRow && f1.Field.ColumnNumber == PositionColumn)
                {
                    if (myBoard.IsWhiteTurn == true && f1.Color != Color.WHITE) {
                        Console.WriteLine("You need to play with white color");
                        return;
                    } else if (myBoard.IsWhiteTurn == false && f1.Color == Color.WHITE) {
                        Console.WriteLine("You need to play with black color");
                        return;
                    }
                    tempFig = f1;
                }

            }
            if (tempFig != null) {
                MoveFigure(tempFig);
            }
            else
            {
                Console.WriteLine("Figure not found on board");
                return;
            }
            
            
        }

        //private static void ChangeMoveTurn() 
        //{
        //    if (IsWhiteTurn == true)
        //    {
        //        IsWhiteTurn = false;
        //    }
        //    else
        //    {
        //        IsWhiteTurn = true;
        //    }
            
        //}

        private static void MoveRook(IFigure f, Field destinationField)
        {//f.Field.CheckDistance(destinationField) > f.Field.CheckDistance(f1.Field)
            IFigure elementToRemoveR = null;
            string eatenFigure;

            if (RookMoveCheck(f, destinationField))
            {
                foreach (IFigure f1 in myBoard.FiguresList)
                {
                    if ( RookMoveCheck(f, f1.Field) && CheckFigureInWay(f, f1, destinationField) )
                    {
                        Console.WriteLine("Figure is on the way");
                        return;
                    }

                }
                myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = false;


                if (myBoard.TheGrid[destinationField.RowNumber, destinationField.ColumnNumber].CurrentlyOccupied == true)
                {
                    foreach (IFigure f1 in myBoard.FiguresList)
                    {
                        if (f1.Field.RowNumber == destinationField.RowNumber && f1.Field.ColumnNumber == destinationField.ColumnNumber)
                        {
                            elementToRemoveR = f1;

                        }

                    }
                    if (f.Color == elementToRemoveR.Color)
                    {
                        Console.WriteLine("Figure can't eat same color figure");
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                        
                    }
                    else
                    {
                        myBoard.FiguresList.Remove(elementToRemoveR);
                        eatenFigure = elementToRemoveR.Name;
                        Console.WriteLine("Eaten figure: " + $"{ eatenFigure}");
                        Console.WriteLine("by:" + $"{ f.Name}");

                        f.Move(destinationField.RowNumber, destinationField.ColumnNumber);
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                        ChangeMoveTurn();
                        
                    }
                }
                else
                {
                    f.Move(destinationField.RowNumber, destinationField.ColumnNumber);
                    myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                    ChangeMoveTurn();
                    
                }
            }
            else Console.WriteLine("Ilegal move enter correct coordinates");
        }

        private static bool CheckFigureInWay(IFigure FigureToMove, IFigure FigureInWay, Field destinationField)
        {
            if (FigureToMove.Field.CheckDistance(FigureInWay.Field) < FigureToMove.Field.CheckDistance(destinationField) &&
                destinationField.CheckDistance(FigureInWay.Field) < destinationField.CheckDistance(FigureToMove.Field))
            {

                return true;
            }
            return false;
        }

        private static bool RookMoveCheck(IFigure f, Field field)
        {
            return f.Field.RowNumber == field.RowNumber || f.Field.ColumnNumber == field.ColumnNumber;
        }

        private static void MoveKnight(IFigure f, Field destinationField) 
        {
            if (destinationField.CheckDistance(f.Field) == 3 && !destinationField.CheckRow(f.Field) && !destinationField.CheckColumn(f.Field))
            {
                foreach (IFigure f1 in myBoard.FiguresList)
                {
                    if (f.Field.CheckDistance(destinationField) > f.Field.CheckDistance(f1.Field))
                    {
                        Console.WriteLine("Figure is on the way");

                    }

                }
                string eatenFigure;
                IFigure elementToRemoveN = null;
                myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = false;

                if (myBoard.TheGrid[destinationField.RowNumber, destinationField.ColumnNumber].CurrentlyOccupied == true)
                {
                    foreach (IFigure f1 in myBoard.FiguresList)
                    {
                        if (f1.Field.RowNumber == destinationField.RowNumber && f1.Field.ColumnNumber == destinationField.ColumnNumber)
                        {
                            elementToRemoveN = f1;

                        }

                    }
                    if (f.Color == elementToRemoveN.Color)
                    {
                        Console.WriteLine("Figure can't eat same color figure");
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                        
                    }
                    else
                    {
                        myBoard.FiguresList.Remove(elementToRemoveN);
                        eatenFigure = elementToRemoveN.Name;
                        Console.WriteLine("Eaten figure: " + $"{ eatenFigure}");
                        Console.WriteLine("by:" + $"{ f.Name}");

                        f.Move(destinationField.RowNumber, destinationField.ColumnNumber);
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                        ChangeMoveTurn();
                        
                    }
                }
                else
                {
                    f.Move(destinationField.RowNumber, destinationField.ColumnNumber);
                    myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                    ChangeMoveTurn();
                    
                }
            }
            else Console.WriteLine("Ilegal move enter correct coordinates");
        }

        private static void MoveQueen(IFigure f, Field destinationField) 
        {
            if (MoveQueenCheckDiagonal(f,destinationField) || MoveQueenCheckRow(f,destinationField) || MoveQueenCheckColumn(f,destinationField))
            {
                foreach (IFigure f1 in myBoard.FiguresList)
                {
                    if (checkQueenWay(f, f1, destinationField) && MoveQueenCheckDiagonal(f, destinationField) && MoveQueenCheckDiagonal(f, f1.Field))
                    {
                        Console.WriteLine("Figure is on the way");
                        return;

                    } else if (checkQueenWay(f, f1, destinationField) && MoveQueenCheckRow(f, destinationField) && MoveQueenCheckRow(f, f1.Field)) {
                        Console.WriteLine("Figure is on the way");
                        return;
                    } else if (checkQueenWay(f, f1, destinationField) && MoveQueenCheckColumn(f, destinationField) && MoveQueenCheckColumn(f, f1.Field)) {
                        Console.WriteLine("Figure is on the way");
                        return;
                    }

                }
                string eatenFigure;
                IFigure elementToRemoveQ = null;
                myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = false;

                if (myBoard.TheGrid[destinationField.RowNumber, destinationField.ColumnNumber].CurrentlyOccupied == true)
                {
                    foreach (IFigure f1 in myBoard.FiguresList)
                    {
                        if (f1.Field.RowNumber == destinationField.RowNumber && f1.Field.ColumnNumber == destinationField.ColumnNumber)
                        {
                            elementToRemoveQ = f1;

                        }

                    }
                    if (f.Color == elementToRemoveQ.Color)
                    {
                        Console.WriteLine("Figure can't eat same color figure");
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                        
                    }
                    else
                    {
                        myBoard.FiguresList.Remove(elementToRemoveQ);
                        eatenFigure = elementToRemoveQ.Name;
                        Console.WriteLine("Eaten figure: " + $"{ eatenFigure}");
                        Console.WriteLine("by:" + $"{ f.Name}");

                        f.Move(destinationField.RowNumber, destinationField.ColumnNumber);
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                        ChangeMoveTurn();
                        
                    }
                }
                else
                {
                    f.Move(destinationField.RowNumber, destinationField.ColumnNumber);
                    myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                    ChangeMoveTurn();
                    
                }
            }
            else Console.WriteLine("Ilegal move enter correct coordinates");

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

        private static void MoveKing(IFigure f, Field destinationField)
        {
            if (destinationField.CheckDiagonal(f.Field) == true || destinationField.CheckRow(f.Field) == true || destinationField.CheckColumn(f.Field) == true && destinationField.CheckDistance(f.Field) == 1)
            {
                foreach (IFigure f1 in myBoard.FiguresList)
                {
                    if (f.Field.CheckDistance(destinationField) > f.Field.CheckDistance(f1.Field))
                    {
                        Console.WriteLine("Figure on the way");

                    }

                }
                string eatenFigure;
                IFigure elementToRemoveK = null;
                myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = false;

                if (myBoard.TheGrid[destinationField.RowNumber, destinationField.ColumnNumber].CurrentlyOccupied == true)
                {
                    foreach (IFigure f1 in myBoard.FiguresList)
                    {
                        if (f1.Field.RowNumber == destinationField.RowNumber && f1.Field.ColumnNumber == destinationField.ColumnNumber)
                        {
                            elementToRemoveK = f1;

                        }

                    }
                    if (f.Color == elementToRemoveK.Color)
                    {
                        Console.WriteLine("Figure can't eat same color figure");
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                        
                    }
                    else
                    {
                        myBoard.FiguresList.Remove(elementToRemoveK);
                        eatenFigure = elementToRemoveK
                            .Name;
                        Console.WriteLine("Eaten figure: " + $"{ eatenFigure}");
                        Console.WriteLine("by:" + $"{ f.Name}");

                        f.Move(destinationField.RowNumber, destinationField.ColumnNumber);
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                        ChangeMoveTurn();
                        
                    }
                }
                else
                {
                    f.Move(destinationField.RowNumber, destinationField.ColumnNumber);
                    myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                    ChangeMoveTurn();
                    
                }
            }
            else Console.WriteLine("Ilegal move enter correct coordinates");

            
        }

        private static void MoveBishop(IFigure f, Field destinationField)
        {
 
            if (BishopMoveCheck(f,destinationField))
            {
                foreach (IFigure f1 in myBoard.FiguresList)
                {
                    if (BishopMoveCheck(f, f1.Field) && BishopCheckDistance(f,destinationField,f1))
                    {
                        Console.WriteLine("Figure is on the way");
                        return;
                    }

                }
                string eatenFigure;
                IFigure elementToRemoveB = null;
                myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = false;

                if (myBoard.TheGrid[destinationField.RowNumber, destinationField.ColumnNumber].CurrentlyOccupied == true)
                {
                    foreach (IFigure f1 in myBoard.FiguresList)
                    {
                        if (f1.Field.RowNumber == destinationField.RowNumber && f1.Field.ColumnNumber == destinationField.ColumnNumber)
                        {
                            elementToRemoveB = f1;
                        }
                    }
                    if (f.Color == elementToRemoveB.Color)
                    {
                        Console.WriteLine("Figure can't eat same color figure");
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                        
                    }
                    else
                    {
                        myBoard.FiguresList.Remove(elementToRemoveB);
                        eatenFigure = elementToRemoveB.Name;
                        Console.WriteLine("Eaten figure: " + $"{ eatenFigure}");
                        Console.WriteLine("by:" + $"{ f.Name}");

                        f.Move(destinationField.RowNumber, destinationField.ColumnNumber);
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                        ChangeMoveTurn();
                        
                    }
                }
                else {
                    f.Move(destinationField.RowNumber, destinationField.ColumnNumber);
                    myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                    ChangeMoveTurn();
                    
                }
            }
            else Console.WriteLine("Ilegal move enter correct coordinates");
        }

        private static bool BishopCheckDistance(IFigure figureToMove, Field destinationField, IFigure figureInWay)
        {
            if (figureToMove.Field.CheckDistance(destinationField) > figureToMove.Field.CheckDistance(figureInWay.Field)
                && destinationField.CheckDistance(figureInWay.Field) < destinationField.CheckDistance(figureToMove.Field)) {
                return true;
            }
            return false;
        }

        private static bool BishopMoveCheck(IFigure f, Field destinationField)
        {
            return f.Field.CheckDiagonal(destinationField);


        }

        private static void MoveFigure(IFigure f) 
        {
            string message = myBoard.IsWhiteTurn ? "WHITE Destination field row:" :
                                           "BLACK Destination field row:";
            Console.WriteLine(message);
            int newPositionRow = int.Parse(Console.ReadLine());
            message = myBoard.IsWhiteTurn ? "WHITE Destination field column:" :
                                    "BLACK Destination field column:";
            Console.WriteLine(message);
            int newPositionColumn = int.Parse(Console.ReadLine());
            Field destinationField = new Field(newPositionRow, newPositionColumn);

            //f.Move(destinationField, myBoard);
            switch (f.Name)
            {
                case "WHITELEFTROOK":
                case "WHITERIGHTROOK":
                case "BLACKRIGHTROOK":
                case "BLACKLEFTROOK":
                    MoveRook(f, destinationField);
                    break;
                case "WHITELEFTKNIGHT":
                case "WHITERIGHTKNIGHT":
                case "BLACKRIGHTKNIGHT":
                case "BLACKLEFTKNIGHT":
                    MoveKnight(f, destinationField);
                    break;
                case "WHITENONEQUEEN":
                case "BLACKNONEQUEEN":
                    MoveQueen(f, destinationField);
                    break;
                case "WHITENONEKING":
                case "BLACKNONEKING":
                    MoveKing(f, destinationField);
                    break;
                case "WHITELEFTBISHOP":
                case "WHITERIGHTBISHOP":
                case "BLACKRIGHTBISHOP":
                case "BLACKLEFTBISHOP":
                    MoveBishop(f, destinationField);
                    break;

            }

            //switch (f.Mark)
            //{
            //    case 'r' or 'R':
            //        IFigure elementToRemoveR = null;
            //        if (f.Field.RowNumber == newPositionRow || f.Field.ColumnNumber == newPositionColumn)
            //        {
            //            myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = false;


            //            if (myBoard.TheGrid[newPositionRow, newPositionColumn].CurrentlyOccupied == true)
            //            {
            //                foreach (IFigure f1 in myBoard.FiguresList)
            //                {
            //                    if (f1.Field.RowNumber == newPositionRow && f1.Field.ColumnNumber == newPositionColumn)
            //                    {
            //                        elementToRemoveR = f1;

            //                    }

            //                }
            //                myBoard.FiguresList.Remove(elementToRemoveR);

            //            }
            //            f.Move(newPositionRow, newPositionColumn);
            //            myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;

            //        }
            //        else Console.WriteLine("Ilegal move enter correct coordinates");

            //        break;

            //    case 'n' or 'N':

            //        if (destinationField.CheckDistance(f.Field) == 3 && !destinationField.CheckRow(f.Field) && !destinationField.CheckColumn(f.Field))
            //        {
            //            IFigure elementToRemoveN = null;
            //            myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = false;

            //            if (myBoard.TheGrid[newPositionRow, newPositionColumn].CurrentlyOccupied == true)
            //            {
            //                foreach (IFigure f1 in myBoard.FiguresList)
            //                {
            //                    if (f1.Field.RowNumber == newPositionRow && f1.Field.ColumnNumber == newPositionColumn)
            //                    {
            //                        elementToRemoveN = f1;

            //                    }

            //                }
            //                myBoard.FiguresList.Remove(elementToRemoveN);

            //            }
            //            f.Move(newPositionRow, newPositionColumn);
            //            myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
            //        }
            //        else Console.WriteLine("Ilegal move enter correct coordinates");
            //        break;
            //    case 'q' or 'Q':
            //        if (destinationField.CheckDiagonal(f.Field) == true || destinationField.CheckRow(f.Field) == true || destinationField.CheckColumn(f.Field) == true)
            //        {
            //            IFigure elementToRemoveQ = null;
            //            myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = false;

            //            if (myBoard.TheGrid[newPositionRow, newPositionColumn].CurrentlyOccupied == true)
            //            {
            //                foreach (IFigure f1 in myBoard.FiguresList)
            //                {
            //                    if (f1.Field.RowNumber == newPositionRow && f1.Field.ColumnNumber == newPositionColumn)
            //                    {
            //                        elementToRemoveQ = f1;

            //                    }

            //                }

            //                myBoard.FiguresList.Remove(elementToRemoveQ);

            //            }
            //            f.Move(newPositionRow, newPositionColumn);
            //            myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
            //        }
            //        else Console.WriteLine("Ilegal move enter correct coordinates");

            //        break;
            //    case 'k' or 'K':
            //        if (destinationField.CheckDiagonal(f.Field) == true || destinationField.CheckRow(f.Field) == true || destinationField.CheckColumn(f.Field) == true && destinationField.CheckDistance(f.Field) == 1)
            //        {
            //            IFigure elementToRemoveK = null;
            //            myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = false;

            //            if (myBoard.TheGrid[newPositionRow, newPositionColumn].CurrentlyOccupied == true)
            //            {
            //                foreach (IFigure f1 in myBoard.FiguresList)
            //                {
            //                    if (f1.Field.RowNumber == newPositionRow && f1.Field.ColumnNumber == newPositionColumn)
            //                    {
            //                        elementToRemoveK = f1;

            //                    }

            //                }
            //                myBoard.FiguresList.Remove(elementToRemoveK);
            //            }
            //            f.Move(newPositionRow, newPositionColumn);
            //            myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
            //        }
            //        else Console.WriteLine("Ilegal move enter correct coordinates");
            //        break;
            //    case 'b' or 'B':

            //        if (destinationField.CheckDiagonal(f.Field) == true)
            //        {

            //            IFigure elementToRemoveB = null;
            //            myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = false;

            //            if (myBoard.TheGrid[newPositionRow, newPositionColumn].CurrentlyOccupied == true)
            //            {

            //                foreach (IFigure f1 in myBoard.FiguresList)
            //                {
            //                    if (f1.Field.RowNumber == newPositionRow && f1.Field.ColumnNumber == newPositionColumn)
            //                    {
            //                        elementToRemoveB = f1;

            //                    }

            //                }
            //                myBoard.FiguresList.Remove(elementToRemoveB);

            //            }
            //            f.Move(newPositionRow, newPositionColumn);
            //            myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;

            //        }
            //        else Console.WriteLine("Ilegal move enter correct coordinates");
            //        break;
            //}


        }
        private static void printBoard(Board myBoard)
        {
            for (int i = 0; i < myBoard.Size; i++) {
                for (int j = 0; j < myBoard.Size; j++) {
                    Field f = myBoard.TheGrid[i,j];
                    if (f.CurrentlyOccupied == true)
                    {
                        foreach (IFigure a in myBoard.FiguresList) {
                            
                            if (a.Color == Color.WHITE)
                            {
                                a.Mark = char.ToLower(a.Mark);
                            }else
                                a.Mark = char.ToUpper(a.Mark);
                            
                            if (f.CheckDistance(a.Field) == 0) {
                                Console.Write(a.Mark);
                                break;   
                            }     
                        } 
                    }
                    else if (f.LegalNextMove == true)
                    {
                        Console.Write("+");
                    }
                    else {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("================");
        }

        private static void MovePiece(Board myBoard,IFigure figure, Field field) { 

        }
    }
}
