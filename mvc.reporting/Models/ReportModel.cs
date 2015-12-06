namespace mvc.reporting.Models
{
    public class ReportModel
    {
        public string Name { get; set; }
        public int Age  { get; set; }

        public ReportModel(string name, int age)
        {
            Name = name;
            Age  = age;
        }
    }
}