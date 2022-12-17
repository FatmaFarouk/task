using System;

// public class FatmaException {}
public class Person 
{
    private string _name;

    // public string Name {get; set;}
    
    private int _age;

    public Person(string name, int age) 
    {
        // if (name == "Fatma") throw new FatmaException();

        if (name == null || name == "" || name.Length >= 32) {
            
            // Console.WriteLine("Invalid Name");
            // return;

            throw new Exception("Invalid Name");
            // var ex = new Exception("Invalid Name");
            // throw ex;

            // var i = 3 / age;
            // throw new NullReferenceException("Invalid Name");
        }

        if (age <= 0 || age > 128) {
            // Console.WriteLine("invalid age");
            // return;

            throw new Exception("Invalid Age");
        }

        _name = name;
        _age = age;
    }

    public string GetName() => _name;
    public int GetAge() => _age;

    public void SetName(String name) {

        if (name == null || name == "" || name.Length >= 32) {

            throw new Exception("Invalid Name");

        }

        _name = name;
    }

    public virtual void print() {
        Console.WriteLine($"my name is {_name}, my age is {_age}");
    }
}

public class Student : Person 
{
    string Name;
    int Age;
    int Year;
    float Gpa;
    public Student (string name, int age, int year, float gpa) : base(name, age) 
    {

        if (year < 1 || year > 5) {

            throw new Exception("Invalid Year");
        }

        if (gpa < 0 || gpa > 4) {

            throw new Exception("Invalid Gpa");
        }

        Name = name;
        Age = age;
        Year = year;
        Gpa = gpa;
    }

    public override void print()
    {
        Console.WriteLine($"My Name is {GetName()}, my age is {GetAge()}, and gpa is {Gpa}");
    }
}

public class Database 
{

    private int _currentIndex;
    public Person[] people = new Person[50];

    public void AddStudent (Student student)
    {
        // people[0] = student;
        people[_currentIndex++] = student; 
    }

    public void AddStaff (Staff staff) 
    {
        people[_currentIndex++] = staff;
    }

    public void AddPerson (Person person) 
    {
        people[_currentIndex++] = person;
    }

    public void printAll() {
        for (var i = 0; i < _currentIndex ; i++) 
        {
            people[i].print();
        }
    }
}

public class Staff : Person 
{

    string Name;
    int Age;
    double Salary;
    int JoinYear;
    public Staff (string name, int age, double salary, int joinYear) : base(name, age)
    {

        if (salary < 0 || salary > 120000) {

            throw new Exception("Invalid salary");
        }

        var AGE = (2022 - Age);
        if (AGE <= 21) {

            throw new Exception("Invalid JoinYear");
        }

        Name = name;
        Age = age;
        Salary = salary;
        JoinYear = joinYear;
    }
    public override void print()
    {
        Console.WriteLine($"My Name is {GetName()}, my age is {GetAge()}, and my salary is {Salary}");
    }
}



public class program 
{
    private static void Main(String[] args) 
    {
        
        var database = new Database();

        while (true) 
        {
            Console.WriteLine("1) Student  2) Staff  3) Person 4) Print All");

            var option = Convert.ToInt32(Console.ReadLine());

            switch (option) 
            {
                case 1 :
                    Console.Write("Name: ");
                    var name = Console.ReadLine();

                    Console.Write("Age: ");
                    var age = Convert.ToInt32(Console.ReadLine());

                    // Console.Write("year: ");
                    // var year = Convert.ToInt32(Console.ReadLine());

                    // Console.Write("Gpa: ");
                    // var gpa = Convert.ToSingle(Console.ReadLine());

                    Console.Write("Salary: ");
                    var salary = Convert.ToSingle(Console.ReadLine());

                    Console.Write("JoinYear: ");
                    var joinYear = Convert.ToInt32(Console.ReadLine());

                    // var student = new Student(name, age, year, gpa);
                    var staff = new Staff(name, age, salary, joinYear);

                    // database.AddStudent(student);
                    database.AddStaff(staff); 
                    break;

                case 2 :
                    Console.Write("Name: ");
                    var name2 = Console.ReadLine();

                    Console.Write("Age: ");
                    var age2 = Convert.ToInt32(Console.ReadLine());

                    // Console.Write("year: ");
                    // var year = Convert.ToInt32(Console.ReadLine());

                    // Console.Write("Gpa: ");
                    // var gpa = Convert.ToSingle(Console.ReadLine());

                    Console.Write("Salary: ");
                    var salary2 = Convert.ToSingle(Console.ReadLine());

                    Console.Write("JoinYear: ");
                    var joinYear2 = Convert.ToInt32(Console.ReadLine());

                    // var student2 = new Student(name2, age2, year, gpa);
                    var staff2 = new Staff(name2, age2, salary2, joinYear2);

                    // database.AddStudent(student2);
                    database.AddStaff(staff2);
                    break;
                
                case 3 : 
                    Console.Write("Name: ");
                    var name3 = Console.ReadLine();

                    Console.Write("Age: ");
                    var age3 = Convert.ToInt32(Console.ReadLine());

                    // var person = new Person(name3, age3);

                    try {

                        // statements ==> expected to throw exception

                        var person = new Person(name3, age3);
                        person.SetName(null);
                        database.AddPerson(person);
                    }

                    // catch (DivideByZeroException)
                    // {
                    //     Console.WriteLine("Zero Age");
                    // }

                    catch (Exception e) {

                        Console.WriteLine(e.Message); 
                    }

                    // database.AddPerson(person);
                    break;

                case 4 :
                    database.printAll();
                    break;

                default: 
                    return;
            }
        }
    }
}
