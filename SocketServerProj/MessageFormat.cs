using System.Net;

namespace SocketServerProj
{
    /// <summary>
    /// effectvie c# always override ToString method
    /// </summary>
    internal class MessageFormat
    {
        public string message { get; private set; }
        public EndPoint? endPoint { get;  private set; }
        public static string FormatMessage(string message, EndPoint endPoint)
        {
            return $"[{DateTime.Now:HH:mm:ss}] [{endPoint}] {Environment.NewLine}{message}{Environment.NewLine}";
        }
        public MessageFormat()
        {
            message = string.Empty;
            endPoint = null;
        }
        public MessageFormat(string message, EndPoint endPoint)
        {
            this.message = message;
            this.endPoint = endPoint;
        }
        public override string ToString()
        {
            return FormatMessage(message, endPoint);
        }

    }
}
