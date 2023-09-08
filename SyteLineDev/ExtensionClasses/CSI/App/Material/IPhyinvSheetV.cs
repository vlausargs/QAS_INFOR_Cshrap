//PROJECT NAME: Material
//CLASS NAME: IPhyinvSheetV.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPhyinvSheetV
	{
		(int? ReturnCode, int? TagXref,
		string Infobar) PhyinvSheetVSp(string Whse,
		string Item,
		string Loc,
		string Lot,
		string SerNum,
		int? LotTracked,
		int? SerialTracked,
		int? SheetNum,
		int? NewSheet,
		int? TagXref,
		string Infobar,
		string ImportDocId,
		int? TaxFreeMatl);
	}
}

