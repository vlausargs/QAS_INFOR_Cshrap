using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class LookupTrimmedFactory : ILookupTrimmedFactory
	{
		public ILookupTrimmed Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LookupTrimmed = new MGCore.LookupTrimmed(appDB);


			return _LookupTrimmed;
		}
	}
}
