using ClassLibrary;
using NUnit.Framework;

namespace ChessProblemTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Bishop bishop = new Bishop(Color.WHITE, new Field(3,3), FigureSide.LEFT, FigureNames.BISHOP);
        }
    }
}