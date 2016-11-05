using System;
using System.Collections;
using System.Collections.Generic;

namespace DivCluster
{
    public class DIANACentroide
    {
        ArrayList agrupamento;
        private Double[,] padroes;
        private int totalGrupos;
        private Dictionary<int, Double[]> grupo;
        private Dictionary<int, Double[]> tempG;
        private int quantidadePadroes;
        private int quantidadeAtributos;
        Distance distancia;
        private int tipoDiametro;
        private double[] diametros;
        private double [,] matrizDissimilaridades;
        public DIANACentroide(Double[,] padroes, int k, int tipoDiametro)
        {
            this.padroes = padroes;
            this.totalGrupos = k;
            this.tipoDiametro = tipoDiametro;
            quantidadePadroes = padroes.GetLength(0);
            quantidadeAtributos = padroes.GetLength(1);
        }
        public ArrayList Agrupa()
        {
            agrupamento = new ArrayList(totalGrupos);
            diametros = new double[totalGrupos];
            NegativaDiametro(0);
            //CriaGrupo 
            CriaGrupoInicial();
            if (tipoDiametro != 2)
            {
                CalculaDistancias();
            }
            AtualizaCentroide(grupo);
            agrupamento.Add(grupo);
            if (totalGrupos == 1)
            {
                return agrupamento;
            }
            tempG = new Dictionary<int, Double[]>(quantidadePadroes);
            distancia = new Distance();
            //inicia o repeat
            for (int quantidadeGrupos = 1; quantidadeGrupos < totalGrupos; quantidadeGrupos++)
            {
                // Busca padrao com maior distancia
                int maiorDistancia = BuscaMaiorDistancia(grupo);

                //cria padrao com maior distancia em tempG
                AdicionaPadraoEmTempG(maiorDistancia);

                // remove padrao com maior distancia do grupo
                RemovePadraoGrupo(maiorDistancia);

                //segundo repeat
                PadroesMaisProximoTempG();

                //insere os grupos no agrupamento
                //   InsereGrupoNoAgrupamento(grupo);
                InsereGrupoNoAgrupamento(tempG);


                if ((quantidadeGrupos + 1) != totalGrupos)
                {
                    // grupo.Clear();
                    tempG.Clear();

                    //busca grupo com maior diametro
                    int indiceGrupoMaiorDiametro = GrupoMaiorDiametro();
                    grupo = (Dictionary<int, double[]>)agrupamento[indiceGrupoMaiorDiametro];
                    NegativaDiametro(indiceGrupoMaiorDiametro);
                }
            }
            //     ImprimeAgrupamento(agrupamento);

            return agrupamento;

        }
        private void NegativaDiametro(int indice)
        {
            diametros[indice] = -1;
        }
        private void CriaGrupoInicial()
        {
            grupo = new Dictionary<int, Double[]>(quantidadePadroes + 1);
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
        private void AtualizaCentroide(Dictionary<int, Double[]> grupo)
        {
            double[] somaDosPadroes = new double[quantidadeAtributos];
            int padroesNoGrupo = grupo.Count;
            foreach (KeyValuePair<int, Double[]> padrao in grupo)
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
            grupo.Add(0, somaDosPadroes);
        }
        private int BuscaMaiorDistancia(Dictionary<int, double[]> grupo)
        {
            Double maiorDissimilaridade = 0;
            int indice = int.MinValue;
            foreach (KeyValuePair<int, Double[]> padrao in grupo)
            {
                if (padrao.Key != 0)
                {
                    Double valor = distancia.euclidiana(grupo[padrao.Key], grupo[0]);
                    if (valor > maiorDissimilaridade)
                    {
                        maiorDissimilaridade = valor;
                        indice = padrao.Key;
                    }
                }
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
        private void RemovePadraoGrupo(int padrao)
        {
            grupo.Remove(padrao);
            grupo.Remove(0);
            AtualizaCentroide(grupo);
        }
        private void AdicionaPadraoEmTempG(int padrao)
        {
            tempG.Add(padrao, grupo[padrao]);
            if (tempG.Count > 2)
            {
                tempG.Remove(0);
            }
            AtualizaCentroide(tempG);
        }
        private double CalculaDissimilaridade(double[] padrao, Dictionary<int, double[]> grupo)
        {
            Double valor = distancia.euclidiana(padrao, grupo[0]);
            return valor;
        }
        private void PadroesMaisProximoTempG()
        {
            bool valoresPositivos = true;
            while (valoresPositivos)
            {
                valoresPositivos = false;
                Double dissimilaridadeIntra = 0;
                Double dissimilaridadeInter = 0;
                Double maiorValor = 0;
               int padraoMaisDissimilar = int.MinValue;
                foreach (KeyValuePair<int, Double[]> pair in grupo)
                {
                    if (pair.Key != 0)
                    {
                        dissimilaridadeIntra = CalculaDissimilaridade(pair.Value, grupo);
                        dissimilaridadeInter = CalculaDissimilaridade(pair.Value, tempG);
                        if ((dissimilaridadeIntra - dissimilaridadeInter) > 0)
                        {
                            if ((dissimilaridadeIntra - dissimilaridadeInter) > maiorValor)
                            {
                                padraoMaisDissimilar = pair.Key;
                                maiorValor = (dissimilaridadeIntra - dissimilaridadeInter);
                            }
                        }
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
        private double VerificaDiametroCentroide(Dictionary<int, double[]> grupo)
        {
            Double diametro = 0;
            foreach (KeyValuePair<int, Double[]> padrao in grupo)
            {
                if (padrao.Key != 0)
                {
                    diametro += distancia.euclidiana(grupo[padrao.Key], grupo[0]);
                }
            }
            return diametro / (grupo.Count - 1);
        }
        private double VerificaDiametroCompleto(Dictionary<int, double[]> cluster)
        {
            Double diametro = 0;
            foreach (KeyValuePair<int, Double[]> padrao1 in cluster)
            {
                foreach (KeyValuePair<int, Double[]> padrao2 in cluster)
                {
                    if (padrao1.Key != padrao2.Key && padrao1.Key != 0 && padrao2.Key != 0)
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
        private double VerificaDiametroMedio(Dictionary<int, double[]> cluster)
        {
            double numeroPadroes = cluster.Count - 1;
            numeroPadroes = numeroPadroes * (numeroPadroes - 1) / 2;
            Double diametro = 0;
            foreach (KeyValuePair<int, Double[]> padrao1 in cluster)
            {
                foreach (KeyValuePair<int, Double[]> padrao2 in cluster)
                {
                    if (padrao1.Key != padrao2.Key && padrao1.Key != 0 && padrao2.Key != 0)
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
        private void CalculaDistancias()
        {
            Distance Distancia = new Distance();
            matrizDissimilaridades = new double [quantidadePadroes +1, quantidadePadroes+1];
            for (int i = 1; i < quantidadePadroes; i++)
            {
                for (int j = i + 1; j <= quantidadePadroes; j++)
                {
                    Double valor = Distancia.euclidiana(grupo[i], grupo[j]);
                    matrizDissimilaridades[i,j]= valor;
                }
            }
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
                    Console.ReadLine();//
                    
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
    */
