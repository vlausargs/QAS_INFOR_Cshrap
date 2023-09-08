//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ContainerContents.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ContainerContents
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ContainerContentsSp(string PWhseStarting = null,
		string PWhseEnding = null,
		string PLocationStarting = null,
		string PLocationEnding = null,
		string PContainerStarting = null,
		string PContainerEnding = null,
		string PItemStarting = null,
		string PItemEnding = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

