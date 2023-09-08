//PROJECT NAME: Data
//CLASS NAME: IFirmTransfer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFirmTransfer
	{
		(int? ReturnCode,
			string TrnNum,
			string Infobar,
			int? CheckInsertPermission) FirmTransferSp(
			string Item,
			string RefNum,
			string TrnNum,
			string FromSite,
			string FromWhse,
			string ToSite,
			string ToWhse,
			int? FromWorkbench = 0,
			DateTime? DueDate = null,
			decimal? ReqdQty = 0,
			string RefType = null,
			int? RefLineSuf = null,
			int? RefRelease = null,
			int? RefSeq = null,
			string Infobar = null,
			int? CheckInsertPermission = null,
			int? CreateTransitLoc = 0);
	}
}

