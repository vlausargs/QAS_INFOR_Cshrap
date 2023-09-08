//PROJECT NAME: Logistics
//CLASS NAME: IFTSLCheckQtyOnCloseJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLCheckQtyOnCloseJob
	{
		(int? ReturnCode, decimal? OperQtyComplete,
		decimal? OperQtyMoved,
		string Infobar) FTSLCheckQtyOnCloseJobSp(string Job,
		int? Suffix,
		int? OperNum,
		decimal? OperQtyComplete,
		decimal? OperQtyMoved,
		string Infobar);
	}
}

