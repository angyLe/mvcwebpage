using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Abstract;
using WebApplication1.Models;
using System.IO;

namespace WebApplication1.Models.repository
{
    public class ImageRepository: IImageRepository
    {
        private Context db = new Context();

        // all images at all
        public IEnumerable <imageLink> GetAll()
        {
            return db.imageLinks;
        }

        // all images of one news
        public IEnumerable <imageLink> Get (news OneNews)
        {
            return OneNews.imgLink;
        }

        // get default image
        public imageLink GetDefault ()
        {
            // TODO
            return null;
        }

        public string SetDefault()
        {
            // TODO
            return null;
        }

        // get only one image
        public imageLink GetOne (int imageLinkId)
        {
            return db.imageLinks.Find(imageLinkId);
        }

        public string Add (imageLink image, HttpPostedFileBase upload, string mapName)
        {
            byte[] imageData = null;
            // считываем переданный файл в массив байтов
            
            if (image == null && upload == null)
            {
                return null;
            }
            // получаем имя файла
            string fileName = System.IO.Path.GetFileName(upload.FileName);

            string mapPath = (mapName != null ? mapPath = mapName + "/" : " ");
            // сохраняем файл в папку Files в проекте
            try
            {
                upload.SaveAs(HttpContext.Current.Server.MapPath("~/Content/img/" + mapPath + fileName));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            try
            {
                db.imageLinks.Add(image);
            }
            catch (Exception ex)
            {
                return "File was not uploaded to the database.Try again!";
            }
            return "File was uploaded";
        }

    }
}