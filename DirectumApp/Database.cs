using System;
using System.Collections;
using MySql.Data.MySqlClient;
using System.IO;

namespace DirectumTestApp
{
    class Database
    {
        private string _connString;
        MySqlConnection _db;
        private bool _connected = false;
        private string _lasterr;

        private string _config_file_name = "mysql.cfg";

        public Database() 
        {
            checkConfig();
        }

        public void setConnection(string conn_str) 
        {
            _connString = conn_str;
        }

        private void checkConfig() 
        {
            if (File.Exists(_config_file_name))
            {
                setConnection(File.ReadAllText(_config_file_name));
                connect();
            }
        }

        public bool connect() 
        {
            _db = new MySqlConnection(_connString);
            try
            {
                _db.Open();
                _connected = true;
                File.WriteAllText(_config_file_name, _connString);
            }
            catch (Exception e)
            {
                _lasterr = e.Message;
                _connected = false;
            }
            
            return _connected;
        }

        public ArrayList query(string query) 
        {
            ArrayList al = new ArrayList();

            if (_connected)
            {
                MySqlCommand cmd = new MySqlCommand(query, _db);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Object[] values = new Object[reader.FieldCount];
                    reader.GetValues(values);
                    al.Add(values);
                }
                reader.Close();
            }
            return al;
        }

        public string getlastError() { return _lasterr;   }
        public bool isConnected()    { return _connected; }
    }

}
