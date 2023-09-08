//PROJECT NAME: Logistics
//CLASS NAME: AU_RepriceCoitemorBlanketLines.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class AU_RepriceCoitemorBlanketLines : IAU_RepriceCoitemorBlanketLines
	{
		readonly IApplicationDB appDB;
		
		
		public AU_RepriceCoitemorBlanketLines(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) AU_RepriceCoitemorBlanketLinesSp(int? LineorBlanketLine,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		decimal? NewPrice,
		DateTime? RecordDate,
		Guid? SessionID = null,
		string ReasonText = null,
		string Infobar = null)
		{
			ListYesNoType _LineorBlanketLine = LineorBlanketLine;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			CostPrcType _NewPrice = NewPrice;
			CurrentDateType _RecordDate = RecordDate;
			RowPointerType _SessionID = SessionID;
			FormEditorType _ReasonText = ReasonText;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_RepriceCoitemorBlanketLinesSp";
				
				appDB.AddCommandParameter(cmd, "LineorBlanketLine", _LineorBlanketLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewPrice", _NewPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate", _RecordDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonText", _ReasonText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
