using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CarDealer
{
    class Program
    {
        static DatabaseConnection databaseConnection = null;

        class DatabaseConnection
        {
            public SqlConnection connection { get; private set; }

            public DatabaseConnection(SqlConnectionStringBuilder csb)
            {
                this.connection = new SqlConnection(csb.ConnectionString);
            }

            public void Connect()
            {
                this.connection.Open();
            }

            public void Disconect()
            {
                this.connection.Close();
            }
        }

        public void Welcome()
        {
            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("=========================================== INFO ===========================================");
            Console.ForegroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("Witaj w aplikacji obsługującej bazę danych CarDealer!");
            System.Console.WriteLine("W celu wykonania poszczególnych czynności wpisz nazwę operacji (znajduje się po znaku : ).");
            System.Console.WriteLine("Następnie kliknij Enter i postępuj zgodnie z dalszymi instrukcjami");
            System.Console.WriteLine("Aby ponownie wyświetlić listę dostępnych operacji wpisz: Options");
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("============================================================================================");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintOptions()
        {
            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("===================== OPTIONS =====================");
            Console.ForegroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("Pokaż tabelę Cars:            Cars");
            System.Console.WriteLine("Pokaż tabelę Menagers:        Menagers");
            System.Console.WriteLine("Pokaż tabelę Clients:         Clients");
            System.Console.WriteLine("Pokaż tabelę Transactions:    Transactions");
            System.Console.WriteLine("Dodaj samochód:               Add Car");
            System.Console.WriteLine("Usuń samochód:                Delete Car");
            System.Console.WriteLine("Zmień cenę samochodu:         Modify Car");
            System.Console.WriteLine("Dodaj menadżera:              Add Menager");
            System.Console.WriteLine("Usuń menadżera:               Delete Menager");
            System.Console.WriteLine("Zmień pensję menadżera:       Modify Menager");
            System.Console.WriteLine("Dodaj klienta:                Add Client");
            System.Console.WriteLine("Usuń klienta:                 Delete Client");
            System.Console.WriteLine("Dodaj transakcję:             Add Transaction");
            System.Console.WriteLine("Usuń transakcję:              Delete Transaction");
            System.Console.WriteLine("Wygeneruj raport              Generate Raport");
            System.Console.WriteLine("Wyjdź z aplikcji:             Exit");
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("===================================================");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Connection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "WINDOWS-JCBU9MC";
            builder.UserID = "sa";
            builder.Password = "Bdpassword";
            builder.InitialCatalog = "CarDealer";

            databaseConnection = new DatabaseConnection(builder);
            databaseConnection.Connect();

            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Pomyślnie nawiązano połączenie z bazą danych.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintCars()
        {
            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("======================================== CARS ========================================");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            System.Console.WriteLine("{0,-5}   {1,-10}   {2,-20}   {3,-11}   {4,-6}   {5,-6}   {6,-8}", 
                                     "CarID", "Brand", "Model", "Price", "Milage", "Weight", "MaxSpeed");
            Console.ForegroundColor = ConsoleColor.Gray;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Cars");
            String sql = sb.ToString();

            using (SqlCommand command = new SqlCommand(sql, databaseConnection.connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0,-5}   {1,-10}   {2,-20}   {3,-11}   {4,-6}   {5,-6}   {6,-8}", reader.GetInt32(0), reader.GetString(1), 
                            reader.GetString(2), reader.GetSqlMoney(3), reader.GetDouble(4), reader.GetInt32(5), reader.GetInt32(6));
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("======================================================================================");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintMenagers()
        {
            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("============================ MENAGERS =============================");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            System.Console.WriteLine("{0,-9}   {1,-20}   {2,-20}   {3,-8}", "MenagerID", "Name", "Surname", "Salary");
            Console.ForegroundColor = ConsoleColor.Gray;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Menagers");
            String sql = sb.ToString();

            using (SqlCommand command = new SqlCommand(sql, databaseConnection.connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0,-9}   {1,-20}   {2,-20}   {3,-8}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                            reader.GetSqlMoney(3));
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("===================================================================");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintClients()
        {
            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("=================== CLIENTS ===================");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            System.Console.WriteLine("{0,-8}   {1,-20}   {2,-20}", "ClientID", "Name", "Surname");
            Console.ForegroundColor = ConsoleColor.Gray;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Clients");
            String sql = sb.ToString();

            using (SqlCommand command = new SqlCommand(sql, databaseConnection.connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0,-8}   {1,-20}   {2,-20}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("===============================================");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintTransactions()
        {
            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("======================== TRANSACTIONS =====================");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            System.Console.WriteLine("{0,-13}   {1,-9}   {2,-8}   {3,-5}   {4,-10}", "TransactionID", "MenagerID", "ClientID", "CarID", "Date");
            Console.ForegroundColor = ConsoleColor.Gray;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Transactions");
            String sql = sb.ToString();

            using (SqlCommand command = new SqlCommand(sql, databaseConnection.connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0,-13}   {1,-9}   {2,-8}   {3,-5}   {4:d}", reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), 
                            reader.GetInt32(3), reader.GetDateTime(4));
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("===========================================================");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Main(string[] args) { new Program().Run(); }

        public void Run()
        {
            Connection();
            Welcome();
            PrintOptions();
            string reader = "Start";
            while (reader != "Exit")
            {
                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                System.Console.Write("Wpisz nazwę operacji: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                reader = Console.ReadLine();
                switch (reader)
                {
                    case "Options":
                        PrintOptions();
                        break;
                    case "Cars":
                        PrintCars();
                        break;
                    case "Menagers":
                        PrintMenagers();
                        break;
                    case "Clients":
                        PrintClients();
                        break;
                    case "Transactions":
                        PrintTransactions();
                        break;
                    case "Add Car":
                        Car.Add();
                        break;
                    case "Delete Car":
                        Car.Delete();
                        break;
                    case "Modify Car":
                        Car.Modify();
                        break;
                    case "Add Menager":
                        Menager.Add();
                        break;
                    case "Delete Menager":
                        Menager.Delete();
                        break;
                    case "Modify Menager":
                        Menager.Modify();
                        break;
                    case "Add Client":
                        Client.Add();
                        break;
                    case "Delete Client":
                        Client.Delete();
                        break;
                    case "Add Transaction":
                        Transaction.Add();
                        break;
                    case "Delete Transaction":
                        Transaction.Delete();
                        break;
                    case "Generate Raport":
                        Raport.Generate();
                        break;
                    case "Exit":
                        System.Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("Praca zakończona.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        System.Console.WriteLine();
                        break;
                    default:
                        System.Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Nieznana operacja!!!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            }
            if (databaseConnection != null) 
                databaseConnection.Disconect();
        }

        static class Car
        {
            public static void Add()
            {
                string reader;
                string brand;
                string model;
                double price;
                double milage;
                int weight;
                int maxspeed;

                System.Console.WriteLine();
                System.Console.WriteLine("Aby dodać do bazy nowy samochód podaj następujące dane (po wpisaniu kliknj Enter):");
                System.Console.Write("Marka (string): ");
                reader = Console.ReadLine();
                brand = reader;
                System.Console.Write("Model (string): ");
                reader = Console.ReadLine();
                model = reader;
                System.Console.Write("Cena (double z przecinkiem): ");
                reader = Console.ReadLine();
                price = Convert.ToDouble(reader);
                System.Console.Write("Spalanie (double z przecinkiem): ");
                reader = Console.ReadLine();
                milage = Convert.ToDouble(reader);
                System.Console.Write("Waga (int): ");
                reader = Console.ReadLine();
                weight = Convert.ToInt32(reader);
                System.Console.Write("Maksymalna prędkość (int): ");
                reader = Console.ReadLine();
                maxspeed = Convert.ToInt32(reader);

                StringBuilder sb = new StringBuilder();
                sb.Append($"INSERT INTO Cars (Brand,Model,Price,Milage,Weight,MaxSpeed) VALUES (@brand, @model, @price, @milage, @weight, @maxspeed)");
                String sql = sb.ToString();

                SqlCommand command = new SqlCommand(sql, databaseConnection.connection);

                command.Parameters.Add("@brand", SqlDbType.VarChar, 20).Value = brand;
                command.Parameters.Add("@model", SqlDbType.VarChar, 20).Value = model;
                command.Parameters.Add("@price", SqlDbType.Money).Value = price;
                command.Parameters.Add("@milage", SqlDbType.Float).Value = milage;
                command.Parameters.Add("@weight", SqlDbType.Int).Value = weight;
                command.Parameters.Add("@maxspeed", SqlDbType.Int).Value = maxspeed;

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Operacja nie powiadła się!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }

                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Samochód zastał dodany do bazy.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            public static void Delete()
            {
                string reader;
                System.Console.WriteLine();
                System.Console.WriteLine("Aby usunąć wszystkie samochody danej marki wpisz 1, aby usunąć tylko konkretny model samochodu wpisz 2.)");
                System.Console.WriteLine();
                System.Console.Write("Wybierz opcję: ");
                reader = Console.ReadLine();
                System.Console.WriteLine();

                if (reader != "1" && reader != "2")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Opcja nieprawidłowa, nastąpi powrót do menu głównego.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }

                int x = Convert.ToInt32(reader);
                if (x == 1)
                {
                    System.Console.Write("Podaj nazwę marki: ");
                    reader = Console.ReadLine();

                    StringBuilder sb = new StringBuilder();
                    sb.Append($"DELETE FROM Cars WHERE Brand='{reader}'");
                    String sql = sb.ToString();

                    SqlCommand command = new SqlCommand(sql, databaseConnection.connection);
                    command.ExecuteNonQuery();

                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine($"Samochody marki {reader} został usunięte.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (x == 2)
                {
                    System.Console.Write("Podaj nazwę modelu: ");
                    reader = Console.ReadLine();

                    StringBuilder sb = new StringBuilder();
                    sb.Append($"DELETE FROM Cars WHERE Model='{reader}'");
                    String sql = sb.ToString();

                    try
                    {
                        SqlCommand command = new SqlCommand(sql, databaseConnection.connection);
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        System.Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Operacja nie powiadła się!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return;
                    }

                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine($"Samochód o modelu {reader} został usunięty.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            public static void Modify()
            {
                string model;
                double price;

                System.Console.WriteLine();
                System.Console.WriteLine("Aby zmodyfikować cenę pojazdu wprowadź jego model, a następnie nową cenę.");
                System.Console.Write("Model: ");
                model = Console.ReadLine();
                System.Console.Write("Nowa cena (double z przecinkiem): ");
                price = Convert.ToDouble(Console.ReadLine());

                StringBuilder sb = new StringBuilder();
                sb.Append($"UPDATE Cars SET Price='{price}' Where Model='{model}'");
                String sql = sb.ToString();

                SqlCommand command = new SqlCommand(sql, databaseConnection.connection);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Operacja nie powiadła się!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }

                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Dane zostały zaktualizowane.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        static class Menager
        {
            public static void Add()
            {
                string reader;
                string name;
                string surname;
                double salary;

                System.Console.WriteLine();
                System.Console.WriteLine("Aby dodać do bazy nowego menadżera podaj następujące dane (po wpisaniu kliknj Enter):");
                System.Console.Write("Imię: ");
                reader = Console.ReadLine();
                name = reader;
                System.Console.Write("Nazwisko: ");
                reader = Console.ReadLine();
                surname = reader;
                System.Console.Write("Wypłata (double z przecinkiem): ");
                reader = Console.ReadLine();
                salary = Convert.ToDouble(reader);

                StringBuilder sb = new StringBuilder();
                sb.Append($"INSERT INTO Menagers (Name,Surname,Salary) VALUES (@name, @surname, @salary)");
                String sql = sb.ToString();

                SqlCommand command = new SqlCommand(sql, databaseConnection.connection);

                command.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = name;
                command.Parameters.Add("@surname", SqlDbType.VarChar, 20).Value = surname;
                command.Parameters.Add("@salary", SqlDbType.Money).Value = salary;

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Operacja nie powiadła się!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }

                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Menadżer został dodany do bazy.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            public static void Delete()
            {
                string name;
                string surname;
                System.Console.WriteLine();
                System.Console.WriteLine("Aby usunąć menadżera podaj następujące dane:");
                System.Console.Write("Imię: ");
                name = Console.ReadLine();
                System.Console.Write("Nazwisko: ");
                surname = Console.ReadLine();

                StringBuilder sb = new StringBuilder();
                sb.Append($"DELETE FROM Menagers WHERE Name='{name}' AND Surname='{surname}'");
                String sql = sb.ToString();

                try
                {
                    SqlCommand command = new SqlCommand(sql, databaseConnection.connection);
                    command.ExecuteNonQuery();
                }
                catch
                {
                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Operacja nie powiadła się!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }


                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine($"Menadżer {name} {surname} zostal usunięty.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            public static void Modify()
            {
                int menagerID;
                double salary;

                System.Console.WriteLine();
                System.Console.WriteLine("Aby zmodyfikować pensję menadżera wprowadź jego ID, a następnie nową pensję.");
                System.Console.Write("ID menadżera: ");
                menagerID = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Nowa pensja (double z przecinkiem): ");
                salary = Convert.ToDouble(Console.ReadLine());

                StringBuilder sb = new StringBuilder();
                sb.Append($"UPDATE Menagers SET Salary='{salary}' Where MenagerID='{menagerID}'");
                String sql = sb.ToString();

                SqlCommand command = new SqlCommand(sql, databaseConnection.connection);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Operacja nie powiadła się!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }

                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Dane zostały zaktualizowane.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        static class Client
        {
            public static void Add()
            {
                string name;
                string surname;

                System.Console.WriteLine();
                System.Console.WriteLine("Aby dodać do bazy nowego klienta podaj następujące dane (po wpisaniu kliknj Enter):");
                System.Console.Write("Imię: ");
                name = Console.ReadLine();
                System.Console.Write("Nazwisko: ");
                surname = Console.ReadLine();

                StringBuilder sb = new StringBuilder();
                sb.Append($"INSERT INTO Clients (Name,Surname) VALUES (@name, @surname)");
                String sql = sb.ToString();

                SqlCommand command = new SqlCommand(sql, databaseConnection.connection);

                command.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = name;
                command.Parameters.Add("@surname", SqlDbType.VarChar, 20).Value = surname;

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Operacja nie powiadła się!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }

                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Klient został dodany do bazy.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            public static void Delete()
            {
                string name;
                string surname;
                System.Console.WriteLine();
                System.Console.WriteLine("Aby usunąć  klienta podaj następujące dane:");
                System.Console.Write("Imię: ");
                name = Console.ReadLine();
                System.Console.Write("Nazwisko: ");
                surname = Console.ReadLine();

                StringBuilder sb = new StringBuilder();
                sb.Append($"DELETE FROM Clients WHERE Name='{name}' AND Surname='{surname}'");
                String sql = sb.ToString();

                try
                {
                    SqlCommand command = new SqlCommand(sql, databaseConnection.connection);
                    command.ExecuteNonQuery();
                }
                catch
                {
                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Operacja nie powiadła się!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }

                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine($"Klient {name} {surname} zostal usunięty.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        static class Transaction
        {
            public static void Add()
            {
                int menagerID;
                int clientID;
                int carID;
                string date;

                System.Console.WriteLine();
                System.Console.WriteLine("Aby dodać do bazy nową transakcję podaj następujące dane (po wpisaniu kliknj Enter):");
                System.Console.Write("ID menadżera: ");
                menagerID = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("ID klienta: ");
                clientID = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("ID samochodu: ");
                carID = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Data transakcji (dd-mm-rrrr): ");
                date = Console.ReadLine();

                StringBuilder sb = new StringBuilder();
                sb.Append($"INSERT INTO Transactions (MenagerID,ClientID,CarID,Date) VALUES (@menagerID, @clientID,@carID,@date)");
                String sql = sb.ToString();

                try
                {
                    SqlCommand command = new SqlCommand(sql, databaseConnection.connection);

                    command.Parameters.Add("@menagerID", SqlDbType.Int).Value = menagerID;
                    command.Parameters.Add("@clientID", SqlDbType.Int).Value = clientID;
                    command.Parameters.Add("@carID", SqlDbType.Int).Value = carID;
                    command.Parameters.Add("@date", SqlDbType.Date).Value = date;

                    command.ExecuteNonQuery();
                }
                catch
                {
                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Przynajmniej jedno z podanych ID nie istnieje w bazie danych!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }

                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Transakcja została dodana do bazy.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            public static void Delete()
            {
                int transactionID;
                System.Console.WriteLine();
                System.Console.WriteLine("Aby usunąć transakcję podaj następujące dane:");
                System.Console.Write("ID transakcji: ");
                transactionID = Convert.ToInt32(Console.ReadLine());


                StringBuilder sb = new StringBuilder();
                sb.Append($"DELETE FROM Transactions WHERE TransactionID='{transactionID}'");
                String sql = sb.ToString();

                try
                {
                    SqlCommand command = new SqlCommand(sql, databaseConnection.connection);
                    command.ExecuteNonQuery();
                }
                catch
                {
                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Podano nieprawidłowe ID!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }

                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine($"Transakcja o numerze {transactionID} została usunięta.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        static class Raport
        {
            public static void Generate()
            {
                StringBuilder sb1 = new StringBuilder();
                sb1.Append($"SELECT Name, Surname, Brand, Date FROM Transactions t ");
                sb1.Append("JOIN Menagers m on m.MenagerID = t.MenagerID ");
                sb1.Append("JOIN Cars c on c.CarID = t.CarID order by Date desc");
                String sql1 = sb1.ToString();

                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                System.Console.WriteLine("================================== RAPORT ==================================");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                System.Console.WriteLine("{0,-20} {1,-20}   {2,-15} {3:-15}", "Imię menadżera", "Nazwisko menadżera", "Marka", "Data transakcji");
                Console.ForegroundColor = ConsoleColor.Gray;

                using (SqlCommand command = new SqlCommand(sql1, databaseConnection.connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            System.Console.WriteLine("{0,-20} {1,-20}   {2,-15} {3:d}", reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3));
                        }
                    }
                }

                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                System.Console.Write("Łączna wartość sprzedanych pojazdów: ");
                Console.ForegroundColor = ConsoleColor.Gray;

                StringBuilder sb2 = new StringBuilder();
                sb2.Append("SELECT SUM(Price) FROM Transactions t JOIN Cars c on c.CarID = t.CarID WHERE c.CarID = t.CarID");
                String sql2 = sb2.ToString();

                using (SqlCommand command = new SqlCommand(sql2, databaseConnection.connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        System.Console.WriteLine("{0} zł", reader.GetSqlMoney(0));
                    }
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                System.Console.WriteLine("============================================================================");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
