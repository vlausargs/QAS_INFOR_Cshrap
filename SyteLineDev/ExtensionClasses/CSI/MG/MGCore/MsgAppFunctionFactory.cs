using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class MsgAppFunctionFactory : IMsgAppFunctionFactory
	{
		public IMsgAppFunction Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MsgAppFunction = new MsgAppFunction(appDB);


			return _MsgAppFunction;
		}
	}
}
