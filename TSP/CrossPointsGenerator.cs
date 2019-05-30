using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TSP
{
    class CrossPointsGenerator
    {
        public Tuple<int, int> GenerateCrossPoints(int individualSize, Random randomNumber)
        {
            int crossPoint1 = randomNumber.Next(0, individualSize);
            int crossPoint2 = randomNumber.Next(0, individualSize);
            while(crossPoint1 == crossPoint2)
            {
                crossPoint2 = randomNumber.Next(0, individualSize);
            }
            if(crossPoint1 > crossPoint2)
            {
                int tmpPoint = crossPoint2;
                crossPoint2 = crossPoint1;
                crossPoint1 = tmpPoint;
            }
            return Tuple.Create(crossPoint1, crossPoint2);
        }
    }
}
