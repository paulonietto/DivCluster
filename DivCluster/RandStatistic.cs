using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivCluster
{
    public class RandStatistic
    {
        ArrayList agrupamento;
        private string[] classe;
        private int quantidadePadroes;
        public RandStatistic(string[] classe, ArrayList agrupamento)
        {
            this.agrupamento = agrupamento;
            this.classe = classe;
            quantidadePadroes = classe.GetLength(0);
        }

        public double CalculaRand()
        {
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            for (int i = 0; i < agrupamento.Count; i++)
            {
                for (int j = 0; j < agrupamento.Count; j++)
                {
                    Dictionary<int, Double[]> grupo1 = (Dictionary<int, Double[]>)agrupamento[i];
                    Dictionary<int, Double[]> grupo2 = (Dictionary<int, Double[]>)agrupamento[j];
                    foreach (KeyValuePair<int, Double[]> padraoG1 in grupo1)
                    {
                        foreach (KeyValuePair<int, Double[]> padraoG2 in grupo2)
                        {
                            if ((padraoG1.Key != 0) && (padraoG2.Key != 0))
                            {
                                if (padraoG1.Key < padraoG2.Key)
                                {
                                    if ((classe[padraoG1.Key - 1] == classe[padraoG2.Key - 1]) && i == j)
                                    {
                                        a++;
                                    }
                                    else if ((classe[padraoG1.Key - 1] != classe[padraoG2.Key - 1]) && i == j)
                                    {
                                        b++;
                                    }
                                    else if ((classe[padraoG1.Key - 1] == classe[padraoG2.Key - 1]) && i != j)
                                    {
                                        c++;
                                    }
                                    else if ((classe[padraoG1.Key - 1] != classe[padraoG2.Key - 1]) && i != j)
                                    {
                                        d++;
                                    }
                                }

                            }
                        }
                    }
                }
            }
            double m = (a + b + c + d);
            return (a + d) / m;
        }
    }
}

