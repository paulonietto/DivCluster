using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivCluster
{
    public class Dunn2
    {
        ArrayList agrupamento;
        private Double[,] padroes;
        private int quantidadePadroes;
        private Distance Distancia;
        public Dunn2(Double[,] padroes, ArrayList agrupamento)
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
                double Dunn = MenorDistanciaInterGrupos(maiorDiametro);
                return Dunn;
            }
            return 0;
        }

        private double MenorDistanciaInterGrupos(double maiorDiametro)
        {
            double distancia;
            double menorDistancia = double.MaxValue;
            for (int i = 0; i < agrupamento.Count - 1; i++)
            {
                for (int j = i + 1; j < agrupamento.Count; j++)
                {
                    Dictionary<String, Double[]> grupo1 = (Dictionary<String, Double[]>)agrupamento[i];
                    Dictionary<String, Double[]> grupo2 = (Dictionary<String, Double[]>)agrupamento[j];
                    foreach (KeyValuePair<String, Double[]> padraoG1 in grupo1)
                    {
                        foreach (KeyValuePair<String, Double[]> padraoG2 in grupo2)
                        {
                            if ((padraoG1.Key != "Centroide") && (padraoG2.Key != "Centroide"))
                            {
                                distancia = CalculaDistancias(padraoG1.Value, padraoG2.Value);
                                distancia = distancia / maiorDiametro;
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
                Double diametro = VerificaDiametro((Dictionary<string, double[]>)agrupamento[i]);
                if (diametro > maiorDiametro)
                {
                    maiorDiametro = diametro;
                }
            }
            return maiorDiametro;
        }
        private double VerificaDiametro(Dictionary<string, double[]> grupo)
        {
            Double diametro = -1;
            foreach (KeyValuePair<String, Double[]> padrao1 in grupo)
            {
                foreach (KeyValuePair<String, Double[]> padrao2 in grupo)
                {
                    if ((padrao1.Key != padrao2.Key) && (padrao1.Key != "Centroide") && (padrao2.Key != "Centroide"))
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
            Distance Distancia = new Distance();
            double valor = Distancia.euclidiana(padrao1, padrao2);
            return valor;
        }
    }
}
