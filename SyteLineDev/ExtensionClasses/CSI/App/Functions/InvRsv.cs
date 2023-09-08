//PROJECT NAME: Data
//CLASS NAME: InvRsv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InvRsv : IInvRsv
	{
		readonly IApplicationDB appDB;
		
		public InvRsv(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? QtyReserved,
			string Infobar) InvRsvSp(
			string Item,
			string CoNum,
			int? CoLine,
			int? CoRelease,
			decimal? QtyToReserve,
			string Whse,
			string UM,
			string CustNum,
			string ProgramName,
			decimal? QtyReserved,
			string Infobar,
			string ParmsSite = null)
		{
			ItemType _Item = Item;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoLineType _CoRelease = CoRelease;
			QtyUnitType _QtyToReserve = QtyToReserve;
			WhseType _Whse = Whse;
			UMType _UM = UM;
			CustNumType _CustNum = CustNum;
			OSLocationType _ProgramName = ProgramName;
			QtyUnitType _QtyReserved = QtyReserved;
			Infobar _Infobar = Infobar;
			SiteType _ParmsSite = ParmsSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvRsvSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyToReserve", _QtyToReserve, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProgramName", _ProgramName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReserved", _QtyReserved, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ParmsSite", _ParmsSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QtyReserved = _QtyReserved;
				Infobar = _Infobar;
				
				return (Severity, QtyReserved, Infobar);
			}
		}
	}
}
