using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFinaleWeek6
{
    internal class RISPESTEteoriche
    {
        /* 1. La connection pool è un'insieme di connessioni messi a disposizioni di più client. 
         *      I metodi che si utilizzano sono : 
         *      - OPEN() in cui si cerca una connessione libera nel pool e se non c'è 
         *      bisogna crearne una nuova.
         *      - CLOSE() il pooler la restituisce al set di connessioni attive nel pool. Poi è pronta per
         *      essere nuovamente utilizzata alla successiva chiamata OPEN().
          2. opzione 2
           3. Nella connected mode l'accesso ai dati è di sola lettura e mantiene aperta la connessione durante
                tutte le operazioni. Nell'altra modalità non si mantiene la connessione aperta in tutte le operazioni, avviene
                    una copia di dati recuperati in locale, quindi posso modificare i dati recuperati e poi dopo posso far 
                    riconciliare i dati all'origine dei dati.
           4. il dataadapter  si usa nella modalità disconessa e fa da ponte tra il DataSet e l'origine dati e utilizza oggetti 
                Command per eseguire i comandi SQL
        5. Lista<Persona> persone= new List<Persona>();
               var personeMagg= persone.Where(p => p.Età >=18
         */
    }
}
