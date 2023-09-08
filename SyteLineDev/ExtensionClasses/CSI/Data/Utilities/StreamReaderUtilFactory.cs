using System;
using System.IO;
using System.Text;

namespace CSI.Data.Utilities
{
    public class StreamReaderUtilFactory : IStreamReaderUtilFactory
    {
        public StreamReaderUtilFactory()
        {
        }

        public IStreamReaderUtil Create(Stream stream)
        {
            return new StreamReaderUtil(stream);
        }
        public IStreamReaderUtil Create(string path)
        {
            return new StreamReaderUtil(path);
        }
        public IStreamReaderUtil Create(Stream stream, bool detectEncodingFromByteOrderMarks)
        {
            return new StreamReaderUtil(stream, detectEncodingFromByteOrderMarks);
        }
        public IStreamReaderUtil Create(Stream stream, Encoding encoding)
        {
            return new StreamReaderUtil(stream, encoding);
        }
        public IStreamReaderUtil Create(string path, bool detectEncodingFromByteOrderMarks)
        {
            return new StreamReaderUtil(path, detectEncodingFromByteOrderMarks);
        }
        public IStreamReaderUtil Create(string path, Encoding encoding)
        {
            return new StreamReaderUtil(path, encoding);
        }
        public IStreamReaderUtil Create(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks)
        {
            return new StreamReaderUtil(stream, encoding, detectEncodingFromByteOrderMarks);
        }
        public IStreamReaderUtil Create(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks)
        {
            return new StreamReaderUtil(path, encoding, detectEncodingFromByteOrderMarks);
        }
        public IStreamReaderUtil Create(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize)
        {
            return new StreamReaderUtil(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize);
        }
        public IStreamReaderUtil Create(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize)
        {
            return new StreamReaderUtil(path, encoding, detectEncodingFromByteOrderMarks, bufferSize);
        }
        public IStreamReaderUtil Create(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen)
        {
            return new StreamReaderUtil(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen);
        }


    }
}
