using APIFirst.Entities.Base;

namespace APIFirst.Entities
{
    public class Category:BaseEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
    }
}
