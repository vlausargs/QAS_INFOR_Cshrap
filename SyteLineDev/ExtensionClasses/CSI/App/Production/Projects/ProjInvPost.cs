//PROJECT NAME: CSIProjects
//CLASS NAME: ProjInvPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProjInvPost
	{
		(int? ReturnCode, string Infobar) ProjInvPostSp(string StartingProjNum = null,
		string EndingProjNum = null,
		string StartingInvMsNum = null,
		string EndingInvMsNum = null,
		byte? EndPeriod = null,
		short? FiscalYear = null,
		DateTime? PostDate = null,
		string PostLevel = null,
		byte? XLateToDomestic = null,
		byte? DoPost = null,
		string Username = null,
		string BGSessionId = null,
		string Infobar = null);
	}
	
	public class ProjInvPost : IProjInvPost
	{
		readonly IApplicationDB appDB;
		
		public ProjInvPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ProjInvPostSp(string StartingProjNum = null,
		string EndingProjNum = null,
		string StartingInvMsNum = null,
		string EndingInvMsNum = null,
		byte? EndPeriod = null,
		short? FiscalYear = null,
		DateTime? PostDate = null,
		string PostLevel = null,
		byte? XLateToDomestic = null,
		byte? DoPost = null,
		string Username = null,
		string BGSessionId = null,
		string Infobar = null)
		{
			ProjNumType _StartingProjNum = StartingProjNum;
			ProjNumType _EndingProjNum = EndingProjNum;
			ProjMsNumType _StartingInvMsNum = StartingInvMsNum;
			ProjMsNumType _EndingInvMsNum = EndingInvMsNum;
			FinPeriodType _EndPeriod = EndPeriod;
			FiscalYearType _FiscalYear = FiscalYear;
			DateType _PostDate = PostDate;
			StringType _PostLevel = PostLevel;
			ListYesNoType _XLateToDomestic = XLateToDomestic;
			ListYesNoType _DoPost = DoPost;
			UsernameType _Username = Username;
			StringType _BGSessionId = BGSessionId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjInvPostSp";
				
				appDB.AddCommandParameter(cmd, "StartingProjNum", _StartingProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingProjNum", _EndingProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingInvMsNum", _StartingInvMsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingInvMsNum", _EndingInvMsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPeriod", _EndPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostLevel", _PostLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "XLateToDomestic", _XLateToDomestic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoPost", _DoPost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
