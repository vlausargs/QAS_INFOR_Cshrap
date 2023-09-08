//PROJECT NAME: Logistics
//CLASS NAME: CoitmCd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoitmCd : ICoitmCd
	{
		readonly IApplicationDB appDB;
		
		
		public CoitmCd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CoitmCdSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		string Stat = null,
		decimal? QtyOrdered = null,
		decimal? QtyShipped = null,
		decimal? QtyReturned = null,
		string Infobar = null,
		string ShipSite = null)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoLineType _CoRelease = CoRelease;
			CoStatusType _Stat = Stat;
			QtyUnitType _QtyOrdered = QtyOrdered;
			QtyUnitType _QtyShipped = QtyShipped;
			QtyUnitType _QtyReturned = QtyReturned;
			Infobar _Infobar = Infobar;
			SiteType _ShipSite = ShipSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoitmCdSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrdered", _QtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyShipped", _QtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReturned", _QtyReturned, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
