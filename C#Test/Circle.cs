using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Test
{
    public class Circle
    {
        static double _diameter;

        public static double Diameter
        {
            get { return _diameter; }
            set { _diameter = value > 0 ? value : throw new ArgumentOutOfRangeException("The diameter must be greater than zero."); }
        }

        public static double GetRadius()
        {
            return _diameter / 2;
        }

        public static double GetCircleArea()
        {
            return Math.PI * (_diameter / 2);
        }

        public Circle()
        {

        }

        public Circle(double inputData) => Diameter = inputData;

        public override string ToString() => $"\n[1] Diameter = {_diameter}\n" +
                                             $"[2] Radius = {GetRadius()}\n" +
                                             $"[3] Circle area = {GetCircleArea()}";

        public static string ToStringWithRound() => $"\n[1] Diameter = {_diameter:f2}\n" +
                                             $"[2] Radius = {GetRadius():f2}\n" +
                                             $"[3] Circle area = {GetCircleArea():f2}";
    }
}
