namespace ProvaFinale6Library
{
    public class ConsoleHelpers
    {
        public static string MainMenu()
        {
            
            Console.WriteLine("Scegli tra le seguenti opzioni: ");
            Console.WriteLine("1) Visualizza l'elenco delle spese,");
            Console.WriteLine("2) Aggiungi una nuova spesa,");
            Console.WriteLine("3) Approva una spesa,");
            Console.WriteLine("4) Modifica una spesa non ancora approvata");
            Console.WriteLine("5) Elimina una spesa,");
            Console.WriteLine("6) Visualizza elenco spese per utente,");
            Console.WriteLine("7) VIsualizza elenco delle spese approvate");
            Console.WriteLine("8) Visualizza spese con importi >100euro");
            Console.WriteLine("9) Visualizza spese di Dicembre");
            Console.WriteLine("10) Visualizza spese ordinate per data e importo");
            Console.WriteLine("11)Visualizza spese per categoria");
            Console.WriteLine("q) Esci");
            Console.Write("\r\nOpzione scelta: ");
            string choice = Console.ReadLine();
            return choice;
         
        }
        public static string GetData(string info)
        {
            string s;
            do
            {
                Console.WriteLine($"Inserisci {info}: ");
                s = Console.ReadLine();
            } while (string.IsNullOrEmpty(s));
            return s;
        }
        public static decimal GetDataDec(string info)
        {
            decimal d;
            do
            {
                Console.WriteLine($"Inserisci {info}: ");

            } while (!decimal.TryParse(Console.ReadLine(), out d));
            return d;
        }
        public static DateTime GetDataTime(string info)
        {
            DateTime dt;
            do
            {
                Console.WriteLine($"Inserisci {info}: ");
            }while (!DateTime.TryParse(Console.ReadLine(),out dt));
            return dt;
        }
    }
}