//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubSelBillLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubSelBillLine
	{
		int? SSSFSConInvSubSelBillLineSp(
			Guid? SessionId,
			string Contract,
			int? StartContLine,
			int? EndContLine,
			DateTime? RenewByDate = null,
			string BillingFreq = "ASQBMOE",
			string CalledFromForm = null);
	}
}

