using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDapper3
{
    public class DataService
    {
        public static List<People> getUsers()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<People>("SELECT id, FIO FROM PEOPLE").ToList();
            }      
        }

        public static void insertNewUser(string user)
        {
            string sql = "INSERT INTO PEOPLE (FIO) Values (@FIO);";

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                db.Execute(sql, new { FIO = user });
            }
        }

        public static Boolean deleteUser(int id)
        {
            string sqlQuery = "DELETE FROM [dbo].[People] WHERE id=@id";

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                int isSuccess = db.Execute(sqlQuery, new { id });
                if(isSuccess == 1)
                {
                    return true;
                } else {
                    return false;
                }
            }
        }

        public static Boolean updateUser(int idValue, string fioValue)
        {
            string sql = "UPDATE PEOPLE SET FIO = @fio WHERE id=@id;";

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                int isSuccess = db.Execute(sql, new { id = idValue,  FIO = fioValue});
                if (isSuccess == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
