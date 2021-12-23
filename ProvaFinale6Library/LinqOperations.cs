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
    public  class LinqOperations
    {
        static IConfiguration config = new ConfigurationBuilder()
           .SetBasePath(@"C:\Users\giada.pantalone\Desktop\Week6_ProvaFinale_GiadaPantalone\ProvaFinaleWeek6\ProvaFinale6Library")
           .AddJsonFile("appsettings.json")
           .Build();
        static string ConnectionString = config.GetConnectionString("Spesedb");
        #region spese >100
        public static void FillSpesaPrice()
        {
            DataSet spesaDs = new DataSet();
            using SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine();
                    Console.WriteLine("Connessione stabilita");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Connessione non riuscita");
                    return;
                }
                SupportDisconnected.InitSpesaDataSetAndAdapter(spesaDs, connection);
                connection.Close();
                List<Spesa> spese= new List<Spesa>();
                foreach (DataRow row in spesaDs.Tables["Spesa"].Rows)
                {
                    spese.Add(new Spesa
                    {
                        IDspesa = (int)row["IDspesa"],
                        Descrizione = (string)row["Descrizione"],
                        DataSpesa = (DateTime)row["DataSpesa"],
                        Utente = (string)row["Utente"],
                        Approvata = (bool)row["Approvata"],
                        IDcat = (int)row["IDcat"],
                        Importo = (decimal)row["Importo"]

                    });
                }
                Console.WriteLine("Metodo 1:");
                    var speseOver100 = from spesa in spese
                                       where spesa.Importo > 100
                                       select spesa;
                    foreach(var s in speseOver100)
                    {
                        Console.WriteLine($"{s.Utente} - {s.Descrizione} - {s.DataSpesa} - " +
                            $"{s.Approvata} - {s.Importo} euro");
                    }
                Console.WriteLine("Metodo 2:");
                var spese100 = spese.Where(s => s.Importo > 100);
                foreach (var s in spese100)
                {
                    Console.WriteLine($"{s.Utente} - {s.Descrizione} - {s.DataSpesa} - " +
                        $"{s.Approvata} - {s.Importo} euro");
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
                connection.Close();
            }
        }
        #endregion

        #region SPESE DICEMBRE
        public static void FillSpesaMese()
        {
            DataSet spesaDs = new DataSet();
            using SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine();
                    Console.WriteLine("Connessione stabilita");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Connessione non riuscita");
                    return;
                }
                SupportDisconnected.InitSpesaDataSetAndAdapter(spesaDs, connection);
                connection.Close();
                List<Spesa> spese = new List<Spesa>();
                foreach (DataRow row in spesaDs.Tables["Spesa"].Rows)
                {
                    spese.Add(new Spesa
                    {
                        IDspesa = (int)row["IDspesa"],
                        Descrizione = (string)row["Descrizione"],
                        DataSpesa = (DateTime)row["DataSpesa"],
                        Utente = (string)row["Utente"],
                        Approvata = (bool)row["Approvata"],
                        IDcat = (int)row["IDcat"],
                        Importo = (decimal)row["Importo"]

                    });
                }
                Console.WriteLine("Metodo 1:");
                var speseDecember = from spesa in spese
                                    where spesa.DataSpesa.Month == 12
                                   select spesa;
                foreach (var s in speseDecember)
                {
                    Console.WriteLine($"{s.Utente} - {s.Descrizione} - {s.DataSpesa} - " +
                        $"{s.Approvata} - {s.Importo} euro");
                }
                Console.WriteLine("Metodo 2:");
                var speseDecember2 = spese.Where(s => s.DataSpesa.Month == 12);
                foreach (var s in speseDecember2)
                {
                    Console.WriteLine($"{s.Utente} - {s.Descrizione} - {s.DataSpesa} - " +
                        $"{s.Approvata} - {s.Importo} euro");
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
                connection.Close();
            }
        }
        #endregion


        #region
        public static void OrdinaSpese()
        {
            DataSet spesaDs = new DataSet();
            using SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine();
                    Console.WriteLine("Connessione stabilita");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Connessione non riuscita");
                    return;
                }
                SupportDisconnected.InitSpesaDataSetAndAdapter(spesaDs, connection);
                connection.Close();
                List<Spesa> spese = new List<Spesa>();
                foreach (DataRow row in spesaDs.Tables["Spesa"].Rows)
                {
                    spese.Add(new Spesa
                    {
                        IDspesa = (int)row["IDspesa"],
                        Descrizione = (string)row["Descrizione"],
                        DataSpesa = (DateTime)row["DataSpesa"],
                        Utente = (string)row["Utente"],
                        Approvata = (bool)row["Approvata"],
                        IDcat = (int)row["IDcat"],
                        Importo = (decimal)row["Importo"]

                    });
                }
                Console.WriteLine("Metodo 1:");
                var orderedSpese= from spesa in spese
                                  orderby spesa.DataSpesa ascending, spesa.Importo descending
                                  select spesa; 
               
                foreach (var s in orderedSpese)
                {
                    Console.WriteLine($"{s.Utente} - {s.Descrizione} - {s.DataSpesa} - " +
                        $"{s.Approvata} - {s.Importo} euro");
                }
                Console.WriteLine("Metodo 2:");
                var orderedSpese2 =spese.OrderBy(s => s.DataSpesa).ThenByDescending(s => s.Importo);
                foreach (var s in orderedSpese2)
                {
                    Console.WriteLine($"{s.Utente} - {s.Descrizione} - {s.DataSpesa} - " +
                        $"{s.Approvata} - {s.Importo} euro");
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
                connection.Close();
            }
        }
        #endregion

        #region spese per categorie
        public static void SpeseForCategory()
        {
            DataSet spesaDs = new DataSet();
            using SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine();
                    Console.WriteLine("Connessione stabilita");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Connessione non riuscita");
                    return;
                }
                SupportDisconnected.InitSpesaDataSetAndAdapter(spesaDs, connection);
                connection.Close();
                List<Spesa> spese = new List<Spesa>();
                foreach (DataRow row in spesaDs.Tables["Spesa"].Rows)
                {
                    spese.Add(new Spesa
                    {
                        IDspesa = (int)row["IDspesa"],
                        Descrizione = (string)row["Descrizione"],
                        DataSpesa = (DateTime)row["DataSpesa"],
                        Utente = (string)row["Utente"],
                        Approvata = (bool)row["Approvata"],
                        IDcat = (int)row["IDcat"],
                        Importo = (decimal)row["Importo"]

                    });
                }
                Console.WriteLine("Metodo 1:");
                var speseByCategory = from spesa in spese
                                      group spesa by spesa.IDcat into SpeseCategory
                                      select SpeseCategory;

                foreach (var s in speseByCategory)
                {
                    Console.WriteLine(s.Key);
                    foreach (var ss in s)
                    {
                        Console.WriteLine($"{ss.Utente} - {ss.Descrizione} - {ss.DataSpesa} - " +
                          $"{ss.Approvata} - {ss.Importo} euro - {ss.IDcat}");
                    }
                }
                Console.WriteLine("Metodo 2:");
                var speseByCategory2 = spese.GroupBy(s => s.IDcat)
                                            .Select(s => new
                                            {
                                               IDcat=s.Key,
                                              Descrizioni=s.Select(s =>s.Descrizione)
                                              });
                foreach (var s in speseByCategory2)
                {
                    Console.WriteLine(s.IDcat);
                    foreach (var ss in s.Descrizioni)
                    {
                        Console.WriteLine($" {ss}  ");
                    }
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
                connection.Close();
            }
        }
        #endregion

    }
}
