using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace TransfersApp
{
    public static class DatabaseHelper
    {
        private static readonly string ConnectionString = 
            @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Database=TransfersAppDB;";

        public static void InitializeDatabase()
        {
            using (var master = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;"))
            {
                master.Open();
                string createDb = @"
                    IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'TransfersAppDB')
                    CREATE DATABASE TransfersAppDB";
                using (var cmd = new SqlCommand(createDb, master))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string createTable = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Transactions' AND xtype='U')
                    CREATE TABLE Transactions (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        FromAccount NVARCHAR(100) NOT NULL,
                        ToAccount NVARCHAR(100) NOT NULL,
                        Amount DECIMAL(18,2) NOT NULL,
                        Date DATETIME2 NOT NULL
                    )";
                using (var cmd = new SqlCommand(createTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void SaveTransaction(Transaction transaction)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string sql = @"
                    INSERT INTO Transactions (FromAccount, ToAccount, Amount, Date)
                    VALUES (@from, @to, @amount, @date)";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@from", transaction.FromAccount);
                    command.Parameters.AddWithValue("@to", transaction.ToAccount);
                    command.Parameters.AddWithValue("@amount", transaction.Amount);
                    command.Parameters.AddWithValue("@date", transaction.Date);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<Transaction> GetAllTransactions()
        {
            var transactions = new List<Transaction>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string sql = "SELECT Id, FromAccount, ToAccount, Amount, Date FROM Transactions ORDER BY Date DESC";
                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transactions.Add(new Transaction
                        {
                            Id = reader.GetInt32("Id"),
                            FromAccount = reader.GetString("FromAccount"),
                            ToAccount = reader.GetString("ToAccount"),
                            Amount = reader.GetDecimal("Amount"),
                            Date = reader.GetDateTime("Date")
                        });
                    }
                }
            }
            return transactions;
        }
    }
}
