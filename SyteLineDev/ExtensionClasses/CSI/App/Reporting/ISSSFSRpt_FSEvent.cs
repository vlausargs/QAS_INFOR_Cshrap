//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_FSEvent.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_FSEvent
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_FSEventSp(string Incident,
		string pSite = null);
	}
}

