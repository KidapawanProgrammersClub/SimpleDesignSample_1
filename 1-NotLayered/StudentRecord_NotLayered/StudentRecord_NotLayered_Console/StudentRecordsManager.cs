using System.Collections.Generic;

namespace StudentRecord_NotLayered_Console
{
	// They say not to name a class as "Manager". Pardon it's use here because I don't know what to name this class.
	public class StudentRecordsManager
	{
		private static List<Student> _listOfStudents = new List<Student>();

		public void EnrollStudent(string firstName, string lastName)
		{
			// Validation
			// NOTE: I do not yet know the best way to do validation here... so I will just throw an exception for now.
			if (firstName.ToLower() == "hudas" || lastName.ToLower() == "hudas")
			{
				throw new System.Exception("A student name cannot have \"Hudas\" in his name");
			}
			Student newStudent = new Student();
			newStudent.Id = GenerateNewStudentID();
			newStudent.FirstName = firstName;
			newStudent.LastName = lastName;
			_listOfStudents.Add(newStudent);
		}

		public void ExpellStudent(Student studentToBeExpelled)
		{
			bool isSuccessfullyRemoved = _listOfStudents.Remove(studentToBeExpelled);
			if(!isSuccessfullyRemoved)
			{
				throw new System.Exception(string.Format("Student with id \"{0}\" does not exist.", studentToBeExpelled.Id));
			}
		}

		public Student FindStudent(int studentID)
		{
			Student currentStudent = null;
			foreach (Student stud in _listOfStudents)
			{
				if (stud.Id == studentID)
				{
					currentStudent = stud;
				}
			}
			return currentStudent;
		}

		public List<Student> GetAllStudents()
		{
			return _listOfStudents;
		}

		private int GenerateNewStudentID()
		{
			return _listOfStudents.Count;
		}
	}
}
