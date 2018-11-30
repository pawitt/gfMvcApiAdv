using App04.Models;
using Xunit;

namespace App04.Tests
{
    public class JobFact
    {
        public class AddFillUp
        {
            [Fact]
            public void GeneralUsage()
            {
                var j = new Job();

                Assert.NotNull(j.FillUps);
                Assert.Equal(0, j.FillUps.Count);
            }

            [Fact]
            public void FirstFillUp()
            {
                var job = new Job();

                FillUp f = job.AddFillUp(odometer: 1000, liters: 60);

                Assert.NotNull(f);
                Assert.Equal(1000, f.Odometer);
                Assert.Equal(60, f.Liters);
                Assert.Equal(1, job.FillUps.Count);
            }


            [Fact]
            public void SecondFillUps()
            {
                var job = new Job();

                FillUp f1 = job.AddFillUp(odometer: 1000, liters: 60);
                FillUp f2 = job.AddFillUp(odometer: 1000, liters: 60);
              
                Assert.Equal(2, job.FillUps.Count);
                Assert.Same(f2, f1.Next);
            }
        }

        public class AverageKmL
        {

        }
    }
}