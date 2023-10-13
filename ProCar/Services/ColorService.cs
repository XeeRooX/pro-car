using ProCar.Models;

namespace ProCar.Services
{
    public class ColorService : IColorService
    {
        private readonly ApplicationDbContext _context;
        public ColorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Color AddItem(string name)
        {
            var color = new Color { Name = name };  
            _context.Colors.Add(color);
            _context.SaveChanges();
            return color;
        }

        public void DeleteItem(int id)
        {
            var color = _context.Colors.Find(id)!;
            _context.Colors.Remove(color);
            _context.SaveChanges();
        }

        public void EditItem(int id, string name)
        {
            var color = _context.Colors.Find(id)!;
            color.Name = name;
            _context.SaveChanges();
        }

        public bool ElementExists(int id)
        {
            return _context.Colors.Find(id) != null;
        }

        public int ElementExists(string name)
        {
            var color = _context.Colors.FirstOrDefault(item => item.Name == name);
            if (color == null)
                return 0;
            return color.Id;
        }

        public List<Color> GetAll()
        {
            return _context.Colors.ToList();
        }

        public Color GetById(int id)
        {
            return _context.Colors.Find(id)!;
        }
    }
}
