using System.Collections.Generic;

namespace StudentRecord_NotLayered_WinForms
{
	public class StudentRecords
	{
		private static List<Student> _listOfStudents = new List<Student>();

		public void Add(string firstName, string lastName)
		{
			Student newStudent = new Student();
			newStudent.FirstName = firstName;
			newStudent.LastName = lastName;
			_listOfStudents.Add(newStudent);
		}

		public void RemoveAt(int index)
		{
			_listOfStudents.RemoveAt(index);
		}

		public List<Student> GetAllStudents()
		{
			return _listOfStudents;
		}
	}
}
