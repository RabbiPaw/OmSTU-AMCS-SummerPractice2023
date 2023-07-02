using System;
namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double eps = 1e-6;
        if ((Math.Abs(a) < eps) || (Double.IsNaN(a)) || (Double.IsPositiveInfinity(a)) || (Double.IsNegativeInfinity(a)))
            throw new System.ArgumentException();
        if ((Double.IsNaN(b)) || (Double.IsPositiveInfinity(b)) || (Double.IsNegativeInfinity(b)))
            throw new System.ArgumentException();
        if ((Double.IsNaN(c)) || (Double.IsPositiveInfinity(c)) || (Double.IsNegativeInfinity(c)))
            throw new System.ArgumentException();
        double[] Ans = new double[0];
        double d = ((b * b) - (4.0 * a * c));
        if (d<-eps){
            return Ans;
        }
        if (-eps < d && d < eps)
        {
            Ans = new double[1];
            Ans[0] = (-b) / 2 * a;
        }
        if (d >= eps)
        {
            if (-eps<b && b<eps){
                Ans = new double[2];
                Ans[0] = Math.Sqrt(d)/(2*a);
                Ans[1] = -Math.Sqrt(d)/(2*a);
            }
            else{
            Ans = new double[2];
            Ans[0] = -(b + Math.Sign(b) * Math.Sqrt(d)) / 2;
            Ans[1] = c / Ans[0];}
        }
        return Ans;
    }
}
