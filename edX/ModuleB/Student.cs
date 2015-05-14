using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleB
{
	class Student
	{
		private string firstName;
		private string lastName;
		private string city;

		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}


		public string LastName
		{
			get { return lastName; }
			set { lastName = value; }
		}


		public string City
		{
			get { return city; }
			set { city = value; }
		}
	}
}
