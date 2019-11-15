using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkGenerator
{
    public class Gaussian
    {
        private Random r;
        private double mean;
        private double standardDeviation;

        public Gaussian(double mean, double sd)
        {
            r = new Random(0);
            this.mean = mean;
            this.standardDeviation = sd;
        }

        public double NextGaussian()
        {
            double u1 = r.NextDouble();
            double u2 = r.NextDouble();
            double left = Math.Cos(2.0 * Math.PI * u1);
            double right = Math.Sqrt(-2.0 * Math.Log(u2));
            double z = left * right;
            return this.mean + (z * this.standardDeviation);
        }
    }
}
