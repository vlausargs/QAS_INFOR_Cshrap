//PROJECT NAME: Logistics
//CLASS NAME: IDelVocuhAdjNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IDelVocuhAdjNum
	{
		(int? ReturnCode, decimal? LasttranLastTran,
		string Infobar) DelVocuhAdjNumSp(int? LasttranKey,
		string Action,
		decimal? LasttranLastTran,
		string VoucherType,
		string Infobar);
	}
}

