using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class GetSiteContextFactory : IGetSiteContextFactory
	{
		public IGetSiteContext Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetSiteContext = new GetSiteContext(appDB);


			return _GetSiteContext;
		}
	}
}
