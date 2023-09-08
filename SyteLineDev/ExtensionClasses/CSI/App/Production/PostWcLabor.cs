//PROJECT NAME: CSIProduct
//CLASS NAME: PostWcLabor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IPostWcLabor
	{
		(int? ReturnCode, decimal? SJobtranTransNum, byte? tCoby, string Infobar) PostWcLaborSp(string pWc,
		string pEmpNum,
		decimal? pAHrs,
		int? pStartTime,
		int? pEndTime,
		string pShift,
		DateTime? pTransDate,
		Guid? SessionID,
		decimal? SJobtranTransNum,
		byte? tCoby,
		string Infobar,
		string DocumentNum = null);
	}
	
	public class PostWcLabor : IPostWcLabor
	{
		readonly IApplicationDB appDB;
		
		public PostWcLabor(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? SJobtranTransNum, byte? tCoby, string Infobar) PostWcLaborSp(string pWc,
		string pEmpNum,
		decimal? pAHrs,
		int? pStartTime,
		int? pEndTime,
		string pShift,
		DateTime? pTransDate,
		Guid? SessionID,
		decimal? SJobtranTransNum,
		byte? tCoby,
		string Infobar,
		string DocumentNum = null)
		{
			WcType _pWc = pWc;
			EmpNumType _pEmpNum = pEmpNum;
			TotalHoursType _pAHrs = pAHrs;
			TimeSecondsType _pStartTime = pStartTime;
			TimeSecondsType _pEndTime = pEndTime;
			ShiftType _pShift = pShift;
			DateType _pTransDate = pTransDate;
			RowPointerType _SessionID = SessionID;
			HugeTransNumType _SJobtranTransNum = SJobtranTransNum;
			ListYesNoType _tCoby = tCoby;
			InfobarType _Infobar = Infobar;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PostWcLaborSp";
				
				appDB.AddCommandParameter(cmd, "pWc", _pWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEmpNum", _pEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAHrs", _pAHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartTime", _pStartTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndTime", _pEndTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShift", _pShift, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransDate", _pTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SJobtranTransNum", _SJobtranTransNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "tCoby", _tCoby, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SJobtranTransNum = _SJobtranTransNum;
				tCoby = _tCoby;
				Infobar = _Infobar;
				
				return (Severity, SJobtranTransNum, tCoby, Infobar);
			}
		}
	}
}
