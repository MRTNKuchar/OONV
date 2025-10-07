using System;

namespace AbstractFactoryDemo
{
    // Abstract Factory Pattern

    // Define interfaces for UI components
    public interface IButton
    {
        void Render();
    }
    public interface IMenuCommandService
    {
        void Show();
    }

    // Concrete implementations for PC
    public class PCButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering a PC button");
        }
    }

    public class PCMenuCommandService : IMenuCommandService
    {
        public void Show()
        {
            Console.WriteLine("Showing the PC menu");
        }
    }

    // Concrete implementations for Mobile
    public class MobileButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering a mobile button");
        }
    }

    public class MobileMenuCommandService : IMenuCommandService
    {
        public void Show()
        {
            Console.WriteLine("Showing the mobile menu");
        }
    }

    // Abstract Factory (interface)
    public interface IGameUIFactory
    {
        IButton CreateButton();
        IMenuCommandService CreateMenu();
    }

    // Concrete Factory for PC
    public class PCUI : IGameUIFactory
    {
        public IButton CreateButton()
        {
            return new PCButton();
        }

        public IMenuCommandService CreateMenu()
        {
            return new PCMenuCommandService();
        }
    }

    public class MBUI : IGameUIFactory
    {
        public IButton CreateButton()
        {
            return new MobileButton();
        }

        public IMenuCommandService CreateMenu()
        {
            return new MobileMenuCommandService();
        }
    }

    public class GameUI
    {
        private IButton _button;
        private IMenuCommandService _menu;

        public GameUI(IGameUIFactory factory)
        {
            _button = factory.CreateButton();
            _menu = factory.CreateMenu();
            // produce immediate visible output for demo
            _button.Render();
            _menu.Show();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GameUI pcUI = new GameUI(new PCUI());
            Console.WriteLine();
            GameUI mobileUI = new GameUI(new MBUI());
            Console.WriteLine();
        }
    }
}
