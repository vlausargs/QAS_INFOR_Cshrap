//PROJECT NAME: Data
//CLASS NAME: IFTValidateInsertCountDeleteTmpSer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTValidateInsertCountDeleteTmpSer
	{
		(int? ReturnCode,
			int? SerCount,
			string Infobar) FTValidateInsertCountDeleteTmpSerSp(
			Guid? SessionID,
			string Site,
			string RefStr = "",
			string Item = "",
			string Whse = "",
			string Loc = "",
			string Lot = "",
			string Ser_num = "",
			int? FlagExpiryCheck = 1,
			int? FlagIONCheck210 = 0,
			int? FlagRsvdCheck = 1,
			string FTUser = "",
			string FTAutomationUser = "",
			string CoNumber = "",
			int? CoLine = 0,
			int? CoRelease = 0,
			string Container = "",
			int? FlagRestricSerialMovement = 0,
			decimal? PickListID = 0,
			int? PickListSeq = 0,
			int? SerCount = null,
			string Infobar = null);
	}
}

