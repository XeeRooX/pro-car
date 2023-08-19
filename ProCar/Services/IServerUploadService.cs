namespace ProCar.Services
{
    public interface IServerUploadService
    {
        void UploadBrandPhoto(int id, IFormFileCollection files);
        void UploadCarPhoto(int id, IFormFileCollection files);
        bool TypeFilePng(IFormFileCollection files);
    }
}
