using System.Collections;

namespace DivCluster
{
    public class VerificaContraditorios
    {
        private string[] classe;
        private double[,] padroes;
        double[,] novosPadroes;
        string[] novasClasses;
        int linhas;
        int colunas;
        ArrayList conjuntoPadroes;
        ArrayList conjuntoClasses;
        public VerificaContraditorios(double[,] padroes, string[] classe)
        {
            this.padroes = padroes;
            this.classe = classe;
            linhas = padroes.GetLength(0);
            colunas = padroes.GetLength(1);
        }
        private void AtualizaPadroesClasses()
        {
            novosPadroes = new double[linhas, colunas];
            novasClasses = new string[linhas];
            for (int i = 0; i < linhas; i++)
            {
                double[] padrao = (double[])conjuntoPadroes[i];
                for (int j = 0; j < colunas; j++)
                {
                    novosPadroes[i, j] = padrao[j];
                }
                novasClasses[i] = (string)conjuntoClasses[i];
            }
        }

        private void VetorClasseParaArrayList()
        {
            conjuntoPadroes = new ArrayList(linhas);
            conjuntoClasses = new ArrayList(linhas);
            string classes;
            double[] padrao = new double[colunas];
            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    padrao[j] = padroes[i, j];
                }
                classes = classe[i];
                conjuntoPadroes.Add(padrao.Clone());
                conjuntoClasses.Add(classes.Clone());
            }
        }

        private void RemoveDuplicados()
        {
            for (int i = 0; i < linhas - 1; i++)
            {
                for (int j = i + 1; j < linhas; j++)
                {
                    int atributosIguais = 0;
                    double[] padrao = (double[])conjuntoPadroes[i];
                    double[] padrao2 = (double[])conjuntoPadroes[j];
                    for (int k = 0; k < colunas; k++)
                    {
                        if (padrao[k] == padrao2[k])
                        {
                            atributosIguais++;
                        }
                    }
                    if (atributosIguais == colunas)
                    {
                        if ((string)conjuntoClasses[j] != (string)conjuntoClasses[i])
                        {
                            conjuntoPadroes.RemoveAt(i);
                            conjuntoPadroes.RemoveAt(j - 1);
                            conjuntoClasses.RemoveAt(i);
                            conjuntoClasses.RemoveAt(j - 1);
                            j = i;
                            linhas = linhas - 2;
                        }
                    }
                }
            }
        }

        public void Controle(out double[,] padroes, out string[] classe)
        {
            VetorClasseParaArrayList();
            RemoveDuplicados();
            AtualizaPadroesClasses();
            classe = novasClasses;
            padroes = novosPadroes;
        }
    }
}
