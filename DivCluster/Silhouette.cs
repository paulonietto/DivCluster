using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivCluster
{
    public class Silhouette
    {
        ArrayList agrupamento;
        private Double[,] padroes;
        private int quantidadePadroes;
        private Distance Distancia;
        public Silhouette(Double[,] padroes, ArrayList agrupamento)
        {
            this.agrupamento = agrupamento;
            this.padroes = padroes;
            quantidadePadroes = padroes.GetLength(0);
        }
        public double CalculaIndice()
        {
            Distancia = new Distance();
            if ((agrupamento.Count > 1) && (agrupamento.Count != quantidadePadroes))
            {
                double somaAgrupamento = 0;
                for (int i = 0; i < agrupamento.Count; i++)
                {
                    double padroesGrupo = 0;
                    double somaGrupo = 0;
                    Dictionary<int, Double[]> grupo = (Dictionary<int, Double[]>)agrupamento[i];
                    foreach (KeyValuePair<int, Double[]> padrao in grupo)
                    {
                        if (padrao.Key != 0)
                        {
                            padroesGrupo++;
                            double maior = 0;
                            double a = CalculaA(padrao.Key, grupo);
                            double b = CalculaB(padrao.Value, i);
                            if (a > b)
                            {
                                maior = a;
                            }
                            else
                            {
                                maior = b;
                            }
                            a = b - a;
                            somaGrupo += a / maior;
                        }
                    }
                    somaAgrupamento += (somaGrupo / padroesGrupo);
                }
                return (somaAgrupamento / agrupamento.Count);
            }
            return 0;
        }
        private double CalculaB(double[] padraoX, int indiceGrupo)
        {
            double distancia = 0;
            double menorDistancia = double.PositiveInfinity;
            int quantidade = 0;
            for (int i = 0; i < agrupamento.Count; i++)
            {
                if (i != indiceGrupo)
                {
                    Dictionary<int, Double[]> grupo = (Dictionary<int, Double[]>)agrupamento[i];
                    foreach (KeyValuePair<int, Double[]> padrao in grupo)
                    {
                        if (padrao.Key != 0)
                        {
                            distancia += CalculaDistancias(padrao.Value, padraoX);
                            quantidade++;
                        }
                    }
                    distancia = (distancia / quantidade);
                    if (distancia < menorDistancia)
                    {
                        menorDistancia = distancia;
                    }
                    distancia = 0;
                    quantidade = 0;
                }
            }
            return menorDistancia;
        }
        private double CalculaA(int x, Dictionary<int, double[]> grupo)
        {
            double dissimilaridade = 0;
            int quantidade = 0;
            foreach (KeyValuePair<int, Double[]> padrao in grupo)
            {
                if ((x != padrao.Key) && (padrao.Key != 0))
                {
                    dissimilaridade += CalculaDistancias(padrao.Value, grupo[x]);
                    quantidade++;
                }
            }
            if (quantidade == 0)
            {
                return 0;
            }
            else
            {
                return (dissimilaridade / quantidade);
            }           
        }
        private double CalculaDistancias(double[] padrao1, double[] padrao2)
        {
            double valor = Distancia.euclidiana(padrao1, padrao2);
            return valor;
        }
    }
}

