using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

namespace CSI.Data.Net
{
    public interface ICSIWebResponse : IDisposable
    {
        long ContentLength { get; set; }
        string ContentType { get; set; }
        WebHeaderCollection Headers { get; }
        bool IsFromCache { get; }
        bool IsMutuallyAuthenticated { get; }
        Uri ResponseUri { get; }
        bool SupportsHeaders { get; }

        void Close();
        new void Dispose();
        Stream GetResponseStream();
    }
}