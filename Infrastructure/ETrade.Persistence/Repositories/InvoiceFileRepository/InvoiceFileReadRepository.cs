using ETrade.Application.Repositories.InvoiceFileRepository;
using ETrade.Domain.Entities;
using ETrade.Persistence.Contexts;
using ETrade.Persistence.Repositories.BaseRepository;

namespace ETrade.Persistence.Repositories.InvoiceFileRepository;

public class InvoiceFileReadRepository : ReadRepository<InvoiceFile>, IInvoiceFileReadRepository
{
    public InvoiceFileReadRepository(ETradeAPIDBContext context) : base(context)
    {
    }
}
