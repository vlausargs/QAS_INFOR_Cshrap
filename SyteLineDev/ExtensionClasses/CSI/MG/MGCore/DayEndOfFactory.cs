using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.Functions;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class DayEndOfFactory : IDayEndOfFactory
	{
		public IDayEndOf Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DayEndOf = new DayEndOf();


			return _DayEndOf;
		}
	}
}
