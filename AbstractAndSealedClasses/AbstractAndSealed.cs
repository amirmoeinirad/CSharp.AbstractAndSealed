
// Amir Moeini Rad
// August 12, 2025

// Main Concepts: Abstract Class & Sealed Class.
// This example code demonstrates the use of abstract and sealed classes in C#.NET.
// Other Concepts: Inheritance, Constructors, Method Overriding.


using System;


namespace AbstractAndSealedClasses
{
    // The following is a documentation comment which is used to generate XML documentation for the code.
    // These documentations can be viewed in IntelliSense in Visual Studio.
    // To Test, hover over the Person class name.
    // <summary> ... </summary> tags provide a summary of a class or method.
    /// <summary>
    /// A Custom Person Class
    /// </summary>

    // Abstract classes cannot be instantiated directly.
    // They are usually used as base classes for other classes (in inheritance hierarchy).
    // They just provide a general concept and template for derived classes.
    internal abstract class Person
    {
        // Fields
        // Protected fields can be only accessed by derived classes.
        protected string firstName;
        protected string lastName;


        // Default Constructor
        // The default constructor takes no parameters.
        // A constructor is a special method that is called when an object of the class is created.
        // It is used to initialize the object's fields or perform any setup required for the object.
        // Block-Body Style (older)
        public Person()
        {
            Console.WriteLine("Person class's default constructor...");
        }
        // Expression-Body Style (newer)
        // '=>' is the lambda operator.
        // The new style for a method definition is implemented using the lambda expression syntax.
        // public Person() => Console.WriteLine("Person class's default constructor...");


        // Custom Constructor
        // A custom constructor takes parameters to initialize the object's fields.
        public Person(string fn, string ln)
        {
            Console.WriteLine("Person class's custom constructor...");

            firstName = fn;
            lastName = ln;
        }


        // Method
        // Abstract classes can have both abstract and non-abstract (concrete) methods.
        // Abstract methods must be implemented in the subclasses.
        // Concrete methods have a body and provide functionality.
        public abstract void DisplayFullName();
    }



    ///////////////////////////////////////////////



    /// <summary>
    /// Employee Class
    /// </summary>

    // Sealed classes cannot be inherited, but can be instantiated.
    // The Employee and Contractor classes are sealed, meaning they cannot be further subclassed.
    // Sealed classes are often used to prevent further inheritance for security or design reasons.
    internal sealed class Employee : Person
    {
        // Field
        // Difference between 'const' and 'readonly':
        // 'const' fields must be initialized at the time of declaration and cannot be changed later.
        // 'readonly' fields can be initialized either at the time of declaration or in the constructor, and cannot be changed afterwards.
        private readonly ushort hireYear;


        // Default Constructor
        // 'base' means calling the base class's constructor.
        // So, the base class's default constructor is called first.
        // If not explicitly called, the base class's default constructor is called implicitly.
        // So, 'base()' can be safely omitted here.
        public Employee() : base() 
        {
            Console.WriteLine("Employee subclass's default constructor...\n");
        }


        // Custom Constructor
        // 'fn' and 'ln' are passed to the base class's constructor to initialize the 'firstName' and 'lastName' fields.
        // Then, Employee inherits the 'firstName' and 'lastName' fields from Person.
        // Here, base() cannot be omitted because we are calling the base class's custom constructor with parameters.
        public Employee(string fn, string ln, ushort hy) : base(fn, ln)
        {
            Console.WriteLine("Employee subclass's custom constructor...\n");

            hireYear = hy;
        }


        // Implementing or overriding the base-class abstract method.
        // The 'override' keyword is used to indicate that this method is overriding a base class method.
        // 'override' is part of the inheritance and polymorphism concepts in OOP.
        // If 'override' is not used, a compile-time error will occur.
        public override void DisplayFullName()
        {
            Console.WriteLine("Employee: {0} {1}. Hiring Year: {2}", firstName, lastName, hireYear);
        }
    }



    ///////////////////////////////////////////////



    /// <summary>
    /// Contractor Class
    /// </summary>

    internal sealed class Contractor : Person
    {
        // Field
        private readonly string companyName;


        // Default Constructor
        public Contractor() : base()
        {
            Console.WriteLine("Contractor subclass's default constructor...\n");
        }


        // Custom Constructor
        // Passing 'fn' and 'ln' to the base class's constructor to initialize the 'firstName' and 'lastName' fields.
        public Contractor(string fn, string ln, string cn) : base(fn, ln)
        {
            Console.WriteLine("Contractor subclass's custom constructor...\n");

            companyName = cn;
        }


        // Implementing or overriding the base-class abstract method.
        public override void DisplayFullName()
        {
            Console.WriteLine("Contractor: {0} {1}. Company Name: {2}", firstName, lastName, companyName);
        }
    }



    ///////////////////////////////////////////////



    /// <summary>
    /// NameApp Class (Running Application Class)
    /// </summary>

    class NameApp
    {
        public static void Main()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Abstract and Sealed Classes in C#.NET.");
            Console.WriteLine("--------------------------------------\n");
            
            Console.WriteLine("In Main()...\n");

            // Person Brad = new Person("Bradley", "Jones"); // Abstract classes cannot be instantiated!

            // An Employee object can be both of type Person and Employee.
            Person employee1 = new Employee("Bradley", "Jones", 1983);
            Employee employee2 = new Employee("Bradley", "Jones", 1983);

            Console.WriteLine("------\n");

            // A Contractor object can be both of type Person and Contractor.
            Person contractor1 = new Contractor("Bryce", "Hatfield", "EdgeQuest");
            Contractor contractor2 = new Contractor("Bryce", "Hatfield", "EdgeQuest");

            Console.WriteLine("------\n");

            // Calling the overridden method from the Employee class.
            // Both 'employee1' and 'employee2' can call the DisplayFullName method, but 'employee1' is of type Person.
            employee1.DisplayFullName();
            employee2.DisplayFullName();

            Console.WriteLine();

            // Calling the overridden method from the Contractor class.
            // Both 'contractor1' and 'contractor2' can call the DisplayFullName method, but 'contractor1' is of type Person.
            contractor1.DisplayFullName();
            contractor2.DisplayFullName();

            Console.WriteLine("\nDone.");
        }
    }   
}
