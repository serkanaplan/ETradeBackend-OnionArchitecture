
using System.ComponentModel.DataAnnotations.Schema;
using ETrade.Domain.Entities.Common;

namespace ETrade.Domain.Entities;

//bu entity TPH(Table Per Hierarchy) yöntemiyle veritabanına kaydedilecek
public class File : BaseEntity
{
    public string FileName { get; set; }
    public string Path { get; set; }
    public string Storage { get; set; }

    [NotMapped]//bu tablo için veritabanında baseentityden gelen UpdatedDate kolonu oluşsun istemiyoruz oyuzden NotMapped işaretledik
    public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
}
