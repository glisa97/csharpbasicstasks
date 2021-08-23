﻿using System;

namespace ClassLibrary
{
    public class Knight:IFigure
    {
        public Color Color { get; set; }
        public Field Field { get; set; }
        public char Mark { get; set; }

        public Knight(Color color, Field field, char mark)
        {
            Color = color;
            Field = field;
            Mark = mark;
        }

        public void Move(int row, int column) {
            Console.WriteLine("Im knight");
            this.Field.RowNumber = row;
            this.Field.ColumnNumber = column;
        }
    }
}
