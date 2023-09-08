//PROJECT NAME: Production
//CLASS NAME: JustInTimeTransactionSetVars.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JustInTimeTransactionSetVars : IJustInTimeTransactionSetVars
	{
		readonly IApplicationDB appDB;
		
		
		public JustInTimeTransactionSetVars(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) JustInTimeTransactionSetVarsSp(string SET,
		string TItem,
		decimal? TcQtuQty,
		string TWhse,
		string TLoc,
		string TLot,
		DateTime? TTransDate,
		string TShift,
		string TEmpNum,
		int? PPostNeg,
		string SerialPrefix,
		Guid? SessionID,
		string Infobar,
		string DocumentNum = null)
		{
			ProcessIndType _SET = SET;
			ItemType _TItem = TItem;
			QtyUnitType _TcQtuQty = TcQtuQty;
			WhseType _TWhse = TWhse;
			LocType _TLoc = TLoc;
			LotType _TLot = TLot;
			DateType _TTransDate = TTransDate;
			ShiftType _TShift = TShift;
			EmpNumType _TEmpNum = TEmpNum;
			Flag _PPostNeg = PPostNeg;
			SerialPrefixType _SerialPrefix = SerialPrefix;
			RowPointerType _SessionID = SessionID;
			InfobarType _Infobar = Infobar;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JustInTimeTransactionSetVarsSp";
				
				appDB.AddCommandParameter(cmd, "SET", _SET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TItem", _TItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TcQtuQty", _TcQtuQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TWhse", _TWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLoc", _TLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLot", _TLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDate", _TTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TShift", _TShift, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEmpNum", _TEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostNeg", _PPostNeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
