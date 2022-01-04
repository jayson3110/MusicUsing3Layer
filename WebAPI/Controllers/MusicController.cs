using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BusinessLogic;
using BusinessObject;
using System.Net.Http;
using System.Net;

namespace WebAPI.Controllers
{
    public class MusicController : ApiController
    {
        // GET: Music
        public List<AlbumBO> GetAllAlbum()
        {
            List<AlbumBO> model = new MusicLogic().GetAlbum();
            return model;
        }

        public HttpResponseMessage PostAlbum(AlbumBO item)
        {
            item = new MusicLogic().PostMusic(item);
            var response = Request.CreateResponse<AlbumBO>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { id = item.album_id });
            response.Headers.Location = new Uri(uri);

            return response;

        }

        public HttpResponseMessage PutAlbum(AlbumBO item)
        {
            item = new MusicLogic().PutAlbum(item);
            var response = Request.CreateResponse<AlbumBO>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { id = item.album_id });
            response.Headers.Location = new Uri(uri);

            return response;

        }

        public HttpResponseMessage DeleteBlog(AlbumBO item)
        {
            item = new MusicLogic().DeleteAlbum(item);
            var response = Request.CreateResponse<AlbumBO>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { id = item.album_id });
            response.Headers.Location = new Uri(uri);

            return response;

        }


    }
}