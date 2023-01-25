
public class A
{
    public virtual void MethodA()
    {
        Console.WriteLine("Class A - Method A");
    }
}
public class B : A
{
    public override void MethodA()
    {
        Console.WriteLine("Class B - Method A - Override Method");
    }
    public void MethodB()
    {
        Console.WriteLine("Class B - Method B");
    }
}

 interface IA
{
    void MethodA();
    void MethodC();
}
public class C : IA
{
    public void MethodA()
    {
        Console.WriteLine("Class C - Method A - Interface Implementation");
    }
    public void MethodC()
    {
        Console.WriteLine("Class C - Method C  - Interface Implementation");
    }
}

public abstract class AbstractX
{
     public abstract void AbMethod();
}

public class Y: AbstractX
{
    
    public override void AbMethod()
    {
        Console.WriteLine("SubClass Y - Method AB  - abstract method Implementation");
    }
}

public interface IEmployee
{
    void Save();
}
public interface ICustomer
{
    void Save();
}
public class OfficeData : IEmployee, ICustomer
{
    void IEmployee.Save()
    {
        Console.WriteLine("Save OfficeData - Employee");
    }

    void ICustomer.Save()
    {
        Console.WriteLine("Save OfficeData - Customer");
    }
}

public class Employee : IEmployee
{
    void IEmployee.Save()
    {
        Console.WriteLine("Save EmployeeData - Explicit Call");
    }
}

public class EmployeeConstruct
{
    string fname;
    string lname;
    public EmployeeConstruct()//Default Constructor
    {

    }
    public EmployeeConstruct(string fname, string lname)// Parameterized Constructor
    {
        this.fname = fname;
        this.lname = lname;
    }

    public EmployeeConstruct(EmployeeConstruct emp)
    {
        this.fname = emp.fname;
        this.lname = emp.lname;

    }
    public void Print()
    {
        Console.WriteLine(this.fname+" "+this.lname);
    }
}

public class EmployeePrivateConstruct
{
    public static string fname;
    public static string lname;
    private EmployeePrivateConstruct()
    {

    }
}

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Comsole Class A Obj--");
            A objA = new A();
            objA.MethodA();

            Console.WriteLine("--Comsole Class B Obj--");
            B objB = new B();
            objB.MethodA();
            objB.MethodB();

            Console.WriteLine("-- SuperClass obj = SubClass()--");
            // SuperClass obj = new SubClass();
            A obj = new B();
            obj.MethodA();
            // value of obj is B but property is A
            //value is on right and property on left/ int x= 10;
            // by default it can only access methods of A (property)

            Console.WriteLine("-- SuperClass obj = SubClass()-- Casting");
            // to access the methods of value , we have to use casting
            //Two ways of casting 
            ((B)obj).MethodB();
            (obj as B).MethodB();

            Console.WriteLine("--Interface I = Subclass()--");
            IA objAC = new C();
            objAC.MethodA();
            objAC.MethodC();

            Console.WriteLine("--Abstract Class--");
            // Abstarct class is half defined parent/ base class
            // AbstractX abstractX = new AbstractX(); - This will not work since class is abstract
            // Some logic and be defined and some cannot 
            // They are inherited
            // Cannot do multiple inheritance for abstract or concrete class
            AbstractX y = new Y();
            y.AbMethod();

            Y directY = new Y();
            directY.AbMethod();

            Console.WriteLine("--Interfaces--");
            // Interfaces just have signature / Its is like a contract
            // All methods of interfaces are public
            // No implementation/ logic - so developer can focus on pure abstraction / Its like a planning phase
            // Interfaces are implementated  
            // Multiple Inheritance support
            // Multiple Inhertiance with class as 1 value eg. public class D: A(always 1st), IB, IC 

            // Save method in two interface - explicit implementation is use
            IEmployee emp = new OfficeData();
            emp.Save(); // Explicit interfaces are called inside officedata

            ICustomer cus = new OfficeData();
            cus.Save(); // Explicit interfaces are called inside officedata

            // Explicitly called interface methods
            Employee emp2 = new Employee();
            //emp2.Save() -> This will not work since interface methods are called explicitly eg void IEmployee.Save() { .. }
            IEmployee emp3 = new Employee();
            emp3.Save();

            // method of interfaces are public - no access modifiers
            // no intance can be created
            // no constructor can be created
            // can have properties int Id { get; set; }
            // one interface can inherit another interface

            Console.WriteLine("--Constructors--");
            // Constructor is a method / no return type / name should match class name
            // Default constru is called when no construc is defined / atleast one constructor is present
            // Constrcutor are responsible for object initialization and memory allocation of class
            // 5 Types - Default, Parameterized, Copy, Static, Private

            // Parameterized Construct -> overloading, add default too

            EmployeeConstruct empParam = new EmployeeConstruct("Ajinkya","Desai");
            empParam.Print();

            // Copy Constructor -> initialze new instance to the values of existing instance
            EmployeeConstruct emp1Copy = new EmployeeConstruct("Copy-Ajinkya", "Copy-Desai");
            EmployeeConstruct emp2Copy = new EmployeeConstruct(emp1Copy);
            emp2Copy.Print();

            // Private -> if we have only static member in class / singleton design pattern
            // Instance cant be created/ Cant be inherited / No Default due to overloading issue
            EmployeePrivateConstruct.fname = "Ajinkya";
            
            // Static Constructor -> When create 1st instance of class static constructor is called.
            // no access modifier/ parameterless
            // only once its call during the execution of the application
            // 1st static is called then default -> second time only default is called
            // Use -> To initialize the static variable

            // Baseclass constructor - > childclass constructor
            // Ways to call baseclass constructor from childclass constructor
            // > public Employee(): base() -> call default baseclass constr
            // > public Employee(): base(10) -> call param baseclass constr from default childclass constr
            // > public Employee(int a): base(a) -> call param baseclass constr from param childclass constr

            // Polymorphism
            // virtual method is not override in child - > code complies
            // new keyword -> method hiding -> hide the base class method / method define is independent of base class
            // override -> override the virtual method/ baseclass method
            // seal(method) -> can be use with override method / prevent method to be further overriden 

        }
    }
}