using Npgsql;
using System;
using System.Collections.Generic;

namespace ListofBooksByGenre.Classes
{
    public class DatabasePG
    {
        public LiteraryGenres literaryGenres { get; set; }
        private static string Host;
        private static string Port;
        private static string User;
        private static string Password;
        private static string DatabaseName;
        private string Query;

        public DatabasePG() { }

        private string ConnectionDB()
        {
            Host = "localhost";
            Port = "3300";
            User = "postgres";
            Password = "NovaSenha.123";
            DatabaseName = "booklist";

            return $"Server={Host};Port={Port};Username={User};Password={Password}; Database={DatabaseName}";
        }

        public void InsertBook(Book book)
        {
            Query = $@"INSERT INTO booklist(isbn, title, author, noofpages,publishcompany, literaygenres ) +
                VALUES ('{book.ISBN}', 
                        '{book.Title}', 
                        '{book.Author}',
                        '{book.NoOfPages}', 
                        '{book.PublishCompany}', 
                        '{book.LiteraryGenre}' )";
            _ExecuteQuery(Query);
        }


        public IEnumerable<Book> SearchAllBooks()
        {

            Query = $@"SELECT * FROM booklist";

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB()))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(Query, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Book()
                            {
                                ISBN = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Author = reader.GetString(2),
                                NoOfPages = reader.GetInt32(3),
                                PublishCompany = reader.GetString(4),
                                LiteraryGenre = (LiteraryGenres)reader.GetValue(5)
                            };
                        }
                    }
                }
            }
        }
        private void _ExecuteQuery(string query)
        {
            throw new NotImplementedException();
        }
    }
}
