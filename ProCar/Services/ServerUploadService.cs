namespace ProCar.Services
{
    public class ServerUploadService : IServerUploadService
    {
        public void UploadBrandPhoto(int id, IFormFileCollection files)
        {

            var uploadPath = $"{Directory.GetCurrentDirectory()}/Data/imgs/brands";
            Directory.CreateDirectory(uploadPath);

            if(id == 0)
            {
                return;
            }

            foreach (var file in files)
            {
                string fullPath = $"{uploadPath}/{id}{Path.GetExtension(file.FileName)}";

                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

        }

        public void UploadCarPhoto(int id, IFormFileCollection files)
        {
            var uploadPath = $"{Directory.GetCurrentDirectory()}/Data/imgs/cars/{id}";
            Directory.CreateDirectory(uploadPath);
            
            if(id == 0)
            {
                return;
            }
            
            int i = 1;
            
            foreach (var file in files)
            {
                string fullPath = $"{uploadPath}/{i}{Path.GetExtension(file.FileName)}";

                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                i++;
            }
        }

        public bool TypeFilePng(IFormFileCollection files)
        {
            foreach (var file in files)
            {
               if(Path.GetExtension(file.FileName) != ".png")
                {
                    return false;
                }
            }
            return true;
        }
        
    }
}
