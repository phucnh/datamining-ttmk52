using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C4._5
{
    public class C45Algorithm
    {
        public static double CaculateEntropy(params double[] probabilities)
        {
            double result = 0.0;

            foreach (double probability in probabilities)
            {
                result -= probability * Math.Log(probability);
            }

            return result;
        }

        
    }
}
