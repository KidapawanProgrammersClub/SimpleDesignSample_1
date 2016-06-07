using System;
using System.Collections.Generic;

namespace StudentRecord_NotLayered_Console
{
	public class Student
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}

	class Program
	{
		private static List<Student> _listOfStudents = new List<Student>();
		private static ConsoleColor _originalConsoleForgroundColor = Console.ForegroundColor;

		static void Main(string[] args)
		{
			Console.WriteLine("=== STUDENT RECORD ===\n");

			DisplayInstructions();

			do
			{
				string input = Console.ReadLine();
				string[] inputs = input.Split();
				string command = inputs[0];

				switch (command)
				{
					case "add":
						string firstName = inputs[1];
						string lastName = inputs[2];
						AddNewStudent(firstName, lastName);
						break;

					case "remove":
						int indexOfStudentToBeRemoved = int.Parse(inputs[1]);
						RemoveStudentAtIndex(indexOfStudentToBeRemoved);
						break;

					case "list":
						ListStudents();
						break;

					case "?":
						DisplayInstructions();
						break;

					case "quit":
						return;

					default:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Command unrecognized");
						Console.ForegroundColor = _originalConsoleForgroundColor;
						break;
				}

			} while (true);
		}

		private static void AddNewStudent(string firstName, string lastName)
		{
			Student newStudent = new Student();
			newStudent.FirstName = firstName;
			newStudent.LastName = lastName;
			_listOfStudents.Add(newStudent);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Student successfully added\n");
			Console.ForegroundColor = _originalConsoleForgroundColor;
		}

		private static void RemoveStudentAtIndex(int indexOfStudentToBeRemoved)
		{
			_listOfStudents.RemoveAt(indexOfStudentToBeRemoved);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Student \"{0}\" successfully removed\n", indexOfStudentToBeRemoved);
			Console.ForegroundColor = _originalConsoleForgroundColor;
		}

		private static void ListStudents()
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			if (_listOfStudents.Count <= 0)
			{
				Console.WriteLine("No student record to display.\n");
			}
			else
			{
				for (int i = 0; i < _listOfStudents.Count; i++)
				{
					Student currentStudent = _listOfStudents[i];
					Console.WriteLine("{0}. {1} {2}", i, currentStudent.FirstName, currentStudent.LastName);
				}
				Console.WriteLine();
			}
			Console.ForegroundColor = _originalConsoleForgroundColor;
		}

		private static void DisplayInstructions()
		{
			Console.WriteLine(@"
	Please type your command:
	- ""add <First name> <Last name>"" to add a student
	- ""remove <Student ID>"" to remove a student
	- ""list"" to view all students
	- ""?"" to display commands
	- ""quit"" to end the application");
			Console.Write("\n\n");
		}
	}
}
