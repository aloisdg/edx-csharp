using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 7.Share your code for feedback and ideas with your fellow students such as:

// 7.1.What other objects could benefit from inheritance in this code?
//    UProgram, Degree and Course could benefit from inheritance

// 7.2.Can you think of a different hierarchy for the Person, Teacher, and Student?  What is it?
//    We could remove the Person class and inherit a Student from a Teacher. We could add a variable Status to split them.

// 7.3.Do NOT grade the answers to these two questions, they are merely for discussion and thought.  Only grade the ability to implement inheritance in the code.

namespace Module6
{
	class Program
	{
		public enum SchoolStatus
		{
			Student,
			Teacher,
			Other
		}

		public class UProgram
		{
			private string Name { get; set; }
			public Degree Degree { get; set; }

			public UProgram(string name)
			{
				Name = name;
			}

			public override string ToString()
			{
				return "The " + Name
				       + " program contains the "
				       + Degree.Name + " degree";
			}
		}

		public class Degree
		{
			public string Name { get; private set; }
			public Course Course { get; set; }

			public Degree(string name)
			{
				Name = name;
			}

			public override string ToString()
			{
				return "The " + Name
				       + " degree contains the course "
				       + Course.Name;
			}
		}

		public class Course
		{
			public string Name { get; private set; }
			public IEnumerable<Student> Students { get; set; }

			private IEnumerable<Teacher> _teachers;
			public IEnumerable<Teacher> Teachers
			{
				get { return _teachers; }
				set
				{
					if (!value.Any())
						throw new Exception("Instantiate at least one Teacher object.");
					_teachers = value;
				}
			}

			public Course(string name)
			{
				Name = name;
			}

			public override string ToString()
			{
				return "The " + Name
				       + " course contains " + Students.Count()
				       + " student<s>";
			}
		}

		// 1.Create a Person base class with common attributes for a person
		public abstract class APerson
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public DateTime Birthdate { get; set; }

			public abstract SchoolStatus SchoolStatus { get; }

			protected APerson(string firstName, string lastName, DateTime birthdate)
			{
				FirstName = firstName;
				LastName = lastName;
				Birthdate = birthdate;
			}
		}

		// 2.Make your Student and Teacher classes inherit from the Person base class
		// 3.Modify your Student and Teacher classes so that they inherit the common attributes from Person
		public class Student : APerson
		{
			public override SchoolStatus SchoolStatus { get { return SchoolStatus.Student; } }

			public Student(string firstName, string lastName, DateTime birthdate)
				: base(firstName, lastName, birthdate) { }

			// 4.Modify your Student and Teacher classes so they include characteristics specific to their type.
			public void TakeTest() { }
		}

		// 2.Make your Student and Teacher classes inherit from the Person base class
		// 3.Modify your Student and Teacher classes so that they inherit the common attributes from Person
		public class Teacher : APerson
		{
			public override SchoolStatus SchoolStatus { get { return SchoolStatus.Teacher; } }

			public Teacher(string firstName, string lastName, DateTime birthdate)
				: base(firstName, lastName, birthdate) { }

			// 4.Modify your Student and Teacher classes so they include characteristics specific to their type. 
			public void GradeTest() { }
		}

		static void Main()
		{
			// 5.Run the same code in Program.cs from Module 5 to create instances of your classes
			// so that you can setup a single course that is part of a program and a degree path.
			var uProgram = new UProgram("Information Technology")
			{
				Degree = new Degree("Bachelor")
				{
					Course = new Course("Programming with C#")
					{
						Students = new Collection<Student>
						{
							new Student("Harry", "Potter", new DateTime(1980, 7, 31)),
							new Student("Ron", "Weasley", new DateTime(1980, 3, 1)),
							new Student("Hermione", "Granger", new DateTime(1979, 9, 19))
						},
						Teachers = new Collection<Teacher> { new Teacher("Remus", "Lupin", new DateTime(1960, 3, 10)) }
					}
				}
			};

			try
			{
				// 6.Ensure the Console.WriteLine statements you included in Homework 5, still output the correct information.
				Console.WriteLine(uProgram + Environment.NewLine);
				Console.WriteLine(uProgram.Degree + Environment.NewLine);
				Console.WriteLine(uProgram.Degree.Course.ToString());
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				Console.WriteLine("Press any key to continue ...");
				Console.ReadLine();
			}
		}
	}
}
