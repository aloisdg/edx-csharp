using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				: base(firstName, lastName, birthdate) {}

			public void TakeTest() {}
		}

		// 2.Make your Student and Teacher classes inherit from the Person base class
		// 3.Modify your Student and Teacher classes so that they inherit the common attributes from Person
		public class Teacher : APerson
		{
			public override SchoolStatus SchoolStatus { get { return SchoolStatus.Teacher; } }

			public Teacher(string firstName, string lastName, DateTime birthdate)
				: base(firstName, lastName, birthdate) {}

			public void GradeTest() {}
		}

		static void Main()
		{
		}
	}
}
