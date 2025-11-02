namespace Task1
{
    public readonly record struct StudentEntry(string Surname, double Gpa, bool IsPaid, bool RetookExams);
    public class Tuple
    {
        public static bool IsGonnaTakeScholarship(StudentEntry student)
        {
            if ((student.Gpa >= 4.5) && (!student.IsPaid) && (!student.RetookExams))
            {
                return true;
            }
            return false;
        }
        public static int CalculateScholarships(List<StudentEntry> students)
        {
            int count = 0;
            foreach (StudentEntry student in students)
            {
                if (IsGonnaTakeScholarship(student))
                {
                    count++;
                }
            }
            return count;
        }
    }
}