using System;

namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double eps = Math.Pow(10, -9);
        if ((Math.Abs(a) < eps) || (Double.IsNaN(a)) || (Double.IsPositiveInfinity(a)) || (Double.IsNegativeInfinity(a)))
            throw new System.ArgumentException();
        if ((Double.IsNaN(b)) || (Double.IsPositiveInfinity(b)) || (Double.IsNegativeInfinity(b)))
            throw new System.ArgumentException();
        if ((Double.IsNaN(c)) || (Double.IsPositiveInfinity(c)) || (Double.IsNegativeInfinity(c)))
            throw new System.ArgumentException();
        double[] Ans = new double[0];
        double d = ((b * b) - (4.0 * a * c));
        if (-eps < d && d < eps)
        {
            Ans = new double[1];
            Ans[0] = (-b) / 2 * a;
        }
        if (d >= eps)
        {
            Ans = new double[2];
            Ans[0] = -(b + Math.Sign(b) * Math.Sqrt(d)) / 2 + 0;
            Ans[1] = c / Ans[0];
        }
        return Ans;
    }
}
