using System;

namespace Module4
{
	class Program
	{
		/// <summary>
		/// We override ToString to pretty print
		/// </summary>
		struct Student
		{
			public readonly string FirstName;
			public readonly string LastName;
			public readonly int Age;
			public DateTime BirthDate;

			public Student(string firstName, string lastName, DateTime birthDate)
				: this()
			{
				FirstName = firstName;
				LastName = lastName;
				BirthDate = birthDate;
				Age = (DateTime.Today.Year - birthDate.Year);
				if (birthDate > DateTime.Today.AddYears(-Age)) Age--;
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
			public string FirstName;
			public string LastName;
			public readonly int Age;
			public DateTime BirthDate;

			public Teacher(string firstName, string lastName, DateTime birthDate)
				: this()
			{
				FirstName = firstName;
				LastName = lastName;
				BirthDate = birthDate;
				Age = (DateTime.Today.Year - birthDate.Year);
				if (birthDate > DateTime.Today.AddYears(-Age)) Age--;
			}
		}

		/// <summary>
		/// We cant use Program
		/// </summary>
		struct Prog
		{
			public readonly string Name;

			public Prog(string name)
			{
				Name = name;
			}
		}

		struct Course
		{
			public string Name;

			public Course(string name)
			{
				Name = name;
			}
		}

		static void Main()
		{
			var teacher =	new Teacher("Remus", "Lupin", new DateTime(1960, 3, 10));
			var program =	new Prog("edx");
			var course =	new Course();
			var students =	new[]
			{
				new Student("Harry", "Potter", new DateTime(1980, 7, 31)),
				new Student("Ron", "Weasley", new DateTime(1980, 3, 1)),
				new Student("Hermione", "Granger", new DateTime(1979, 9, 19)),
				new Student("Fred", "Weasley", new DateTime(1978, 4, 1)),
				new Student("George", "Weasley", new DateTime(1978, 4, 1)),
			};
			
			foreach (var student in students)
				Console.WriteLine(student.ToString());
			Console.ReadLine();
		}
	}
}
