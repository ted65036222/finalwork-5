using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Service
{
    public class DatabaseService
    {

        public List<Models.Album> LoadAllAlbum()
        {
            List<Models.Album> result = new List<Models.Album>();

            var connection = new System.Data.SqlClient.SqlConnection(@"
Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\homejia\Desktop\KUAS-1230\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = @"
Select * from Album";
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Models.Album item = new Models.Album();

                item.ID = reader["ID"].ToString();
                item.Name = reader["Name"].ToString();
                item.Number = reader["Number"].ToString();
                item.Email = reader["Email"].ToString();
                item.ImageUrl = reader["ImageUrl"].ToString();
                result.Add(item);
            }
            connection.Close();
            return result;
        }
        public Models.Album GetAlbumByID(string id)
        {
           Models.Album result = new Models.Album();

            var connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\homejia\Desktop\KUAS-1230\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
Select * from Album
Where ID='{0}'", id);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Models.Album item = new Models.Album();

                item.ID = reader["ID"].ToString();
                item.Name = reader["Name"].ToString();
                item.Number = reader["Number"].ToString();
                item.Email = reader["Email"].ToString();
                item.ImageUrl = reader["ImageUrl"].ToString();
                result = item;
            }
            connection.Close();
            return result;
        }
        public void CreateAlbum(Models.Album newAlbum)
        {
            var connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\homejia\Desktop\KUAS-1230\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT        INTO    Album(ID, Name, Number, Email, ImageUrl)
VALUES          ('{0}',N'{1}',N'{2}',N'{3}',N'{4}')
", newAlbum.ID, newAlbum.Name, newAlbum.Number, newAlbum.Email, newAlbum.ImageUrl);

            command.ExecuteNonQuery();
            

            connection.Close();
        }


        public void DeleteAlbum(string id)
        {
            var connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\homejia\Desktop\KUAS-1230\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
DELETE FROM Album
Where ID='{0}'
", id);

            command.ExecuteNonQuery();
            connection.Close();

        }
        public void UpdateAlbum(Models.Album updateAlbum)
        {
            var connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\homejia\Desktop\KUAS-1230\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
UPDATE          Album
SET             Name=N'{1}',Number=N'{2}',Email=N'{3}',ImageUrl=N'{4}'
Where           ID='{0}'
", updateAlbum.ID, updateAlbum.Name, updateAlbum.Number, updateAlbum.Email, updateAlbum.ImageUrl);
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}