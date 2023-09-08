using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class PrefixOnlyFactory : IPrefixOnlyFactory
	{
		public IPrefixOnly Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PrefixOnly = new PrefixOnly(appDB);


			return _PrefixOnly;
		}
	}
}
