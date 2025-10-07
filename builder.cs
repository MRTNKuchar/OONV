using System;

namespace Builder2Demo;

// Interface Builder
interface Builder
{
    void postavZeď();
    void postavStřecha();
    void postavOkna();
    void postavDveře();
    void postavPodlaha();
}

// Usteckej Builder

class UstiBuilder : Builder
{
    public void postavZeď() { Console.WriteLine("Ukrást zeď v Ústí"); }
    public void postavStřecha() { Console.WriteLine("Ukrást střechu v Ústí"); }
    public void postavOkna() { Console.WriteLine("Ukrást okna v Ústí"); }
    public void postavDveře() { Console.WriteLine("Ukrást dveře v Ústí"); }
    public void postavPodlaha() { Console.WriteLine("Ukrást podlahu v Ústí"); }
}

// Pražskej Builder
class PrahaBuilder : Builder
{
    public void postavZeď() { Console.WriteLine("Koupit zeď v Praze"); }
    public void postavStřecha() { Console.WriteLine("Koupit střechu v Praze"); }
    public void postavOkna() { Console.WriteLine("Koupit okna v Praze"); }
    public void postavDveře() { Console.WriteLine("Koupit dveře v Praze"); }
    public void postavPodlaha() { Console.WriteLine("Koupit podlahu v Praze"); }
}

//Produkty builderu
class UsteckejBarak
{
    Builder builder;

    public UsteckejBarak(Builder builder)
    {
        this.builder = builder;
    }

    public void postavBarak()
    {
        builder!.postavZeď();
        builder!.postavStřecha();
        builder!.postavOkna();
        builder!.postavDveře();
        builder!.postavPodlaha();
    }
}

class PražskejBarak
{
    Builder builder;

    public PražskejBarak(Builder builder)
    {
        this.builder = builder;
    }

    public void postavBarak()
    {
        builder.postavZeď();
        builder.postavStřecha();
        builder.postavOkna();
        builder.postavDveře();
        builder.postavPodlaha();
    }
}

// Director builderu

class Director
{
    Builder? builder;

    public Director(Builder builder)
    {
        this.builder = builder;
    }

    public void postavBarak()
    {
        builder.postavZeď();
        builder.postavStřecha();
        builder.postavOkna();
        builder.postavDveře();
        builder.postavPodlaha();
    }

    public void setBuilder(Builder builder)
    {
        this.builder = builder;
    }

    public Builder getBuilder()
    {
        return builder!;
    }

    public void postavBarak2()
    {
        builder!.postavZeď();
        builder!.postavStřecha();
        builder!.postavOkna();
        builder!.postavDveře();
        builder!.postavPodlaha();
    }

    public void resetBuilder()
    {
        builder = null;
    }
}

// Client
public class Program
{
    public static void Main(string[] args)
    {
        // Použití builderu přímo
        Builder ustiBuilder = new UstiBuilder();
        UsteckejBarak ustiBarak = new UsteckejBarak(ustiBuilder);
        ustiBarak.postavBarak();

        Console.WriteLine();

        Builder prahaBuilder = new PrahaBuilder();
        PražskejBarak prahaBarak = new PražskejBarak(prahaBuilder);
        prahaBarak.postavBarak();

        Console.WriteLine();

        // Použití builderu přes Directora
        Director director = new Director(ustiBuilder);
        director.postavBarak();

        Console.WriteLine();

        director.setBuilder(prahaBuilder);
        director.postavBarak2();
    }
}
