namespace Project1StudentManagment
{
    class MarkCompare : IComparer<StudentWithTotalMark>
    {
        public int Compare(StudentWithTotalMark x, StudentWithTotalMark y)
        {
            // Compare based on TotalMarks
            return y.TotalMark.CompareTo(x.TotalMark);
        }
    }
}
