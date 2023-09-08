using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class ReplicationFiltersFactory : IReplicationFiltersFactory
	{
		public IReplicationFilters Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ReplicationFilters = new MGCore.ReplicationFilters(appDB);


			return _ReplicationFilters;
		}
	}
}
