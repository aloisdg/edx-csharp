using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4
{
	class Program
	{
		/// <summary>
		/// We override ToString to pretty print
		/// </summary>
		struct Student
		{
			private readonly string _firstName;
			private readonly string _lastName;
			private readonly int _age;
			private readonly DateTime _birthDate;

			public Student(string firstName, string lastName, DateTime birthDate)
				: this()
			{
				_firstName = firstName;
				_lastName = lastName;
				_birthDate = birthDate;
				_age = (DateTime.Today.Year - birthDate.Year);
				if (birthDate > DateTime.Today.AddYears(-_age)) _age--;
			}

			private string FirstName
			{
				get { return _firstName; }
			}

			private string LastName
			{
				get { return _lastName; }
			}

			private int Age
			{
				get { return _age; }
			}

			public DateTime BirthDate
			{
				get { return _birthDate; }
			}

			public override string ToString()
			{
				return FirstName.PadRight(12)
				       + LastName.PadRight(12)
				       + Age + " years old";
			}
		}

		/// <summary>
		/// A Teacher is a person like a student.
		/// </summary>
		struct Teacher
		{
			private readonly string _firstName;
			private readonly string _lastName;
			private readonly int _age;
			private readonly DateTime _birthDate;

			public Teacher(string firstName, string lastName, DateTime birthDate)
				: this()
			{
				_firstName = firstName;
				_lastName = lastName;
				_birthDate = birthDate;
				_age = (DateTime.Today.Year - birthDate.Year);
				if (birthDate > DateTime.Today.AddYears(-_age)) _age--;
			}

			private string FirstName
			{
				get { return _firstName; }
			}

			private string LastName
			{
				get { return _lastName; }
			}

			private int Age
			{
				get { return _age; }
			}

			private DateTime BirthDate
			{
				get { return _birthDate; }
			}
		}

		/// <summary>
		/// We cant use Program
		/// </summary>
		struct Prog
		{
			private readonly string _name;
			public string Name
			{
				get { return _name; }
			}

			public Prog(string name)
			{
				_name = name;
			}
		}

		struct Course
		{
			private readonly string _name;
			public string Name
			{
				get { return _name; }
			}

			public Course(string name)
			{
				_name = name;
			}
		}

		static void Main()
		{
			var students = new[]
			{
				new Student("Harry", "Potter", new DateTime(1980, 7, 31)),
				new Student("Ron", "Weasley", new DateTime(1980, 3, 1)),
				new Student("Hermione", "Granger", new DateTime(1979, 9, 19)),
				new Student("Fred", "Weasley", new DateTime(1978, 4, 1)),
				new Student("George", "Weasley", new DateTime(1978, 4, 1)),
			};

			foreach (var student in students)
				Console.WriteLine(student.ToString());

			var teacher = new Teacher("Remus", "Lupin", new DateTime(1960, 3, 10));
			var program = new Prog("edx");
			var course = new Course();

			Console.ReadLine();
		}
	}
}
