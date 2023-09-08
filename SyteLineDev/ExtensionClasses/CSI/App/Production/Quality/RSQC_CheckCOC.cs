//PROJECT NAME: Production
//CLASS NAME: RSQC_CheckCOC.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CheckCOC : IRSQC_CheckCOC
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CheckCOC(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? QCItem,
		int? COCItem,
		decimal? QtyCOC,
		decimal? QtyCOCPrinted,
		Guid? SessionID,
		string Infobar) RSQC_CheckCOCSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		string Item,
		int? QCItem,
		int? COCItem,
		decimal? QtyCOC,
		decimal? QtyCOCPrinted,
		Guid? SessionID,
		string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			ItemType _Item = Item;
			ListYesNoType _QCItem = QCItem;
			ListYesNoType _COCItem = COCItem;
			QtyUnitType _QtyCOC = QtyCOC;
			QtyUnitType _QtyCOCPrinted = QtyCOCPrinted;
			RowPointerType _SessionID = SessionID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CheckCOCSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QCItem", _QCItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "COCItem", _COCItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyCOC", _QtyCOC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyCOCPrinted", _QtyCOCPrinted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QCItem = _QCItem;
				COCItem = _COCItem;
				QtyCOC = _QtyCOC;
				QtyCOCPrinted = _QtyCOCPrinted;
				SessionID = _SessionID;
				Infobar = _Infobar;
				
				return (Severity, QCItem, COCItem, QtyCOC, QtyCOCPrinted, SessionID, Infobar);
			}
		}
	}
}
