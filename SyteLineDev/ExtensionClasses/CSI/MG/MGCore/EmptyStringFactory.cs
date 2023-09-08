using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class EmptyStringFactory : IEmptyStringFactory
	{
		public IEmptyString Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EmptyString = new MGCore.EmptyString(appDB);


			return _EmptyString;
		}
	}
}
