using System;
using System.Collections.Generic;
using System.Text;
using BusinessObject;
using DataAccess;

namespace BusinessLogic
{
    public class MusicLogic
    {

        public List<AlbumBO> GetAlbum()
        {
            return new MusicDataAcess().GetAlbumList();
        }
        public AlbumBO PostMusic(AlbumBO item)
        {
            return new MusicDataAcess().createMusic(item);
        }

        public AlbumBO PutAlbum(AlbumBO item)
        {
            return new MusicDataAcess().UpdateAlbum(item);
        }

        public AlbumBO DeleteAlbum(AlbumBO item)
        {
            return new MusicDataAcess().DeleteAlbum(item);
        }
    }
}
