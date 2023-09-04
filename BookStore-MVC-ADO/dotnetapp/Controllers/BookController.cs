using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using dotnetapp.Models; // Replace YourNamespace with the actual namespace of your models

public class BookController : Controller
{
    private readonly string connectionString = "User ID=sa;password=examlyMssql@123;server=dffafdafebcfacbdcbaeadbebabcdebdca-0;Database=BookStoreDB;trusted_connection=false;Persist Security Info=False;Encrypt=False"; // Replace with your SQL Server connection string
    // private string connectionString = "User ID=sa;password=examlyMssql@123;server=dffafdafebcfacbdcbaeadbebabcdebdca-0;Database=GymDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";

    // GET: /Book
    public ActionResult Index()
    {
        List<Book> books = GetBooksFromDatabase();
        return View(books);
    }

    // GET: /Book/Details/5
    public ActionResult Details(int id)
    {
        Book book = GetBookByIdFromDatabase(id);
        if (book == null)
        {
            return HttpNotFound();
        }
        return View(book);
    }

    // Helper methods for database interaction
    private List<Book> GetBooksFromDatabase()
    {
        List<Book> books = new List<Book>();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Books", connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            using (DataTable dataTable = new DataTable())
            {
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    books.Add(new Book
                    {
                        BookID = Convert.ToInt32(row["BookID"]),
                        Title = row["Title"].ToString(),
                        Author = row["Author"].ToString(),
                        Genre = row["Genre"].ToString(),
                        Price = Convert.ToDecimal(row["Price"]),
                        Quantity = Convert.ToInt32(row["Quantity"])
                    });
                }
            }
        }
        return books;
    }

    private Book GetBookByIdFromDatabase(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Books WHERE BookID = @BookID", connection))
            {
                command.Parameters.AddWithValue("@BookID", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Book
                        {
                            BookID = Convert.ToInt32(reader["BookID"]),
                            Title = reader["Title"].ToString(),
                            Author = reader["Author"].ToString(),
                            Genre = reader["Genre"].ToString(),
                            Price = Convert.ToDecimal(reader["Price"]),
                            Quantity = Convert.ToInt32(reader["Quantity"])
                        };
                    }
                }
            }
        }
        return null;
    }
}
