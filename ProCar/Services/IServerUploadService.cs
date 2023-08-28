namespace ProCar.Services
{
    public interface IServerUploadService
    {
        void UploadBrandPhoto(int id, IFormFileCollection files);
        void UploadCarPhoto(int id, IFormFileCollection files);
        bool TypeFilePng(IFormFileCollection files);
        void DeleteBrandPhoto(int id);
        void DeleteCarPhoto(int id);
        int CountCarPhotos(int id);
    }
}
