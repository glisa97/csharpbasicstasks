using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
     public class Board
    {
        public int Size { get; set; }
        public Field[,] TheGrid { get; set; }
        public List<IFigure> FiguresList { get; set; }

        public bool IsWhiteTurn { get; set; }


        public Board(int s)
        {
            Size = s;
            TheGrid = new Field[Size, Size];
            FiguresList = new List<IFigure>();

            for (int i = 0; i < Size; i++) {
                for (int j = 0; j < Size; j++) {
                    TheGrid[i, j] = new Field(i, j);
                }
            }
        }
        public void MarkNextLegalMoves(Field currentField, string chessPiece)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    TheGrid[i, j].LegalNextMove = false;
                  /*  TheGrid[i, j].CurrentlyOccupied = false;*/
                }
            } 
        }

        public void ChangeMoveTurn()
        {
            if (IsWhiteTurn == true)
            {
                IsWhiteTurn = false;
            }
            else
            {
                IsWhiteTurn = true;
            }

        }
    }

    
}
