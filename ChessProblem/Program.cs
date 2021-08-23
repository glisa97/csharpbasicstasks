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
            Knight n = new Knight(Color.white, new Field(0, 0), 'N');
            King k = new King(Color.white, new Field(2, 2), 'K');
            Rook r = new Rook(Color.black, new Field(4, 6), 'R');
            Queen q = new Queen(Color.white, new Field(5, 7), 'Q');
            Bishop b = new Bishop(Color.black, new Field(0, 7), 'N');

            myBoard.FiguresList.Add(n);
            myBoard.FiguresList.Add(k);
            myBoard.FiguresList.Add(r);
            myBoard.FiguresList.Add(q);
            myBoard.FiguresList.Add(b);

            foreach (IFigure f in myBoard.FiguresList) {
                Field currentField = setCurrentField(f.Field);
                currentField.CurrentlyOccupied = true;
            }
            

            printBoard(myBoard);
            choseFigure();
            printBoard(myBoard);
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

            
            foreach (IFigure f1 in myBoard.FiguresList) {
             
                if (f1.Field.RowNumber == PositionRow && f1.Field.ColumnNumber == PositionColumn) {
                    MarkMove(f1);
                }
            }
                   

        }
            
        
    
        private static void MarkMove(IFigure f) {

            Console.WriteLine("Enter row for move:");
            int newPositionRow = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter column for move:");
            int newPositionColumn = int.Parse(Console.ReadLine());
            Field temp = new Field(newPositionRow, newPositionColumn);
             switch(f.Mark) {
                case 'r' or 'R':
                    if (f.Field.RowNumber == newPositionRow || f.Field.ColumnNumber == newPositionColumn) {
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = false;
                        
                  
                        f.Move(newPositionRow,newPositionColumn);
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                    }
                break;

                case 'n' or 'N':
                    if (temp.CheckDistance(f.Field) == 3 && !temp.CheckRow(f.Field) && !temp.CheckColumn(f.Field)) {
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = false;
                        f.Move(newPositionRow, newPositionColumn);
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                    }


                    break;
                case 'q' or 'Q':
                    if(temp.CheckDiagonal(f.Field) == true || temp.CheckRow(f.Field) == true || temp.CheckColumn(f.Field) == true)
                    {
                        
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = false;
                        f.Move(newPositionRow, newPositionColumn);
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                    }
                    
                    break;

                case 'k' or 'K':
                    if (temp.CheckDiagonal(f.Field) == true || temp.CheckRow(f.Field) == true || temp.CheckColumn(f.Field) == true && temp.CheckDistance(f.Field) == 1)
                    {
                        
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = false;
                        f.Move(newPositionRow, newPositionColumn);
                        myBoard.TheGrid[f.Field.RowNumber, f.Field.ColumnNumber].CurrentlyOccupied = true;
                    }

                    break;

                case 'b' or 'B':
                    
                    break;


            }
            
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
    }
}
