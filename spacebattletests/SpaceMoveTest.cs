using System;
using spacebattle;
using TechTalk.SpecFlow;

namespace spacebattletests{

    public class UnitTest1
    {
         [Binding]
         public class Spacebattle{
            private ScenarioContext _scenarioContext;
            private double x;
            private double y;
            private double speedx;
            private double speedy;
            private double movment;
            private bool exp;
            private double[] NewPos = new double[2];
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
            [When(@"происходит прямолинейное равномерное движение без деформации")]
            public void check(){
                try{
                NewPos = spacebattle.Move.Line(x,y,speedx,speedy,movment);
                }
                catch (Exception){
                    exp = false;
                }
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
         }
    }
}