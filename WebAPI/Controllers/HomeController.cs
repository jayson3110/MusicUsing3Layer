using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using BusinessObject;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Album()
        {
            List<AlbumBO> model = new MusicLogic().GetAlbum();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            List<AlbumBO> model = new MusicLogic().GetAlbum();
            var getId = model.Single(m => m.album_id == id);

            return View(getId);
        }
        public ActionResult DeleteBlog(int id)
        {
            List<AlbumBO> model = new MusicLogic().GetAlbum();
            var getId = model.Single(m => m.album_id == id);

            return View(getId);
        }


    }
}
