//PROJECT NAME: Data
//CLASS NAME: IFirmPO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFirmPO
	{
		(int? ReturnCode,
			string ReqNum,
			string Infobar,
			int? CheckInsertPermission) FirmPOSp(
			string Item,
			string RefNum,
			string ReqNum,
			string PoChange,
			int? BlanketQtyOverOK,
			string VendNum,
			decimal? BlanketQty,
			int? FromWorkbench = 0,
			string MrpWbDemandReqNum = null,
			int? MrpWbDemandReqLine = 0,
			DateTime? DueDate = null,
			decimal? ReqdQty = 0,
			string RefType = null,
			int? RefLineSuf = 0,
			int? RefRelease = 0,
			int? RefSeq = 0,
			string Whse = null,
			int? PurchReqNotes = 0,
			string ManufacturerId = null,
			string ManufacturerItem = null,
			string Infobar = null,
			int? CheckInsertPermission = null,
			DateTime? ReleaseDate = null);
	}
}

