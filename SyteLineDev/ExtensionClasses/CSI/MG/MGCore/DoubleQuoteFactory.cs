using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class DoubleQuoteFactory : IDoubleQuoteFactory
	{
		public IDoubleQuote Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DoubleQuote = new DoubleQuote(appDB);


			return _DoubleQuote;
		}
	}
}
