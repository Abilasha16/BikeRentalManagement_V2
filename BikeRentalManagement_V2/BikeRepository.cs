using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRentalManagement_V2
{
    public class BikeRepository
    {
        private string _connectionstring;

        public BikeRepository(string connectionstring)
        {
            _connectionstring = connectionstring;
        }
        //AddBike
        public void AddBike(Bike bike)
        {
            using(var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                var cmd = new SqlCommand("insert into Bikes(BikeId,Brand,Model,RentalPrice)values(@id,@brand,@model,@price)",connection);
                cmd.Parameters.AddWithValue("@id",bike.BikeId);
                cmd.Parameters.AddWithValue("@brand", bike.Brand);
                cmd.Parameters.AddWithValue("@model", bike.Model);
                cmd.Parameters.AddWithValue("@price", bike.RentalPrice);
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Bike added successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        //View Bikes
        public void GetBikes()
        {
            using(var connection =new SqlConnection(_connectionstring))
            {
                connection.Open();
                var cmd = new SqlCommand("select * from Bikes",connection);
                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID:{reader["BikeId"]} Brand:{reader["Brand"]} Model:{reader["Model"]} RentalPrice:{reader["RentalPrice"]}");
                    }
                }
            }
        }
        //Update Bikes
        public void EditBike(string id,string newBrand,string newModel,decimal newPrice)
        {
            using( var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                var cmd = new SqlCommand("update Bikes set  Brand=@brand,Model=@model,RentalPrice=@price where BikeId = @id", connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@brand", newBrand);
                cmd.Parameters.AddWithValue("@model", newModel);
                cmd.Parameters.AddWithValue("@price", newPrice);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Bike updated successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        //DeleteBike
        public void DeleteBike(string id)
        {
            using(var conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                var cmd = new SqlCommand("delete from Bikes where BikeId = @id",conn);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Bike deleted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
