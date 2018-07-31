using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Net;
using System.IO;

namespace restApp
{
    #region Photo
    interface IPhoto
    {
        [OperationContract, WebInvoke(UriTemplate = "/photo", Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PhotoEntity get(string path);

        [OperationContract, WebInvoke(UriTemplate = "/photos", Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<PhotoEntity> get();
    }

    class Photo : IPhoto
    {
        private string path = "D://pictures/";

        public PhotoEntity get(string name)
        {
            return createPhotoEntity(path + name); ;
        }

        public List<PhotoEntity> get()
        {
            List<PhotoEntity> photos = new List<PhotoEntity>();
            string[] dirs = Directory.GetFiles(path, "*");
            foreach (string file in dirs)
            {
                PhotoEntity p = createPhotoEntity(file);
                if (p != null)
                {
                    photos.Add(p);
                }
            }
            return photos;
        }

        private PhotoEntity createPhotoEntity(string path)
        {
            return new PhotoEntity(path);
        }
    }

    class PhotoEntity
    {
        public byte[] img { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string type { get; set; }

        public PhotoEntity(string path)
        {
            this.path = path;
            this.name = path.Split('\\')[path.Split('\\').Length - 1];
            this.type = path.Split('.')[path.Split('.').Length - 1];
            this.img = File.ReadAllBytes(path);
        }
    }
    #endregion
    #region video
    public interface IVideo
    {
        [OperationContract, WebInvoke(UriTemplate = "/video", Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        VideoEntity get(string path);

        [OperationContract, WebInvoke(UriTemplate = "/videos", Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<VideoEntity> get();
    }

    public class Video : IVideo
    {
        private string path = "D://Videos/";

        public VideoEntity get(string path)
        {
            return createVideoEntity(path);
        }

        public List<VideoEntity> get()
        {
            List<VideoEntity> videos = new List<VideoEntity>();
            string[] dirs = Directory.GetFiles(path, "*");
            foreach (string file in dirs)
            {
                VideoEntity p = createVideoEntity(file);
                if (p != null)
                {
                    videos.Add(p);
                }
            }
            return videos;
        }

        private VideoEntity createVideoEntity(string path)
        {
            return new VideoEntity(path);
        }
    }

    public class VideoEntity
    {
        public byte[] vid { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string type { get; set; }
        public VideoEntity(string path)
        {
            this.path = path;
            this.name = path.Split('\\')[path.Split('\\').Length - 1];
            this.type = path.Split('\\')[path.Split('\\').Length - 1];
            this.vid = File.ReadAllBytes(path);
        }
    }
    #endregion
    #region music
    public interface IMusic
    {
        [OperationContract, WebInvoke(UriTemplate = "/music", Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        MusicEntity get(string path);

        [OperationContract, WebInvoke(UriTemplate = "/musics", Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<MusicEntity> get();
    }

    public class Music : IMusic
    {
        private string path = "D://musics/";

        public MusicEntity get(string path)
        {
            return createMusicEntity(path);
        }

        public List<MusicEntity> get()
        {
            List<MusicEntity> videos = new List<MusicEntity>();
            string[] dirs = Directory.GetFiles(path, "*");
            foreach (string file in dirs)
            {
                MusicEntity p = createMusicEntity(file);
                if (p != null)
                {
                    videos.Add(p);
                }
            }
            return videos;
        }

        private MusicEntity createMusicEntity(string path)
        {
            return new MusicEntity(path);
        }
    }

    public class MusicEntity
    {
        public byte[] song { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string type { get; set; }
        public MusicEntity(string path)
        {
            this.path = path;
            this.name = path.Split('\\')[path.Split('\\').Length - 1];
            this.type = path.Split('\\')[path.Split('\\').Length - 1];
            this.song = File.ReadAllBytes(path);
        }
    }
    #endregion
}
