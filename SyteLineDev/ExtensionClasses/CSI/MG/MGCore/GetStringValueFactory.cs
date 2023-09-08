using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class GetStringValueFactory : IGetStringValueFactory
	{
		public IGetStringValue Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetStringValue = new GetStringValue(appDB);


			return _GetStringValue;
		}
	}
}
