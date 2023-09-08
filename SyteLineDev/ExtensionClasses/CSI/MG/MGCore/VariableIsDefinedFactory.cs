using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class VariableIsDefinedFactory : IVariableIsDefinedFactory
	{
		public IVariableIsDefined Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _VariableIsDefined = new VariableIsDefined(appDB);


			return _VariableIsDefined;
		}
	}
}
