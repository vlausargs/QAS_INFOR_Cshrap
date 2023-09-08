//PROJECT NAME: Logistics
//CLASS NAME: IFTInsertIntoTmpser.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTInsertIntoTmpser
	{
		(int? ReturnCode, string Infobar) FTInsertIntoTmpserSp(Guid? SessionID,
		string Ser_num,
		string RefStr,
		string Item,
		int? FlagInvCheck,
		string Infobar);
	}
}

