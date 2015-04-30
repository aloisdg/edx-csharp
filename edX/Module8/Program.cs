using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Module8
{
	// 1. Used a List<T> collection of the proper data type, inside the Course object.

	//	Students is an List<T>. You can find it inside the Course object.

	// 2. Added a Stack<T> of the proper data type, called Grades, inside the Student object.

	//	I added it inside the Student object. I created an object Grade for fun.

	// 3. Added 3 Student objects to this List<T> using the List<T> method for adding objects.

	//	I use my own List<T>.

	// 4. Used a foreach loop to output the first and last name of each Student in the List<T>.

	//	I overrided the ToString() method, to print the name directly.

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
			public string Name { get; protected set; }

			protected ANameable(string name)
			{
				Name = name;
			}

			public override string ToString()
			{
				return Name;
			}
		}

		public abstract class APerson : ANameable
		{
			public string FirstName { get; protected set; }
			public string LastName { get; protected set; }
			public DateTime Birthdate { get; set; }
			public abstract SchoolStatus SchoolStatus { get; }

			protected APerson(string firstName, string lastName, DateTime birthdate)
				: base(firstName + " " + lastName)
			{
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

		// Create a List<T>, of the proper data type, to replace the ArrayList and to hold students, inside the Course object.
		public class Students : List<Student> { }

		public class Course : ANameable
		{
			// Modify your code to use the List<T> collection as the replacement to the ArrayList.
			// Nothing to do in fact
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

			// Create a method inside the Course object called ListStudents() that contains the foreach loop.
			public void ListStudents()
			{
				// Using a foreach loop, iterate over the Students in the List<T> and output their first and last names to the console window.
				// (For this exercise, casting is no longer required.  Also, place each student name on its own line)
				foreach (var student in Students)
					Console.WriteLine(student);
			}

			public override string ToString()
			{
				return "The " + Name
				       + " course contains " + Students.Count
				       + " student<s>";
			}
		}

		public class Grade : ANameable
		{
			public int Score { get; private set; }

			public Grade(string name, int score)
				: base(name)
			{
				Score = score;
			}
		}

		public class Student : APerson
		{
			public override SchoolStatus SchoolStatus { get { return SchoolStatus.Student; } }

			// Create a Stack<T> object, of the proper data type, inside the Student object, called Grades, to store test scores.
			public Stack<Grade> Grades { get; set; }

			public Student(string firstName, string lastName, DateTime birthdate)
				: base(firstName, lastName, birthdate)
			{
				Grades = new Stack<Grade>();
			}

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
			try
			{
				//Create 3 student objects.
				var students = new Students
				{
					new Student("Harry", "Potter", new DateTime(1980, 7, 31)),
					new Student("Ron", "Weasley", new DateTime(1980, 3, 1)),
					new Student("Hermione", "Granger", new DateTime(1979, 9, 19))
				};

				// Add 5 grades to the the Stack in the each Student object.
				// This does not have to be inside the constructor because you may not have grades for a student when you create a new student.
				foreach (var student in students)
					student.Grades = new Stack<Grade>(
						Enumerable.Repeat(new Grade("Magic", 1), 5));

				var uProgram = new UProgram("Information Technology")
				{
					Degree = new Degree("Bachelor")
					{
						Course = new Course("Programming with C#")
						{
							// Add the three Student objects to the List<T> inside the Course object.
							Students = students,
							Teachers = new Collection<Teacher> { new Teacher("Remus", "Lupin", new DateTime(1960, 3, 10)) }
						}
					}
				};

				// Call the ListStudents() method from Main().
				uProgram.Degree.Course.ListStudents();

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
