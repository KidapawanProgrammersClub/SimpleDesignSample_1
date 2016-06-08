﻿using System;
using System.Collections.Generic;

namespace StudentRecord_NotLayered_Console
{
	class Program
	{
		private static StudentRecordsManager _studentRecordsManager = new StudentRecordsManager();
		private static ConsoleColor _originalConsoleForgroundColor = Console.ForegroundColor;

		static void Main(string[] args)
		{
			Console.WriteLine("=== STUDENT RECORDS ===\n");
			DisplayInstructions();

			do
			{
				string input = Console.ReadLine();
				string[] inputs = input.Split();
				string command = inputs[0];

				switch (command)
				{
					case "enrol":
						bool hasTwoArguments = inputs.Length >= 3;
						if (hasTwoArguments)
						{
							string firstName = inputs[1];
							string lastName = inputs[2];
							EnrollStudent(firstName, lastName);
						}
						break;

					case "expel":
						int idOfStudentToBeExpelled;
						bool hasOneArgument = inputs.Length >= 2;
						bool isArgumentAnInteger = int.TryParse(inputs[1], out idOfStudentToBeExpelled);
						if (hasOneArgument && isArgumentAnInteger)
						{
							ExpelStudent(idOfStudentToBeExpelled);
						}
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
						DisplayError("Command unrecognized");
						break;
				}

			} while (true);
		}

		private static void EnrollStudent(string firstName, string lastName)
		{
			try
			{
				_studentRecordsManager.EnrollStudent(firstName, lastName);
				DisplayMessage("Student successfully enrolled");
			}
			catch (Exception ex)
			{
				DisplayError(ex.Message);
			}
		}

		private static void ExpelStudent(int idOfStudentToBeExpelled)
		{
			Student studentToBeExpelled = _studentRecordsManager.FindStudent(idOfStudentToBeExpelled);
			if (studentToBeExpelled == null)
			{
				DisplayError(string.Format("Student with ID \"{0}\" is not found", idOfStudentToBeExpelled));
				return;
			}

			_studentRecordsManager.ExpellStudent(studentToBeExpelled);
			DisplayMessage(string.Format("Student with ID \"{0}\" successfully expelled", idOfStudentToBeExpelled));
		}

		private static void ListStudents()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			List<Student> students = _studentRecordsManager.GetAllStudents();
			if (students.Count <= 0)
			{
				Console.WriteLine("No student record to display.\n");
			}
			else
			{
				foreach (Student student in students)
				{
					Console.WriteLine("{0}. {1} {2}", student.Id, student.FirstName, student.LastName);
				}
				Console.WriteLine();
			}
			Console.ForegroundColor = _originalConsoleForgroundColor;
		}

		private static void DisplayInstructions()
		{
			Console.WriteLine(@"
	Please type your command:
	  ENROL [First name] [Last name] -> to enrol a student
	  EXPEL [Student ID]             -> to expel a student
	  LIST                           -> to view all students
	  ?                              -> to display the available commands
	  QUIT                           -> to end the application");
			Console.Write("\n\n");
		}

		private static void DisplayMessage(string message)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(message);
			Console.WriteLine();
			Console.ForegroundColor = _originalConsoleForgroundColor;
		}

		private static void DisplayError(string errorMessage)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(errorMessage);
			Console.WriteLine();
			Console.ForegroundColor = _originalConsoleForgroundColor;
		}
	}
}