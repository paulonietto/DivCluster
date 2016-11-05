using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivCluster
{
    class BSAS_NG
    {
        Distance distancia;
        ArrayList agrupamento;
        int quantidadePadroes;
        int quantidadeAtributos;
        double[,] padroes;
        double limiar;
        Dictionary<int, Double[]> grupo;
        int t;
        public BSAS_NG(double[,] padroes, double limiar)
        {
            this.padroes = padroes;
            this.limiar = limiar;
            distancia = new Distance();
        }

        public int Agrupa()
        {
            t = 1;
            quantidadePadroes = padroes.GetLength(0);
            quantidadeAtributos = padroes.GetLength(1);
            grupo = new Dictionary<int, Double[]>(quantidadePadroes + 1);
            Double[] padrao = RecuperaPadrao(0); //ok
            CriaGrupo(1, padrao);
            agrupamento = new ArrayList(quantidadePadroes); //OK
            AdicionaGrupoAoAgrupamento(grupo);
            for (int i = 1; i < quantidadePadroes; i++)
            {
                padrao = RecuperaPadrao(i);
                EncontrarGrupoMaisSimilar(padrao, (i + 1));
            }
            //  ImprimeAgrupamento(agrupamento);
            return t;
        }
        private void EncontrarGrupoMaisSimilar(Double[] padrao, int nomePadrao)
        {
            Dictionary<int, Double[]> grupo;
            int padroesNoGrupo = agrupamento.Count;
            int indiceMaisSimilar = -1;
            double menorDistancia = double.MaxValue;
            for (int i = 0; i < padroesNoGrupo; i++)
            {
                grupo = (Dictionary<int, Double[]>)agrupamento[i];
                double valorDistancia = distancia.euclidiana(padrao, grupo[0]);

                // Console.WriteLine(valorDistancia + " calculo");
                if (menorDistancia > valorDistancia)
                {
                    menorDistancia = valorDistancia;
                    indiceMaisSimilar = i;
                }

            }
            InsereNoGrupoMaisProximo(padrao, nomePadrao, indiceMaisSimilar, menorDistancia);
        }
        private void InsereNoGrupoMaisProximo(double[] padrao, int nomePadrao, int indiceMaisSimilar, double menorDistancia)
        {
            if (menorDistancia > limiar)
            {
                grupo.Clear();
                t = t + 1;
                CriaGrupo(nomePadrao, padrao);
                AdicionaGrupoAoAgrupamento(grupo);

            }
            else
            {
                grupo = (Dictionary<int, Double[]>)agrupamento[indiceMaisSimilar];
                AdicionaPadraoAoGrupo(nomePadrao, padrao, grupo);
                RecalculaCentroide(grupo);
                RemoveGrupoDoAgrupamento(indiceMaisSimilar);
                AdicionaGrupoAoAgrupamento(grupo);
            }
        }
        private void RecalculaCentroide(Dictionary<int, Double[]> grupo)
        {
            Double[,] padroesGrupo = new double[(grupo.Count - 1), quantidadeAtributos];
            int indiceX = 0;
            grupo.Remove(0);
            foreach (KeyValuePair<int, Double[]> item in grupo)
            {
                for (int i = 0; i < quantidadeAtributos; i++)
                {
                    padroesGrupo[indiceX, i] = item.Value[i];
                }

                indiceX++;
            }
            Double[] centroide = CalculaCentroide(padroesGrupo);
            grupo.Add(0, centroide);
        }
        private double[] CalculaCentroide(double[,] padroesGrupo)
        {
            Double[] centroide = new Double[quantidadeAtributos];
            int x = padroesGrupo.GetLength(0);
            for (int i = 0; i < quantidadeAtributos; i++)
            {
                double media = 0;
                for (int j = 0; j < x; j++)
                {
                    media += padroesGrupo[j, i];
                }
                centroide[i] = (media / x);
                media = 0;
            }
            return centroide;
        }
        private void RemoveGrupoDoAgrupamento(int indiceGrupo)
        {
            agrupamento.RemoveAt(indiceGrupo);
        }
        private void AdicionaPadraoAoGrupo(int nome, double[] padrao, Dictionary<int, double[]> grupo)
        {
            grupo.Add(nome, padrao);
        }
        private void CriaGrupo(int nomePadrao, double[] padrao)
        {
            grupo.Add(nomePadrao, padrao);
            grupo.Add(0, padrao);
        }
        private double[] RecuperaPadrao(int indice)
        {
            Double[] padrao = new double[quantidadeAtributos];
            for (int i = 0; i < quantidadeAtributos; i++)
            {
                padrao[i] = padroes[indice, i];
            }
            return padrao;
        }
        private void AdicionaGrupoAoAgrupamento(Dictionary<int, double[]> grupo)
        {
            Dictionary<int, Double[]> grupoCopia = new Dictionary<int, Double[]>(grupo);
            agrupamento.Add(grupoCopia);
        }
    }

    /*  private int Controle(double [] padroes, double limiar)
      {
          int quantidadeGrupos = 1;
          Dictionary <String, double >grupo1 = new Dictionary<String, double>();
          grupo1.Add("1", padroes[1]);
          grupo1.Add("Centroide", padroes[1]);
          for (int i = 2; i <= padroes.Length; i++)
          {
              double menorDissimilaridade = double.MaxValue;
              int indiceGrupo = 0;
              for (int j = 1; j <= quantidadeGrupos; j++)
              {
                  double dissimilaridade = distancia.euclidiana(grupo1.Values, padroes[i]);
                  if (menorDissimilaridade > dissimilaridade)
                  {
                      menorDissimilaridade = dissimilaridade;
                      indiceGrupo = j;
                  }
              }
              if (menorDissimilaridade > limiar)
              {
                  quantidadeGrupos++;
                 //criar novo grupo
                 //adicionar o padrao
                 //o padrao eh o centroide
              }
              else
              {
                  //o grupo de indice indiceGrupo recebe o padrao
                  //recalcula o centroide

              }
               int indiceGrupo = 0;
              for (int j = 1; j <= quantidadeGrupos; j++)
          }
          return quantidadeGrupos;
      }

     */
}
/*
procedure BSAS_NG (X, O, t)
Input: X = {P1, P2,...,PN}               % N padrões a serem agrupados
            O                                         % limiar de dissimilaridade

Output: t 			    % quantidade de grupos

1. begin
2. t = 1
3. Gt  U {P1}
4. for i = 2 to N                                             % N número de padrões
5.     encontrar Gk: d(Pi,Gk) = min1 ≤ j ≤ t d(Pi,Gj)
6.      if (d(Pi,Gk) > limiar) then
7.           t = t + 1
8.          Gt U {Pi}
9.     else 
10.        Gk = Gk U {Pi}	
11.   end
12. end 
13. return t
14. end procedure
*/


