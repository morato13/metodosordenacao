using System;
using System.Diagnostics;

namespace tp1
{
    class TP_Ordenacao
    {
        static int[] decrescente(int tamanho)
        {
            int[] vetor = new int[tamanho];

            for (int z = 0; z < vetor.Length; z++)
            {

                vetor[z] = tamanho;
                tamanho = tamanho - 1;

            }
            return vetor;

        }


        static int[] vetorcrescente(int tamanho)
        {
            int[] vetor = new int[tamanho];
            for (int i = 0; i < vetor.Length; i++)
            {
                vetor[i] = i;

            }

            return vetor;
        }

        static int[] vetorrandomico(int tamanho)
        {
            int[] vetor = new int[tamanho];
            Random aleatorio = new Random();
            for (int j = 0; j < vetor.Length; j++)
            {
                vetor[j] = aleatorio.Next(0, 10000); 
            }
            return vetor;

        }

        private static int[] SelectionSort(int[] vetor)

        {

            int menor, aux;

            for (int i = 0; i < vetor.Length - 1; i++)

            {

                menor = i;



                for (int j = i + 1; j < vetor.Length; j++)

                    if (vetor[j] < vetor[menor])

                        menor = j;

                if (menor != i)

                {

                    aux = vetor[menor];

                    vetor[menor] = vetor[i];

                    vetor[i] = aux;
                }
            }
            return vetor;
        }

        void insertion_sort(int[] vetor, int tamanhoVetor)
        {

            int escolhido, j;

            for (int i = 1; i < tamanhoVetor; i++)
            {
                escolhido = vetor[i];
                j = i - 1;

                while ((j >= 0) && (vetor[j] > escolhido))
                {
                    vetor[j + 1] = vetor[j];
                    j--;
                }

                vetor[j + 1] = escolhido;
            }


        }

        static int[] bubbleSort(int[] vetor)
        {

            int tamanho = vetor.Length;
            int comparacoes = 0;
            int trocas = 0;

            for (int i = tamanho - 1; i >= 1; i--)

            {

                for (int j = 0; j < i; j++)

                {

                    comparacoes++;

                    if (vetor[j] > vetor[j + 1])

                    {

                        int aux = vetor[j];

                        vetor[j] = vetor[j + 1];

                        vetor[j + 1] = aux;

                        trocas++;

                    }

                }

            }

            return vetor;

        }

        static int[] QuickSort(int[] vetor)

        {
            int inicio = 0;
            int fim = vetor.Length - 1;
            QuickSort(vetor, inicio, fim);
            return vetor;
        }
        static void QuickSort(int[] vetor, int inicio, int fim)

        {
            if (inicio < fim)
            {
                int p = vetor[inicio];
                int i = inicio + 1;
                int f = fim;
                while (i <= f)
                {
                    if (vetor[i] <= p)
                    {
                        i++;
                    }
                    else if (p < vetor[f])
                    {
                        f--;
                    }
                    else
                    {
                        int troca = vetor[i];
                        vetor[i] = vetor[f];
                        vetor[f] = troca;
                        i++;
                        f--;
                    }
                }
                vetor[inicio] = vetor[f];
                vetor[f] = p;
                QuickSort(vetor, inicio, f - 1);
                QuickSort(vetor, f + 1, fim);
            }
        }


         void MergeSort(int[] vetor, int ini, int meio, int fim, int[] vetAux)
        {
            int esq = ini;
            int dir = meio;
            for (int i = ini; i < fim; ++i)
            {
                if ((esq < meio) && ((dir >= fim) || (vetor[esq] < vetor[dir])))
                {
                    vetAux[i] = vetor[esq];
                    ++esq;
                }
                else
                {
                    vetAux[i] = vetor[dir];
                    ++dir;
                }
            }

            for (int i = ini; i < fim; ++i)
            {
                vetor[i] = vetAux[i];
            }
        }

        void MergeSort(int[] vetor, int inicio, int fim, int[] vetorAux)
        {
            if ((fim - inicio) < 2) return;

            int meio = ((inicio + fim) / 2);
            MergeSort(vetor, inicio, meio, vetorAux);
            MergeSort(vetor, meio, fim, vetorAux);
            MergeSort(vetor, inicio, meio, fim, vetorAux);
        }

