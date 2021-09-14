using System;
using System.Collections.Concurrent;
using static System.Console;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.IO;
using Autofac;
using Autofac.Core;

namespace Structural.Adapter
{
    public interface ICommand
    {
        void Execute();
    }

    public class SaveCommand: ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Saving a file");
        }
    }

    public class OpenCommand: ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Opening a file");
        }       
    }

    public class Button
    {
        private ICommand command;
        private string name;
        public Button(ICommand command, string name)
        {
            this.command = command ?? throw new ArgumentNullException(paramName: nameof(command));
            this.name = name;
        }

        public void Click()
        {
            command.Execute();
        }

        public void PrintMe()
        {
            WriteLine($"I am button {name}");
        }
    }

    public class Editor
    {
        private IEnumerable<Button> buttons;
        public IEnumerable<Button> Buttons => buttons;
        public Editor(IEnumerable<Button> buttons)
        {
            this.buttons = buttons ?? throw new ArgumentNullException(paramName: nameof(buttons));
        }

        public void ClickAll()
        {
            foreach (var button in buttons)
            {
                button.Click();
            }
        }
    }
}
