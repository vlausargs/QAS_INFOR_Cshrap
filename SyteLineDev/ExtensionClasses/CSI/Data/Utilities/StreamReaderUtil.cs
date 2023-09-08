using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace CSI.Data.Utilities
{
    public class StreamReaderUtil : IStreamReaderUtil
    {
        StreamReader streamReader;
        
        public StreamReaderUtil(Stream stream)
        {
            streamReader = new StreamReader(stream);
        }
        public StreamReaderUtil(string path)
        {
            streamReader = new StreamReader(path);
        }
        public StreamReaderUtil(Stream stream, bool detectEncodingFromByteOrderMarks)
        {
            streamReader = new StreamReader(stream, detectEncodingFromByteOrderMarks);
        }
        public StreamReaderUtil(Stream stream, Encoding encoding)
        {
            streamReader = new StreamReader(stream, encoding);
        }
        public StreamReaderUtil(string path, bool detectEncodingFromByteOrderMarks)
        {
            streamReader = new StreamReader(path, detectEncodingFromByteOrderMarks);
        }
        public StreamReaderUtil(string path, Encoding encoding)
        {
            streamReader = new StreamReader(path, encoding);
        }
        public StreamReaderUtil(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks)
        {
            streamReader = new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks);
        }
        public StreamReaderUtil(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks)
        {
            streamReader = new StreamReader(path, encoding, detectEncodingFromByteOrderMarks);
        }
        public StreamReaderUtil(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize)
        {
            streamReader = new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize);
        }
        public StreamReaderUtil(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize)
        {
            streamReader = new StreamReader(path, encoding, detectEncodingFromByteOrderMarks, bufferSize);
        }
        public StreamReaderUtil(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen)
        {
            streamReader = new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen);
        }


        public Encoding CurrentEncoding { get => streamReader.CurrentEncoding; }
        public bool EndOfStream { get => streamReader.EndOfStream; }
        public Stream BaseStream { get => streamReader.BaseStream; }
        public void Close() => streamReader.Close();
        public void DiscardBufferedData() => streamReader.DiscardBufferedData();
        public int Peek() => streamReader.Peek();
        public int Read() => streamReader.Read();
        public int Read(char[] buffer, int index, int count) => streamReader.Read();
        public Task<int> ReadAsync(char[] buffer, int index, int count) => streamReader.ReadAsync(buffer, index, count);
        public int ReadBlock(char[] buffer, int index, int count) => streamReader.ReadBlock(buffer, index, count);
        public Task<int> ReadBlockAsync(char[] buffer, int index, int count) => streamReader.ReadBlockAsync(buffer, index, count);
        public string ReadLine() => streamReader.ReadLine();
        public Task<string> ReadLineAsync() => streamReader.ReadLineAsync();
        public string ReadToEnd() => streamReader.ReadToEnd();
        public Task<string> ReadToEndAsync() => streamReader.ReadToEndAsync();
        public void Dispose() => streamReader.Dispose();
    }
}
