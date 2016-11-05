using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivCluster
{
    public class Dunn
    {
        ArrayList agrupamento;
        private Double[,] padroes;
        private int quantidadePadroes;
        private Distance Distancia;
        public Dunn(Double[,] padroes, ArrayList agrupamento)
        {
            this.agrupamento = agrupamento;
            this.padroes = padroes;
            quantidadePadroes = padroes.GetLength(0);
        }
        public double CalculaIndice()
        {
            if ((agrupamento.Count > 1) && (agrupamento.Count != quantidadePadroes))
            {
                Distancia = new Distance();
                double maiorDiametro = GrupoMaiorDiametro();
                double menorDistanciaInter = MenorDistanciaInterGrupos();
                return (menorDistanciaInter / maiorDiametro);
            }
            return 0;
        }
        private double MenorDistanciaInterGrupos()
        {
            double distancia;
            double menorDistancia = double.MaxValue;
            for (int i = 0; i < agrupamento.Count - 1; i++)
            {
                for (int j = i + 1; j < agrupamento.Count; j++)
                {
                    Dictionary<int, Double[]> grupo1 = (Dictionary<int, Double[]>)agrupamento[i];
                    Dictionary<int, Double[]> grupo2 = (Dictionary<int, Double[]>)agrupamento[j];
                    foreach (KeyValuePair<int, Double[]> padraoG1 in grupo1)
                    {
                        foreach (KeyValuePair<int, Double[]> padraoG2 in grupo2)
                        {
                            if ((padraoG1.Key != 0) && (padraoG2.Key != 0))
                            {
                                distancia = CalculaDistancias(padraoG1.Value, padraoG2.Value);
                                if (distancia < menorDistancia)
                                {
                                    menorDistancia = distancia;
                                }
                            }

                        }
                    }
                }
            }
            return menorDistancia;
        }
        private double GrupoMaiorDiametro()
        {
            Double maiorDiametro = 0;
            for (int i = 0; i < agrupamento.Count; i++)
            {
                Double diametro = VerificaDiametro((Dictionary<int, double[]>)agrupamento[i]);
                if (diametro > maiorDiametro)
                {
                    maiorDiametro = diametro;
                }
            }
            return maiorDiametro;
        }
        private double VerificaDiametro(Dictionary<int, double[]> grupo)
        {
            Double diametro = -1;
            foreach (KeyValuePair<int, Double[]> padrao1 in grupo)
            {
                foreach (KeyValuePair<int, Double[]> padrao2 in grupo)
                {
                    if ((padrao1.Key != padrao2.Key) && (padrao1.Key != 0) && (padrao2.Key != 0))
                    {
                        double dissimilaridade;
                        dissimilaridade = CalculaDistancias(padrao1.Value, padrao2.Value);
                        if (dissimilaridade > diametro)
                        {
                            diametro = dissimilaridade;
                        }
                    }
                }
            }
            return diametro;
        }
        private double CalculaDistancias(double[] padrao1, double[] padrao2)
        {
            double valor = Distancia.euclidiana(padrao1, padrao2);
            return valor;
        }
    }
}
