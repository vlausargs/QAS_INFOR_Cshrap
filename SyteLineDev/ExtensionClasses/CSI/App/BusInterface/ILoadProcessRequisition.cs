//PROJECT NAME: BusInterface
//CLASS NAME: ILoadProcessRequisition.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ILoadProcessRequisition
	{
		(int? ReturnCode, string Infobar) LoadProcessRequisitionSp(string ReqNum,
		string ActionCode,
		string StatusCode,
		string Whse,
		DateTime? RequisitionDate,
		string Requester,
		string Infobar);
	}
}

