using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class IsValidURLFactory : IIsValidURLFactory
	{
		public IIsValidURL Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _IsValidURL = new MGCore.IsValidURL(appDB);


			return _IsValidURL;
		}
	}
}
