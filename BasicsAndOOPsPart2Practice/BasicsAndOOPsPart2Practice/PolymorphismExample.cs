using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsAndOOPsPart2Practice
{
    class PolymorphismExample
    {
        //Method OverLoading
        public int Add(int x, int y)
        {
            return x + y;
        }
        public int Add(double x, int y)
        {
            return (int)x + y;
        }
        public int Add(int y, double x)
        {
            return (int)x + y;
        }
        public int Add(int x, int y, int z)
        {
            return x + y + z;
        }

        //Method Overriding
        public virtual int Sub(int x, int y)
        {
            return x - y;
        }

        public int Mul(int x, int y)
        {
            return x * y;
        }
    }

    class OverridingExample : PolymorphismExample
    {
        public override int Sub(int x, int y)
        {
            return y - x;
        }
    }

    //Method Hiding
    class HidingExample : PolymorphismExample
    {
        public new int Sub(int x, int y)
        {
            return y - x;
        }
        public int Mul(int x, int y)
        {
            return x * y;
        }
    }

    class Vote
    {
        private int Age { get; set; }
        private int voterId;
        public int VoterId
        {
            get { return voterId; }
            set 
            { 
                if(this.Age < 18)
                {
                    return;
                }
                else
                {
                    this.VoterId = value;
                }
            }
        }
    }
}
