using ProvaFinale6Library;

bool exit = true;
do
{
    string userChoice = ConsoleHelpers.MainMenu();
    switch (userChoice)
    {
        case "1":
            ConnectedMode.ListBills();
            break;
        case "2":
            ConnectedMode.InsertSpesa();
            break;
        case "3":
            ConnectedMode.ApproveBill();
            break;
        case "4":
            ConnectedMode.UpdateBill();
            break;
        case "5":
            DisconnectedMode.DeleteSpesa();
            break;
        case "6":
            DisconnectedMode.SelectUtente();
            break;
            case "7":
            DisconnectedMode.SelectApp();
            break;
        case "8":
            LinqOperations.FillSpesaPrice();
            break;
        case "9":
            LinqOperations.FillSpesaMese();
            break;
        case "10":
            LinqOperations.OrdinaSpese();
            break;
        case "11":
            LinqOperations.SpeseForCategory();
            break;
        case "q":
            exit = false;
            break;
            default: Console.WriteLine("\nSCELTA NON VALIDA");
            break;
    }
} while (exit);


