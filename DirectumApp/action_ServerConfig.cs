using System;

namespace DirectumTestApp
{
    class action_ServerConfig : iAction
    {
        private Database _db;
        
        public action_ServerConfig(ref Database db) 
        {
            this._db = db;
        }
        public string GetDescr()
        {
            return (!_db.isConnected()) ? "Настройка подключения к серверу (не подключено)" :
                                          "Изменить настройки сервера (подключено)";
        }

        public void Run()
        {
            string s_conn;
            Console.Write("Адрес сервера ...: ");
            s_conn  = "SERVER=" + Console.ReadLine();
            Console.Write("Имя базы данных .: ");
            s_conn += ";DATABASE=" + Console.ReadLine();
            Console.Write("Логин ...........: ");
            s_conn += ";UID=" + Console.ReadLine();
            Console.Write("Пароль ..........: ");
            s_conn += ";PASSWORD=" + Console.ReadLine() + ";";

            Console.Write("Тест подключения ... ");
            
            _db.setConnection(s_conn);
            if (_db.connect())
            {
                Console.WriteLine("ОК");
            }
            else
            {
                Console.WriteLine("ОШИБКА!\n\nMySQL Error Message: " + _db.getlastError());
                Console.WriteLine("Для использования последнего рабочего конфига, перезапустите программу.");
            }
        }
    }
}
