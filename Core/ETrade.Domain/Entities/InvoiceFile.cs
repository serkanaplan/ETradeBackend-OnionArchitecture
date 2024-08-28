namespace ETrade.Domain.Entities;

//bu entity TPH(Table Per Hierarchy) yöntemiyle veritabanına kaydedilecek
public class InvoiceFile : File
{
    public decimal Price { get; set; }
}
