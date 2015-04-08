using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Module1
{
	class Program
	{
		/// <summary>
		/// Facebook allow 71 gender options
		/// </summary>
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

		enum DegreeType
		{
			Bachelor,
			Master,
			PhD,
			Other
		}

		/// <summary>
		/// AddressLine3 is required for some countries like France
		/// </summary>
		class Address
		{
			public string AddressLine1 { get; set; }
			public string AddressLine2 { get; set; }
			public string AddressLine3 { get; set; }
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


		// TODO : Idea for a degreeType notation ? I dont want to keep hungarian
		interface IDegree
		{
			string Name { get; set; }
			//string DegreeType Dt { get; set; }
		}

		class University
		{
			IEnumerable<Student> Students { get; set; }
			IEnumerable<Professor> Professors { get; set; }
			private IEnumerable<IDegree> Degrees { get; set; }
		}

		static void Main(string[] args)
		{
		}
	}
}
