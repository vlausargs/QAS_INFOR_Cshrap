//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSVTXGetDropShip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSVTXGetDropShip
	{
		(int? ReturnCode,
			string DropType,
			string DropNum,
			int? DropSeq,
			string Infobar) SSSFSVTXGetDropShipSp(
			string Type,
			Guid? RowPtr,
			string DropType,
			string DropNum,
			int? DropSeq,
			string Infobar);
	}
}

