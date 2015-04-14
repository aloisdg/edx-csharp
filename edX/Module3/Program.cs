using System;

namespace Module3
{
	public class Program
	{
		/// <summary>
		/// Defines the entry point of the application.
		/// </summary>
		/// <remarks>
		/// You can find each exception in the code.
		/// You can download the solution here :
		/// <see href="https://github.com/aloisdg/edX/archive/master.zip" />
		/// </remarks>
		public static void Main()
		{
			try
			{
				GetPeopleInfo();
				GetInfo("course");
				GetInfo("program");
				GetInfo("degree");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				Console.WriteLine("We are going to exit the program.");
				Console.WriteLine("Thank you. See you next time.");
				Console.ReadLine();
			}
		}

		/// <summary>
		/// Gets the information.
		/// </summary>
		/// <param name="s">The s.</param>
		private static void GetInfo(string s)
		{
			string name;
			SetDetails(s, out name);
			PrintDetails(s, name);
			Console.WriteLine();
		}

		/// <summary>
		/// Sets the details.
		/// </summary>
		/// <param name="s">The s.</param>
		/// <param name="name">The name.</param>
		private static void SetDetails(string s, out string name)
		{
			name = HandleInputOutput(s + " name");
		}

		/// <summary>
		/// Prints the details.
		/// </summary>
		/// <param name="s">The s.</param>
		/// <param name="name">The name.</param>
		private static void PrintDetails(string s, string name)
		{
			Console.WriteLine("{0}'s name is: {1}", s, name);
		}

		#region people

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
		/// Prints the person details.
		/// </summary>
		/// <param name="first">The first.</param>
		/// <param name="last">The last.</param>
		/// <param name="birthday">The birthday.</param>
		private static void PrintPersonDetails(string first, string last, DateTime birthday)
		{
			Console.WriteLine("{0} {1} was born on: {2}", first, last, birthday);
		}

		#endregion

		#region io handler

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

		#endregion
	}
}
