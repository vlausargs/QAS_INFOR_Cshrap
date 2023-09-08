using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class IsValidLiteralFactory : IIsValidLiteralFactory
	{
		public IIsValidLiteral Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _IsValidLiteral = new MGCore.IsValidLiteral(appDB);


			return _IsValidLiteral;
		}
	}
}
