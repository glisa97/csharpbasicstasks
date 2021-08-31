using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Pawn : Figure 
    {
        public string Name { get; set; }

        public Pawn(Color color, Field field, string mark) : base(color, field, mark)
        {            
        }
       

        public override bool CheckMove(Field destinationField)
        {
            if (this.Color == Color.WHITE && this.Field.RowNumber < destinationField.RowNumber ||
                this.Color == Color.BLACK && this.Field.RowNumber > destinationField.RowNumber)
            {
                if((this.Color == Color.WHITE && this.Field.RowNumber == 1 && destinationField.CheckDistance(this.Field) <= 2) ||
                    (this.Color == Color.BLACK && this.Field.RowNumber == 6 && destinationField.CheckDistance(this.Field) <= 2) ||
                    destinationField.CheckDistance(this.Field) == 1) 
                {

                    return this.Field.CheckColumn(destinationField);
                }
            }
            return false;
            
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
        public override void Move(Field destinationField, Board myBoard)
        {
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
