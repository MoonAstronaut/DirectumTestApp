using System;
using System.Collections;

namespace DirectumTestApp
{
    class action_ChiefSalary : iAction
    {
        private Database _db;
        public action_ChiefSalary(ref Database db)
        {
            this._db = db;
        }
        public string GetDescr()
        {
            return "Вывести з/п руководителей департаментов.";
        }

        public void Run()
        {
            if (!_db.isConnected())
            {
                Console.WriteLine("ОШИБКА! Подключение к БД не установлено.");
                return;
            }

            string query = "SELECT a.name, a.salary " +
                           "FROM employee AS a " +
                           "INNER JOIN employee AS b ON a.id = b.chief_id " +
                           "GROUP BY(a.name) " +
                           "ORDER BY a.salary DESC";
            
            ArrayList res = _db.query(query);

            string[] head = new string[] { "Имя руководителя", "Зарплата" };
            PrettyPrint.print(ref res, ref head);
        }
    }
}
