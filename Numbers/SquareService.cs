using System;
namespace System.Square
{
    public class SquareService
    {
        public bool SquareMath(double a, double b, double c, double[] Answ)
        {
            double Eps = Math.Pow(10,-9);
            if (Answ.Count() ==0)
            {
                return false;
            }
            if (Answ.Count() == 1 & a*Answ[0]*Answ[0]+b*Answ[0]+c < Eps & a*Answ[0]*Answ[0]+b*Answ[0]+c > -Eps)
            {
                return true;
            }
            if (Answ.Count() == 2 & a*Answ[0]*Answ[0]+b*Answ[0]+c < Eps & a*Answ[0]*Answ[0]+b*Answ[0]+c > -Eps & a*Answ[1]*Answ[1]+b*Answ[1]+c < Eps & a*Answ[1]*Answ[1]+b*Answ[1]+c > -Eps)
            {
                return true;
            }
            return false;
        }
    }
}
