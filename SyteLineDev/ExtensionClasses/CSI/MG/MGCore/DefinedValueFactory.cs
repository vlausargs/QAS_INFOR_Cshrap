using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class DefinedValueFactory : IDefinedValueFactory
	{
		public IDefinedValue Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DefinedValue = new DefinedValue(appDB);


			return _DefinedValue;
		}
	}
}
