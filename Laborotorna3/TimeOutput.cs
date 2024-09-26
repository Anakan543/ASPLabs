namespace Laborotorna3
{
    public class TimeOutput
    {
        public string Time() 
        {
            DateTime date = DateTime.Now;
            int currenyHout = date.Hour;

            switch(currenyHout)
            {
                case >= 12 and < 18:
                    return "зараз день";
                case >= 18 and <= 24:
                    return "зараз вечір";
                case >= 0 and < 6:
                    return "зараз ніч";
                case >= 6 and < 12:
                    return "зараз ранок";
                default:
                    return "None";
            }
        }
    }
}
