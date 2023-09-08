//PROJECT NAME: Logistics
//CLASS NAME: CoBlnPostQuery.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoBlnPostQuery : ICoBlnPostQuery
	{
		readonly IApplicationDB appDB;
		
		
		public CoBlnPostQuery(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? QtyReserved,
		decimal? QtyShipped,
		decimal? QtyReleased,
		string Infobar) CoBlnPostQuerySp(string CoNum,
		int? CoLine,
		decimal? QtyReserved,
		decimal? QtyShipped,
		decimal? QtyReleased,
		string Infobar,
		string Site = null)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			QtyUnitType _QtyReserved = QtyReserved;
			QtyUnitType _QtyShipped = QtyShipped;
			QtyUnitType _QtyReleased = QtyReleased;
			Infobar _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoBlnPostQuerySp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReserved", _QtyReserved, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyShipped", _QtyShipped, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyReleased", _QtyReleased, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QtyReserved = _QtyReserved;
				QtyShipped = _QtyShipped;
				QtyReleased = _QtyReleased;
				Infobar = _Infobar;
				
				return (Severity, QtyReserved, QtyShipped, QtyReleased, Infobar);
			}
		}
	}
}
