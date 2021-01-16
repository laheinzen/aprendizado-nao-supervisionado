
using System;
using System.Text;

namespace TrabalhoFinal
{
    public class Sample
    {
        public double[] Data { get; set; }
        public string Label { get; set; }

        private int SumDataCounter;
        
        public Sample(double[] data, string label)
        {
            this.Data = data;
            this.Label = label;
        }

        public override string ToString()
       {
            var stringData = new StringBuilder("[");
            foreach(double coordinate in Data)
            {
                stringData.Append(coordinate.ToString());
                stringData.Append(",");
            }
            stringData.Remove(stringData.Length-1, 1);
            stringData.Append("]");
            return $"Sample data={stringData}, label={Label}";        
        }

        public Sample Clone()
        {
           return CloneDataOnly(this.Label);
        }

        internal double EuclidianDistanceFrom(Sample other)
        {
            // distancia = raiz.quadrada(soma(pi-qi)**2))
            var distanceHelper = 0d;
            for (int dimension = 0; dimension < Data.Length; dimension++) 
            {
                var point = Data[dimension];
                var otherPoint = other.Data[dimension];
                var distance = point - otherPoint;
                distanceHelper += distance * distance;
            }

            return Math.Sqrt(distanceHelper);
        }

        public void ResetData()
        {
            Data = new double[Data.Length];
            SumDataCounter = 0;
        }
        
        public void SumData(double[] dataToSum)
        {
            for (int dimension = 0; dimension < Data.Length; dimension++)
            {
                Data[dimension] += dataToSum[dimension];
                SumDataCounter++;
            }
        }

        public void ApplyDataMean()
        {
            for (int dimension = 0; dimension < Data.Length; dimension++)
            {
                //Calcula a média
                Data[dimension] /= SumDataCounter;
            }
        }

        public Sample CloneDataOnly(string newLabel)
        {
            double[] clonedData = new double[this.Data.Length];
            Array.Copy(this.Data, clonedData, this.Data.Length);
            return new Sample(clonedData, newLabel);
        }
    }
}