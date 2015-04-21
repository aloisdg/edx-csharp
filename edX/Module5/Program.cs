using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module5
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
			public string Name { get; private set; }
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
					// Instantiate at least one Teacher object.
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

		public class Student : APerson
		{
			// Add a static class variable to the Student class to track the number of students currently enrolled in a school.
			// Increment a student object count every time a Student is created.
			public static uint EnrolledCount;

			public override SchoolStatus SchoolStatus { get { return SchoolStatus.Student; } }

			public Student(string firstName, string lastName, DateTime birthdate)
				: base(firstName, lastName, birthdate)
			{
				EnrolledCount++;
			}
		}

		public class Teacher : APerson
		{
			public override SchoolStatus SchoolStatus { get { return SchoolStatus.Teacher; } }

			public Teacher(string firstName, string lastName, DateTime birthdate)
				: base(firstName, lastName, birthdate) {}
		}

		private static void Main()
		{
			// Instantiate three Student objects.
			var harry = new Student("Harry", "Potter", new DateTime(1980, 7, 31));
			var ron = new Student("Ron", "Weasley", new DateTime(1980, 3, 1));
			var hermione = new Student("Hermione", "Granger", new DateTime(1979, 9, 19));

			// Instantiate a Course object called Programming with C#.
			var course = new Course("Programming with C#")
			{
				// Add your three students to this Course object.
				Students = new Collection<Student> { harry, ron, hermione },
				// Add that Teacher object to your Course object.
				Teachers = new Collection<Teacher> { new Teacher("Remus",  "Lupin", new DateTime(1960, 3, 10)) }
			};
			
			// Instantiate a Degree object, such as Bachelor.
			var degree = new Degree("Bachelor")
			{
				// Add your Course object to the Degree object.
				Course = course
			};

			// Instantiate a UProgram object called Information Technology.
			var uProgram = new UProgram("Information Technology")
			{
				// Add the Degree object to the UProgram object.
				Degree = degree
			};

			try
			{
				// Using Console.WriteLine statements, output the following information to the console window:
				Console.WriteLine(uProgram + Environment.NewLine);
				Console.WriteLine(degree + Environment.NewLine);
				Console.WriteLine(course.ToString());

				// Uncomment the following line to print the current enrolled count 
				// Console.WriteLine(Student.EnrolledCount);
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
