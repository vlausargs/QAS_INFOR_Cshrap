//PROJECT NAME: Data.Functions
//CLASS NAME: QuotedLiteralFactory.cs

using CSI.Data.SQL;
using CSI.MG;

namespace CSI.Data.Functions
{
    public interface IQuotedLiteralFactory
    {
        IQuotedLiteral Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}