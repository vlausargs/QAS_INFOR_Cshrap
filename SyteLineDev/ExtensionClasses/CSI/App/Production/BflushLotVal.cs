//PROJECT NAME: Production
//CLASS NAME: BflushLotVal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class BflushLotVal : IBflushLotVal
	{
		readonly IApplicationDB appDB;
		
		
		public BflushLotVal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) BflushLotValSp(string Whse,
		string Lot,
		int? Selected,
		string JobMatlItem,
		string Loc,
		string Infobar,
		string RefNum,
		int? OperNum)
		{
			WhseType _Whse = Whse;
			LotType _Lot = Lot;
			ListYesNoType _Selected = Selected;
			ItemType _JobMatlItem = JobMatlItem;
			LocType _Loc = Loc;
			InfobarType _Infobar = Infobar;
			EmpJobCoPoRmaProjPsTrnNumType _RefNum = RefNum;
			OperNumType _OperNum = OperNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BflushLotValSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Selected", _Selected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobMatlItem", _JobMatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
