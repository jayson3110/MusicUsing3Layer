using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using BusinessObject;
using System.Data;

namespace DataAccess
{
    public class MusicDataAcess
    {
        public SqlConnection con = new SqlConnection("data source=JAYSON\\SQLEXPRESS; database=MusicSystem; integrated security=SSPI; MultipleActiveResultSets=True");

        public List<AlbumBO> GetAlbumList()
        {

            SqlCommand cmd = new SqlCommand();
            var model = new List<AlbumBO>();

            cmd.Connection = con;
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAlbums";

            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                var album = new AlbumBO();
                album.album_id += (int)sdr["album_id"];
                album.album_Title += sdr["album_Title"];
                album.album_Producer += sdr["album_Producer"];
                album.album_Year += sdr["album_Year"];
                album.song_Title += sdr["song_Title"];


                model.Add(album);



            }
            con.Close();
            return model;

        }

        public AlbumBO createMusic(AlbumBO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            con.Open();
            try
            {

                SqlCommand cm = new SqlCommand("PostAlbum", con);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new SqlParameter("@album_id", item.album_id));
                cm.Parameters.Add(new SqlParameter("@album_Producer", item.album_Producer));
                cm.Parameters.Add(new SqlParameter("@album_Title", item.album_Title));
                cm.Parameters.Add(new SqlParameter("@album_Year", item.album_Year));


                cm.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();

            }
            return item;
        }

        public AlbumBO UpdateAlbum(AlbumBO item)
        {


            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            con.Open();
            try
            {

                SqlCommand cm = new SqlCommand("PUTAlbum", con);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new SqlParameter("@album_id", item.album_id));
                cm.Parameters.Add(new SqlParameter("@album_Producer", item.album_Producer));
                cm.Parameters.Add(new SqlParameter("@album_Title", item.album_Title));
                cm.Parameters.Add(new SqlParameter("@album_Year", item.album_Year));


                cm.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();

            }
            return item;
        }
        public AlbumBO DeleteAlbum(AlbumBO item)
        {

            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            con.Open();
            try
            {

                SqlCommand cm = new SqlCommand("DELETEAlbum", con);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new SqlParameter("@album_id", item.album_id));


                cm.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();

            }
            return item;
        }


    }
}
