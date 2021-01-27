using Conway.Classes;
using System;
using Xunit;

namespace Conway.Test
{
    public class ConwayTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 4)]
        [InlineData(1, 10)]
        [InlineData(1, 9)]
        public void Setup_CreateValidMatrix(int rows, int cols)
        {
            var sysUnderTest = new Matrix(rows,cols);

            Assert.NotNull(sysUnderTest);
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, 0)]
        [InlineData(0, 10)]
        [InlineData(-20, -30)]
        [InlineData(10, -20)]
        public void Setup_CreateInvalidMatrix_ThrowException(int rows, int cols)
        {
            Matrix sysUnderTest;
            Assert.Throws<ArgumentException>(() => sysUnderTest = new Matrix(rows, cols));
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, 0)]
        [InlineData(0, 10)]
        [InlineData(-20, -30)]
        [InlineData(10, -20)]
        public void Setup_CreateArrayWrapper_ThrowException(int rows, int cols)
        {
            ArrayWrapper sysUnderTest;
            Assert.Throws<ArgumentException>(() => sysUnderTest = new ArrayWrapper(rows, cols));
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 4)]
        [InlineData(1, 10)]
        [InlineData(1, 9)]
        public void Setup_CreateValidArrayWrapper(int rows, int cols)
        {
            var sysUnderTest = new ArrayWrapper(rows, cols);

            Assert.NotNull(sysUnderTest);
        }
    }
}
