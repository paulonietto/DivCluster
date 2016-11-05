using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivCluster
{
    public class EstimaGrupos2
    {
        private double[,] padroes;
        private int quantidadeLimiares;
        private int iteracaoPorLimiar;
        private int linhas;
        private int colunas;

        public EstimaGrupos2(double[,] padroes, int quantidadeLimiares, int iteracaoPorLimiar)
        {
            this.padroes = padroes;
            this.quantidadeLimiares = quantidadeLimiares;
            this.iteracaoPorLimiar = iteracaoPorLimiar;
            linhas = padroes.GetLength(0);
            colunas = padroes.GetLength(1);
        }

        public int Controle()
        {
            double[] dissimilaridades = CalculaDistancias();
            double menorDissimilaridade = dissimilaridades.Min();
            double maiorDissimilaridade = dissimilaridades.Max();
            double pulaLimiar = (maiorDissimilaridade - menorDissimilaridade) / quantidadeLimiares;
            List<int> limiares = new List<int>();
           
            for (double i = menorDissimilaridade; i <= maiorDissimilaridade; i += pulaLimiar )
            {
                for (int j = 0; j < iteracaoPorLimiar; j++)
                {
                    BSAS_NG BSAS = new BSAS_NG(padroes, i);
                    limiares.Add(BSAS.Agrupa());
                    Shake();
                }

            }

            int[] lista = limiares.Cast<int>().ToArray();
            int maisRecorrente = EstimaK(lista);
            Console.WriteLine("Moda" + maisRecorrente);
            Console.ReadLine();
            return maisRecorrente;
        }

        private void ImprimeConjuntoDados()
        {
            for (int i = 0; i < padroes.GetLength(0); i++)
            {
                for (int j = 0; j < padroes.GetLength(1); j++)
                {
                    Console.Write(padroes[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
               
        private void Shake()
        {
            Random radom = new Random();
            ArrayList conjuntoPadroes = new ArrayList(linhas);
            for (int i = 0; i < linhas; i++)
            {
                double[] padrao = new double[colunas];
                for (int j = 0; j < colunas; j++)
                {
                    padrao[j] = padroes[i, j];
                }
                conjuntoPadroes.Add(padrao);
            }
            int qtdLinhas = linhas;
            for (int i = 0; i < linhas; i++)
            {
                int novaLinha = radom.Next(0, qtdLinhas);
                double[] padrao = (double[])conjuntoPadroes[novaLinha];
                conjuntoPadroes.RemoveAt(novaLinha);
                qtdLinhas--;
                for (int j = 0; j < colunas; j++)
                {
                    padroes[i, j] = padrao[j];
                }
            }
            // ImprimeConjuntoDados();
        }

        private double[] CalculaDistancias()
        {
            Distance distancia = new Distance();
            double[] padrao1 = new double[colunas];
            double[] padrao2 = new double[colunas];
            double[] dissimilaridades = new double[(linhas * (linhas - 1)) / 2];
            int indice = 0;
            for (int k = 0; k < linhas - 1; k++)
            {
                for (int i = k + 1; i < linhas; i++)
                {
                    for (int j = 0; j < colunas; j++)
                    {
                        padrao1[j] = padroes[k, j];
                        padrao2[j] = padroes[i, j];
                    }
                    dissimilaridades[indice] = distancia.euclidiana(padrao1, padrao2);
                    indice++;
                }
            }
            return dissimilaridades;
        }

        public int EstimaK(int[] vetorK)
        {
            int frequencia = 0;
            int moda = 0;
            int maiorFrequencia = 0;
            for (int i = 0; i < vetorK.Length; i++)
            {
                int indice = i;
                frequencia = Frequencia(vetorK, indice, vetorK[i]);
                if (frequencia > maiorFrequencia)
                {
                    maiorFrequencia = frequencia;
                    moda = vetorK[i];

                }
            }
            return moda;

        }
        private int Frequencia(int[] vetorElemetos, int indice, int elemento)
        {
            int frequencia = 0;
            for (int i = indice; i < vetorElemetos.Length; i++)
            {
                if (vetorElemetos[i] == elemento)
                {
                    frequencia++;
                }
            }
            return frequencia;
        }

    }


}
    

