using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using restApi.Models;

namespace restApi.Services
{
    public class PhotoService
    {
        public PhotoService()
        {

        }

        public Photo getFile(string path)
        {
            try
            {
                Photo photo = new Photo();
                photo.fromFile(path);
                return photo;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
    }
}