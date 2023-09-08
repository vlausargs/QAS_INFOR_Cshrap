using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface ISitePartitionFunctionExists
	{
		int? SitePartitionFunctionExistsFn(string PSitePartitionFunction = "SitePFunction");
	}
}
