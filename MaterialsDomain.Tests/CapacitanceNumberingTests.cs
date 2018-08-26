using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MaterialsDomain
{
    public class CapacitanceNumberingTests
    {
        [Fact]
        public void Test100()
        {
            //Given
            var pf = new PicoFarads(10);
            
            //When
            var sut = (CapacitanceNumberingSystem)pf;

            //Then
            Assert.Equal(100, actual: sut.CapacitanceCode);
            Assert.Equal(0.01, ((NanoFarads)sut).Value);
            Assert.Equal(0.00001, ((MicroFarads)sut).Value);
        }

        [Fact]
        public void TestCapacitanceCode()
        {
            var mf = new MicroFarads(1.0);

            var sut = (CapacitanceNumberingSystem)mf;

            Assert.Equal(105, sut.CapacitanceCode);
        }

        [Fact]
        public void TestConcatNumbers()
        {
            var numbers = new[] { 1, 0, 3, 4, 5};

            var sut = numbers.ConcatNumbers();

            Assert.Equal(10345, sut);
        }

        [Fact]
        public void TestMicroFaradConversion()
        {
            var mf = new MicroFarads(1.0);

            var sut = (PicoFarads)mf;

            Assert.Equal(1000000, sut.Value);
        }

        [Fact]
        public void TestLeftToRight()
        {
            var mf = new MicroFarads(1.0);
            var pf = (PicoFarads)mf;

            var sut = ((int)pf.Value).GetIntArray().ToList();

            var expected = new List<int>() {1, 0, 0, 0, 0, 0, 0};

            Assert.Equal(expected, sut);
        }
    }
}
