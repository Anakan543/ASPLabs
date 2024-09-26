namespace Laborotorna3
{
    public class CalcService
    {
        public int Sum(int x, int y)
        {
            return x + y;
        }

        public int Substract(int x, int y)
        {
            return x - y;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public double Divide(int x, int y) { 
            if (y == 0)
            {
                throw new DivideByZeroException("no divided by zero");
            }
            else
            {
                return x / y;
            }

        }


    }
}
