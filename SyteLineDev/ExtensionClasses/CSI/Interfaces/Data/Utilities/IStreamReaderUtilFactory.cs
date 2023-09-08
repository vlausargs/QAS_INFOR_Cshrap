using System.IO;
using System.Text;

namespace CSI.Data.Utilities
{
    public interface IStreamReaderUtilFactory
    {
        IStreamReaderUtil Create(Stream stream);
        IStreamReaderUtil Create(Stream stream, bool detectEncodingFromByteOrderMarks);
        IStreamReaderUtil Create(Stream stream, Encoding encoding);
        IStreamReaderUtil Create(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks);
        IStreamReaderUtil Create(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize);
        IStreamReaderUtil Create(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen);
        IStreamReaderUtil Create(string path);
        IStreamReaderUtil Create(string path, bool detectEncodingFromByteOrderMarks);
        IStreamReaderUtil Create(string path, Encoding encoding);
        IStreamReaderUtil Create(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks);
        IStreamReaderUtil Create(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize);
    }
}