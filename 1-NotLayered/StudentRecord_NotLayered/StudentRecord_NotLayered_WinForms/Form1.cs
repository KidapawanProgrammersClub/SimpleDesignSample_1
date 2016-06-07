using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRecord_NotLayered_WinForms
{
	public partial class Form1 : Form
	{
		private static StudentRecords _studentRecords = new StudentRecords();

		public Form1()
		{
			InitializeComponent();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			_studentRecords.Add(txtFirstName.Text, txtLastName.Text);
			dataGridViewStudents.DataSource = null;
			dataGridViewStudents.DataSource = _studentRecords.GetAllStudents();
			//MessageBox.Show("Student successfully added");
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			int indexOfStudentToBeRemoved = int.Parse(txtIndex.Text);
			_studentRecords.RemoveAt(indexOfStudentToBeRemoved);
			dataGridViewStudents.DataSource = null;
			dataGridViewStudents.DataSource = _studentRecords.GetAllStudents();
			//MessageBox.Show(string.Format("Student \"{0}\" successfully removed\n", indexOfStudentToBeRemoved));
		}
	}
}
