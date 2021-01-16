using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoFinal
{
    class KMeans
    {
        public List<Sample> Samples{ get; }

        public int K { get; }

        public KMeans(List<Sample> samples, int clusters)
        {

            this.Samples = samples;
            this.K = K;

        }


        //Calcula o k-means, efetivamente
        public List<Sample> Find(List<Sample> centroids = null)
        {
            var result = new List<Sample>();
            if (centroids is null)
            {
                centroids = new List<Sample>();
                SetRandomCentroids(centroids);
            }

            //Clonando a lista de centroides para poder verificar se houve movimentação dos centroids
            var previousCentroids = new List<Sample>();
            foreach (var centroid in centroids)
            {
                previousCentroids.Add(centroid.Clone());
            }

            foreach (var sample in Samples)
            {
                FindAndSetNearestCentroidFor(sample, centroids);
            }

            centroids = GetRecenteredCentroids(centroids);

            var centroidsMoved = CentroidsMoved(centroids, previousCentroids);

            if (centroidsMoved)
            {
                result = Find(centroids);
            }
            else {
                result = centroids;

            } 

            return result;
        }

        private bool CentroidsMoved(List<Sample> centroids, List<Sample> previousCentroids)
        {
            //Varre e verifica se tem alguma distancia maior que zero
            for (int i = 0; i < centroids.Count; i++)
            {
                if (centroids[i].EuclidianDistanceFrom(previousCentroids[i]) > 0 ){
                    return true;
                }
            }

            return false;
        }

        private List<Sample> GetRecenteredCentroids(List<Sample> centroids)
        {
            var result = new List<Sample>();
            //Convertendo de lista para dicionário
            var indexedCentroids = new Dictionary<string, Sample>();
            foreach (var centroid in centroids)
            {
                //Clonando para não ficar mexendo no objeto em si
                var clonedCentroid = centroid.Clone();
                //Zeradno para ser usado na soma do proximo foreach
                clonedCentroid.ResetData();
                indexedCentroids[centroid.Label] = clonedCentroid;
            }

            foreach (var sample in Samples)
            {
                var centroid = indexedCentroids[sample.Label];
                //Adicionando dados no centroid
                centroid.SumData(sample.Data);
            }

            //Calcula a média e atribui aos novosntroids = new List<Sample>();
            foreach (var centroid in indexedCentroids.Values)
            {
                centroid.ApplyDataMean();
                result.Add(centroid);
            }

            return result;

        }

        private void FindAndSetNearestCentroidFor(Sample sample, List<Sample> centroids)
        {
            var shortestDistance = double.MaxValue;
            foreach (var centroid in centroids)
            {
                var distance = sample.EuclidianDistanceFrom(centroid);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    sample.Label = centroid.Label;
                }
            }
        }

        private void  SetRandomCentroids(List<Sample> centroids)
        {
            var random = new Random();
            var usedIndexes = new HashSet<int>(K);
            while (centroids.Count < K)
            {
                int randomIndex;
                do
                {
                    randomIndex = random.Next(Samples.Count);
                } while (usedIndexes.Contains(randomIndex));
                usedIndexes.Add(randomIndex);

                var randomCentroid = Samples[randomIndex].CloneDataOnly(newLabel: centroids.Count.ToString());
                centroids.Add(randomCentroid);
            }

        }
    }

}
