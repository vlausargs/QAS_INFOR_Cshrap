//PROJECT NAME: Logistics
//CLASS NAME: IARPaymentPostingBG.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IARPaymentPostingBG
	{
		int? ARPaymentPostingBGSp(int? DisplayHeader = 1,
		int? DisplayDetail = 1,
		string StartingCustNum = null,
		string EndingCustNum = null,
		string StartBnkCode = null,
		string EndBnkCode = null,
		DateTime? StartRecDate = null,
		DateTime? EndRecDate = null,
		int? StartChkNum = null,
		int? EndChkNum = null,
		Guid? PSessionID = null,
		string StartCreditMemo = null,
		string EndCreditMemo = null,
		string PSite = null,
		string PayType = null,
		decimal? UserId = null);
	}
}

