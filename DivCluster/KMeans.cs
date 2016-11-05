using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivCluster
{
    public class KMeans
    {
        private int k;
        double[,] padroes;
        ArrayList agrupamento;
        private int quantidadeDePadroes;
        private int quantidadeDeAtributos;
        private Distance distancia;

        public KMeans(double[,] padroes, int k)
        {
            this.padroes = padroes;
            this.k = k;
        }

        public ArrayList Agrupa()
        {
            quantidadeDePadroes = padroes.GetLength(0);
            quantidadeDeAtributos = padroes.GetLength(1);
            double[,] centroides = CentroidesAleatorios();
            agrupamento = new ArrayList();
            AdicionaCentroidesAosGrupos(centroides);
            // ImprimeAgrupamento(agrupamento);
            bool novosCentroides = true;
            distancia = new Distance();
            while (novosCentroides)
            {
                for (int i = 0; i < quantidadeDePadroes; i++)
                {
                    double[] padrao = RecuperaPadrao(i);
                    int nome = (i + 1);
                    AdicionaPadraoAoGrupoMaisProximo(nome, padrao);
                }
              //  ImprimeAgrupamento(agrupamento);
                novosCentroides = false;
                AtualizaCentroides(agrupamento);
                novosCentroides = VerificaCentroides(agrupamento);
            }
            LimparCentroides();
            // ImprimeAgrupamento(agrupamento);
            return agrupamento;
        }
        private void AtualizaCentroides(ArrayList agrupamento)
        {
            Dictionary<int, Double[]> grupo = new Dictionary<int, Double[]>((quantidadeDePadroes + 2));
            for (int i = 0; i < k; i++)
            {
                double[] somaDosPadroes = new double[quantidadeDeAtributos];

                grupo = (Dictionary<int, Double[]>)agrupamento[i];
                int quantidade = 0;
                int padroesNoGrupo = grupo.Count - 1;
                foreach (KeyValuePair<int, Double[]> padrao in grupo)
                {
                    if (padrao.Key != 0)
                    {
                        quantidade++;
                        for (int j = 0; j < quantidadeDeAtributos; j++)
                        {
                            somaDosPadroes[j] += padrao.Value[j];
                            if (quantidade == padroesNoGrupo)
                            {
                                somaDosPadroes[j] = (somaDosPadroes[j] / quantidade);
                            }
                        }
                    }
                }
                grupo.Add(-1, somaDosPadroes);
            }
            //ImprimeAgrupamento(agrupamento);
        }
        private void LimparCentroides()
        {
            Dictionary<int, Double[]> grupo = new Dictionary<int, Double[]>((quantidadeDePadroes + 2));
            for (int i = 0; i < k; i++)
            {
                grupo = (Dictionary<int, Double[]>)agrupamento[i];
                grupo.Remove(-1);
                grupo.Remove(0);
            }
        }
        private bool VerificaCentroides(ArrayList agrupamentos)
        {
            bool resetarGrupos = false;
            Dictionary<int, Double[]> grupo = new Dictionary<int, Double[]>((quantidadeDePadroes + 2));
            for (int i = 0; i < k; i++)
            {
                double[] centroide = new double[quantidadeDeAtributos];
                double[] novoCentroide = new double[quantidadeDeAtributos];
                grupo = (Dictionary<int, Double[]>)agrupamento[i];
                i++;
                centroide = grupo[0];
                novoCentroide = grupo[-1];
                for (int j = 0; j < quantidadeDeAtributos; j++)
                {
                    if (centroide[j] != novoCentroide[j])
                    {
                        resetarGrupos = true;
                        i = k;
                        j = quantidadeDeAtributos;
                        ResetarAgrupamento();
                    }
                }
            }

            return resetarGrupos;
        }
        private void ResetarAgrupamento()
        {
            Dictionary<int, Double[]> grupo = new Dictionary<int, Double[]>((quantidadeDePadroes + 2));
            for (int i = 0; i < k; i++)
            {
                grupo = (Dictionary<int, Double[]>)agrupamento[i];
                int nome = 0;
                double[] centroide = new double[quantidadeDeAtributos];
                centroide = grupo[-1];
                grupo.Clear();
                grupo.Add(nome, centroide);
            }
            //ImprimeAgrupamento(agrupamento);
        }
        private void AdicionaPadraoAoGrupoMaisProximo(int nome, double[] padrao)
        {
            double menorDistancia = double.MaxValue;
            int indiceMenorDistancia = -1;
            Dictionary<int, Double[]> grupo = new Dictionary<int, Double[]>((quantidadeDePadroes));
            for (int i = 0; i < agrupamento.Count; i++)
            {
                grupo = (Dictionary<int, Double[]>)agrupamento[i];
                double dissimilaridade = distancia.euclidiana(padrao, grupo[0]);
                if (dissimilaridade < menorDistancia)
                {
                    menorDistancia = dissimilaridade;
                    indiceMenorDistancia = i;
                }
            }
            grupo = (Dictionary<int, Double[]>)agrupamento[indiceMenorDistancia];
            grupo.Add(nome, padrao);

        }
        private double[] RecuperaPadrao(int indice)
        {
            double[] padrao = new double[quantidadeDeAtributos];
            for (int i = 0; i < quantidadeDeAtributos; i++)
            {
                padrao[i] = padroes[indice, i];
            }
            return padrao;
        }
        private void ImprimeAgrupamento(ArrayList agrupamento)
        {
            for (int i = 0; i < agrupamento.Count; i++)
            {
                Console.WriteLine("Grupo" + (i + 1));

                foreach (KeyValuePair<String, Double[]> item in (Dictionary<string, double[]>)agrupamento[i])
                {
                    Console.Write(item.Key + " ");
                    foreach (var valor in item.Value)
                    {
                        Console.Write(valor + "-");
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }
        private void AdicionaCentroidesAosGrupos(double[,] centroides)
        {
            Dictionary<int, Double[]> grupo = new Dictionary<int, Double[]>();
            for (int i = 0; i < k; i++)
            {
                double[] centroide = new double[quantidadeDeAtributos];
                for (int j = 0; j < quantidadeDeAtributos; j++)
                {
                    centroide[j] = centroides[i, j];
                }
                grupo.Add(0, centroide);
                InsereGrupoNoAgrupamento(grupo);
                grupo.Clear();
            }
        }
        private void InsereGrupoNoAgrupamento(Dictionary<int, double[]> grupo)
        {
            Dictionary<int, Double[]> grupoCopia = new Dictionary<int, Double[]>(grupo);
            agrupamento.Add(grupoCopia);
        }
        private double[,] CentroidesAleatorios()
        {
            Random random = new Random();
            int novoCentroide = 0;
            double[,] conjuntoDeCentroides = new double[k, quantidadeDeAtributos];
            int[] centroidesUtilizados = new int[k];
            for (int i = 0; i < k; i++)
            {
                novoCentroide = random.Next(1, (quantidadeDePadroes + 1));
                while (centroidesUtilizados.Contains(novoCentroide))
                {
                    novoCentroide = random.Next(1, (quantidadeDePadroes + 1));
                }
                centroidesUtilizados[i] = novoCentroide;

                for (int j = 0; j < quantidadeDeAtributos; j++)
                {
                    conjuntoDeCentroides[i, j] = padroes[(centroidesUtilizados[i] - 1), j];
                }

            }
            return conjuntoDeCentroides;
        }
    }
}

