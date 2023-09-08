//PROJECT NAME: Data
//CLASS NAME: ISupplyWEBInPoAckVal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISupplyWEBInPoAckVal
	{
		(int? ReturnCode,
			string Infobar) SupplyWEBInPoAckValSp(
			Guid? TmpAckPoRowPointer,
			string Infobar);
	}
}

