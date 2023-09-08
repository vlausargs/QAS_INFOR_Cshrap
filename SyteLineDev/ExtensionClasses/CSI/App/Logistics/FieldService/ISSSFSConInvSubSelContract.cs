//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubSelContract.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubSelContract
	{
		int? SSSFSConInvSubSelContractSp(Guid? SessionId,
		string StartContract,
		string EndContract,
		int? StartContLine,
		int? EndContLine,
		string StartCustNum,
		string EndCustNum,
		string StartServType = null,
		string EndServType = null,
		DateTime? RenewByDate = null,
		string BillingFreq = "ASQBMOE");
	}
}

