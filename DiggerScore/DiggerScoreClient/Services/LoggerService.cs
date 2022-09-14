using Serilog;
using Serilog.Core;

namespace DiggerScoreClient.Services
{
    public class LoggerService
    {
        public static Logger GetLogger()
        {
            string? logFormatMessage = @"{Timestamp:yyyy-MM-dd HH:mm-dd }[{Level:u3}] {Message:lj}{NewLine}";

            var log=new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(
                    @"loggs\log.txt",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: logFormatMessage,
                    rollOnFileSizeLimit: true,
                    fileSizeLimitBytes: 3_000,
                    retainedFileCountLimit:10)
                .CreateLogger();

            return log;
        }            
    }
}