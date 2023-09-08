using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface IReplicationFilters
	{
		string ReplicationFiltersFn(string SourceSite,
		string TargetSite,
		string TableName);
	}
}
