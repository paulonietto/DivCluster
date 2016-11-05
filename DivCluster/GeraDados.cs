using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivCluster
{
    public class GeraDados
    {
        private int atributoMinX;
        private int quantidadePadroes;
        private int atributoMinY;
        private int atributoMaxX;
        private int atributoMaxY;
        public GeraDados(int quantidadePadroes, int atributoMinX, int atributoMaxX, int atributoMinY, int atributoMaxY)
        {
            this.quantidadePadroes = quantidadePadroes;
            this.atributoMinX = atributoMinX;
            this.atributoMinY = atributoMinY;
            this.atributoMaxX = atributoMaxX;
            this.atributoMaxY = atributoMaxY;
        }
        public double[,] GeradorDeDadosCirculo()
        {
            Distance distancia = new Distance();
            double raio = atributoMaxX - atributoMinX;
            raio = raio / 2;
            double x = atributoMaxX + atributoMinX;
            x = x / 2;
            double y = atributoMaxY + atributoMinY;
            y = y / 2;
            double[] vetorRaio = new double[2] { x, y };
            double[] novoPadrao = new double[2];
            double[,] padroes = new double[quantidadePadroes, 2];
            Random random = new Random();
            ArrayList listaPadroes = new ArrayList(quantidadePadroes);
            int atributos = 0;
            int diminuiDensidade = random.Next(2, 8);
            diminuiDensidade = (quantidadePadroes / diminuiDensidade);
            double diminuiRaio = random.Next(5, 9);
            diminuiRaio = diminuiRaio / 10;
            System.Threading.Thread.Sleep(500);
            for (int i = 0; i < quantidadePadroes; i++)
            {
                atributos++;
                if (diminuiDensidade < atributos)
                {
                    diminuiDensidade = diminuiDensidade * 2;
                    raio = raio * diminuiRaio;
                }
                int atributoX = random.Next(atributoMinX, atributoMaxX);
                int atributoY = random.Next(atributoMinY, atributoMaxY);
                padroes[i, 0] = random.NextDouble() + atributoX;
                padroes[i, 1] = random.NextDouble() + atributoY;
                novoPadrao[0] = padroes[i, 0];
                novoPadrao[1] = padroes[i, 1];
                double resultado = distancia.euclidiana(novoPadrao, vetorRaio);
                while (listaPadroes.Contains(padroes[i, 0] + "," + padroes[i, 1]) || resultado > raio)
                {
                    atributoX = random.Next(atributoMinX, atributoMaxX);
                    atributoY = random.Next(atributoMinY, atributoMaxY);
                    padroes[i, 0] = random.NextDouble() + atributoX;
                    padroes[i, 1] = random.NextDouble() + atributoY;
                    novoPadrao[0] = padroes[i, 0];
                    novoPadrao[1] = padroes[i, 1];
                    resultado = distancia.euclidiana(novoPadrao, vetorRaio);
                }
                listaPadroes.Add(padroes[i, 0] + "," + padroes[i, 1]);
            }
            return padroes;
        }
        public double[,] GeradorDeDadosQuadrado()
        {
            double[,] padroes = new double[quantidadePadroes, 2];
            Random random = new Random();
            ArrayList listaPadroes = new ArrayList(quantidadePadroes);
            for (int i = 0; i < quantidadePadroes; i++)
            {
                int atributoX = random.Next(atributoMinX, atributoMaxX);
                int atributoY = random.Next(atributoMinY, atributoMaxY);
                padroes[i, 0] = random.NextDouble() + atributoX;
                padroes[i, 1] = random.NextDouble() + atributoY;
                if (!listaPadroes.Contains(padroes[i, 0] + "," + padroes[i, 1]))
                {
                    listaPadroes.Add(padroes[i, 0] + "," + padroes[i, 1]);
                }
                else
                {
                    while (listaPadroes.Contains(padroes[i, 0] + "," + padroes[i, 1]))
                    {
                        padroes[i, 0] = random.NextDouble() + atributoX;
                        padroes[i, 1] = random.NextDouble() + atributoY;
                    }
                    listaPadroes.Add(padroes[i, 0] + "," + padroes[i, 1]);
                }
            }
            return padroes;
        }

    }
}
/* public double[,] GeradorDeDados()
        {
            double[,] padroes = new double[quantidadePadroes, 2];
            int padroesPorGrupo;
            double teste1 = quantidadePadroes;
            double resultado = quantidadePadroes;
               resultado= resultado / quantidadeGrupos;
            if (resultado % 2 == 0)
            {
                padroesPorGrupo = (quantidadePadroes / quantidadeGrupos);
            }
            else
            {
                padroesPorGrupo = (quantidadePadroes / quantidadeGrupos) + 1;
            }
            Random random = new Random();
            int minX = 1;
            int maxX = padroesPorGrupo;
            int minY = 1;
            int maxY = padroesPorGrupo;
            int pulaGrupo = padroesPorGrupo;
            for (int i = 0; i < gruposDensos; i++)
            {

            }
            ArrayList listaPadroes = new ArrayList(padroesPorGrupo);
            for (int i = 0; i < quantidadePadroes; i++)
            {
                padroes[i, 0] = random.Next(minX, (maxX + 1));
                padroes[i, 1] = random.Next(minY, (maxY + 1));
                if (!listaPadroes.Contains(padroes[i, 0] + "," + padroes[i, 1]))
                {
                    listaPadroes.Add(padroes[i, 0] + "," + padroes[i, 1]);
                }
                else
                {
                    while (listaPadroes.Contains(padroes[i, 0] + "," + padroes[i, 1]))
                    {
                        padroes[i, 0] = random.Next(minX, (maxX + 1));
                        padroes[i, 1] = random.Next(minY, (maxY + 1));
                    }
                    listaPadroes.Add(padroes[i, 0] + "," + padroes[i, 1]);
                }
                if (i == (pulaGrupo - 1))
                {
                    listaPadroes.Clear();
                    pulaGrupo += padroesPorGrupo;
                    minX += padroesPorGrupo;
                    maxX += padroesPorGrupo;
                    if (maxY != padroesPorGrupo)
                    {
                        maxY = padroesPorGrupo;
                        minY = 1;
                    }
                    else
                    {
                        minY += (padroesPorGrupo + (padroesPorGrupo/2));
                        maxY = (minY + padroesPorGrupo);
                    }
                }
            }
            return padroes;
        }

    public double[,] GeradorDeDados()
         {
             int minY = 1;
             int minX = 1;
             int padroesPorGrupo = (quantidadePadroes / quantidadeGrupos);
             int maxX = padroesPorGrupo;
             int maxY = padroesPorGrupo;
             Random random = new Random();
             double[,] padroes = new double[quantidadePadroes, 2];
             for (int i = 1; i <= quantidadeGrupos; i++)
             {
                 for (int j = 0; j < padroesPorGrupo; j++)
                 {
                     int numero = random.Next(minX, maxX + 1);
                     int numero2 = random.Next(minY, maxY + 1);
                 }
                 minX += padroesPorGrupo;
                 maxX += padroesPorGrupo;
                 if (maxY != padroesPorGrupo)
                 {
                     maxY = padroesPorGrupo;
                     minY = 1;
                 }
                 else
                 {
                     minY += padroesPorGrupo;
                     maxY = (padroesPorGrupo * 2);
                 }

             }
             return padroes;
         }*/
