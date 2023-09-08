//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSProfileSROPrePackSlip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSProfileSROPrePackSlip
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSProfileSROPrePackSlipSp(string StartSRONum = null,
		string EndSRONum = null,
		string StartCustNum = null,
		string EndCustNum = null,
		DateTime? StartOpenDate = null,
		DateTime? EndOpenDate = null,
		DateTime? StartTransDate = null,
		DateTime? EndTransDate = null,
		string OrdStat = "OIC");
	}
}

