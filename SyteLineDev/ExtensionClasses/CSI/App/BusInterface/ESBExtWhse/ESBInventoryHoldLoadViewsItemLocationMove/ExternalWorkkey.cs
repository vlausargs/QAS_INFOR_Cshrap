
namespace CSI.BusInterface.ESBExtWhse
{
    public interface IExternalWorkkey
    {
        string ConcatWorkkey(string documentID, string lineNumber);
    }

    public class ExternalWorkkey : IExternalWorkkey
    {
        public ExternalWorkkey()
        { 
        }
        public string ConcatWorkkey(string documentID, string lineNumber)
        {
            return documentID?.Trim() + "~" + lineNumber?.Trim();
        }
    }
}
