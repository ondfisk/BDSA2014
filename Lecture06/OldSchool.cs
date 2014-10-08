using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Lecture06
{
    public class OldSchool
    {
        public IEnumerable<OldSchoolProduct> Read()
        {
            var sql = "SELECT * FROM Products ORDER BY Id";
            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        var product = new OldSchoolProduct
                        {
                            Id = (int) reader["Id"],
                            Name = reader["Name"] as string,
                            Price = (decimal) reader["Price"]
                        };

                        yield return product;
                    }
                }
            }
        }

        public OldSchoolProduct Read(int productId)
        {
            var sql = "SELECT Id, Name, Price FROM Products WHERE Id = @Id";
            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", productId);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        return null;
                    }
                    reader.Read();

                    var product = new OldSchoolProduct
                    {
                        Id = (int) reader["Id"],
                        Name = reader["Name"] as string,
                        Price = (decimal) reader["Price"]
                    };

                    return product;
                }
            }
        }

        public int Create(OldSchoolProduct product)
        {
            var sql = "INSERT Products (Name, Price) VALUES (@Name, @Price); SELECT SCOPE_IDENTITY()";
            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);

                connection.Open();

                var id = (int) command.ExecuteScalar();

                return id;
            }
        }

        public void Update(OldSchoolProduct product)
        {
            var sql = "UPDATE Products SET Name = @Name, Price = @Price WHERE Id = @Id";
            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int productId)
        {
            var sql = "DELETE WHERE Id = @Id";
            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", productId);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }

    public class OldSchoolProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0, -3} {1, -65} {0:c}", Id, Name, Price);
        }
    }
}
 