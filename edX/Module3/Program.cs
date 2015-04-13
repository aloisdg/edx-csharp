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
		public static void Main()
		{
			try
			{
				HandlePeople();

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

		private static void HandlePeople()
		{
			const string studentStatus =	"student";
			const string teacherStatus =	"teacher";

			HandlePerson(studentStatus);
			HandlePerson(teacherStatus);
		}

		private static void HandlePerson(string status)
		{
			string firstName =	null;
			string lastName =	null;
			ushort? age =		null;

			SetPersonDetails(status, ref firstName, ref lastName, ref age);
			PrintPersonDetails(status, firstName, lastName, age);
			Console.WriteLine();
		}

		private static void PrintPersonDetails(string status, string firstName, string lastName, ushort? age)
		{
			Console.WriteLine("{1}'s detail{0}" +
					  "{1}'s first name :\t{2}{0}" +
					  "{1}'s last name :\t{3}{0}" +
					  "{1}'s age :\t\t{4}",
				Environment.NewLine, status, firstName, lastName, age);
		}

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

		private static string HandleInputOutput(string output)
		{
			Console.WriteLine("Enter {0}: ", output);
			return ReadInput();
		}

		private static string ReadInput()
		{
			string input;
			if (IsNotNullNorWhiteSpace(Console.ReadLine(), out input))
				return input;
			throw new Exception("Input is null, empty or consists exclusively of white-space characters.");
		}

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
