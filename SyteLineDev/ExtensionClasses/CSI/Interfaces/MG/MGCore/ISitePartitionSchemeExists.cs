using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface ISitePartitionSchemeExists
	{
		int? SitePartitionSchemeExistsFn(string PSitePartitionScheme = "SitePScheme");
	}
}
