namespace Inheritance
{
    class EmployeeSE : Employee
    {
        public string Position = "Software Engineer";

        public EmployeeSE(string name, string position)
        {
            Name = name;
            Position = position;
        }
    }
}