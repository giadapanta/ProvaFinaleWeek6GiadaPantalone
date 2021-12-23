using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFinale6Library
{
    public class ConnectedMode
    {
        static string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=SpeseDB;Trusted_Connection=True;";
       
        #region LISTA SPESE
        public static void ListBills()
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("\nConnessi al DB");

                }
                else
                {
                    Console.WriteLine("\nNon connessi al DB");

                }
                string sqlStatement = "SELECT * FROM Spesa";
                SqlCommand readCommand = conn.CreateCommand();
                readCommand.CommandText = sqlStatement;
                SqlDataReader reader = readCommand.ExecuteReader();
                Console.WriteLine("==== SPESE ====");
                while (reader.Read())
                {
                    Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}",
                        reader["IDspesa"],
                        reader["DataSpesa"],
                        reader["Descrizione"],
                        reader["Utente"],
                        reader["Importo"],
                        reader["Approvata"],
                        reader["IDcat"]);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine($" SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Generic Error: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region aggiungi spesa
        public static void InsertSpesa()
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("\nConnesso al DB");
                }
                else
                {
                    Console.WriteLine("\nNon connesso al DB");
                }

                DateTime dataSpesa = ConsoleHelpers.GetDataTime("DATA della SPESA");
                var descrizione = ConsoleHelpers.GetData("DESCRIZIONE");
                var utente = ConsoleHelpers.GetData("NOME UTENTE");
                var importo = ConsoleHelpers.GetDataDec("IMPORTO");
                var approvata = 0;

                               
                var idCat = InsertIDCategory();

                string insertSqlStatement = "INSERT INTO Spesa VALUES(@dataSpesa, @descrizione, " +
                    "@utente, @importo, @approvata, @idCat)";
                SqlCommand insertCommand = conn.CreateCommand();
                insertCommand.CommandText = insertSqlStatement;
                
                insertCommand.Parameters.AddWithValue("@dataSpesa", dataSpesa);
                insertCommand.Parameters.AddWithValue("@descrizione", descrizione);
                insertCommand.Parameters.AddWithValue("@importo", importo);
                insertCommand.Parameters.AddWithValue("@utente", utente);
                insertCommand.Parameters.AddWithValue("@approvata", approvata);
                insertCommand.Parameters.AddWithValue("@idCat", idCat);


                int result = insertCommand.ExecuteNonQuery();
                if (result == 1)
                {
                    Console.WriteLine("Aggiunta effettuata con successo");
                }
                else
                    Console.WriteLine("Errore!");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($" SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Generic Error: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }

        private static int InsertIDCategory()
        {
            int categoryChosen;
            
            using SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();
                              
                string sqlStatement = "SELECT * FROM Categoria";
                SqlCommand readCommand = conn.CreateCommand();
                readCommand.CommandText = sqlStatement;
                SqlDataReader reader = readCommand.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("{0} - {1} ",
                        reader["IDcat"],
                        reader["Nome"]);

                }
                categoryChosen = (int)ConsoleHelpers.GetDataDec("CATEGORY ID");
              
            }            
            finally
            {
                conn.Close();
            }
            return categoryChosen;

        }

        #endregion

        #region approva spesa
        public static void ApproveBill()
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("\nConnessi al DB");

                }
                else
                {
                    Console.WriteLine("\nNon connessi al DB");

                }
               
                int idSpesaToApprove = (int)ConsoleHelpers.GetDataDec("ID della SPESA");
                if (idSpesaToApprove > 0)
                {
                    string sqlStatement = "UPDATE Spesa SET Approvata=1 WHERE IDspesa=@idSpesaToApprove";
                    SqlCommand updateCommand = conn.CreateCommand();
                    updateCommand.CommandText = sqlStatement;
                    updateCommand.Parameters.AddWithValue("@idSpesaToApprove", idSpesaToApprove);
                   int result=updateCommand.ExecuteNonQuery();
                    if (result == 1)
                    {
                        Console.WriteLine("Operazione effettuata con successo");
                    }
                    else
                        Console.WriteLine("Update non effettuato");
                }
                
                
            }
            catch (SqlException ex)
            {
                Console.WriteLine($" SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Generic Error: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region modifica spesa
        public static void UpdateBill()
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("\nConnessi al DB");

                }
                else
                {
                    Console.WriteLine("\nNon connessi al DB");

                }

                int idSpesa = (int)ConsoleHelpers.GetDataDec("ID della SPESA");
                int count = 0;
                do
                {
                    var dataSpesa = ConsoleHelpers.GetDataTime("DATA");
                    var descrizione = ConsoleHelpers.GetData("DESCRIZIONE");
                    var importo = ConsoleHelpers.GetDataDec("IMPORTO");
                    var utente = ConsoleHelpers.GetData("UTENTE");
                    
                    string sqlStatement = "UPDATE Spesa SET DataSpesa=@dataSpesa," +
                        "Descrizione=@descrizione, Importo=@importo, Utente=@utente" +
                        " WHERE Approvata=0 AND IDspesa=@idSpesa";
                    SqlCommand updateCommand = conn.CreateCommand();
                    updateCommand.CommandText = sqlStatement;
                    
                    updateCommand.Parameters.AddWithValue("@importo", importo);
                    updateCommand.Parameters.AddWithValue("@dataSpesa", dataSpesa);
                    updateCommand.Parameters.AddWithValue("@descrizione", descrizione);
                    updateCommand.Parameters.AddWithValue("@utente", utente);
                    updateCommand.Parameters.AddWithValue("@idSpesa", idSpesa);
                    
                    int result = updateCommand.ExecuteNonQuery();
                    if (result == 1)
                    {
                        Console.WriteLine("Operazione effettuata con successo");
                    }
                    else
                    {
                        Console.WriteLine("Update non effettuato");
                    }
                    count++;
                }while(idSpesa!=0 && count==0);


            }
            catch (SqlException ex)
            {
                Console.WriteLine($" SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Generic Error: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion


    }
}
