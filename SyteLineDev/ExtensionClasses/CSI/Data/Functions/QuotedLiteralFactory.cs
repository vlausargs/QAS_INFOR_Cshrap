//PROJECT NAME: Data.Functions
//CLASS NAME: QuotedLiteralFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
	public class QuotedLiteralFactory : IQuotedLiteralFactory
	{
		public IQuotedLiteral Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _QuotedLiteral = new Functions.QuotedLiteral(appDB);


			return _QuotedLiteral;
		}
	}
}
