using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFinale6Library
{
    public static class SupportDisconnected
    {
        public static SqlDataAdapter InitSpesaDataSetAndAdapter(DataSet spesaDs, SqlConnection conn)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
                    
            adapter.DeleteCommand = GenerateDeleteCommand(conn);
            adapter.SelectCommand = GenerateSelectCommand(conn);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(spesaDs, "Spesa");
            return adapter;

        }

        private static SqlCommand GenerateSelectCommand(SqlConnection conn)
        {
            SqlCommand spesaSelectCommand = new SqlCommand();
            spesaSelectCommand.Connection = conn;
            spesaSelectCommand.CommandType = CommandType.Text;
            spesaSelectCommand.CommandText = "SELECT * FROM Spesa";
            return spesaSelectCommand;
        }

        public static SqlDataAdapter SelectForUtente(DataSet spesaDs, SqlConnection conn)
        {
            SqlDataAdapter adapter= new SqlDataAdapter();
            adapter.SelectCommand= GenerateSelectUtenteCommand(conn);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(spesaDs, "Spesa");
            return adapter;
        }

        private static SqlCommand GenerateSelectUtenteCommand(SqlConnection conn)
        {
            SqlCommand spesaUSelectCommand = new SqlCommand();
            spesaUSelectCommand.Connection = conn;
            spesaUSelectCommand.CommandType = CommandType.Text;
           spesaUSelectCommand.CommandText = "SELECT * FROM Spesa WHERE Utente=@utente";
            string utente = ConsoleHelpers.GetData("UTENTE");
            spesaUSelectCommand.Parameters.AddWithValue("@utente", utente);
            

            return spesaUSelectCommand;
        }

        private static SqlCommand GenerateDeleteCommand(SqlConnection conn)
        {
            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = conn;
            deleteCommand.CommandType = CommandType.Text;
            deleteCommand.CommandText = "DELETE FROM Spesa WHERE IDspesa =@idSpesa";
            deleteCommand.Parameters.Add(new SqlParameter(
                "@idSpesa", SqlDbType.Int, 0, "IDspesa"
                ));
            return deleteCommand;

        }

        public static SqlDataAdapter SelectForApprovazione(DataSet spesaDs, SqlConnection conn)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = GenerateSelectAppCommand(conn);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(spesaDs, "Spesa");
            return adapter;
        }

        private static SqlCommand GenerateSelectAppCommand(SqlConnection conn)
        {
            SqlCommand spesaAppSelectCommand = new SqlCommand();
            spesaAppSelectCommand.Connection = conn;
            spesaAppSelectCommand.CommandType = CommandType.Text;
            spesaAppSelectCommand.CommandText = "SELECT * FROM Spesa WHERE Approvata=@approvata";
            var approvata = ConsoleHelpers.GetDataDec("APPROVATA: 0 NO, 1 SI");
            spesaAppSelectCommand.Parameters.AddWithValue("@approvata", approvata);


            return spesaAppSelectCommand;
        }
    }
    }

