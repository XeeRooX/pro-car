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
                //string fullPath = $"{uploadPath}/{i}{Path.GetExtension(file.FileName)}";
                string fullPath = $"{uploadPath}/{i}.png";

                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                i++;
            }
        }

        public void DeleteBrandPhoto(int id)
        {
            var deletePath = $"{Directory.GetCurrentDirectory()}/Data/imgs/brands/{id}.png";
            if (File.Exists(deletePath))
            {
                try
                {
                    File.Delete(deletePath);
                }
                catch (Exception e)
                {
                    Console.WriteLine("The deletion failed: {0}", e.Message);
                }
            }
        }

        public void DeleteCarPhoto(int id)
        {
            var deletePath = $"{Directory.GetCurrentDirectory()}/Data/imgs/cars/{id}";

            if (Directory.Exists(deletePath))
            {
                try
                {
                    Directory.Delete(deletePath, true);
                }
                catch (Exception e)
                {
                    Console.WriteLine("The deletion failed: {0}", e.Message);
                }
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

        public int CountCarPhotos(int id)
        {
            var carPath = $"{Directory.GetCurrentDirectory()}/Data/imgs/cars/{id}";

            if (Directory.Exists(carPath))
            {
                try
                {
                    return Directory.GetFiles(carPath).Length;
                }
                catch (Exception e)
                {
                    Console.WriteLine("The get info failed: {0}", e.Message);
                }
            }

            return 0;
        }
    }
}
