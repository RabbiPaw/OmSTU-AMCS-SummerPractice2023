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
        public static double Fuel(double start_fuel, double fuelPerLine){
            double end_fuel = 0;
            if (start_fuel < fuelPerLine){
                throw new Exception();
            }
            else{
                end_fuel = start_fuel - fuelPerLine;
            }
            return end_fuel;
        }
        public static double Angle(double start_angle, double angle_speed){
            double end_angle = start_angle+angle_speed;
            return end_angle;
        }
    }   
}
