//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBSSDLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBSSDLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBSSDLineSp(string TransIndicator,
		string RefType,
		DateTime? StartPeriod,
		DateTime? EndPeriod,
		string StartCust,
		string EndCust,
		string StartVend,
		string EndVend,
		string StartWhse,
		string EndWhse);
	}
}

