//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBSSDLineDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBSSDLineDetail
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBSSDLineDetailSp(string TransIndicator,
		string RefType,
		DateTime? StartPeriod,
		DateTime? EndPeriod,
		string StartCust,
		string EndCust,
		string StartVend,
		string EndVend,
		string StartWhse,
		string EndWhse,
		string DeclarationID);
	}
}

