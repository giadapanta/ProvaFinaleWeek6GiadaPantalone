using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFinale6Library
{
    public static class DisconnectedMode
    {
        static IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(@"C:\Users\giada.pantalone\Desktop\Week6_ProvaFinale_GiadaPantalone\ProvaFinaleWeek6\ProvaFinale6Library")
            .AddJsonFile("appsettings.json")
            .Build();
        static string ConnectionString = config.GetConnectionString("Spesedb");

        #region select for app
        public static void SelectApp()
        {
            Console.WriteLine();
            DataSet spesaDs = new DataSet();
            using SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();
                SqlDataAdapter adapter = SupportDisconnected.SelectForApprovazione(spesaDs, conn);
                conn.Close();
                Console.WriteLine();

                foreach (DataRow row in spesaDs.Tables["Spesa"].Rows)
                {
                    Console.WriteLine($"{row["Utente"]} - {row["IDspesa"]}" +
                        $" {row["Descrizione"]} - {row["DataSpesa"]} - {row["Importo"]}Euro - " +
                        $"{row["Approvata"]} - {row["IDcat"]}");
                }


            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Generic Error:{ex.Message}");
            }
            finally
            {
                conn.Close();
            }


        }

        #endregion


        #region DELETE SPESA
        public static void DeleteSpesa()
        {
            DataSet spesaDs = new DataSet();
            using SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();
                SqlDataAdapter adapter = SupportDisconnected.InitSpesaDataSetAndAdapter(spesaDs, conn);
                conn.Close();
                Console.WriteLine();
                int id = (int)ConsoleHelpers.GetDataDec("ID");
                DataRow rowToDelete = spesaDs.Tables["Spesa"].Rows.Find(id);
                if (rowToDelete != null)
                {
                    rowToDelete.Delete();
                    Console.WriteLine("\nCancellazione avvenuta con successo");
                }
                adapter.Update(spesaDs, "Spesa");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Generic Error:{ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region SELECT PER UTENTE
        public static void SelectUtente()
        {
            Console.WriteLine();
            DataSet spesaDs = new DataSet();
            using SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();
                SqlDataAdapter adapter = SupportDisconnected.SelectForUtente(spesaDs, conn);
                conn.Close();
                Console.WriteLine();

                foreach (DataRow row in spesaDs.Tables["Spesa"].Rows)
                {
                    Console.WriteLine($"{row["Utente"]} - {row["IDspesa"]}" +
                        $" {row["Descrizione"]} - {row["DataSpesa"]} - {row["Importo"]}Euro - " +
                        $"{row["Approvata"]} - {row["IDcat"]}");
                }


            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Generic Error:{ex.Message}");
            }
            finally
            {
                conn.Close();
            }


        }
        #endregion

        
    }

}

