﻿using System;
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

        public Rook(Color color, Field field)
        {
            Color = color;
            Field = field;
            //Mark = mark;
        }

        public void Move(int row,int column) {
            Console.WriteLine("Im rook");
            this.Field.RowNumber = row;
            this.Field.ColumnNumber = column;
            
            
        }
        public bool checkMove(Field field) {
            if (this.Field.RowNumber == field.RowNumber || this.Field.ColumnNumber == field.ColumnNumber)
            {
                return true;
            }
            else return false;
        }
        
    }
}