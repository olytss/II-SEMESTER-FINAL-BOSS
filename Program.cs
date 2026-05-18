using System.Data;

namespace meow
{
    internal class programm
    {
        static private void Main(string[] args)
        {
            CustomDate.NewDate();
            Console.WriteLine(CustomDate.isLeapYear(CustomDate.dates[0]));
            Console.WriteLine(CustomDate.HowManyDaysInMonths(CustomDate.dates[0]));
        }
    }
    public class CustomDate
    {
        static public List<CustomDate> dates = new List<CustomDate>();
        private int _day; //backing field
        private int Day {get { return _day; } set 
            {
                if (value < 0 || value > 31)
                {
                    throw new ArgumentOutOfRangeException("No"); //xd first time seeing Visual Studio tabulating throw exception
                }
                else
                {
                    _day = value; //ALWAYS ASSING TO THE BACKING FIELD!!!!!!!!!!!!!!!!!!
                }
            
            } 
        
        }
        private int _month;
        public int Month
        {
            get 
            { return _month; }
            set
            {
                if (value < 0)
                {
                   throw new ArgumentOutOfRangeException("Cant be less than 0 MONTH");
                }
                else
                {
                    _month = value;
                }
            }
        }
        private int _year;
        public int Year
        {
            get
            {
                return _year;

            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Can be less than 0");
                }
                else
                {
                    _year = value;
                }

            }

        }
        

        // hehehehehh six seven
        CustomDate(int day, int month, int year)
        {
            if(month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException("MONTH", "OUT OF RANGE");
            }
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }
        static public void NewDate()
        {
            int day = 0;
            int month = 0;
            int year = 0;
            bool exception = false;
            Console.WriteLine("Give me day, month and year");
            do
            {
                try
                {
                    day = int.Parse(Console.ReadLine());
                    month = int.Parse(Console.ReadLine());
                    year = int.Parse(Console.ReadLine());
                    
                    CustomDate date = new CustomDate(day, month, year);
                    dates.Add(date);
                    exception = true;
                }
                catch (FormatException ex)
                {

                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (ArgumentOutOfRangeException ex1)
                {
                    Console.WriteLine("out of range buddy");
                    continue;
                }


            } while (!exception);
        }
        static public bool isLeapYear(CustomDate Date)
        {
            return DateTime.IsLeapYear(Date.Year);
        }
        static public int HowManyDaysInMonths(CustomDate date)
        {
            return DateTime.DaysInMonth(date.Year, date.Month);
        }
        static public bool isLeapYear(int year)
        {
            return DateTime.IsLeapYear(year);
        }

        static public bool isLeapYear(string yearText)
        {
            int parsedYear = int.Parse(yearText);
            return DateTime.IsLeapYear(parsedYear);
        }

        static public int HowManyDaysInMonths(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }
        static public int HowManyDaysInMonths(string fullDateString)
        {
            DateTime parsedDate = DateTime.Parse(fullDateString);
            return DateTime.DaysInMonth(parsedDate.Year, parsedDate.Month);
        }
    }
}