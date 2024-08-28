using NpgsqlTypes;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;

namespace ETrade.API.Configurations.ColumnWriters
{
    // Serilog logları için PostgreSQL'e özel bir sütun yazıcısıdır.
    // Bu sınıf, log verilerinde 'user_name' olarak belirtilen kullanıcı adını alır 
    // ve bunu PostgreSQL'de varchar türünde bir sütuna yazar.
    public class UsernameColumnWriter : ColumnWriterBase
    {
        public UsernameColumnWriter() : base(NpgsqlDbType.Varchar)
        {
        }

        public override object GetValue(LogEvent logEvent, IFormatProvider formatProvider = null)
        {
            var (username, value) = logEvent.Properties.FirstOrDefault(p => p.Key == "user_name");
            return value?.ToString() ?? null;
        }
    }
}
