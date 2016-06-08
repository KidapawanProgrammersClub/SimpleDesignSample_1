using System;
using System.Collections.Generic;

namespace StudentRecord_NotLayered_Spaghetti_Simple
{
	public class Student
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			List<Student> _listOfStudents = new List<Student>();

			Console.WriteLine("=== STUDENT RECORDS ===\n");
			Console.WriteLine(@"
	Please type your command:
	  ENROL [First name] [Last name] -> to enrol a student
	  EXPEL [Student ID]             -> to expel a student
	  LIST                           -> to view all students
	  QUIT                           -> to end the application");
			Console.Write("\n\n");

			do
			{
				string input = Console.ReadLine();
				string[] inputs = input.Split();
				string command = inputs[0];

				switch (command)
				{
					case "enrol":
						Student newStudent = new Student();
						newStudent.Id = _listOfStudents.Count;
						newStudent.FirstName = inputs[1];
						newStudent.LastName = inputs[2];
						_listOfStudents.Add(newStudent);
						Console.WriteLine("Student successfully enrolled\n");
						break;

					case "expel":
						int idOfStudentToBeExpelled = int.Parse(inputs[1]);
						// Find student with given ID
						Student studentToBeExpelled = null;
						foreach (Student currentStudent in _listOfStudents)
						{
							if (currentStudent.Id == idOfStudentToBeExpelled)
							{
								studentToBeExpelled = currentStudent;
							}
						}
						if (studentToBeExpelled != null)
						{
							_listOfStudents.Remove(studentToBeExpelled);
						}
						Console.WriteLine("Student with ID \"{0}\" successfully expelled\n", idOfStudentToBeExpelled);
						break;

					case "list":
						foreach (Student student in _listOfStudents)
						{
							Console.WriteLine("{0}. {1} {2}", student.Id, student.FirstName, student.LastName);
						}
						Console.WriteLine();
						break;

					case "quit":
						return;

					default:
						Console.WriteLine("Command unrecognized\n");
						break;
				}

			} while (true);
		}
	}
}
