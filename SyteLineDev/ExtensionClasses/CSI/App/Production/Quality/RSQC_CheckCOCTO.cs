//PROJECT NAME: Production
//CLASS NAME: RSQC_CheckCOCTO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CheckCOCTO : IRSQC_CheckCOCTO
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CheckCOCTO(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? QCItem,
		int? COCItem,
		decimal? QtyCOC,
		decimal? QtyCOCPrinted,
		Guid? SessionID,
		string Infobar) RSQC_CheckCOCTOSp(string ToNum,
		int? ToLine,
		int? ToRelease,
		string Item,
		int? QCItem,
		int? COCItem,
		decimal? QtyCOC,
		decimal? QtyCOCPrinted,
		Guid? SessionID,
		string Infobar)
		{
			PoNumType _ToNum = ToNum;
			PoLineType _ToLine = ToLine;
			CoReleaseType _ToRelease = ToRelease;
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
				cmd.CommandText = "RSQC_CheckCOCTOSp";
				
				appDB.AddCommandParameter(cmd, "ToNum", _ToNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLine", _ToLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToRelease", _ToRelease, ParameterDirection.Input);
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
