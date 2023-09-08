//PROJECT NAME: Production
//CLASS NAME: PSCmplTransSetVars.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IPSCmplTransSetVars
	{
		(int? ReturnCode, decimal? JobtranTransNum, byte? TCoby, string Infobar, string PromptMsg, string PromptButtons) PSCmplTransSetVarsSp(string SET,
		string Item,
		decimal? Qty,
		DateTime? TransDate,
		string PsNum,
		string Employee,
		int? OperNum,
		string Wc,
		string Shift,
		string Loc,
		string Lot,
		string SerialPrefix,
		Guid? SessionID,
		decimal? JobtranTransNum,
		byte? TCoby,
		string Infobar,
		string PromptMsg = null,
		string PromptButtons = null,
		byte? CreateMatPostRecord = (byte)0,
		string ContainerNum = null,
		string DocumentNum = null);
	}
	
	public class PSCmplTransSetVars : IPSCmplTransSetVars
	{
		readonly IApplicationDB appDB;
		
		public PSCmplTransSetVars(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? JobtranTransNum, byte? TCoby, string Infobar, string PromptMsg, string PromptButtons) PSCmplTransSetVarsSp(string SET,
		string Item,
		decimal? Qty,
		DateTime? TransDate,
		string PsNum,
		string Employee,
		int? OperNum,
		string Wc,
		string Shift,
		string Loc,
		string Lot,
		string SerialPrefix,
		Guid? SessionID,
		decimal? JobtranTransNum,
		byte? TCoby,
		string Infobar,
		string PromptMsg = null,
		string PromptButtons = null,
		byte? CreateMatPostRecord = (byte)0,
		string ContainerNum = null,
		string DocumentNum = null)
		{
			ProcessIndType _SET = SET;
			ItemType _Item = Item;
			QtyUnitType _Qty = Qty;
			DateType _TransDate = TransDate;
			PsNumType _PsNum = PsNum;
			EmpNumType _Employee = Employee;
			OperNumType _OperNum = OperNum;
			WcType _Wc = Wc;
			ShiftType _Shift = Shift;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			SerialPrefixType _SerialPrefix = SerialPrefix;
			RowPointerType _SessionID = SessionID;
			HugeTransNumType _JobtranTransNum = JobtranTransNum;
			ListYesNoType _TCoby = TCoby;
			InfobarType _Infobar = Infobar;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			ListYesNoType _CreateMatPostRecord = CreateMatPostRecord;
			ContainerNumType _ContainerNum = ContainerNum;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PSCmplTransSetVarsSp";
				
				appDB.AddCommandParameter(cmd, "SET", _SET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PsNum", _PsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Employee", _Employee, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Shift", _Shift, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobtranTransNum", _JobtranTransNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCoby", _TCoby, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreateMatPostRecord", _CreateMatPostRecord, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				JobtranTransNum = _JobtranTransNum;
				TCoby = _TCoby;
				Infobar = _Infobar;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return (Severity, JobtranTransNum, TCoby, Infobar, PromptMsg, PromptButtons);
			}
		}
	}
}
