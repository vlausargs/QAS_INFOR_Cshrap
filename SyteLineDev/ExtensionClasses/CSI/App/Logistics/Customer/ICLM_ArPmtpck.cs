//PROJECT NAME: Logistics
//CLASS NAME: ICLM_ArPmtpck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_ArPmtpck
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ArPmtpckSp(string PBankCode,
		string PCustNum,
		string PType,
		int? PCheckNum,
		string PCreditMemoNum,
		string PFilter = null,
		Guid? PProcessId = null);
	}
}

