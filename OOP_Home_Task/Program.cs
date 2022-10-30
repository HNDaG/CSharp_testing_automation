using System;

namespace OOP_Home_Task
{
    internal class Program
    {
        class Company
        {
            public string Brand { get; set; }
            public void Display()
            {
                Console.WriteLine($"Property of {Brand}\n");
            }
            public Company(string Brand)
            {
                this.Brand = Brand;
            }
        }

        class Product : Company
        {
            public string Type { get; set; }
            public double Weight { get; set; }
            public DateTime DateProduced { get; set;  }

            public Product(string Brand, string Type, double Weight) : base(Brand)
            {
                this.Type = Type;
                this.Weight = Weight;
                this.DateProduced = DateTime.Now;
            }
            new public void Display()
            {
                Console.WriteLine($"Brand: {this.Brand}\nType: {this.Type}\n Weight: {this.Weight}\nProduction date: {this.DateProduced.Date}");
            }
        }

        class MobilePhone: Product
        {
            private string _serialNumber { get; set; }
            public string Model;
            public double ScreenIn;
            public double CameraMx;
            public double MemoryGb;

            public MobilePhone(string Brand, string Type, double Weight, string Model, double ScreenIn, double CameraMx, double MemoryGb, string _serialNumber) : base(Brand, Type, Weight)
            {
                this.Model = Model;
                this.ScreenIn = ScreenIn;
                this.CameraMx = CameraMx;
                this.MemoryGb = MemoryGb;
            }

            new public void Display()
            {
                Console.WriteLine($"Brand: {this.Brand}\nType: {this.Type}\nModel: {this.Model}\nScreen: {this.ScreenIn}\n" +
                    $"CameraMx: {this.CameraMx}\nMemoryGb: {this.MemoryGb} Weight: {this.Weight}\nProduction date: {this.DateProduced.Date}\n");
            }

        }

        class WorkPosition: Company
        {
            public string Position;

            public WorkPosition(string Company, string Position): base(Company) { this.Position = Position; }

            public void Hello()
            {
                Console.WriteLine($"Hello from {this.Position}, I'm working in {this.Brand}!!!");
            }
        }

        class Employee: WorkPosition
        {
            public string Name;
            private double Salary { get; set; }
            public double StageMounths;

            public Employee(string name, double salary, double stageMounths, string Company, string Position): base(Company, Position)
            {
                this.Name = name;
                this.Salary = salary;
                this.StageMounths = stageMounths;
            }
        }


        static void Main(string[] args)
        {
            Company Apple = new Company("Apple");
            Apple.Display();

            MobilePhone Iphone11 = new MobilePhone("Apple", "Mobile phone", 350, "11proMax", 8, 16, 64, "dvausyvcuUAHSJVLCSUYH");
            Iphone11.Display();

            Employee Alex = new Employee("Alex", 2000, 12, "Ford", "CO");
            Alex.Hello();
        }
    }
}
