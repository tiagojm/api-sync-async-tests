using System;

namespace netcore_3._1_api_performance_tests.Models
{
    public class Employee
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime OnBoardDate { get; set; }
        public string PicturePath { get; set; }

        public Employee(int id)
        {
            this.Id = id;
            this.PicturePath = $"images/employee/image-{this.Id}.png";
        }

        public Employee()
        {
            this.Id = 1;
            this.PicturePath = $"images/employee/image-{this.Id}.png";
        }

        public Employee(string name, DateTime birthDate, DateTime onBoardDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
            this.OnBoardDate = onBoardDate;
        }
    }
}
