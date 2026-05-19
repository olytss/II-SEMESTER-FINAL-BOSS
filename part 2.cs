using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace meow
{
    internal class Mewo
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome!");
                Console.WriteLine("1. Add new Team Member \n 2. Delete Team Member \n 3. Middle Salary Value \n 4. Number of Technical Team Members");
                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        Team.NewTeamMember();
                        break;

                    case ConsoleKey.D2:
                        Team.DeleteMember();
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine($"Middle value is {Team.commandSalary()}");
                        Console.ReadLine();
                        break;

                    case ConsoleKey.D4:
                    System.Console.WriteLine($"Number of Technical Team: {TechnicalTeam.TechTeamMembers()}");
                        break;
                    default:
                        continue;
                        
                }
            }
        }
    }
    public class Team
    {
        static public List<Team> TeamList = new List<Team>();
        private string _name;
        private string _surname;
        private string _department;
        private long _salary;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value == "" || value == null)
                {
                    throw new FormatException("Wrong Format");
                }
                else
                {
                    _name = value;
                }
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (value == "" || value == null)
                {
                    throw new FormatException("Wrong Format");
                }
                else
                {
                    _surname = value;
                }
            }
        }
        public string Department
        {
            get
            {
                return _department;
            }
            set
            {
                 value = value.ToLower();
                if (value == "technical team" || value == "social team")
                {
                    _department = value;
                }
                else
                {
                    throw new Exception("No such department");
                }
            }
        }
        public long Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Ivalid Value");
                }
                else
                {
                    _salary = value;
                }
            }
        }
        public Team(string name, string surname, string department, long salary)
        {
            Name = name;
            Surname = surname;
            Department = department;
            Salary = salary;
        }

        static public void NewTeamMember()
        {
            
            {
                bool isValid = false;
                do
                {
                    Console.Clear();
                    try
                    {
                       
                        Console.WriteLine("Input name, surname, department and salary");
                        string nameTemp = Console.ReadLine();
                        string surnameTemp = Console.ReadLine();
                        Console.WriteLine("Departments: \n Social Team");

                        string departmentTemp = Console.ReadLine();
                        long salaryTemp = long.Parse(Console.ReadLine());

                        Team teamMember = new Team(nameTemp, surnameTemp, departmentTemp, salaryTemp);
                        TeamList.Add(teamMember);
                        isValid = true;
                    }catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine("Argument out of Range" + ex.Message);
                    }
                    catch(FormatException ex1) 
                    {
                        Console.WriteLine("Format Exception" + ex1.Message);
                    }
                    
                }
                while (!isValid);

            }
        }
        static public void DeleteMember()
        {
            if(TeamList.Count == 0) return;
            foreach (var item in TeamList)
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine($"Name: {item.Name} \n Surname: {item.Surname} \n Department: {item.Department} \n Salary {item.Salary}");
                Console.WriteLine("----------------------------");
            }

            Console.WriteLine("What member of the Team do you want to delete");
            int index = 0;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out index))
                {
                    Console.WriteLine("Input invalid");
                }
                else
                {
                    while (true)
                    {
                        if(index > Team.TeamList.Count)
                        {
                            Console.WriteLine("No");
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                }
               
            }
            TeamList.RemoveAt(index - 1);
            Console.WriteLine("Removed!");
        }
       
        static public long commandSalary()
        {
            if(TeamList.Count == 0) return 0;
            long salaryCombined= 0;
            long middleValue = 0;
            foreach (var person in TeamList)
            {
                salaryCombined += person.Salary;
            }
            middleValue = salaryCombined / TeamList.Count;
            return middleValue;
        }

    }
    public class TechnicalTeam : Team
    {
        public TechnicalTeam(string name, string surname, string department, long salary)   
                            : base (name, surname, department, salary)
        {
             this.Name = name;
            this.Surname = surname;
            this.Department = department;
            this.Salary = salary;
        }
    static public int TechTeamMembers()
        {
            IEnumerable<Team> technicalTeam =
            from team in TeamList
            where team.Department == "Technical Team"
            select team;
            return technicalTeam.Count();
        }
    }

}
