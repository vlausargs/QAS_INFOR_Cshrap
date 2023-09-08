//PROJECT NAME: BusInterface
//CLASS NAME: ISupplyWEBInPoAck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ISupplyWEBInPoAck
	{
		(int? ReturnCode, string Infobar) SupplyWEBInPoAckSp(Guid? TmpAckPoRowPointer,
		string FromLogicalID,
		string FromReferenceID,
		DateTime? FromCreateTime,
		string FromBODID,
		string Infobar);
	}
}

