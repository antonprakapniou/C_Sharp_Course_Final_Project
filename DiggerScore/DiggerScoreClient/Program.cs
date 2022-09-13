using DiggerScoreClient.Pages;
using DiggerScoreClient.Services;

var log=LoggerService.GetLogger();
log.Debug("App started"+" in "+Thread.CurrentThread.ManagedThreadId+" "+"thread");
log.Information("Score opened"+" in "+Thread.CurrentThread.ManagedThreadId+" "+"thread");

Console.ForegroundColor= ConsoleColor.DarkYellow;

WelcomePage _ = new();

log.Debug("App stopped"+" in "+Thread.CurrentThread.ManagedThreadId+" "+"thread");
log.Information("Score closed"+" in "+Thread.CurrentThread.ManagedThreadId+" "+"thread");