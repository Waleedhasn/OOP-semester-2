using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge01
{
    public class Bicycle
    {
        private int cadence;
        private int gear;
        private int speed;

        public Bicycle(int cadence, int speed, int gear)
        {
            this.cadence = cadence;
            this.speed = speed;
            this.gear = gear;
        }

        public void SetCadence(int cadence) => this.cadence = cadence;
        public void SetGear(int gear) => this.gear = gear;
        public void ApplyBrake(int decrement) => speed -= decrement;
        public void SpeedUp(int increment) => speed += increment;

        public override string ToString()
        {
            return $"Bicycle: Cadence = {cadence}, Gear = {gear}, Speed = {speed}";
        }
    }
}
