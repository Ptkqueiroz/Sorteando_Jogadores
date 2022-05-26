using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sorteando_Jogadores
{
    class Program
    {
        static void Main(string[] args)
        {
            /*SOLICITACAO AO USUARIO*/

            Console.WriteLine("Quantos jogadores terá ?");
            int totalJogadores;

            while (!int.TryParse(Console.ReadLine(), out totalJogadores))
            {
                Console.WriteLine("Insira apenas números");
                Console.WriteLine("Quantos jogadores terá ?");
            }                 
            
            Console.WriteLine("Serão quantos na linha ?");
            int totalLinha;

            while (!int.TryParse(Console.ReadLine(), out totalLinha))
            {
                Console.WriteLine("Insira apenas números");
                Console.WriteLine("Serão quantos na linha ?");
            }

            // PROXIMOS
            int proximo = totalJogadores % totalLinha;

            if (proximo >0)
            {
               Console.WriteLine($"Terá um total de {proximo}  proximos");
            }

            // TOTAL TIMES
            int totalTimes = totalJogadores / totalLinha;

           
            // CRIAÇÃO DOS TIMES
            List<string> times = new List<string>();

            for (int i = 1; i <= totalTimes; i++)
            {
                
                times.Add($"Time {i}");
            }

           Console.WriteLine($"Tera um total de : {totalTimes} times");

            // LISTA DE JOGADORES
            List<string> listaDosCraques = new List<string>();

            for (int i = 1; i <= totalJogadores; i++)
            {
                Console.WriteLine($"Informe o nome do {i}° jogador");
                string nomeDosCraques = Console.ReadLine();
                listaDosCraques.Add(nomeDosCraques);

            }

            ArrayList sorteados = new ArrayList();

            //PROXIMOS
                if (proximo > 0)
                {
                    while (proximo > 0)
                    {
                        Random prox = new Random();
                        int proximos = prox.Next(listaDosCraques.Count);
                        sorteados.Add("Proximo: " + listaDosCraques[proximos]);
                        listaDosCraques.RemoveAt(proximos);
                        proximo = --proximo;

                    }
                    
                }
           
            // SORTEIO
            while (listaDosCraques.Count > 0) 
            {
                         
                Random r = new Random();
                int jogadorSelecionado = r.Next(listaDosCraques.Count);
                

                Random r2 = new Random();
                int timeSelecionado = r2.Next(times.Count);

                int cont1 = 0;
                int cont2 = 0;

                if (times[timeSelecionado] == "Time 1")
                {
                    if (cont1 <= totalLinha)
                    {
                        sorteados.Add(times[timeSelecionado] + listaDosCraques[jogadorSelecionado]);
                        cont1++;
                    }
                    else
                    {
                        times[timeSelecionado] = "Time 2";
                        sorteados.Add(times[timeSelecionado] + listaDosCraques[jogadorSelecionado]);
                        cont2++;

                    }
                }
                if (times[timeSelecionado] == "Time 2")
                {
                    if (cont2 <= totalLinha)
                    {
                        sorteados.Add(times[timeSelecionado] + listaDosCraques[jogadorSelecionado]);
                        cont2++;
                    }
                    else
                    {
                        times[timeSelecionado] = "Time 1";
                        sorteados.Add(times[timeSelecionado] + listaDosCraques[jogadorSelecionado]);
                        cont1++;
                    }
                }
                
                
                listaDosCraques.RemoveAt(jogadorSelecionado);


            };
                sorteados.Sort();
                
                foreach (var item in sorteados)
                {   
                    Console.WriteLine($"Time é formador por :  {item} ");
                }

           


        }

    }
}
