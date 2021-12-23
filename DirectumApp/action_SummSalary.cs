using System;
using System.Collections;

namespace DirectumTestApp
{
    class action_SummSalary : iAction
    {
        private Database _db;
        public action_SummSalary(ref Database db) 
        {
            this._db = db;
        }
        public string GetDescr()
        {
            return "Вывести суммарную зарплату по департаментам";
        }

        public void Run()
        {
            if (!_db.isConnected())
            {
                Console.WriteLine("ОШИБКА! Подключение к БД не установлено.");
                return;
            }

            Console.Write("Включить в список руководителей? [ Y / N ]: ");
            ConsoleKeyInfo k = Console.ReadKey();
            Console.WriteLine();
            string query;

            if (k.Key == ConsoleKey.Y)
            {
                query = "SELECT department.name, SUM(salary) " +
                        "FROM `employee` " +
                        "LEFT JOIN department ON department.id = employee.department_id " +
                        "GROUP BY `department_id`";
            }
            else
            {
                query = "SELECT department.name, SUM(employee.salary) " +
                        "FROM `employee` " +
                        "LEFT JOIN department ON department.id = employee.department_id " +
                        "WHERE employee.id NOT IN ( SELECT DISTINCT(chief_id) FROM `employee` WHERE chief_id IS NOT NULL )" +
                        "GROUP BY `department_id`";
            }

            ArrayList res = _db.query(query);

            string[] head = new string[] { "Департамент", "Суммарная зарплата" };
            PrettyPrint.print(ref res, ref head);
        }
    }
}
