using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepWiseBuilder
{
    public class Car
    {
        public CarType Type { get; set; }
        public int WheelSize { get; set; }
    }

    public enum CarType
    {
        Sedan, 
        Crossover
    }
}
