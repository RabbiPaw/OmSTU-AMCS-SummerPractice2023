using System;
using spacebattle;
using TechTalk.SpecFlow;

namespace spacebattletests{

    public class UnitTest1
    {
         [Binding]
         public class Spacebattle{
            private ScenarioContext _scenarioContext;
            private double x = 1;
            private double y = 1;
            private double speedx = 1;
            private double speedy = 1;
            private double movment = 1;
            private bool exp;
            private double start_fuel = 1;
            private double FuelPerLine = 1;
            private double start_angle = 1;
            private double angle_speed = 1;
            private double[] NewPos = new double[2];
            private double end_fuel = 0;
            private double end_angle = 0;
            public Spacebattle(ScenarioContext input){
                _scenarioContext = input;
            }
            [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
            public void Input1(double k1, double k2){
                x = k1;
                y = k2;
            }
            [Given(@"космический корабль, положение в пространстве которого невозможно определить")]
            public void Input2(){
                x=0;
                y=0;
                speedx=0;
                speedy=0;
                movment = 0;
            }
            [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
            public void Input3(double k1, double k2){
                speedx = k1;
                speedy = k2;
                movment = 1;
            }
            [Given(@"скорость корабля определить невозможно")]
            
            public void Input4(){
                x=0;
                y=0;
                speedx=0;
                speedy=0;
                movment = 0;
            }
            [Given(@"изменить положение в пространстве космического корабля невозможно")]
            public void Input5(){
                x=0;
                y=0;
                speedx=0;
                speedy=0;
                movment = 0;
            }
            [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
            public void Input6(double k1){
                start_fuel = k1;
            }
            [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
            public void Input7(double k1){
                FuelPerLine = k1;
            }
            [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
            public void Input8(double k1){
                start_angle = k1;
            }
            [Given(@"имеет мгновенную угловую скорость (.*) град")]
            public void Input9(double k1){
                angle_speed = k1;
            }
            [Given(@"космический корабль, угол наклона которого невозможно определить")]
            public void Input10(){
                exp = false;
            }
            [Given(@"мгновенную угловую скорость невозможно определить")]
            public void Input11(){
                exp = false;
            }
            [Given(@"невозможно изменить уголд наклона к оси OX космического корабля")]
            public void Input12(){
                exp = false;
            }
            [When(@"происходит прямолинейное равномерное движение без деформации")]
            public void check1(){
                try{
                NewPos = spacebattle.Move.Line(x,y,speedx,speedy,movment);
                end_fuel = spacebattle.Move.Fuel(start_fuel,FuelPerLine);
                }
                catch (Exception){
                    exp = false;
                }
            }
            [When(@"происходит вращение вокруг собственной оси")]
            public void check2(){
                end_angle = spacebattle.Move.Angle(start_angle,angle_speed);
            }
            [Then(@"возникает ошибка Exception")]
            public void Error(){
                Assert.False(exp);
            }
            [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
            public void UpdatePos(double k1,double k2){
                double[]NP = new double[2] {k1,k2};
                for (int i =0;i<NewPos.Length;i++){
                    Assert.Equal(NewPos[i],NP[i]);
                }
            }
            [Then(@"новый объем топлива космического корабля равен (.*) ед")]
            public void UpdateFuel(double k1){
                Assert.Equal(end_fuel,k1);
            }
            [Then("угол наклона космического корабля к оси OX составляет (.*) град")]
            public void UpdateAngle(double k1){
                Assert.Equal(end_angle,k1);
            }

         }
    }
}