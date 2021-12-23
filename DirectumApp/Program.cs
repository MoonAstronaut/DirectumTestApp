using System;
using System.Collections.Generic;

namespace DirectumTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleMenu menu = new ConsoleMenu();
            Database db = new Database();

            menu.AddAction(new action_ServerConfig(ref db));
            menu.AddAction(new action_SummSalary(ref db));
            menu.AddAction(new action_MaxSalaryDepartment(ref db));
            menu.AddAction(new action_ChiefSalary(ref db));
            menu.Show();
        }
    }

}