//PROJECT NAME: Production
//CLASS NAME: PSScrapTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IPSScrapTrans
	{
		(int? ReturnCode, decimal? JobtranTransNum, byte? TCoby, string Infobar) PSScrapTransSp(string Item,
		decimal? ScrapQty,
		DateTime? TransDate,
		string PsNum,
		string ReasonCode,
		string Employee,
		int? OperNum,
		string Wc,
		string Shift,
		Guid? SessionID,
		decimal? JobtranTransNum,
		byte? TCoby,
		string Infobar,
		string DocumentNum = null);
	}
	
	public class PSScrapTrans : IPSScrapTrans
	{
		readonly IApplicationDB appDB;
		
		public PSScrapTrans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? JobtranTransNum, byte? TCoby, string Infobar) PSScrapTransSp(string Item,
		decimal? ScrapQty,
		DateTime? TransDate,
		string PsNum,
		string ReasonCode,
		string Employee,
		int? OperNum,
		string Wc,
		string Shift,
		Guid? SessionID,
		decimal? JobtranTransNum,
		byte? TCoby,
		string Infobar,
		string DocumentNum = null)
		{
			ItemType _Item = Item;
			QtyUnitType _ScrapQty = ScrapQty;
			DateType _TransDate = TransDate;
			PsNumType _PsNum = PsNum;
			ReasonCodeType _ReasonCode = ReasonCode;
			EmpNumType _Employee = Employee;
			OperNumType _OperNum = OperNum;
			WcType _Wc = Wc;
			ShiftType _Shift = Shift;
			RowPointerType _SessionID = SessionID;
			HugeTransNumType _JobtranTransNum = JobtranTransNum;
			ListYesNoType _TCoby = TCoby;
			InfobarType _Infobar = Infobar;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PSScrapTransSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScrapQty", _ScrapQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PsNum", _PsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Employee", _Employee, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Shift", _Shift, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobtranTransNum", _JobtranTransNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCoby", _TCoby, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				JobtranTransNum = _JobtranTransNum;
				TCoby = _TCoby;
				Infobar = _Infobar;
				
				return (Severity, JobtranTransNum, TCoby, Infobar);
			}
		}
	}
}
