using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivCluster
{
    public class Normalization
    {
        public Double[,] MinMax(Double[,] padroes)
        {
            int quantidadeAtributos = padroes.GetLength(1);
            int quantidadePadroes = padroes.GetLength(0);

            for (int i = 0; i < quantidadeAtributos; i++)
            {
                double[] atributos = new double[quantidadePadroes];
                for (int j = 0; j < quantidadePadroes; j++)
                {
                    atributos[j] = padroes[j, i];
                }
                Normaliza(atributos);
                for (int j = 0; j < quantidadePadroes; j++)
                {
                    padroes[j, i] = atributos[j];
                }
            }
            return padroes;
        }
        private void Normaliza(Double[] atributos)
        {
            Double maiorAtributo = atributos.Max();
            Double menorAtributo = atributos.Min();
            for (int i = 0; i < atributos.Length; i++)
            {
                atributos[i] = ((atributos[i] - menorAtributo) / (maiorAtributo - menorAtributo));
            }
        }
    }
}
