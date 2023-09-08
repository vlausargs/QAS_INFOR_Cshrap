//PROJECT NAME: Material
//CLASS NAME: IPhyInvChkEmpItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPhyInvChkEmpItem
	{
		(int? ReturnCode, string tEmpName,
		string tItemDesc) PhyInvChkEmpItemSP(Guid? PhyInvRowPointer,
		string tEmpName,
		string tItemDesc);
	}
}

