using CSI.Data.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG.MGCore
{
	public class AllSitesSameDbFactory
	{
		public IAllSitesSameDb Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AllSitesSameDb = new AllSitesSameDb(appDB);


			return _AllSitesSameDb;
		}
	}
}
