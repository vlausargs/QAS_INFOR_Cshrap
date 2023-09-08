using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class SitePartitionFunctionExistsFactory : ISitePartitionFunctionExistsFactory
	{
		public ISitePartitionFunctionExists Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SitePartitionFunctionExists = new MGCore.SitePartitionFunctionExists(appDB);


			return _SitePartitionFunctionExists;
		}
	}
}
