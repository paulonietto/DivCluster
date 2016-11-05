using System;

namespace DivCluster
{
    public class Distance
    {
        public double euclidiana(double[] P1, double[] P2)
        {
            double soma = 0;
            for (int i = 0; i < P1.Length; i++)
            {
                soma += Math.Pow((P1[i] - P2[i]), 2);
            }
            return Math.Sqrt(soma);
        }
    }
}