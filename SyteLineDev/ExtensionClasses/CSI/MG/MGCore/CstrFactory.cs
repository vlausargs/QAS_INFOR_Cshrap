using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class CstrFactory : ICstrFactory
	{
		public ICstr Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Cstr = new Cstr(appDB);


			return _Cstr;
		}
	}
}
