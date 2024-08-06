using System;
using System.Collections.Generic;

// Apstraktna klasa Person
public abstract class Person
{
    public string Ime { get; set; }
    public int GodineStarosti { get; set; }

    public Person(string ime, int godineStarosti)
    {
        Ime = ime;
        GodineStarosti = godineStarosti;
    }
}

// Interfejs IPayable
public interface IPayable
{
    void Earn(double iznos);
    void Spend(double iznos);
}

// Klasa Employee
public class Employee : Person, IPayable
{
    public int Staz { get; set; }
    public double BankovniRacun { get; private set; }

    // Konstruktor
    public Employee(string ime, int godineStarosti, int staz)
        : base(ime, godineStarosti)
    {
        Staz = staz;
        BankovniRacun = 200000;

        // Pozivanjem ove metode, trenutna instanca Employee se dodaje u statičku listu employees u klasi EmployeeDbFake
        //u konstruktoru, this referencira trenutnu instancu klase Employee da bi metoda AddEmployee znala koji objekat treba dodati u svoju listu.
        EmployeeDbFake.AddEmployee(this);
    }

    public void Earn(double iznos)
    {
        Console.WriteLine($" Osoba {Ime} ima {GodineStarosti} godina i {Staz} godine staza.");

        if (iznos > 0)
        {
            BankovniRacun += iznos;
            Console.WriteLine($"{Ime} je zaradio {iznos} dinara. Trenutno stanje: {BankovniRacun} dinara.");
        }
        else
        {
            Console.WriteLine("Iznos mora biti pozitivan.");
        }
    }

    public void Spend(double iznos)
    {
        if (iznos > 0 && iznos <= BankovniRacun)
        {
            BankovniRacun -= iznos;
            Console.WriteLine($"{Ime} je potrošio {iznos} dinara. Trenutno stanje: {BankovniRacun} dinara.");
        }
        else if (iznos > BankovniRacun)
        {
            Console.WriteLine("Transakcija nije moguća. Nemate dovoljno sredstava na računu.");
        }
        else
        {
            Console.WriteLine("Iznos mora biti pozitivan.");
        }
       
    }
}

// Klasa EmployeeDbFake koja imitira bazu podataka
public static class EmployeeDbFake
{
    // Staticka lista za cuvanje svih objekata Employee
    private static List<Employee> zaposleni = new List<Employee>();

    // Metoda za dodavanje zaposlenog u listu
    public static void AddEmployee(Employee employee)
    {
        zaposleni.Add(employee);
    }

    // Metoda za ispis imena svih zaposlenih
    public static void PrikaziImenaZaposlenih()
    {
        foreach (var employee in zaposleni)
        {
            Console.WriteLine(employee.Ime);
        }
    }
}

// Klasa za testiranje/proveru koda
class Provera 
{
    static void Main()
    {
        // Kreiranje objekata Employee
        Employee employee1 = new Employee("Milovan", 30, 5);
        Employee employee2 = new Employee("Jelena", 25, 3);
        Employee employee3 = new Employee("Marko", 40, 11);
        Employee employee4 = new Employee("Petar", 43, 10);
        Employee employee5 = new Employee("Ana", 50, 9);
        Employee employee6 = new Employee("Filip", 20, 1);
       
        // Pozivanje metoda za rad sa zaposlenima

        employee1.Earn(885750000);
        employee1.Spend(56700000);
        employee1.Spend(498982473500);
        employee1.Spend(-1000000);


        employee2.Earn(10000);
        employee2.Spend(100000);
        employee2.Spend(300000);
        employee2.Spend(-1000000);



        employee3.Earn(60000);
        employee3.Spend(100000);
        employee3.Spend(900000);
        employee3.Spend(-1000000);


        employee4.Earn(100000);
        employee4.Spend(600000);
        employee4.Spend(300000);
        employee4.Spend(-1000000);

        employee5.Earn(00000);
        employee5.Spend(100000);
        employee5.Spend(300000);
        employee5.Spend(-1000000);

        employee6.Earn(7770000);
        employee6.Spend(100000);
        employee6.Spend(300000);
        employee6.Spend(-1000000);


        // Ispis imena svih zaposlenih
        Console.WriteLine("Ovo su imena svih zaposlenih:");
        EmployeeDbFake.PrikaziImenaZaposlenih();
    }

    class TestClass
    {
        //implementation
    }
}