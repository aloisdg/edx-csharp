using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7
{

	//Create a Stack object inside the Student object, called Grades, to store test scores.
	//Create 3 student objects.
	//Add 5 grades to the the Stack in the each Student object. (this does not have to be inside the constructor because you may not have grades for a student when you create a new student.)
	//Add the three Student objects to the Students ArrayList inside the Course object.
	//Using a foreach loop, iterate over the Students in the ArrayList and output their first and last names to the console window. (For this exercise you MUST cast the returned object from the ArrayList to a Student object.  Also, place each student name on its own line)
	//Create a method inside the Course object called ListStudents() that contains the foreach loop.
	//Call the ListStudents() method from Main().

	class Program
	{
		#region enum
		public enum SchoolStatus
		{
			Student,
			Teacher,
			Other
		}

		#endregion

		#region interface

		public interface INameable
		{
			string Name { get; }
		}

		#endregion

		#region abstract

		public abstract class ANameable : INameable
		{
			public string Name { get; private set; }

			protected ANameable(string name)
			{
				Name = name;
			}
		}

		public abstract class APerson : INameable
		{
			public string Name { get; private set; }
			public string FirstName { get; protected set; }
			public string LastName { get; protected set; }
			public DateTime Birthdate { get; set; }
			public abstract SchoolStatus SchoolStatus { get; }

			protected APerson(string firstName, string lastName, DateTime birthdate)
			{
				Name = firstName + " " + lastName;
				FirstName = firstName;
				LastName = lastName;
				Birthdate = birthdate;
			}
		}

		#endregion

		#region class

		public class UProgram : ANameable
		{
			public Degree Degree { get; set; }

			public UProgram(string name) : base(name) { }

			public override string ToString()
			{
				return "The " + Name
				       + " program contains the "
				       + Degree.Name + " degree";
			}
		}

		public class Degree : ANameable
		{
			public Course Course { get; set; }

			public Degree(string name) : base(name) { }

			public override string ToString()
			{
				return "The " + Name
				       + " degree contains the course "
				       + Course.Name;
			}
		}

		//Modify your code to use the ArrayList collection as the replacement to the array.
		public class Students : ArrayList
		{
			//In other words, when you add a Student to the Course object, you will add it to the ArrayList and not an array.
			public override int Add(object value)
			{
				if (value is Student)
					return base.Add(value);
				throw new InvalidOperationException();
			}
		}

		public class Course : ANameable
		{
			//Delete the Student array in your Course object that you created in Module 5.
			//Create an ArrayList to replace the array and to hold students, inside the Course object.
			public Students Students { get; set; }

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

			public Course(string name) : base(name) { }

			public override string ToString()
			{
				return "The " + Name
				       + " course contains " + Students.Count
				       + " student<s>";
			}
		}

		public class Student : APerson
		{
			public override SchoolStatus SchoolStatus { get { return SchoolStatus.Student; } }

			public Student(string firstName, string lastName, DateTime birthdate)
				: base(firstName, lastName, birthdate) { }

			public void TakeTest()
			{
				Console.WriteLine("Student takes the test.");
			}
		}

		public class Teacher : APerson
		{
			public override SchoolStatus SchoolStatus { get { return SchoolStatus.Teacher; } }

			public Teacher(string firstName, string lastName, DateTime birthdate)
				: base(firstName, lastName, birthdate) { }

			public void GradeTest()
			{
				Console.WriteLine("Teacher grades the test.");
			}
		}

		#endregion

		private static void Main()
		{
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
