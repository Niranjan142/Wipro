using BookStoreADO.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BookStoreADO.Data
{
    public class BookRepository
    {
        private readonly string _connectionString;

        public BookRepository(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("DefaultConnection");
        }

        // READ USING SQLDATAREADER
        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();

            using(SqlConnection con =
                new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Books";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                con.Open();

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while(reader.Read())
                {
                    books.Add(new Book
                    {
                        BookId = Convert.ToInt32(reader["BookId"]),
                        Title = reader["Title"].ToString(),
                        Author = reader["Author"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Quantity = Convert.ToInt32(reader["Quantity"])
                    });
                }
            }

            return books;
        }

        // ADD USING STORED PROCEDURE
        public void AddBook(Book book)
        {
            using(SqlConnection con =
                new SqlConnection(_connectionString))
            {
                SqlCommand cmd =
                    new SqlCommand("sp_AddBook", con);

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Price", book.Price);
                cmd.Parameters.AddWithValue("@Quantity", book.Quantity);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // UPDATE USING STORED PROCEDURE
        public void UpdateBook(Book book)
        {
            using(SqlConnection con =
                new SqlConnection(_connectionString))
            {
                SqlCommand cmd =
                    new SqlCommand("sp_UpdateBook", con);

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BookId", book.BookId);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Price", book.Price);
                cmd.Parameters.AddWithValue("@Quantity", book.Quantity);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE USING STORED PROCEDURE
        public void DeleteBook(int id)
        {
            using(SqlConnection con =
                new SqlConnection(_connectionString))
            {
                SqlCommand cmd =
                    new SqlCommand("sp_DeleteBook", con);

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BookId", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
