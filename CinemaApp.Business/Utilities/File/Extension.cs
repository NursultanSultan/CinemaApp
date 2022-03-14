using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Utilities.File
{
    public static class Extension
    {

        public static bool CheckFileType(this IFormFile file, string type)
        {
            return file.ContentType.Contains(type);
        }

        public static bool CheckFileSize(this IFormFile file, int kb)
        {
            return file.Length / 1024 < kb;
        }


        public async static Task<string> SaveFileAsync(this IFormFile file, string root)
        {
            string FileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string resultPath = Path.Combine(root, FileName);

            using (FileStream stream = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return FileName;
        }
    }
}
