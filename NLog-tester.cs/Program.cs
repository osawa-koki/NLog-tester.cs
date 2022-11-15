using System;

namespace NLogSample
{
  class Program
  {
    static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

    static void Main(string[] args)
    {
      logger.Trace("Trace ログです。");
      logger.Debug("Debug ログです。");
      logger.Info("Info ログです。");
      logger.Warn("Warn ログです。");
      logger.Error("Error ログです。");
      logger.Fatal("Fatal ログです。");

      try
      {
        var a = 0;
        Console.WriteLine(10 / a);  // エラーを発生させる
      }
      catch (Exception ex)
      {
        logger.Error(ex, "エラーが発生しました。");
      }
    }
  }
}
