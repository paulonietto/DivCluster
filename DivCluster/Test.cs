using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivCluster
{
    class Test
    {
        private ArrayList padroes;
        private Double[,] matrizDissimilaridade;

        public Test(ArrayList padroes)
        {
            this.padroes = padroes;
            CalculaDistancia(padroes);
        }

        public void CalculaDistancia(ArrayList padroes)
        {
            Distance Distancia = new Distance();
            int tamanho = padroes.Count;

            matrizDissimilaridade = new Double[tamanho, tamanho];
            for (int i = 0; i < tamanho - 1; i++)
            {
                for (int j = i + 1; j < tamanho; j++)
                {


                    matrizDissimilaridade[i, j] = Distancia.euclidiana((Double[])padroes[i], (Double[])padroes[j]);
                    matrizDissimilaridade[j, i] = matrizDissimilaridade[i, j];
                }

            }

            /*  Double[] vetorMedia = new Double[tamanho+1];
               for (int i = 0; i <= tamanho; i++)
               {

                  for (int j = 0; j < i; j++)
                   {
                      vetorMedia[i] += matrizDissimilaridade[j,i-1];
                  }
                  for (int k = i; k <tamanho; k++)
                  {
                      vetorMedia[i] += matrizDissimilaridade[i, k];

                  }
                  vetorMedia[i] = (vetorMedia[i] / tamanho); 


              }*/





        }



        /*private int MaiorDissimilaridade(Double[,] matriz)
    {
    return 1}
/*  1.begin
2.t = 1
3.AG1  = { X}                 % agrupamento inicial
4.G = X
5.repeat
6.maxDiss = maiorDissimilaridade(G) % encontrar elemento mais dissimilar
7.G  G – { maxDiss}
        8.tempG { maxDiss}
        9.repeat
10.Para cada padrão x pertencente a G encontre:
        12.Dx = (média diss(x, y), x  G e xy]  (média diss(x, z) z  tempG)
11.Encontre o padrão x para qual a diferença Dx é a maior.
12.         if Dx  0 then tempG  tempG  { x}
        13.until todos valores Dh sejam negativos
14.t  t + 1
15.Gt  tempG
16.AGt    (AGt - 1  { G})  { G, Gt}
        17.G  grupoMaiorDiametro(AGt) % encontrar grupo com maior diâmetro
18.until MaxGrupos = t.
19.return AGt
20.end procedure*/

    }
}


