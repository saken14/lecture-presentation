using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp6
{
    public class DB
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=lecture;Uid=root;Pwd=root;");

        public void openConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        
        public void closeConnection()
        {
            if(connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}