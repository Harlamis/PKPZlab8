using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
namespace Task1
{
    public partial class MainWindow : Window
    {
        private List<StudentEntry> students = new List<StudentEntry>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                MessageBox.Show("Please enter a surname.", "Input Error");
                return;
            }
            if (!double.TryParse(txtGpa.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double gpa))
            {
                MessageBox.Show("Please enter a valid GPA (e.g., 4.5).", "Input Error");
                return;
            }

            string surname = txtSurname.Text;
            bool isPaid = chkIsPaid.IsChecked ?? false;
            bool retookExams = chkRetookExams.IsChecked ?? false;

            StudentEntry newStudent = new StudentEntry(surname, gpa, isPaid, retookExams);

            students.Add(newStudent);

            lstStudents.Items.Add(newStudent.ToString());

            txtSurname.Clear();
            txtGpa.Clear();
            chkIsPaid.IsChecked = false;
            chkRetookExams.IsChecked = false;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int count = Tuple.CalculateScholarships(students);

            tbResult.Text = $"Amount of scholarships: {count}";
        }

    }
}
