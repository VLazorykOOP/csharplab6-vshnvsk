using System;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace Task2
{
    public interface IPersonInterface : IComparable, IEnumerable<object>
    {
        void DisplayInfo();
        int Age();
    }

    public abstract class Persona : IPersonInterface
    {
        protected string name;
        protected string surname;
        protected DateTime dateOfBirth;
        protected string faculty;

        public Persona(string name, string surname, DateTime dateOfBirth, string faculty)
        {
            this.name = name;
            this.surname = surname;
            this.dateOfBirth = dateOfBirth;
            this.faculty = faculty;
        }

        public virtual void DisplayInfo() { }

        public int Age()
        {
            DateTime currentTime = DateTime.Now;
            int age = currentTime.Year - dateOfBirth.Year;
            if (currentTime < dateOfBirth.AddYears(age))
            {
                age--;
            }
            return age;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            IPersonInterface otherPersona = obj as IPersonInterface;
            if (otherPersona != null)
                return this.Age().CompareTo(otherPersona.Age());
            else
                throw new ArgumentException("Object is not a Persona");
        }

        public IEnumerator<object> GetEnumerator()
        {
            yield return this;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Applicant : Persona
    {
        public Applicant(string name, string surname, DateTime dateOfBirth, string faculty) : base(name, surname, dateOfBirth, faculty)
        {
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"\nApplicant: \t{name} {surname}\nAge: \t\t{Age()}\nFaculty: \t{faculty}");
        }
    }

    class Student : Persona
    {
        public int course;

        public Student(string name, string surname, DateTime dateOfBirth, string faculty, int course) : base(name, surname, dateOfBirth, faculty)
        {
            this.course = course;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"\nStudent: \t{name} {surname}\nAge: \t\t{Age()}\nFaculty: \t{faculty}\nCourse: \t{course}");
        }
    }

    class Teacher : Persona
    {
        public string position;
        public int expirience;

        public Teacher(string name, string surname, DateTime dateOfBirth, string faculty, string position, int expirience) : base(name, surname, dateOfBirth, faculty)
        {
            this.position = position;
            this.expirience = expirience;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"\nTecher: \t{name} {surname}\nAge: \t\t{Age()}\nFaculty: \t{faculty}\nPosition: \t{position}\nExpirience: \t{expirience}");
        }
    }

    class Program
    {
        public static void Main_Task2()
        {
            List<IPersonInterface> persons = new List<IPersonInterface>();

            persons.Add(new Applicant("Mary", "Smith", new DateTime(2000, 5, 10), "Computer Sience"));
            persons.Add(new Student("Andrew", "Johnson", new DateTime(2001, 6, 30), "Mathematics", 3));
            persons.Add(new Teacher("Elizaveta", "Williams", new DateTime(1970, 1, 5), "Physics", "Professor", 20));

            Console.WriteLine("All persons: ");
            foreach (IPersonInterface person in persons)
            {
                person.DisplayInfo();
            }


            Console.WriteLine("\nEnter age range: ");
            int minAge = Convert.ToInt32(Console.ReadLine());
            int maxAge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nPersons within age range {minAge}-{maxAge}:");
            foreach (IPersonInterface person in persons)
            {
                int age = person.Age();
                if (age >= minAge && age <= maxAge)
                {
                    person.DisplayInfo();
                }
            }
        }
    }
}
