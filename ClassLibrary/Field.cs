using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Field
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public bool CurrentlyOccupied { get; set; }
        public bool LegalNextMove { get; set; }

        public Field(int x, int y) {
            RowNumber = x;
            ColumnNumber = y;
           
        }
        public bool CheckColumn(Field f) {
            return f.ColumnNumber == this.ColumnNumber;
        }
        public bool CheckRow(Field f)
        {
            return f.RowNumber == this.RowNumber;
        }
        public bool CheckDiagonal(Field f)
        {
            return Math.Abs(f.RowNumber - this.RowNumber) == Math.Abs(f.ColumnNumber - this.ColumnNumber);
        }
        public int CheckDistance(Field f)
        {
            return Math.Abs(f.RowNumber - this.RowNumber) + Math.Abs(f.ColumnNumber - this.ColumnNumber);
        }
    }
}
