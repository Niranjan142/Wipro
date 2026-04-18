using System;
using System.Configuration;

class Student
{
    // Define properties
    // Complete Step 1:............
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }

    // Define constructor
    // Complete Step 2:............
    public Student(String name, int age, String grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user to enter student details
        Console.WriteLine("Enter student's name:");
        // Complete Step 3:............
        string name = Console.ReadLine();
        Console.WriteLine("Enter student's age:");
        // Complete Step 4:............
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter student's grade:");
        // Complete Step 5:............
        string grade = Console.ReadLine();
        // Create an instance of the Student class
        // Complete Step 6:............
        Student student = new Student(name,age,grade);
        // Print student details
        // Complete Step 7:............
        Console.WriteLine("Student Name: "+student.Name);
        Console.WriteLine("Student Age: "+student.Age);
        Console.WriteLine("Student Grade: "+student.Grade);
    }
}