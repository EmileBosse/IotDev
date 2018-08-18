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

        [OperationContract, WebInvoke(UriTemplate = "/music", Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string getAllMusic();
    }

    public class Multimedia : IMultimedia
    {
        private string pathPhoto = "C:\\Users\\EmileBosse\\Pictures";
        private string pathVideo = "C:\\Users\\EmileBosse\\Videos";
        private string pathMusic = "C:\\Users\\EmileBosse\\Music";

        public string getPhoto(string name)
        {
            PhotoEntity photo = new PhotoEntity();
            photo = (PhotoEntity)createEntity(pathPhoto + "\\" + name, photo);
            if(photo != null)
                return utils.getJson(photo);
            return "{No photo with this name.}";
        }

        public string getVideo(string name)
        {
            VideoEntity video = new VideoEntity();
            video = (VideoEntity)createEntity(pathVideo + "\\" + name, video);
            if(video != null)
                return utils.getJson(video);
            return "{No video with this name.}";
        }

        public string getMusic(string name)
        {
            MusicEntity music = new MusicEntity();
            music = (MusicEntity)createEntity(pathMusic + "\\" + name, music);
            if (music != null)
                return utils.getJson(music);
            return "{No music with this name.}";
        }

        public string getAllPhoto()
        {
            List<PhotoEntity> photos = new List<PhotoEntity>();
            string[] dirs = Directory.GetFiles(pathPhoto, "*");
            foreach (string file in dirs)
            {
                PhotoEntity p = new PhotoEntity();
                p = (PhotoEntity)createEntity(file, p);
                if (p != null)
                {
                    photos.Add(p);
                }
            }
            return utils.getJson(photos);
        }

        public string getAllVideo()
        {
            List<VideoEntityView> videos = new List<VideoEntityView>();
            string[] dirs = Directory.GetFiles(pathVideo, "*");
            foreach (string file in dirs)
            {
                VideoEntity p = new VideoEntity();
                p = (VideoEntity)createEntity(file, p);
                if (p != null)
                {
                    videos.Add(new VideoEntityView(p));
                }
            }
            return utils.getJson(videos);
        }

        public string getAllMusic()
        {
            List<MusicEntityView> videos = new List<MusicEntityView>();
            string[] dirs = Directory.GetFiles(pathMusic, "*");
            foreach (string file in dirs)
            {
                MusicEntity p = new MusicEntity();
                p = (MusicEntity)createEntity(file, p);
                if (p != null)
                {
                    videos.Add(new MusicEntityView(p));
                }
            }
            return utils.getJson(videos);
        }

        private Entity createEntity(string path, Entity type)
        {
            if (utils.isValid(path.Split('.')[path.Split('.').Length - 1], type.getValidType()))
            {
                type.setEntity(path);
                return type;
            }
            return null;
        }
    }

    interface Entity
    {
        string[] getValidType();
        void setEntity(string path);
    }

    class PhotoEntity : Entity
    {
        public byte[] img { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string type { get; set; }
        private string[] validType = { "png", "PNG", "JPEG", "jpeg", "jpg", "JPG" };

        public PhotoEntity() { }
        public PhotoEntity(string path)
        {
            this.path = path;
            this.name = path.Split('\\')[path.Split('\\').Length - 1];
            this.type = path.Split('.')[path.Split('.').Length - 1];
            this.img = File.ReadAllBytes(path);
        }

        public void setEntity(string path)
        {
            Console.WriteLine("in the Pictures one");
            this.path = path;
            this.name = path.Split('\\')[path.Split('\\').Length - 1];
            this.type = path.Split('.')[path.Split('.').Length - 1];
            this.img = File.ReadAllBytes(path);
        }

        public string[] getValidType()
        {
            return this.validType;
        }
    }

    class VideoEntity : Entity
    {
        public byte[] vid { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string type { get; set; }
        private string[] validType = { "mp4", "MP4", "wav", "WAV" };

        public VideoEntity() { }
        public VideoEntity(string path)
        {
            this.path = path;
            this.name = path.Split('\\')[path.Split('\\').Length - 1];
            this.type = path.Split('.')[path.Split('.').Length - 1];
            this.vid = File.ReadAllBytes(path);
        }

        public void setEntity(string path)
        {
            Console.WriteLine("in the Video one");
            this.path = path;
            this.name = path.Split('\\')[path.Split('\\').Length - 1];
            this.type = path.Split('.')[path.Split('.').Length - 1];
            this.vid = File.ReadAllBytes(path);
        }

        public string[] getValidType()
        {
            return this.validType;
        }
    }

    class VideoEntityView
    {
        public string name { get; set; }
        public string path { get; set; }
        public string type { get; set; }
        public VideoEntityView(VideoEntity entity)
        {
            name = entity.name;
            path = entity.path;
            type = entity.type;
        }
    }

    class MusicEntity : Entity
    {
        public byte[] song { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string type { get; set; }
        private string[] validType = { "mp3", "MP3" };

        public MusicEntity() { }
        public MusicEntity(string path)
        {
            this.path = path;
            this.name = path.Split('\\')[path.Split('\\').Length - 1];
            this.type = path.Split('.')[path.Split('.').Length - 1];
            this.song = File.ReadAllBytes(path);
        }

        public void setEntity(string path)
        {
            Console.WriteLine("in the Music one");
            this.path = path;
            this.name = path.Split('\\')[path.Split('\\').Length - 1];
            this.type = path.Split('.')[path.Split('.').Length - 1];
            this.song = File.ReadAllBytes(path);
        }

        public string[] getValidType()
        {
            return this.validType;
        }
    }

    class MusicEntityView
    {
        public string name { get; set; }
        public string path { get; set; }
        public string type { get; set; }
        public MusicEntityView(MusicEntity entity)
        {
            name = entity.name;
            path = entity.path;
            type = entity.type;
        }
    }

    class utils
    {
        public static bool isValid(string type, string[] validType)
        {
            foreach(string s in validType)
            {
                if (s == type)
                    return true;
            }
            return false;
        }

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
