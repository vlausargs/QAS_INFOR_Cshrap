using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Data.Utilities
{
    public interface IStreamReaderUtil
    {
        Stream BaseStream { get; }
        Encoding CurrentEncoding { get; }
        bool EndOfStream { get; }

        void Close();
        void DiscardBufferedData();
        void Dispose();
        int Peek();
        int Read();
        int Read(char[] buffer, int index, int count);
        Task<int> ReadAsync(char[] buffer, int index, int count);
        int ReadBlock(char[] buffer, int index, int count);
        Task<int> ReadBlockAsync(char[] buffer, int index, int count);
        string ReadLine();
        Task<string> ReadLineAsync();
        string ReadToEnd();
        Task<string> ReadToEndAsync();
    }
}