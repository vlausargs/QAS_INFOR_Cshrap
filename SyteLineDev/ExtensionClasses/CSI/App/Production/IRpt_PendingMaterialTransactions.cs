//PROJECT NAME: Production
//CLASS NAME: IRpt_PendingMaterialTransactions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IRpt_PendingMaterialTransactions
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PendingMaterialTransactionsSp(decimal? PTransNumStarting,
		decimal? PTransNumEnding,
		DateTime? PTransDateStarting,
		DateTime? PTransDateEnding,
		string PJobStarting,
		string PJobEnding,
		int? PSuffixStarting,
		int? PSuffixEnding,
		string PItemStarting,
		string PItemEnding,
		string PLocationStarting,
		string PLocationEnding,
		string PEmployeeStarting,
		string PEmployeeEnding,
		string PTransClass,
		string PSite = null);
	}
}

