using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Service
{
    public class Database2Service
    {
        private const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GitHub\WebApplication1\WebApplication1\App_Data\Database2.mdf;Integrated Security=True";
        public List<Models.Genre> LoadAllGenre()
        {
            List<Models.Genre> result = new List<Models.Genre>();

            var connection = new System.Data.SqlClient.SqlConnection(connectionString);
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = @"
Select * from Genres";
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Models.Genre item = new Models.Genre();

                item.GenreId = (int)reader["GenreId"];
                item.Name = reader["Name"].ToString();
                item.Description= reader["Description"].ToString();

                result.Add(item);
            }
            connection.Close();
            return result;
        }


        public List<Models.Albums> LoadAlbumByGenreID(int genreID)
        {
            List<Models.Albums> result = new List<Models.Albums>();

            var connection = new System.Data.SqlClient.SqlConnection(connectionString);
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
Select * from Albums where GenreId={0}",genreID);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Models.Albums item = new Models.Albums();

                item.AlbumID = (int)reader["AlbumId"];
                item.GenreId = (int)reader["GenreID"];
                item.Price = (decimal)reader["Price"];
                item.Title = reader["Title"].ToString();
                item.AlbumArtUrl = reader["AlbumArtUrl"].ToString();
                result.Add(item);
            }
            connection.Close();
            return result;
        }

    }
}