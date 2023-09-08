using CSI.Data.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG.MGCore
{
	public class ASCIIBetweenFactory : IASCIIBetweenFactory
	{
		public IASCIIBetween Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ASCIIBetween = new MGCore.ASCIIBetween(appDB);


			return _ASCIIBetween;
		}
	}
}
