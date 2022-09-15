using DiggerScoreClient.Services;
using Serilog.Core;

namespace DiggerScoreClient.BaseModels
{
    public abstract class BaseClass
    {
        public static Logger? Log { get; set; } = LoggerService.GetLogger();
    }
}
