using Conway.Classes;
using Xunit;

namespace Conway.Test
{
    public class ConwayTests
    {
        [Fact]
        public void Setup_TestPaintMatrix()
        {
            var sysUnderTest = new Matrix(4,4);

            sysUnderTest.DrawBoardDimension();
        }
    }
}
