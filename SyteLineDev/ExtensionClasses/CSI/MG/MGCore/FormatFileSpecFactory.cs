using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class FormatFileSpecFactory : IFormatFileSpecFactory
	{
		public IFormatFileSpec Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FormatFileSpec = new MGCore.FormatFileSpec(appDB);


			return _FormatFileSpec;
		}
	}
}