        void MergeSort(int[] vetor, int tamanho)
        {
            int[] vetorAux = new int[tamanho];
            MergeSort(vetor, 0, tamanho, vetorAux);
        }
                     

        static void Main(string[] args)
        {


            {
                // *** Merge Sort ***//
                Console.WriteLine("Ordenardo pelo Merge sort");

                Stopwatch temp_decrescente_merge = new Stopwatch();
                Stopwatch temp_crescente_merge = new Stopwatch();
                Stopwatch temp_randon_merge = new Stopwatch();



                int[] d_merge = new int[10000];
                d_merge = decrescente(10000);

                temp_decrescente_merge.Start();

                TP_Ordenacao ordena_merge = new TP_Ordenacao();
                ordena_merge.MergeSort(d_merge, 10000);
                temp_decrescente_merge.Stop();
                TimeSpan tempo_merge = temp_decrescente_merge.Elapsed;


                //******

                int[] c_merge = new int[10000];
                c_merge = vetorcrescente(10000);

                temp_crescente_merge.Start();
                TP_Ordenacao ordena_crescente_merge = new TP_Ordenacao();
                ordena_crescente_merge.MergeSort(c_merge, 10000);
                temp_crescente_merge.Stop();
                TimeSpan tempo_crescente_merge = temp_crescente_merge.Elapsed;


                //******
                int[] r_merge = new int[10000];
                r_merge = vetorrandomico(10000);


                temp_randon_merge.Start();
                TP_Ordenacao ordena_randon_merge = new TP_Ordenacao();
                ordena_randon_merge.MergeSort(r_merge, 10000);
                temp_randon_merge.Stop();
                TimeSpan tempo_randon_merge = temp_randon_merge.Elapsed;


                Console.WriteLine();
                Console.WriteLine("vetor decrescente: " + tempo_merge);
                Console.WriteLine("vetor crescente: " + tempo_crescente_merge);
                Console.WriteLine("vetor randomico: " + tempo_randon_merge);
                Console.WriteLine("Aperte ENTER para continuar");
                Console.ReadKey();
                Console.Clear();



                // ** Insertion Sort ** //
                Console.WriteLine("Ordenardo pelo insertion sort");

                Stopwatch temp_crescente_insertion = new Stopwatch();
                Stopwatch temp_decrescente_insertion = new Stopwatch();
                Stopwatch temp_randon_insertion = new Stopwatch();


                int[] d_in = new int[10000]; 
                d_in = decrescente(10000); 

                temp_crescente_insertion.Start();

                TP_Ordenacao insertion = new TP_Ordenacao();
                insertion.insertion_sort(d_in, 10000);
                temp_crescente_insertion.Stop();
                TimeSpan tempo_insertion = temp_decrescente_insertion.Elapsed;

                // ****** 

                int[] c_in= new int[10000]; 
                c_in = vetorcrescente(10000); 

                Stopwatch time = new Stopwatch();
                temp_crescente_insertion.Start();
                TP_Ordenacao ordena_crescente_insertion = new TP_Ordenacao(); 
                ordena_crescente_insertion.insertion_sort(c_in, 10000);
                 temp_crescente_insertion.Stop();
                TimeSpan tempo_crescente_insertion = temp_crescente_insertion.Elapsed;

                //*******


                int[] r_in = new int[10000]; 
                r_in = vetorrandomico(10000); 


                temp_randon_insertion.Start();
                TP_Ordenacao ordena_randon_insertion = new TP_Ordenacao();
                ordena_randon_insertion.insertion_sort(r_in, 10000);
                temp_randon_insertion.Stop();
                TimeSpan tempo_randon_insertion = temp_randon_insertion.Elapsed;


                Console.WriteLine("vetor decrescente: " + tempo_insertion);
                Console.WriteLine("vetor crescente: " + tempo_crescente_insertion);
                Console.WriteLine("vetor randomico: " + tempo_randon_insertion);
                Console.WriteLine("Aperte ENTER para continuar");
                Console.ReadKey();
                Console.Clear();


                // *** Bubble Sort ***//

                Console.WriteLine("Ordenardo pelo Bubble sort");

                Stopwatch temp_crescente_bubble = new Stopwatch();
                Stopwatch temp_decrescente_bubble = new Stopwatch();
                Stopwatch temp_randon_bubble = new Stopwatch();

                int[] d_bu = new int[10000];
                d_bu = decrescente(10000);

                temp_decrescente_bubble.Start();
                bubbleSort(d_bu);
                temp_decrescente_bubble.Stop();
                TimeSpan tempo_bubble = temp_decrescente_bubble.Elapsed;
              

                //**********

                int[] c_bu = new int[10000]; 
                c_bu = vetorcrescente(10000);


                temp_crescente_bubble.Start();
                bubbleSort(c_bu);
                 temp_crescente_bubble.Stop();
                TimeSpan tempo_crescente_bubble = temp_crescente_bubble.Elapsed;


                //*******
                int[] r_bu = new int[10000];
                r_bu = vetorrandomico(10000);

                temp_randon_bubble.Start();
                bubbleSort(r_bu);
                temp_randon_bubble.Stop();
                TimeSpan tempo_randon_bubble = temp_randon_bubble.Elapsed;

                Console.WriteLine("vetor decrescente: " + tempo_bubble);
                Console.WriteLine("vetor crescente: " + tempo_crescente_bubble);
                Console.WriteLine("vetor randomico: " + tempo_randon_bubble);
                Console.WriteLine("Aperte ENTER para continuar");
                Console.ReadKey();
                Console.Clear();


                // *** Quick Sort ***//
                Console.WriteLine("Ordenardo pelo Quick sort");

                Stopwatch tempo_decrescente_quick = new Stopwatch();
                Stopwatch temp_crescente_quick = new Stopwatch();
                Stopwatch temp_randon_quick = new Stopwatch();

                int[] de_quick = new int[10000];
                de_quick = decrescente(10000);

                tempo_decrescente_quick.Start();
                QuickSort(de_quick);
                tempo_decrescente_quick.Stop();
                TimeSpan tempo_quick = tempo_decrescente_quick.Elapsed;

                //******
                int[] c_quick = new int[10000]; 
                c_quick = vetorcrescente(10000); 

                 temp_crescente_quick.Start();
                QuickSort(c_quick);
                temp_crescente_quick.Stop();
                TimeSpan tempo_crescente_quick = temp_crescente_quick.Elapsed;


                //********
                int[] r_quick = new int[10000];
                r_quick = vetorrandomico(10000);


                temp_randon_quick.Start();
                QuickSort(r_quick);
                temp_randon_quick.Stop();
                TimeSpan tempo_randon_quick = temp_randon_quick.Elapsed;

                Console.WriteLine("vetor decrescente: " + tempo_quick);
                Console.WriteLine("vetor crescente: " + tempo_crescente_quick);
                Console.WriteLine("vetor randomico: " + tempo_randon_quick);
                Console.WriteLine("Aperte ENTER para continuar");
                Console.ReadKey();
                Console.Clear();


                // *** Selection Sort ***//
                Console.WriteLine("Ordenardo pelo Selection sort");

                Stopwatch temp_crescente_selection = new Stopwatch();
                Stopwatch temp_decrescente_selection = new Stopwatch();
                Stopwatch temp_randonselection = new Stopwatch();


                int[] d_se = new int[10000];
                d_se = decrescente(10000);

                temp_decrescente_selection.Start();
                SelectionSort(d_se);
                temp_decrescente_selection.Stop();
                TimeSpan tempo_selection = temp_decrescente_selection.Elapsed;


                // ******

                int[] c_se = new int[10000];
                c_se = vetorcrescente(10000);

                temp_crescente_selection.Start();

                SelectionSort(c_se);
                temp_crescente_selection.Stop();
                TimeSpan tempo_crescente_selection = temp_crescente_selection.Elapsed;


                //*******
                int[] r_se = new int[10000];
                r_se = vetorrandomico(10000);

                temp_randonselection.Start();
                SelectionSort(r_se);
                temp_randonselection.Stop();
                TimeSpan tempo_randon_selection = temp_randonselection.Elapsed;


                Console.WriteLine();
                Console.WriteLine("vetor decrescente: " + tempo_selection);
                Console.WriteLine("vetor crescente: " + tempo_crescente_selection);
                Console.WriteLine("vetor randomico: " + tempo_randon_selection);
                Console.WriteLine("Aperte ENTER para continuar");
                Console.ReadKey();
                Console.Clear();



            }

        }
    }
}