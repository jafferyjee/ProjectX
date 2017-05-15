using Newtonsoft.Json;
using ProjectX.Web.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ProjectX.Web.Api
{
    public class PhotoController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> Upload() 
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                    this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);

                var provider = GetMultipartStreamProvider();
                var result = await Request.Content.ReadAsMultipartAsync(provider);

                //var file = GetFormData<FileUploadData>(result);
                var fileName = GenerateFileName(result.FileData.First());
                var path = Path.GetDirectoryName(result.FileData.First().LocalFileName);

                File.Move(result.FileData.First().LocalFileName, Path.Combine(path, fileName));

                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            catch 
            {
                //todo: log exception in db.
                return this.Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted");
            }
        }


        private MultipartFormDataStreamProvider GetMultipartStreamProvider() 
        {
            var uploadFolder = Util.UploadPath;
            var root = HttpContext.Current.Server.MapPath(uploadFolder);

            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);

            return new MultipartFormDataStreamProvider(root);
        }

        private T GetFormData<T>(MultipartFormDataStreamProvider result) 
        {
            if (result.FormData.HasKeys()) 
            {
                var unescapedFormData = Uri.UnescapeDataString(result.FormData.GetValues(0).FirstOrDefault() ?? string.Empty);
                if (!string.IsNullOrEmpty(unescapedFormData))
                    return JsonConvert.DeserializeObject<T>(unescapedFormData);
            }

            return default(T);
        }

        private string GetDeserializedFileName(MultipartFileData fileData) 
        {
            if (string.IsNullOrEmpty(fileData.Headers.ContentDisposition.FileName)) 
            {
                throw new ArgumentException("Invalid file name.");
            }
            
            string fileName = fileData.Headers.ContentDisposition.FileName;
            
            if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
            {
                fileName = fileName.Trim('"');
            }
            if (fileName.Contains(@"/") || fileName.Contains(@"\"))
            {
                fileName = Path.GetFileName(fileName);
            }            

            return fileName;
        }

        private string GenerateFileName(MultipartFileData fileData) 
        {
            string fileName = GetDeserializedFileName(fileData);
            if (!string.IsNullOrEmpty(fileName)) 
            {
                fileName = string.Format("{0}{1}", Guid.NewGuid().ToString("N").ToString(), Path.GetExtension(fileName));
            }
            return fileName;
        }
    }

    public class FileUploadData 
    {
        public string Side { get; set; }
    }
}