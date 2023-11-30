using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Documents_Тепляков.Classes
{
    public class UserContext : Model.User, Interfaces.IUser
    {
        public List<UserContext> AllUsers()
        {
            List<UserContext> allUsers = new List<UserContext>();
            OleDbConnection connection = Common.DBConnection.Connection();
            OleDbDataReader dataUsers = Common.DBConnection.Query("SELECT * FROM [Ответственные]", connection);
            while (dataUsers.Read())
            {
                DocumentContext newDocument = new DocumentContext();
                newDocument.id = dataUsers.GetInt32(0);
                newDocument.user = dataUsers.GetString(1);
            }
            Common.DBConnection.CloseConnection(connection);
            return allUsers;
        }

        public void Save(bool Update = false)
        {
            if (Update)
            {
                OleDbConnection connection = Common.DBConnection.Connection();
                Common.DBConnection.Query("UPDATE [Ответственные] " +
                                          "SET " + $"[Ответственный] = '{this.user}', " +
                                                   $"WHERE [Код] = {this.id}", connection);
                Common.DBConnection.CloseConnection(connection);
            }
            else
            {
                OleDbConnection connection = Common.DBConnection.Connection();
                Common.DBConnection.Query("INSERT INTO " +
                                            "[Ответственные]" +
                                                "([Ответственный])" +
                                            "VALUES (" +
                                                $"'{this.user}')", connection);
                Common.DBConnection.CloseConnection(connection);
            }
        }

        public void Delete()
        {
            OleDbConnection connection = Common.DBConnection.Connection();
            Common.DBConnection.Query($"DELETE FROM [Ответственный] WHERE [Код] = {this.id}", connection);
            Common.DBConnection.CloseConnection(connection);

        }
    }
}
