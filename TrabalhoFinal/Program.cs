using System;
using System.Collections.Generic;

namespace TrabalhoFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            //carrega as amostras/objetos
            var samples = loadStaticData();

            //Verificando 

            foreach (var sample in samples)
            {
                Console.WriteLine(sample);
            }
            
            //lista os k centroides
            var centroids = new List<Sample>();
            centroids.Add(samples[0].CloneDataOnly("1"));
            centroids.Add(samples[2].CloneDataOnly("2"));

            Console.WriteLine("Verificando escolha dos centroides"); 

            //Verificando que estamos no caminho certo
            foreach (var centroid in centroids){
                Console.WriteLine(centroid.ToString());
            }

            var kmeans = new KMeans(samples: samples, clusters: 3);
            kmeans.Find(centroids);

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
    }
}
