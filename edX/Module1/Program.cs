using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1
{
	class Program
	{
		enum Gender
		{
			Male,
			Female,
			Other
		}

		enum SchoolStatus
		{
			Student,
			Professor,
			Other
		}

		class Address
		{
			public string AddressLine1 { get; set; }
			public string AddressLine2 { get; set; }
			public string City { get; set; }
			public string State { get; set; }
			public string Zip { get; set; }
			public string Country { get; set; }
		}

		abstract class APerson
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public DateTime Birthdate { get; set; }
			public Address Address { get; set; }
			public Gender Gender { get; set; }

			public abstract SchoolStatus SchoolStatus { get; }
		}

		class Student : APerson
		{
			public override SchoolStatus SchoolStatus { get { return SchoolStatus.Student; }}
		}

		class Professor : APerson
		{
			public override SchoolStatus SchoolStatus { get { return SchoolStatus.Professor; }}
		}

		static void Main(string[] args)
		{
		}
	}
}
