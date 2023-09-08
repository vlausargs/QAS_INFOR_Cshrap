//PROJECT NAME: BusInterface
//CLASS NAME: ILoadESBProductionOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ILoadESBProductionOrder
	{
		(int? ReturnCode, string Job,
		int? Suffix,
		string Infobar) LoadESBProductionOrderSp(string DerBODID,
		string ActionExpression,
		string Description,
		DateTime? CreateDate,
		DateTime? DueDateTime,
		DateTime? EarliestStartDateTime,
		DateTime? RecordDate,
		string Rework,
		string Status,
		string Job,
		int? Suffix,
		string Infobar);
	}
}

