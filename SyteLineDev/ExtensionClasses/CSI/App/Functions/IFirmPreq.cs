//PROJECT NAME: Data
//CLASS NAME: IFirmPreq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFirmPreq
	{
		(int? ReturnCode,
			string ReqNum,
			string Infobar,
			int? CheckInsertPermission) FirmPreqSp(
			string Item,
			string RefNum,
			string ReqNum,
			string VendNum,
			int? FromWorkbench = 0,
			DateTime? DueDate = null,
			decimal? ReqdQty = 0,
			string RefType = null,
			int? RefLineSuf = null,
			int? RefRelease = null,
			int? RefSeq = null,
			string Whse = null,
			string ManufacturerId = null,
			string ManufacturerItem = null,
			string Infobar = null,
			int? CheckInsertPermission = null);
	}
}

