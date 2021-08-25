using NUnit.Framework;
using ClassLibrary;
using ChessProblemTests;

namespace ChessProblemTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestBishop()
        {
            int a = 7;
            int b = 2;
            int c = 6;
            int d = 3;
            Bishop test = new Bishop(Color.white, new Field(a, b), 'b');
            Bishop test2 = new Bishop(Color.white, new Field(c, d), 'b');
            if (test.CheckDiagonal(test2.Field) == true)



                Assert.Pass();
        }


        [Test]
        public void Test2()
        {
            Assert.Pass();
        }
    }
}