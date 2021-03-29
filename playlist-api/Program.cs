using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace playlist_api
{
    public class Program
    {

        static void Main(string[] args)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "127.0.0.1";
                builder.UserID = "SA";
                builder.Password = "";
                builder.InitialCatalog = "PlaylistApp";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    //string directory = System.IO.Directory.GetParent(Directory.GetCurrentDirectory()) + "/Database/StoreProcs/GetAllPlaylists.sql";
                    //Console.WriteLine(directory);
                    //string text = System.IO.File.ReadAllText(directory);

                    //set stored procedure name
                    string storeProcName = @"dbo.[GetAllPlaylists]";

                    SqlCommand cmd = new SqlCommand(storeProcName, connection);
                    //Console.WriteLine("\nQuery data example:");
                    //Console.WriteLine("=========================================\n");

                    //connection.Open();

                    //open connection
                    connection.Open();

                    //set the SqlCommand type to stored procedure and execute
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //parse playlist
                            int playlistId = reader.GetInt32(0);
                            string playlistTitle = reader.GetString(1);
                            string playlistDescription = reader.GetString(2);
                            DateTime playlistCreatedDate = reader.GetDateTime(3);
                            DateTime playlistModifiedDate = reader.GetDateTime(4);
                            string playlistGenre = reader.GetString(5);

                            Console.WriteLine("{0},{1},{2},{3},{4},{5}", playlistId.ToString(), playlistTitle, playlistDescription, playlistCreatedDate, playlistModifiedDate, playlistGenre);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                    reader.Close();

                    //close connection
                    connection.Close();

                    //String sql = "SELECT name, collation_name FROM sys.databases";

                    //using (SqlCommand command = new SqlCommand(sql, connection))
                    //{
                    //    using (SqlDataReader reader = command.ExecuteReader())
                    //    {
                    //        while (reader.Read())
                    //        {
                    //            Console.WriteLine(reader.GetString(0), reader.GetString(1));
                    //            Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                    //        }
                    //    }
                    //}
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }
        //public static void Main(string[] args)
        //{
        //    var host = new WebHostBuilder()
        //        .UseKestrel()
        //        .UseContentRoot(Directory.GetCurrentDirectory())
        //        .UseIISIntegration()
        //        .UseStartup<Startup>()
        //        .Build();

        //    host.Run();
        //}

        //public class Program
        //{
        //    public static void Main(string[] args)
        //    {
        //        CreateHostBuilder(args).Build().Run();
        //    }

        //    public static IHostBuilder CreateHostBuilder(string[] args) =>
        //        Host.CreateDefaultBuilder(args)
        //            .ConfigureWebHostDefaults(webBuilder =>
        //            {
        //                webBuilder.UseStartup<Startup>();
        //            });
        //}
    }
}
