namespace System.Numbers
{
    public class PrimeService
    {
        public bool IsPrime(double a, double b, double c, double[] Answ)
        {
            if (Answ.Count() == 1)
            {
                return true;
            }
            if (Answ.Count() == 2)
            {
                return true;
            }
            return false;
        }
    }
}