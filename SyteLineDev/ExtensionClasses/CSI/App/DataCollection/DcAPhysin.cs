//PROJECT NAME: DataCollection
//CLASS NAME: DcAPhysin.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcAPhysin : IDcAPhysin
	{
		readonly IApplicationDB appDB;
		
		
		public DcAPhysin(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DcAPhysinSp(string TTermId,
		string TEmpNum,
		DateTime? TTransDate,
		string TItem,
		string TCurWhse,
		string TLocation,
		string TLot,
		decimal? TQty,
		int? PTagNum,
		int? PSheetNum,
		string PEmpCount,
		string PEmpCheck,
		string Infobar)
		{
			DcTermIdType _TTermId = TTermId;
			EmpNumType _TEmpNum = TEmpNum;
			DateTimeType _TTransDate = TTransDate;
			ItemType _TItem = TItem;
			WhseType _TCurWhse = TCurWhse;
			LocType _TLocation = TLocation;
			LotType _TLot = TLot;
			QtyUnitType _TQty = TQty;
			SheetTagNumType _PTagNum = PTagNum;
			SheetTagNumType _PSheetNum = PSheetNum;
			EmpNumType _PEmpCount = PEmpCount;
			EmpNumType _PEmpCheck = PEmpCheck;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcAPhysinSp";
				
				appDB.AddCommandParameter(cmd, "TTermId", _TTermId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEmpNum", _TEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDate", _TTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TItem", _TItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCurWhse", _TCurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLocation", _TLocation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLot", _TLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQty", _TQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTagNum", _PTagNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSheetNum", _PSheetNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmpCount", _PEmpCount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmpCheck", _PEmpCheck, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
