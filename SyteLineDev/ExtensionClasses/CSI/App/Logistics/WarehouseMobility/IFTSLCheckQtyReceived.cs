//PROJECT NAME: Logistics
//CLASS NAME: IFTSLCheckQtyReceived.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLCheckQtyReceived
	{
		(int? ReturnCode, decimal? OperQtyComplete,
		decimal? OperQtyScrapped,
		decimal? OperQtyReceived,
		string Infobar) FTSLCheckQtyReceivedSp(string Job,
		int? Suffix,
		int? OperNum,
		decimal? OperQtyComplete,
		decimal? OperQtyScrapped,
		decimal? OperQtyReceived,
		string Infobar);
	}
}

