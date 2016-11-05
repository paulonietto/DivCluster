using System;
using System.Collections;
using System.Collections.Generic;


namespace DivCluster
{
    public class DIANA

    {
        ArrayList agrupamento;
        double [,] matrizDissimilaridades;
        private Double[,] padroes;
        private int totalGrupos;
        private Dictionary<int, Double[]> grupo;
        private Dictionary<int, Double[]> tempG;
        private int quantidadePadroes;
        private int quantidadeAtributos;
        private int tipoDiametro;
        private double[] diametros;
        public DIANA(Double[,] padroes, int k, int tipoDiametro)
        {
            this.padroes = padroes;
            this.totalGrupos = k;
            this.tipoDiametro = tipoDiametro;
            quantidadePadroes = padroes.GetLength(0);
            quantidadeAtributos = padroes.GetLength(1);
        }

        public ArrayList Agrupa()
        {
            diametros = new double[totalGrupos];
            NegativaDiametro(0);
            agrupamento = new ArrayList(totalGrupos);

            //CriaGrupo 
            CriaGrupoInicial();
            agrupamento.Add(grupo);
            if (totalGrupos == 1)
            {
                return agrupamento;
            }
            //Calcula as distancias
            CalculaDistancias();

            tempG = new Dictionary<int, Double[]>(quantidadePadroes);

            //inicia o repeat
            for (int quantidadeGrupos = 1; quantidadeGrupos < totalGrupos; quantidadeGrupos++)
            {
                // Busca padrao com maior distancia
                int maiorDistancia = BuscaMaiorDistanciaMedia(grupo);

                //cria padrao com maior distancia em tempG
                AdicionaPadraoEmTempG(maiorDistancia);

                // remove padrao com maior distancia do grupo
                RemovePadraoGrupo(maiorDistancia);

                //segundo repeat
                PadroesMaisProximoTempG();

                //insere os grupos no agrupamento
                //  InsereGrupoNoAgrupamento(grupo);
                InsereGrupoNoAgrupamento(tempG);


                if ((quantidadeGrupos + 1) != totalGrupos)
                {
                    // grupo.Clear();
                    tempG.Clear();

                    //busca grupo com maior diametro
                    int indiceGrupoMaiorDiametro = GrupoMaiorDiametro();
                    grupo = (Dictionary<int, double[]>)agrupamento[indiceGrupoMaiorDiametro];
                    NegativaDiametro(indiceGrupoMaiorDiametro);
                    // RemoveGrupoDoAgrupamento(indiceGrupoMaiorDiametro);
                }
            }
            return agrupamento;
        }
        private void ImprimeAgrupamento(ArrayList agrupamento)
        {
            for (int i = 0; i < agrupamento.Count; i++)
            {
                Console.WriteLine("Grupo" + (i + 1));

                foreach (KeyValuePair<int, Double[]> item in (Dictionary<int, double[]>)agrupamento[i])
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
        private void PadroesMaisProximoTempG()
        {
            bool valoresPositivos = true;
            while (valoresPositivos)
            {
                valoresPositivos = false;
                Double mediaIntra = 0;
                Double mediaInter = 0;
                Double maiorValor = 0;
                int padraoMaisDissimilar = int.MinValue;
                foreach (KeyValuePair<int, Double[]> pair in grupo)
                {
                    mediaIntra = CalculaMedia(pair.Key, grupo);
                    mediaInter = CalculaMedia(pair.Key, tempG);
                    double valor;
                    valor = (mediaIntra - mediaInter);
                       if ( valor > maiorValor)
                        {
                            padraoMaisDissimilar = pair.Key;
                            maiorValor = valor;
                        }
                }
                if (maiorValor > 0)
                {
                    valoresPositivos = true;
                    AdicionaPadraoEmTempG(padraoMaisDissimilar);
                    RemovePadraoGrupo(padraoMaisDissimilar);
                }
            }
        }
        private int BuscaMaiorDistanciaMedia(Dictionary<int, double[]> grupo)
        {
            Double media = 0;
            Double maiorMedia = media;
           int indice =int.MinValue;
            foreach (KeyValuePair<int, Double[]> padrao1 in grupo)
            {
                foreach (KeyValuePair<int, Double[]> padrao2 in grupo)
                {
                    if (padrao1.Key != padrao2.Key)
                    {
                        if (padrao1.Key < padrao2.Key)
                        {
                            media += matrizDissimilaridades[padrao1.Key,padrao2.Key];
                        }
                        else
                        {
                            media += matrizDissimilaridades[padrao2.Key,padrao1.Key];
                        }

                    }
                }
                media = media / (grupo.Count - 1);
                //Console.WriteLine(media);
                if (media > maiorMedia)
                {
                    maiorMedia = media;
                    indice = padrao1.Key;
                }
                media = 0;
            }
            return indice;
        }
        private void RemoveGrupoDoAgrupamento(int indiceGrupoMaiorDiametro)
        {
            agrupamento.RemoveAt(indiceGrupoMaiorDiametro);
        }
        private void InsereGrupoNoAgrupamento(Dictionary<int, double[]> grupo)
        {
            Dictionary<int, Double[]> grupoCopia = new Dictionary<int, Double[]>(grupo);
            agrupamento.Add(grupoCopia);
            NegativaDiametro(agrupamento.Count - 1);
        }
        private void NegativaDiametro(int indice)
        {
            diametros[indice] = -1;
        }
        private int GrupoMaiorDiametro()
        {
            int indiceMaiorDiametro = -1;
            Double maiorDiametro = 0;
            Double diametro;
            if (tipoDiametro == 0)
            {

                for (int i = 0; i < agrupamento.Count; i++)
                {
                    if (diametros[i] > -1)
                    {
                        diametro = diametros[i];
                    }
                    else
                    {
                        diametro = VerificaDiametroCompleto((Dictionary<int, double[]>)agrupamento[i]);
                        diametros[i] = diametro;
                    }
                    if (diametro > maiorDiametro)
                    {
                        maiorDiametro = diametro;
                        indiceMaiorDiametro = i;
                    }
                }
                return indiceMaiorDiametro;
            }
            else if (tipoDiametro == 1)
            {
                for (int i = 0; i < agrupamento.Count; i++)
                {
                    if (diametros[i] > -1)
                    {
                        diametro = diametros[i];
                    }
                    else
                    {
                        diametro = VerificaDiametroMedio((Dictionary<int, double[]>)agrupamento[i]);
                        diametros[i] = diametro;
                    }
                    if (diametro > maiorDiametro)
                    {
                        maiorDiametro = diametro;
                        indiceMaiorDiametro = i;
                    }
                }
                return indiceMaiorDiametro;
            }
            else
            {
                for (int i = 0; i < agrupamento.Count; i++)
                {
                    if (diametros[i] > -1)
                    {
                        diametro = diametros[i];
                    }
                    else
                    {
                        AtualizaCentroide((Dictionary<int, double[]>)agrupamento[i]);
                        diametro = VerificaDiametroCentroide((Dictionary<int, double[]>)agrupamento[i]);
                        diametros[i] = diametro;
                    }
                    if (diametro > maiorDiametro)
                    {
                        maiorDiametro = diametro;
                        indiceMaiorDiametro = i;
                    }
                }
                return indiceMaiorDiametro;
            }

        }
        private double VerificaDiametroMedio(Dictionary<int, double[]> cluster)
        {
            double numeroPadroes = cluster.Count;
            numeroPadroes = numeroPadroes * (numeroPadroes - 1) / 2;
            Double diametro = 0;
            foreach (KeyValuePair<int, Double[]> padrao1 in cluster)
            {
                foreach (KeyValuePair<int, Double[]> padrao2 in cluster)
                {
                    if (padrao1.Key != padrao2.Key)
                    {
                        if (padrao1.Key < padrao2.Key)
                        {
                            diametro += matrizDissimilaridades[padrao1.Key,padrao2.Key];
                        }
                    }
                }
            }
            return diametro / numeroPadroes;
        }
        private double VerificaDiametroCentroide(Dictionary<int, double[]> cluster)
        {
            Distance distancia = new Distance();
            Double diametro = 0;
            foreach (KeyValuePair<int, Double[]> padrao in cluster)
            {
                if (padrao.Key != 0)
                {
                    diametro += distancia.euclidiana(cluster[padrao.Key], cluster[0]);
                }
            }
            cluster.Remove(0);
            return diametro / (cluster.Count);
        }
        private void AtualizaCentroide(Dictionary<int, Double[]> cluster)
        {
            double[] somaDosPadroes = new double[quantidadeAtributos];
            int padroesNoGrupo = cluster.Count;
            foreach (KeyValuePair<int, Double[]> padrao in cluster)
            {
                for (int j = 0; j < quantidadeAtributos; j++)
                {
                    somaDosPadroes[j] += padrao.Value[j];
                }
            }
            for (int i = 0; i < quantidadeAtributos; i++)
            {
                somaDosPadroes[i] = (somaDosPadroes[i] / padroesNoGrupo);
            }
            cluster.Add(0, somaDosPadroes);
        }
        private void RemovePadraoGrupo(int padrao)
        {
            grupo.Remove(padrao);
        }
        private void AdicionaPadraoEmTempG(int padrao)
        {
            tempG.Add(padrao, grupo[padrao]);
        }
        private void CriaGrupoInicial()
        {
            grupo = new Dictionary<int, Double[]>(quantidadePadroes);
            for (int i = 0; i < quantidadePadroes; i++)
            {
                Double[] padrao = new Double[quantidadeAtributos];
                for (int j = 0; j < quantidadeAtributos; j++)
                {
                    padrao[j] = padroes[i, j];
                }
                grupo.Add((i + 1), padrao);
            }
        }
        private void CalculaDistancias()
        {
            Distance Distancia = new Distance();
            matrizDissimilaridades = new double [quantidadePadroes+1,quantidadePadroes+1];
            for (int i = 1; i < quantidadePadroes; i++)
            {
                for (int j = i + 1; j <= quantidadePadroes; j++)
                {
                    Double valor = Distancia.euclidiana(grupo[i], grupo[j]);
                    matrizDissimilaridades[i,j]= valor;
                }
            }
        }
        private double VerificaDiametroCompleto(Dictionary<int, double[]> cluster)
        {
            Double diametro = 0;
            foreach (KeyValuePair<int, Double[]> padrao1 in cluster)
            {
                foreach (KeyValuePair<int, Double[]> padrao2 in cluster)
                {
                    if (padrao1.Key != padrao2.Key)
                    {
                        Double dissimilaridade = 0;
                        if (padrao1.Key < padrao2.Key)
                        {
                            dissimilaridade = matrizDissimilaridades[padrao1.Key,padrao2.Key];
                        }
                        if (dissimilaridade > diametro)
                        {
                            diametro = dissimilaridade;
                        }
                    }
                }
            }
            return diametro;

        }
        private double CalculaMedia(int key, Dictionary<int, double[]> grupo)
        {
            Double media = 0;
            int totalPadroes = 0;
            foreach (KeyValuePair<int, Double[]> pair in grupo)
            {
                if (pair.Key != key)
                {
                    if (key < pair.Key)
                    {
                        media += matrizDissimilaridades[key,pair.Key];
                    }
                    else
                    {
                        media += matrizDissimilaridades[pair.Key,key];
                    }
                    totalPadroes++;
                }
            }
            return (media / totalPadroes);
        }
    }
}
/*  for (int i = 0; i < agrupamento.Count; i++)
               {
                   Console.WriteLine("Grupo" + (i + 1));

                   foreach (KeyValuePair<String, Double[]> item in (Dictionary<string, double[]>)agrupamento[i])
                   {
                       foreach (var valor in item.Value)
                       {
                           Console.Write(valor);
                       }
                       Console.WriteLine();
                   }
               }
Console.WriteLine(indiceGrupoMaiorDiametro);
                    Console.ReadLine();

                    
                    Console.WriteLine("Grupo");
                    foreach (KeyValuePair<String, Double[]> item in grupo)
                    {
                        for (int i = 0; i< 4; i++)
                        {
                            Console.Write(item.Value[i]);
                        }

                    }
                    Console.ReadLine();//*/


