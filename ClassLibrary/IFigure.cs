using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IFigure
    {
        
        public Color Color { get; set; }
        public Field Field{ get; set; }
        public char Mark { get; set; } 

        void Move(Field destinationField, Board myBoard);

        bool CheckMove(Field destinationField);

    }
}
