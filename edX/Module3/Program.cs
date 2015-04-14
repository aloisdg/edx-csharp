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
				GetPeople();

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
		private static void GetPeople()
		{
			const string studentStatus =	"student";
			const string teacherStatus =	"teacher";

			GetPerson(studentStatus);
			GetPerson(teacherStatus);
		}

		/// <summary>
		/// Gets the person.
		/// </summary>
		/// <param name="status">The status.</param>
		private static void GetPerson(string status)
		{
			string firstName =	null;
			string lastName =	null;
			ushort? age =		null;

			SetPersonDetails(status, ref firstName, ref lastName, ref age);
			PrintPersonDetails(status, firstName, lastName, age);
			Console.WriteLine();
		}

		/// <summary>
		/// Prints the person details.
		/// </summary>
		/// <param name="status">The status.</param>
		/// <param name="firstName">The first name.</param>
		/// <param name="lastName">The last name.</param>
		/// <param name="age">The age.</param>
		private static void PrintPersonDetails(string status, string firstName, string lastName, ushort? age)
		{
			Console.WriteLine("{1}'s detail{0}" +
					  "{1}'s first name :\t{2}{0}" +
					  "{1}'s last name :\t{3}{0}" +
					  "{1}'s age :\t\t{4}",
				Environment.NewLine, status, firstName, lastName, age);
		}

		/// <summary>
		/// Sets the person details.
		/// </summary>
		/// <param name="status">The status.</param>
		/// <param name="firstName">The first name.</param>
		/// <param name="lastName">The last name.</param>
		/// <param name="age">The age.</param>
		/// <exception cref="System.Exception">Age invalid!</exception>
		private static void SetPersonDetails(string status, ref string firstName, ref string lastName, ref ushort? age)
		{
			const string output =	"the {0}'s {1} ";
			const ushort ageMax =	200;
			ushort num;

			firstName = HandleInputOutput(String.Format(output, status, "first name"));
			lastName = HandleInputOutput(String.Format(output, status, "last name"));
			if (!UInt16.TryParse(HandleInputOutput(String.Format(output, status, "age")).Trim(), out num) || num > ageMax)
				throw new Exception("Age invalid!");
			age = num;
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
