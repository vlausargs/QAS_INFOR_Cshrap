//PROJECT NAME: Reporting
//CLASS NAME: IRpt_TransferOrderReceivingList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_TransferOrderReceivingList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_TransferOrderReceivingListSp(string ExOptprRecvTrans = null,
		int? ExOptprPostRcpts = null,
		DateTime? ExOptprPostDate = null,
		int? ExOptprPrintBc = null,
		int? ExOptprPrSerialNumbers = null,
		int? DateStarting = null,
		int? DisplayHeader = null,
		decimal? UserId = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null);
	}
}

