namespace Inheritance
{
    class EmployeeQA : Employee
    {
        public string Position = "QA Engineer";

        public EmployeeQA(string name, string position)
        {
            Name = name;
            Position = position;
        }
    }
}