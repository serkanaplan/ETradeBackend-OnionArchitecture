using ETrade.API.Configurations.ColumnWriters;
using NpgsqlTypes;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.PostgreSQL;

namespace ETrade.API.Extensions;

public static class LoggingExtensions
{
    public static IHostBuilder ConfigureLogging(this IHostBuilder hostBuilder, IConfiguration configuration)
    {
        return hostBuilder.UseSerilog(CreateLogger(configuration));
    }

    private static Logger CreateLogger(IConfiguration configuration)
    {
        var loggerConfiguration = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("logs/log.txt")
            .WriteTo.Seq(configuration["Seq:ServerURL"])
            .WriteTo.PostgreSQL(
                connectionString: configuration.GetConnectionString("PostgreSQL"),
                tableName: "logs",
                needAutoCreateTable: true,
                columnOptions: CreatePostgreSqlColumnOptions());

        return loggerConfiguration.CreateLogger();
    }

    private static IDictionary<string, ColumnWriterBase> CreatePostgreSqlColumnOptions()
    {
        return new Dictionary<string, ColumnWriterBase>
        {
            {"message", new RenderedMessageColumnWriter(NpgsqlDbType.Text)},
            {"message_template", new MessageTemplateColumnWriter(NpgsqlDbType.Text)},
            {"level", new LevelColumnWriter(true, NpgsqlDbType.Varchar)},
            {"time_stamp", new TimestampColumnWriter(NpgsqlDbType.Timestamp)},
            {"exception", new ExceptionColumnWriter(NpgsqlDbType.Text)},
            {"log_event", new LogEventSerializedColumnWriter(NpgsqlDbType.Json)},
            {"user_name", new UsernameColumnWriter()}
        };
    }
}
