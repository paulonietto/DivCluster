using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivCluster
{
    public class AtributoAusente
    {
        private double[,] padroes;
        private int linhas;
        private int colunas;
        private int[] tiposAtributos;
        public AtributoAusente(double[,] padroes, int[] tiposAtributos)
        {
            this.padroes = padroes;
            this.tiposAtributos = tiposAtributos;
            linhas = padroes.GetLength(0);
            colunas = padroes.GetLength(1);
        }

        public void ImputaAtributo()
        {
            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    if (double.IsNaN(padroes[i, j]))
                    {
                        if (tiposAtributos[j] == 0)
                        {
                            padroes[i, j] = MediaAtributo(j);
                        }
                        else
                        {
                            padroes[i, j] = MaiorFrequencia(j);
                        }
                    }
                }
            }
        }

        private double MaiorFrequencia(int j)
        {
            int frequencia = 0;
            double moda = 0;
            int maiorFrequencia = 0;
            for (int i = 0; i < linhas; i++)
            {
                frequencia = Frequencia(i, j);
                if (frequencia > maiorFrequencia)
                {
                    maiorFrequencia = frequencia;
                    moda = padroes[i, j];

                }
            }
            return moda;
        }
        private int Frequencia(int indice, int j)
        {
            int frequencia = 0;
            for (int i = indice; i < linhas; i++)
            {
                if (padroes[i, j] == padroes[indice, j])
                {
                    frequencia++;
                }
            }
            return frequencia;
        }
        private double MediaAtributo(int j)
        {
            double media = 0;
            int contador = 0;
            for (int i = 0; i < linhas; i++)
            {
                if (!double.IsNaN(padroes[i, j]))
                {
                    media += padroes[i, j];
                    contador++;
                }
            }
            return (media / contador);
        }
    }
}
