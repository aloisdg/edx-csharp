using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
		public enum Gender
		{
			Male,
			Female,
			Other
		}

		public enum SchoolStatus
		{
			Student,
			Professor,
			Other
		}

		/// <summary>
		/// AddressLine3 is required for some countries like France
		/// </summary>
		public class Address
		{
			public string AddressLine1 { get; set; }
			public string AddressLine2 { get; set; }
			public string AddressLine3 { get; set; }
			public string City { get; set; }
			public string State { get; set; }
			public string Zip { get; set; }
			public string Country { get; set; }
		}

		public abstract class APerson
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public DateTime Birthdate { get; set; }
			public Address Address { get; set; }
			public Gender Gender { get; set; }

			public abstract SchoolStatus SchoolStatus { get; }
		}

		public class Student : APerson
		{
			public override SchoolStatus SchoolStatus { get { return SchoolStatus.Student; }}
		}

		public class Professor : APerson
		{
			public override SchoolStatus SchoolStatus { get { return SchoolStatus.Professor; }}
		}

		public class Degree
		{
			public string Name { get; set; }
			public string FullName { get; set; }
			public int CreditsRequired { get; set; }
		}

		public class University
		{
			public string Name { get; set; }
			public string FullName { get; set; }
			public Address Adress { get; set; }
			public IEnumerable<Degree> Degrees { get; set; }
			public IEnumerable<Student> Students { get; set; }
			public IEnumerable<Professor> Professors { get; set; }
		}

		static void Main(string[] args)
		{
			var hogwarts = new University
			{
				Name = "Hogwarts",
				FullName = "Hogwarts School of Witchcraft and Wizardry",
				Adress = new Address { Country = "Scotland"},
				Degrees = new Collection<Degree>
				{
					new Degree
					{
						Name = "O.W.L.",
						FullName = "Ordinary Wizarding Level",
						CreditsRequired = 180
					},
					new Degree
					{
						Name = "N.E.W.T.",
						FullName = "Nastily Exhausting Wizarding Test",
						CreditsRequired = 300
					},
				},
				Students = new Collection<Student>
				{
					new Student
					{
						FirstName = "Harry",
						LastName = "Potter",
						Gender = Gender.Male,
						Birthdate = new DateTime(1980, 7, 31),
						Address = new Address
						{
							AddressLine1 = "The Cupboard under the Stairs",
							AddressLine2 = "4, Privet Drive",
							City = "Little Whinging",
							State = "Surrey",
							Country = "England"
						}
					}
				},
				Professors = new Collection<Professor>
				{
					new Professor
					{
						FirstName = "Remus",
						LastName = "Lupin",
						Gender = Gender.Male,
						Birthdate = new DateTime(1960, 3, 10),
						Address = new Address
						{
							AddressLine1 = "The Shrieking Shack",
							City = "Hogsmeade",
							Country = "Scotland"
						}
					}
				}
			};

			Console.ReadLine();
		}
	}
}
