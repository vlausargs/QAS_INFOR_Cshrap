//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_BankStmTypeCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_BankStmTypeCode
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode,
		string InfoBar) CLM_BankStmTypeCodeSp(
			string ReferenceType,
			string InfoBar);
	}
}

