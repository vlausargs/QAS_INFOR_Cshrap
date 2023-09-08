using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.Functions
{
	public class HighIntFactory : IHighIntFactory
	{
		public IHighInt Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _HighInt = new HighInt(appDB);


			return _HighInt;
		}
	}
}
