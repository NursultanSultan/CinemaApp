using CinemaApp.Business.Exceptions.ImageException;

namespace CinemaApp.Business.Exceptions.FileExceptions
{
    public class FileSizeException : FileException
    {
        public FileSizeException(string message) : base(message)
        {

        }
    }
}
