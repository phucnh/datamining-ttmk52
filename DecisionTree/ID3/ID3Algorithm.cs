using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIDT.ID3
{
    public class ID3Algorithm
    {
        public static double CalculateInformationFunction(double p, double n)
        {
            if ((p == 0) || (n == 0)) return 0;
            return -(((double)p / (p + n)) * (Math.Log((double)p / (p + n), 2)) + ((double)n / (p + n)) * (Math.Log((double)n / (p + n), 2)));
        }

        public static double CalculateEntropyFunction(int[,] propertyDataSet)
        {
            int totalItem = 0;
            double finalEntropy = 0;
            double tempPropability = 0;
            int i, j = 0;
            for (i = 0; i < propertyDataSet.GetLength(0); i++)
            {
                for (j = 0; j < propertyDataSet.GetLength(1); j++)
                {
                    totalItem = totalItem + propertyDataSet[i, j];
                }
            }
            for (i = 0; i < propertyDataSet.GetLength(0); i++)
            {
                if ((propertyDataSet[i, 0] == 0) || (propertyDataSet[i, 1] == 0))
                {
                    tempPropability = 0;
                }
                else
                {
                    tempPropability = (double)((double)(propertyDataSet[i, 0] + propertyDataSet[i, 1]) / totalItem) * (CalculateInformationFunction(propertyDataSet[i, 0], propertyDataSet[i, 1]));
                }
                finalEntropy = finalEntropy + tempPropability;
            }
            return finalEntropy;
        }

        public static double CalculateGainFunction(int[,] propertyDataSet)
        {
            int i = 0;
            int totalPi = 0;
            int totalNi = 0;
            for (i = 0; i < propertyDataSet.GetLength(0); i++)
            {
                totalPi = totalPi + propertyDataSet[i, 0];
                totalNi = totalNi + propertyDataSet[i, 1];
            }

            double valueOfInformationFunction = CalculateInformationFunction(totalPi, totalNi);
            double valueOfEntropyFunction = CalculateEntropyFunction(propertyDataSet);

            return (valueOfInformationFunction - valueOfEntropyFunction);
        }
    }
}
