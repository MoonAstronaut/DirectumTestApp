using System;
using System.Collections;

namespace DirectumTestApp
{
    class action_MaxSalaryDepartment : iAction
    {
        private Database _db;
        public action_MaxSalaryDepartment(ref Database db)
        {
            this._db = db;
        }
        public string GetDescr()
        {
            return "Вывести департамент, в котором з/п сотрудника максимальна.";
        }

        public void Run()
        {
            if (!_db.isConnected())
            {
                Console.WriteLine("ОШИБКА! Подключение к БД не установлено.");
                return;
            }

            string query = "SELECT department.name, employee.name, employee.salary " +
                           "FROM `employee` LEFT JOIN department ON department.id = employee.department_id " +
                           "WHERE employee.id NOT IN(SELECT DISTINCT(chief_id) FROM `employee` WHERE chief_id IS NOT NULL) " +
                           "GROUP BY `department_id` ORDER BY employee.salary DESC LIMIT 1";

            ArrayList res = _db.query(query);

            string[] head = new string[] { "Департамент", "Имя сотрудника", "Зарплата" };
            PrettyPrint.print(ref res, ref head);
        }
    }
}
