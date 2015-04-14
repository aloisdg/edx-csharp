using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Module3
{
	public class Program
	{
		/// <summary>
		/// Defines the entry point of the application.
		/// </summary>
		public static void Main()
		{
			try
			{
				GetPeopleInfo();

				// ToDo
				// course
				//string courseName = null;

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				Console.WriteLine("We are going to exit the program.");
				Console.WriteLine("See you next time.");
				Console.ReadLine();
			}
		}

		/// <summary>
		/// Handles student and teacher in one time.
		/// </summary>
		private static void GetPeopleInfo()
		{
			const string studentStatus = "student";
			const string teacherStatus = "teacher";

			GetPersonInfo(studentStatus);
			GetPersonInfo(teacherStatus);
		}

		/// <summary>
		/// Gets the person.
		/// </summary>
		/// <param name="status">The status.</param>
		private static void GetPersonInfo(string status)
		{
			string firstName = null;
			string lastName = null;
			DateTime? birthday = null;

			SetPersonDetails(status, ref firstName, ref lastName, ref birthday);
			PrintPersonDetails(firstName, lastName, birthday ?? default(DateTime));
			Console.WriteLine();
		}

		/// <summary>
		/// Prints the person details.
		/// </summary>
		/// <param name="first">The first.</param>
		/// <param name="last">The last.</param>
		/// <param name="birthday">The birthday.</param>
		private static void PrintPersonDetails(string first, string last, DateTime birthday)
		{
			Console.WriteLine("{0} {1} was born on: {2}", first, last, birthday);
		}

		/// <summary>
		/// Sets the person details.
		/// </summary>
		/// <param name="status">The status.</param>
		/// <param name="firstName">The first name.</param>
		/// <param name="lastName">The last name.</param>
		/// <param name="birthday">The birthday.</param>
		/// <exception cref="System.Exception">Age invalid!</exception>
		private static void SetPersonDetails(string status, ref string firstName, ref string lastName, ref DateTime? birthday)
		{
			const string output = "the {0}'s {1} ";
			const ushort ageMax = 142;
			DateTime date;

			firstName = HandleInputOutput(String.Format(output, status, "first name"));
			lastName = HandleInputOutput(String.Format(output, status, "last name"));
			if (!DateTime.TryParse(HandleInputOutput(String.Format(output, status, "birthday")).Trim(), out date)
			    ||  GetAge(date) > ageMax)
				HandleWrongAge();
			birthday = date;
		}

		/// <summary>
		/// Handles the wrong age.
		/// </summary>
		/// <exception cref="System.NotImplementedException">Age invalid!</exception>
		public static void HandleWrongAge()
		{
			throw new NotImplementedException("Age invalid!");
		}

		/// <summary>
		/// Gets the age from the birthday.
		/// </summary>
		/// <param name="birthday">The birthday.</param>
		/// <returns>age</returns>
		private static int GetAge(DateTime birthday)
		{
			var age = DateTime.Today.Year - birthday.Year;
			if (birthday > DateTime.Today.AddYears(-age))
				age--;
			return age;
		}

		/// <summary>
		/// Handles the input output.
		/// </summary>
		/// <param name="output">The output.</param>
		/// <returns>console input</returns>
		private static string HandleInputOutput(string output)
		{
			Console.WriteLine("Enter {0}:", output);
			return ReadInput();
		}

		/// <summary>
		/// Reads the input.
		/// </summary>
		/// <returns>console input</returns>
		/// <exception cref="System.Exception">Input is null, empty or consists exclusively of white-space characters.</exception>
		private static string ReadInput()
		{
			string input;
			if (IsNotNullNorWhiteSpace(Console.ReadLine(), out input))
				return input;
			throw new Exception("Input is null, empty or consists exclusively of white-space characters.");
		}

		/// <summary>
		/// Determines whether the specified value is not null nor white space.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="result">The result.</param>
		/// <returns>is not null nor white space</returns>
		public static bool IsNotNullNorWhiteSpace(string value, out string result)
		{
			result = String.Empty;
			if (String.IsNullOrWhiteSpace(value))
				return false;
			result = value;
			return true;
		}
	}
}
