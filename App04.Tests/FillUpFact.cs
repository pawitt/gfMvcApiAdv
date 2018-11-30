
using App04.Models;
using System;
using Xunit;

namespace App04.Tests
{
    public class FillUpFact
    {
        public class KmL
        {
            [Fact]
            public void SingleFillUp()
            {
                // arrange
                var f1 = new FillUp(odometer: 1000, liters: 50);

                // act
                double? kml = f1.KmL;

                // assert
                Assert.Null(kml);
            }

            // 1000 60     10.0
            // 1500 50     null
            [Fact]
            public void TwoFillUps()
            {
                var f1 = new FillUp(1000, 60);
                var f2 = new FillUp(1500, 50);
                f1.Next = f2;

                var kml1 = f1.KmL;
                var kml2 = f2.KmL;

                Assert.Equal(10.0, kml1);
                Assert.Null(kml2);
            }
        }

    }
}