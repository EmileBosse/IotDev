using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace restApp
{
    [ServiceContract]
    public interface IMultimedia
    {
        [OperationContract, WebInvoke(UriTemplate = "/photo?name={name}", Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string getPhoto(string name);

        [OperationContract, WebInvoke(UriTemplate = "/photo", Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string getAllPhoto();

        [OperationContract, WebInvoke(UriTemplate = "/video?name={name}", Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string getVideo(string name);

        [OperationContract, WebInvoke(UriTemplate = "/video", Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string getAllVideo();

        [OperationContract, WebInvoke(UriTemplate = "/music?name={name}", Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string getMusic(string name);

        [OperationContract, WebInvoke(UriTemplate = "/musics", Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string getAllMusic();
    }

    public class Multimedia : IMultimedia
    {
        private string pathPhoto = "C:\\Users\\EmileBosse\\Pictures";
        private string pathVideo = "C:\\Users\\EmileBosse\\Videos";
        private string pathMusic = "C:\\Users\\EmileBosse\\Music";

        public string getPhoto(string name)
        {
            return utils.getJson(createPhotoEntity(pathPhoto + "\\" + name));
        }

        public string getVideo(string name)
        {
            return utils.getJson(createVideoEntity(pathVideo + "\\" + name));
        }

        public string getMusic(string name)
        {
            return utils.getJson(createMusicEntity(pathMusic + "\\" + name));
        }

        public string getAllPhoto()
        {
            List<PhotoEntity> photos = new List<PhotoEntity>();
            string[] dirs = Directory.GetFiles(pathPhoto, "*");
            foreach (string file in dirs)
            {
                PhotoEntity p = createPhotoEntity(file);
                if (p != null)
                {
                    photos.Add(p);
                }
            }
            return utils.getJson(photos);
        }

        public string getAllVideo()
        {
            List<VideoEntity> videos = new List<VideoEntity>();
            string[] dirs = Directory.GetFiles(pathVideo, "*");
            foreach (string file in dirs)
            {
                VideoEntity p = createVideoEntity(file);
                if (p != null)
                {
                    videos.Add(p);
                }
            }
            return utils.getJson(videos);
        }

        public string getAllMusic()
        {
            List<MusicEntity> videos = new List<MusicEntity>();
            string[] dirs = Directory.GetFiles(pathMusic, "*");
            foreach (string file in dirs)
            {
                MusicEntity p = createMusicEntity(file);
                if (p != null)
                {
                    videos.Add(p);
                }
            }
            return utils.getJson(videos);
        }

        private MusicEntity createMusicEntity(string path)
        {
            return new MusicEntity(path);
        }

        private PhotoEntity createPhotoEntity(string path)
        {
            return new PhotoEntity(path);
        }

        private VideoEntity createVideoEntity(string path)
        {
            return new VideoEntity(path);
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

    class VideoEntity
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

    class MusicEntity
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

    class utils
    {
        public static string getJson(Object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }

        public static string getJson(List<Object> objs)
        {
            return new JavaScriptSerializer().Serialize(objs);
        }
    }
    
}
