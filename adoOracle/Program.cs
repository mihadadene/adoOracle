using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adoOracle
{
    class Program
    {
        static void Main(string[] args)
        {
            //connection vers l'instance ORCL 
            //string cs = "Data source = gdna10:User Id = ug283f20:Password=k5e7jc:";
            string cs =
                "Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)" + "(HOST = oracleadudb1.bdeb.qc.ca)(PORT = 1521))) (CONNECT_DATA = (SERVICE_NAME = gdna10) ));" + "User Id = UG214E30; Password=W5hx2u;";

            OracleConnection connection = new OracleConnection();
            connection.ConnectionString = cs;

            try
            {
                Console.WriteLine("connexion vers Oracle ...");
                connection.Open();

                //cree une requete
                string query = "SELECT LAST_NAME, FIRST_NAME FROM EMPLOYEES";

                //REPARER L'EXCUTION DE LA REQUERE
                OracleCommand sql = new OracleCommand();
                sql.Connection = connection;
                sql.CommandText = query;
                sql.CommandType = System.Data.CommandType.Text;

                //Recuperer le curseur
                OracleDataReader reader = sql.ExecuteReader();

                //parcourir le curseur
                while (reader.Read())
                {
                    //afficher detail
                    string nom, prenom;
                    nom = (string)reader[0];
                    prenom = (string)reader[1];
                    Console.WriteLine("nom: {0} - prenom: {1}", nom, prenom);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Clone();
            }
            Console.ReadKey();
        }
    }
}
