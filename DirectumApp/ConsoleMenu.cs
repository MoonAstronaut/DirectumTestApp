using System;
using System.Collections.Generic;

namespace DirectumTestApp
{
    class ConsoleMenu
    {
        private List<iAction> _actions;
        private int _selected;

        public ConsoleMenu()
        {
            _actions = new List<iAction>();
        }

        public void AddAction(iAction a)
        {
            _actions.Add(a);
        }

        public void Show(bool waitInput = true)
        {
            Console.SetCursorPosition(0, 0);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("  ____  _               _                       ");
            Console.WriteLine(" |  _ \\(_)_ __ ___  ___| |_ _   _ _ __ ___     ");
            Console.WriteLine(" | | | | | '__/ _ \\/ __| __| | | | '_ ` _ \\   ");
            Console.WriteLine(" | |_| | | | |  __/ (__| |_| |_| | | | | | |    ");
            Console.WriteLine(" |____/|_|_|  \\___|\\___|\\__|\\__,_|_| |_| |_|");
            Console.WriteLine();
            Console.WriteLine(" // Тестовое приложение на C# (работа с базой даных SQL)");
            Console.WriteLine(" // от Лифар А. В., 23.12.2021");
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine(" Выберите стрелками ( ↑ ↓ ) действие, [Enter] - выполнить");
            Console.WriteLine();

            for (int i = 0; i < _actions.Count; i++)
            {
                Console.ResetColor();
                Console.Write("                   " + (i+1) + ". ");

                Console.BackgroundColor = (i == _selected) ? ConsoleColor.Blue : ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" " + _actions[i].GetDescr() + " ");
            }

            Console.ResetColor();

            Console.WriteLine("------------------------------------------------------------------------------------");

            if (waitInput)
                _waitKeypress();
        }

        private void _waitKeypress()
        {
            ConsoleKeyInfo cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.DownArrow:
                    _selected = (_selected == _actions.Count - 1) ? 0 : _selected + 1;
                    Show();
                    break;

                case ConsoleKey.UpArrow:
                    _selected = (_selected == 0) ? _actions.Count - 1 : _selected - 1;
                    Show();
                    break;

                case ConsoleKey.Enter:
                    Console.Clear();
                    Show(false);
                    Console.Write("\n\n");
                    _actions[_selected].Run();
                    _waitKeypress();
                    break;

                default:
                    Show();
                    break;
            }
        }
    }
}