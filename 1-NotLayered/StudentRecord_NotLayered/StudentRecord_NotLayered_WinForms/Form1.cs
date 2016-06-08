using System;
using System.Windows.Forms;

namespace StudentRecord_NotLayered_WinForms
{
	public partial class Form1 : Form
	{
		private static StudentRecordsManager _studentRecordsManager = new StudentRecordsManager();

		public Form1()
		{
			InitializeComponent();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				_studentRecordsManager.EnrollStudent(txtFirstName.Text, txtLastName.Text);
				dataGridViewStudents.DataSource = null;
				dataGridViewStudents.DataSource = _studentRecordsManager.GetAllStudents();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{

			int idOfStudentToBeExpelled;
			bool isInputAnInteger = int.TryParse(txtIdOfStudentToExpel.Text, out idOfStudentToBeExpelled);
			if(!isInputAnInteger)
			{
				MessageBox.Show("Please enter an integer for the ID of the student to be expelled.");
				return;
			}

			Student studentToBeExpelled = _studentRecordsManager.FindStudent(idOfStudentToBeExpelled);
			if (studentToBeExpelled == null)
			{
				MessageBox.Show(string.Format("Student with ID \"{0}\" is not found", idOfStudentToBeExpelled));
				return;
			}

			_studentRecordsManager.ExpellStudent(studentToBeExpelled);
			dataGridViewStudents.DataSource = null;
			dataGridViewStudents.DataSource = _studentRecordsManager.GetAllStudents();
		}
	}
}
