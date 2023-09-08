//PROJECT NAME: DataCollection
//CLASS NAME: DccycV.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DccycV : IDccycV
	{
		readonly IApplicationDB appDB;
		
		public DccycV(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) DccycVSp(
			Guid? DcitemRowPointer,
			int? DcitemTransNum,
			string DcitemItem,
			string DcitemLoc,
			string DcitemWhse,
			decimal? DcitemCountQty,
			string DcitemLot,
			string Infobar)
		{
			RowPointerType _DcitemRowPointer = DcitemRowPointer;
			DcTransNumType _DcitemTransNum = DcitemTransNum;
			ItemType _DcitemItem = DcitemItem;
			LocType _DcitemLoc = DcitemLoc;
			WhseType _DcitemWhse = DcitemWhse;
			QtyUnitNoNegType _DcitemCountQty = DcitemCountQty;
			LotType _DcitemLot = DcitemLot;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DccycVSp";
				
				appDB.AddCommandParameter(cmd, "DcitemRowPointer", _DcitemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DcitemTransNum", _DcitemTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DcitemItem", _DcitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DcitemLoc", _DcitemLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DcitemWhse", _DcitemWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DcitemCountQty", _DcitemCountQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DcitemLot", _DcitemLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
