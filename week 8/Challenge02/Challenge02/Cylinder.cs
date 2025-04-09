using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge02
{
    public class Cylinder : Circle
    {
        private double height;

        public Cylinder() : this(1.0, 1.0, "red") { }
        public Cylinder(double radius) : this(radius, 1.0, "red") { }
        public Cylinder(double radius, double height) : this(radius, height, "red") { }
        public Cylinder(double radius, double height, string color)
            : base(radius, color)
        {
            this.height = height;
        }

        public double GetHeight() => height;
        public void SetHeight(double h) => height = h;
        public double GetVolume() => GetArea() * height;

        public override string ToString() => $"Cylinder[radius={radius}, height={height}, color={color}]";
    }
}
