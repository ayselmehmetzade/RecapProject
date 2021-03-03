using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileUploadHelper
    {
        const string ImageFolder = @"\App_Data\Images";
        public static string Add(IFormFile formFile)
        {
            var sourcePath = Path.GetTempFileName();
            if (formFile.Length > 0)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            var result = NewFolderPath(formFile);
            File.Move(sourcePath, result);
            return result;
        }
        public static string NewFolderPath(IFormFile formFile)
        {
            FileInfo fileInfo = new FileInfo(formFile.FileName);
            string fileExtension = fileInfo.Extension;
            string path = Environment.CurrentDirectory + ImageFolder;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var newPath = Guid.NewGuid().ToString("N")+ fileExtension;
            string result = $@"{path}\{newPath}";
            return result;
        }

        public static string Update(string sourcePath, IFormFile formFile)
        {
            var result = NewFolderPath(formFile);
            if (sourcePath.Length > 0 )
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }
        public static void Delete(string path)
        {
            File.Delete(path);
        }
    }
}
