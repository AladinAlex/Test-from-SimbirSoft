using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Intensive
{
    class DateBase
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=statistics.accdb;";
        private OleDbConnection myConnection;
        public string Uri;
        Dictionary<string, int> date = new Dictionary<string, int>();
        public DateBase()
        { }
        public DateBase(string uRi, Dictionary<string, int> DATA)
        {
            Uri = uRi;
            date = DATA;
        }
        internal void main()
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            OleDbCommand command;
            //string query;
            try
            {
                Uri = Uri.Replace(".", " ");
                //создание таблицы
                string query = $"CREATE TABLE " + "[" + Uri + "]" + " ([Id] COUNTER NOT NULL PRIMARY KEY, [Word] STRING, [Unique] INT);";
                command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                // ввод данных
                int i = 1;
                OleDbCommand commandQuery = new OleDbCommand(connectString);
                foreach (KeyValuePair<string, int> a in date)
                {
                    string h = a.Key;
                    h = h.Replace("'", "");

                    string Query = $"INSERT INTO " + "[" + Uri + "] " + "([Id], [Word], [Unique]) VALUES (" + i +",'" + h + "', '" + a.Value + "');";
                    commandQuery = new OleDbCommand(Query, myConnection);
                    commandQuery.ExecuteNonQuery();
                    i++;
                }
                Console.WriteLine("Создана таблица с уникальными слова сайта."); //https://www.simbirsoft.com/
            }
            catch (OleDbException)
            {
                //удаление данных
                string deleteTable = "DELETE FROM [" + Uri + "];";
                OleDbCommand delete_command = new OleDbCommand(deleteTable, myConnection);
                delete_command.ExecuteNonQuery();
                //ввод данных
                int i = 1;
                OleDbCommand commandQuery = new OleDbCommand(connectString);
                foreach (KeyValuePair<string, int> a in date)
                {
                    string h = a.Key;
                    h = h.Replace("'", "");
                    string Query = $"INSERT INTO " + "[" + Uri + "] " + "([Id], [Word], [Unique]) VALUES (" + i + ",'" + h + "', '" + a.Value + "');";
                    commandQuery = new OleDbCommand(Query, myConnection);
                    commandQuery.ExecuteNonQuery();
                    i++;
                }
                Console.WriteLine($"Таблица {Uri} перезаписана.");
            }
            finally
            {
                myConnection.Close();
            }
        }
    }
}
