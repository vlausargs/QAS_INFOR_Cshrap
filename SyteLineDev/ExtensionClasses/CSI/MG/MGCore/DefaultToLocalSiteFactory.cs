using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class DefaultToLocalSiteFactory : IDefaultToLocalSiteFactory
	{
		public IDefaultToLocalSite Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DefaultToLocalSite = new DefaultToLocalSite(appDB);


			return _DefaultToLocalSite;
		}
	}
}
