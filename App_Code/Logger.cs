using System;
using System.Configuration;
using System.IO;
using System.Web;

    /// <summary>
    /// The Class Writes Exception and Error information into a log file named ErrorLog.txt.
    /// </summary>
public class LoggError
{
    /// <summary>
    /// Writes error occured in log file,if log file does not exist,it creates the file first.
    /// </summary>
    /// <param name="exception">Exception</param>
    public static void Write(Exception exception)
    {
        string logFile = String.Empty;
        StreamWriter logWriter;
        try
        {
            logFile = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ErrorLog"].ToString());
            if (File.Exists(logFile))
                logWriter = File.AppendText(logFile);
            else
                logWriter = File.CreateText(logFile);
            logWriter.WriteLine("=>" + DateTime.Now + " " + " An Error occured : " +
                exception.StackTrace + " Message : " + exception.InnerException + "\n\n");
            logWriter.Close();
            throw exception;

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            throw exception;
        }
    }
}
