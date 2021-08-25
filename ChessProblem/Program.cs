using ClassLibrary;
using System;
using System.Collections.Generic;

namespace ChessProblem
{
    public class Program
    {
        static Board myBoard = new Board(8);
        public static void Main(string[] args)
        {
            printBoard(myBoard);
            Rook r = new Rook(Color.white, new Field(7, 0), 'r');
            Knight n = new Knight(Color.white, new Field(7, 1), 'n');
            Bishop b = new Bishop(Color.white, new Field(7, 2), 'b');
            King k = new King(Color.white, new Field(7, 3), 'k');
            Queen q = new Queen(Color.white, new Field(7, 4), 'q');
            Bishop b1 = new Bishop(Color.white, new Field(7, 5), 'b');
            Knight n1 = new Knight(Color.white, new Field(7, 6), 'n');
            Rook r1 = new Rook(Color.white, new Field(7, 7), 'r');

            Rook r2 = new Rook(Color.black, new Field(0, 0), 'R');
            Knight n2 = new Knight(Color.black, new Field(0, 1), 'N');
            Bishop b2 = new Bishop(Color.black, new Field(0, 2), 'B');
            King k1 = new King(Color.black, new Field(6, 3), 'K');
            Queen q1 = new Queen(Color.black, new Field(0, 4), 'Q');
            Bishop b3 = new Bishop(Color.black, new Field(0, 5), 'B');
            Knight n3 = new Knight(Color.black, new Field(0, 6), 'N');
            Rook r3 = new Rook(Color.black, new Field(0, 7), 'R');

/*
            //Passing by reference
            Rook r4 = new Rook(Color.black, new Field(3, 7), 'R');
            Console.WriteLine(r4);

            Rook rookRef;
            rookRef = r4;

            Console.WriteLine(rookRef);

            rookRef.Mark = 'g';
            Console.WriteLine(rookRef);
            Console.WriteLine(r4);



            //Passing by values
            int a = 2;
            int c = 3;
            Console.WriteLine("Int a is: " + a);
            Console.WriteLine("Int b is: " + c);

            a = c;

            Console.WriteLine("Int a is: " + a);
            Console.WriteLine("Int b is: " + c);

            a += 4;

            Console.WriteLine("Int a is: " + a);
            Console.WriteLine("Int b is: " + c);



            //Ne znam sta je ovo koj k
            string s = "Hello";
            string test = s;

            s = s.Remove(0);

            Console.WriteLine(" String test is : " + test);
            Console.WriteLine("String s is: " + s);
*/


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
            

            printBoard(myBoard);
            choseFigure();
           // printBoard(myBoard);
            Console.WriteLine();
            
        }
        private static Field setCurrentField(Field f)
        {
            return myBoard.TheGrid[f.RowNumber, f.ColumnNumber];
        }
        private static void choseFigure() {

            
            
                Console.WriteLine("Enter row of figure to move:");
                int PositionRow = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter column of figure to move:");
                int PositionColumn = int.Parse(Console.ReadLine());

                IFigure tempFig = null;
                foreach (IFigure f1 in myBoard.FiguresList)
                {

                    if (f1.Field.RowNumber == PositionRow && f1.Field.ColumnNumber == PositionColumn)
                    {
                        tempFig = f1;
                    }

                }
                MarkMove(tempFig);
            
        }
        private static void MarkMove(IFigure f) {

            Console.WriteLine("Enter row for move:");
            int newPositionRow = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter column for move:");
            int newPositionColumn = int.Parse(Console.ReadLine());
            Field temp = new Field(newPositionRow, newPositionColumn);

             switch(f.Mark) {
                case 'r' or 'R':
                    IFigure elementToRemoveR = null;
                    if (f.Field.RowNumber == newPositionRow || f.Field.ColumnNumber == newPositionColumn)
                    {
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = false;

                        
                        if (myBoard.TheGrid[newPositionRow, newPositionColumn].CurrentlyOccupied == true)
                        {
                            foreach (IFigure f1 in myBoard.FiguresList)
                            {
                                if (f1.Field.RowNumber == newPositionRow && f1.Field.ColumnNumber == newPositionColumn)
                                {
                                    elementToRemoveR = f1;

                                }

                            }
                            myBoard.FiguresList.Remove(elementToRemoveR);

                        }
                        f.Move(newPositionRow, newPositionColumn);
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;

                    }
                    else Console.WriteLine("Ilegal move enter correct coordinates");

                break;

                case 'n' or 'N':
                    
                    if (temp.CheckDistance(f.Field) == 3 && !temp.CheckRow(f.Field) && !temp.CheckColumn(f.Field)) {
                        IFigure elementToRemoveN = null;
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = false;
                        
                        if (myBoard.TheGrid[newPositionRow, newPositionColumn].CurrentlyOccupied == true)
                        {
                            foreach (IFigure f1 in myBoard.FiguresList)
                            {
                                if (f1.Field.RowNumber == newPositionRow && f1.Field.ColumnNumber == newPositionColumn)
                                {
                                    elementToRemoveN = f1;

                                }

                            }
                            myBoard.FiguresList.Remove(elementToRemoveN);

                        }
                        f.Move(newPositionRow, newPositionColumn);
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                    }
                    else Console.WriteLine("Ilegal move enter correct coordinates");
                    break;
                case 'q' or 'Q':
                    if(temp.CheckDiagonal(f.Field) == true || temp.CheckRow(f.Field) == true || temp.CheckColumn(f.Field) == true)
                    {
                        IFigure elementToRemoveQ = null;
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = false;
                        
                        if (myBoard.TheGrid[newPositionRow, newPositionColumn].CurrentlyOccupied == true)
                        {
                            foreach (IFigure f1 in myBoard.FiguresList)
                            {
                                if (f1.Field.RowNumber == newPositionRow && f1.Field.ColumnNumber == newPositionColumn)
                                {
                                    elementToRemoveQ = f1;

                                }

                            }
                            
                            myBoard.FiguresList.Remove(elementToRemoveQ);

                        }
                        f.Move(newPositionRow, newPositionColumn);
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                    }
                    else Console.WriteLine("Ilegal move enter correct coordinates");

                    break;
                case 'k' or 'K':
                    if (temp.CheckDiagonal(f.Field) == true || temp.CheckRow(f.Field) == true || temp.CheckColumn(f.Field) == true && temp.CheckDistance(f.Field) == 1)
                    {
                        IFigure elementToRemoveK = null;
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = false;
                        
                        if (myBoard.TheGrid[newPositionRow, newPositionColumn].CurrentlyOccupied == true)
                        {
                            foreach (IFigure f1 in myBoard.FiguresList)
                            {
                                if (f1.Field.RowNumber == newPositionRow && f1.Field.ColumnNumber == newPositionColumn)
                                {
                                    elementToRemoveK = f1;

                                }

                            }
                            myBoard.FiguresList.Remove(elementToRemoveK);
                        }
                        f.Move(newPositionRow, newPositionColumn);
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                    }
                    else Console.WriteLine("Ilegal move enter correct coordinates");
                    break;
                case 'b' or 'B':
                    
                    if (temp.CheckDiagonal(f.Field) == true)
                    {

                        IFigure elementToRemoveB = null;
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = false;
                        
                        if (myBoard.TheGrid[newPositionRow, newPositionColumn].CurrentlyOccupied == true)
                        {
                            
                            foreach (IFigure f1 in myBoard.FiguresList)
                            {
                                if (f1.Field.RowNumber == newPositionRow && f1.Field.ColumnNumber == newPositionColumn)
                                {
                                    elementToRemoveB = f1;
                                    
                                }
                                
                            }
                            myBoard.FiguresList.Remove(elementToRemoveB);
                            
                        }
                        f.Move(newPositionRow, newPositionColumn);
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                        
                    }
                    else Console.WriteLine("Ilegal move enter correct coordinates");
                    break;
            }
            
            printBoard(myBoard);
            choseFigure();


        }
        private static void printBoard(Board myBoard)
        {
            for (int i = 0; i < myBoard.Size; i++) {
                for (int j = 0; j < myBoard.Size; j++) {
                    Field f = myBoard.TheGrid[i,j];
                    if (f.CurrentlyOccupied == true)
                    {
                        foreach (IFigure a in myBoard.FiguresList) {
                            
                            if (a.Color == Color.white)
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
