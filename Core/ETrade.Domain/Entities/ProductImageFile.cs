namespace ETrade.Domain.Entities;

//bu entity TPH(Table Per Hierarchy) yöntemiyle veritabanına kaydedilecek
public class ProductImageFile : File
{
    public bool Showcase { get; set; }
    public ICollection<Product> Products { get; set; }
}
