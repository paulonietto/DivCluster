using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivCluster
{
    public class EstimaGrupos
    {
        private double[,] padroes;
        private double pulaLimiares;
        private int iteracaoPorLimiar;
        private int linhas;
        private int colunas;
        double menorDissimilaridade;
        double maiorDissimilaridade;

        public EstimaGrupos(double[,] padroes, double pulaLimiares, int iteracaoPorLimiar)
        {
            this.padroes = padroes;
            this.pulaLimiares = pulaLimiares;
            this.iteracaoPorLimiar = iteracaoPorLimiar;
            linhas = padroes.GetLength(0);
            colunas = padroes.GetLength(1);
        }

        public int Controle()
        {
            ArrayList numerosGrupos = new ArrayList();
            CalculaDistancias();
            int[] vetorLimiares = new int[iteracaoPorLimiar];
            for (double i = menorDissimilaridade; i < maiorDissimilaridade; i += pulaLimiares)
            {
                for (int j = 0; j < iteracaoPorLimiar; j++)
                {
                    BSAS_NG BSAS = new BSAS_NG(padroes, i);
                    vetorLimiares[j] = BSAS.Agrupa();
                    Shake();
                }
                numerosGrupos.Add(EstimaK(vetorLimiares));
            }
            int[] lista = numerosGrupos.Cast<int>().ToArray();
            int maisRecorrente = EstimaK(lista);
            //  Console.WriteLine("Moda" + maisRecorrente);
            //  Console.ReadLine();
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

        /* private void Shake()
         {
             Random radom = new Random();
             int linhas = padroes.GetLength(0);
             int colunas = padroes.GetLength(1);
             double[,] novosPadroes = new double[linhas, colunas];
             int[] linhasUtilizadas = new int[linhas];
             int novaLinha = 0;
             for (int i = 0; i < linhas; i++)
             {
                 novaLinha = radom.Next(1, (linhas + 1));
                 while (linhasUtilizadas.Contains(novaLinha))
                 {
                     novaLinha = radom.Next(1, (linhas + 1));
                 }
                 linhasUtilizadas[i] = novaLinha;
                 for (int j = 0; j < colunas; j++)
                 {
                     novosPadroes[(novaLinha - 1), j] = padroes[i, j];
                 }
             }
             padroes = novosPadroes;
         }*/
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
        private void CalculaDistancias()
        {
            Distance distancia = new Distance();
            double[] padrao1 = new double[colunas];
            double[] padrao2 = new double[colunas];
            menorDissimilaridade = double.PositiveInfinity;
            maiorDissimilaridade = double.NegativeInfinity;

            for (int k = 0; k < linhas - 1; k++)
            {
                for (int i = k + 1; i < linhas; i++)
                {
                    for (int j = 0; j < colunas; j++)
                    {
                        padrao1[j] = padroes[k, j];
                        padrao2[j] = padroes[i, j];
                    }
                    double valorDistancia = distancia.euclidiana(padrao1, padrao2);
                    if (valorDistancia < menorDissimilaridade)
                    {
                        menorDissimilaridade = valorDistancia;
                    }
                    if (valorDistancia > maiorDissimilaridade)
                    {
                        maiorDissimilaridade = valorDistancia;
                    }
                }
            }
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


/*Input: X = {P1, P2, ..., PN} %conjunto de padrões de dados a serem agrupados
        S                             % número de vezes que será executado o algoritmo BSAS modificado; a cada execução os padrões são apresentados em uma ordem diferente
        Q                             %limiar de dissimilaridade 
        P                              %passo do processo iterativo {default = 1}

Output: K                           %estimativa para o número de grupos do agrupamento}

1. begin
2. menor ¬ distancia(P1,P2)
3. maior ¬ distancia(P1,P2)
4.   for i = 1 to N-1 do
5.     for j = i+1 to N do
6.       begin
7.         if distancia(Pi,Pj) < menor then menor ¬ distancia(Pi,Pj)
8.         if maior < distancia(Pi,Pj) then maior¬ distancia(Pi,Pj)
9.       end
10.   for Q = menor to maior step P do
11.     begin
12.       for roda  = 1 to S do
13.         begin
14.           BSAS(Q,X,t)
15.           shake(X,X)
16.         end
17.        estima(K)  ok %K: a moda resultante das S execuções de BSAS_NG(Q,X,t)
18.    end
19. end
20. end procedure.*/

