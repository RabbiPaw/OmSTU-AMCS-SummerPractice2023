using System;
namespace spacebattle{
    public class Move
    {
        public static double[] Line(double x,double y,double speedx,double speedy,double movment){
            double[] newPos = new double[2];
            if (movment ==0){
                throw new Exception();
            }
            else{
                newPos[0] = x + speedx;
                newPos[1] = y + speedy;
            }
            return newPos;
        }
    }   
}
