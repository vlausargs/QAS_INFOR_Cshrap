//PROJECT NAME: Logistics
//CLASS NAME: IARPayPostCreateTmp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IARPayPostCreateTmp
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ARPayPostCreateTmpSp(string PStartCustNum,
		string PEndCustNum,
		string PStartBnkCode,
		string PEndBnkCode,
		DateTime? StartDate,
		DateTime? EndDate,
		int? StartChkNum,
		int? EndChkNum,
		string StartCreditMemo,
		string EndCreditMemo,
		string PType,
		Guid? PSessionID,
		int? CalledFromBackground = 0);
	}
}

