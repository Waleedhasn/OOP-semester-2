using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge02
{
    public class Circle
    {
        protected double radius;
        protected string color;

        public Circle() : this(1.0, "red") { }
        public Circle(double radius) : this(radius, "red") { }
        public Circle(double radius, string color)
        {
            this.radius = radius;
            this.color = color;
        }

        public double GetRadius() => radius;
        public void SetRadius(double r) => radius = r;
        public string GetColor() => color;
        public void SetColor(string color) => this.color = color;

        public double GetArea() => System.Math.PI * radius * radius;

        public override string ToString() => $"Circle[radius={radius}, color={color}]";
    }
}
