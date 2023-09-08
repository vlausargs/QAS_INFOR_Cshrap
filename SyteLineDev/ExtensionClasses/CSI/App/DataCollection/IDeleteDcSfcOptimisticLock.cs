//PROJECT NAME: DataCollection
//CLASS NAME: IDeleteDcSfcOptimisticLock.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDeleteDcSfcOptimisticLock
	{
		(int? ReturnCode, string Infobar) DeleteDcSfcOptimisticLockSp(int? TransNum,
		string OldStat,
		string OldErrorMsg,
		string OldRecordDate,
		string Infobar);
	}
}

