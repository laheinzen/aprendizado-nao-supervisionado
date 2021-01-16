using System;
using System.Collections.Generic;
using System.IO;

namespace TrabalhoFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //carrega as amostras/objetos

                //var samples = loadStaticData();

                var samples = loadDataFromFile($"..\\..\\..\\csv\\DataHotDogs.csv");

                //Verificando 

                Console.WriteLine("Dados estatíticos");
                foreach (var sample in samples)
                {
                    Console.WriteLine(sample);
                }

                // Não defino mais os centroides manualmente
                ////lista os k centroides
                //var centroids = new List<Sample>();
                //centroids.Add(samples[0].CloneDataOnly("1"));
                //centroids.Add(samples[2].CloneDataOnly("2"));

                //Console.WriteLine("Verificando escolha dos centroides");
                //foreach (var centroid in centroids)
                //{
                //    Console.WriteLine(centroid.ToString());
                //}

                var kmeans = new KMeans(samples: samples, clusters: 3);
                var centroids = kmeans.Find();

                Console.WriteLine("Samples final");
                foreach (var sample in kmeans.Samples)
                {
                    Console.WriteLine(sample.ToString());
                }

                Console.WriteLine("Centroids finais");
                foreach (var centroid in centroids)
                {
                    Console.WriteLine(centroid);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro na rotina {e.Message} com stack Trace {e.StackTrace}");
            }
            Console.Read();
        }

        private static List<Sample> loadStaticData()
        {
            var result = new List<Sample>();

            double[][] staticData = new double[][]
            { 
                //Deve haver um jeito mais simples de inicializar, mas meus conhecimentos em C# não chegam até lá
                new double[] { 1, 1 } ,
                new double[] { 2, 1 } ,
                new double[] { 3, 2 } ,
                new double[] { 2, 4.5 },
                new double[] { 1, 5 } ,
                new double[] { 3, 7 } ,
                new double[] { 6, 5 }
            };

            int label = 0;
            foreach (var data in staticData)
            {
                label++;
                var newSample = new Sample(data, label.ToString());
                result.Add(newSample);
            }

            return result;
        }

        private static List<Sample> loadDataFromFile(String fileName, int labelColumnIndex = 0, bool hasHeader = true, char separator = ',')         {
            var result = new List<Sample>();

            using (var reader = new StreamReader(fileName))
            {
                if (hasHeader)
                {
                    reader.ReadLine(); //Discarta a primeira linha
                }
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Trim(); //Lê e remove os espaços
                    bool isLabel = false;
                    if (line.Length > 0) //Pode ser que haja linhas vazias
                    {
                        var row = line.Split(separator);
                        var data = new double[row.Length - 1]; //Não conta o label
                        var label = "";
                        var dataColumn = 0;
                        for (int column = 0; column < row.Length; column++)
                        {
                            isLabel = column == labelColumnIndex;
                            if (isLabel)
                            {
                                label = row[column];
                            }
                            else
                            {
                                data[dataColumn] = Convert.ToDouble(row[column]);
                                dataColumn++;
                            }
                        }
                        //Cria o sample
                        var newSample = new Sample(data, label);
                        //Adciona aos resultados
                        result.Add(newSample);
                    }
                }
            }

            return result;
        }
    }
}
