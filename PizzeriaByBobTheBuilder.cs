using System;
namespace Pizzerka;

//Interface pro pizzerku


interface Pizzar
{
    void Těsto();
    void Základ();
    void Sýr();
    void Přísady();
    string GetPrice();
}

// Pizza Menu pro 1. restauraci 

class PizzaMenu1 : Pizzar
{
    public void Těsto()
    {
        Console.WriteLine("Těsto pro Margherita pizzu");
    }

    public void Základ()
    {
        Console.WriteLine("Základ pro Margherita pizzu");
    }

    public void Sýr()
    {
        Console.WriteLine("Sýr pro Margherita pizzu");
    }

    public void Přísady()
    {
        Console.WriteLine("Přísady pro Margherita pizzu");
    }

    public string GetPrice()
    {
        return "5.99 $";
    }
}

//Pizza Menu pro 2. restauraci

class PizzaMenu2 : Pizzar
{
    public void Těsto()
    {
        Console.WriteLine("Těsto pro Fromaggi pizzu");
    }

    public void Základ()
    {
        Console.WriteLine("Základ pro Fromaggi pizzu");
    }

    public void Sýr()
    {
        Console.WriteLine("Sýr pro Fromaggi pizzu");
    }

    public void Přísady()
    {
        Console.WriteLine("Přísady pro Fromaggi pizzu");
    }

    public string GetPrice()
    {
        return "6.99 $";
    }
}

//Produkty pizza makerů
class Restaurace1
{
    Pizzar pizzar;
    public Restaurace1(Pizzar pizzar)
    {
        this.pizzar = pizzar;
    }

    public void VytvořitPizzu()
    {
        pizzar.Těsto();
        pizzar.Základ();
        pizzar.Sýr();
        pizzar.Přísady();
    }
}


class Restaurace2
{
    Pizzar pizzar;
    public Restaurace2(Pizzar pizzar)
    {
        this.pizzar = pizzar;
    }

    public void VytvořitPizzu()
    {
        pizzar.Těsto();
        pizzar.Základ();
        pizzar.Sýr();
        pizzar.Přísady();
    }
}

// Director pizza makerů

class DirectorPizzar
{
    Pizzar pizzar;

    public DirectorPizzar(Pizzar pizzar)
    {
        this.pizzar = pizzar;
    }

    public void VytvořitPizzu()
    {
        pizzar.Těsto();
        pizzar.Základ();
        pizzar.Sýr();
        pizzar.Přísady();
    }

    public string GetPrice()
    {
        return pizzar.GetPrice();
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        // Použití builderu přímo
        Console.WriteLine("Pizzarka pomocí builderu:");
        Pizzar pizzar1 = new PizzaMenu1();
        Restaurace1 restaurace1 = new Restaurace1(pizzar1);
        restaurace1.VytvořitPizzu();
        Console.WriteLine("Cena pizzy: " + pizzar1.GetPrice());
        Console.WriteLine();

        Pizzar pizzar2 = new PizzaMenu2();
        Restaurace2 restaurace2 = new Restaurace2(pizzar2);
        restaurace2.VytvořitPizzu();
        Console.WriteLine("Cena pizzy: " + pizzar2.GetPrice());
        Console.WriteLine();

        // Použití directoru
        Console.WriteLine("Pizzarka pomocí directoru:");
        DirectorPizzar director1 = new DirectorPizzar(new PizzaMenu1());
        director1.VytvořitPizzu();
        Console.WriteLine("Cena pizzy: " + director1.GetPrice());
        Console.WriteLine();

        DirectorPizzar director2 = new DirectorPizzar(new PizzaMenu2());
        director2.VytvořitPizzu();
        Console.WriteLine("Cena pizzy: " + director2.GetPrice());
    }
}
