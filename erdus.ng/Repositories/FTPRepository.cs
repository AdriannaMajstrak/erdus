using System;
using System.IO;
using System.Net;

namespace erdus.ng.Repositories
{
    public class FTPRepository : IFTPRepository
    {
        public string SaveFile(Stream fileStream)
        {
            try
            {
                // Get the object used to communicate with the server.

                //FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"ftp://erdusserver.westeurope.cloudapp.azure.com/{Guid.NewGuid()}.bmp");
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"ftp://localhost/{Guid.NewGuid()}.bmp");
                request.Method = WebRequestMethods.Ftp.UploadFile;

                // This example assumes the FTP site uses logon.
                request.Credentials = new NetworkCredential("erdus", "erdus");


                using (Stream requestStream = request.GetRequestStream())
                {
                    fileStream.CopyTo(requestStream);
                }

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    return response.ResponseUri.AbsoluteUri;
                }
            }
            catch (Exception ex)
            {
                ////TODO: Log
                throw;
            }
        }
    }
}
