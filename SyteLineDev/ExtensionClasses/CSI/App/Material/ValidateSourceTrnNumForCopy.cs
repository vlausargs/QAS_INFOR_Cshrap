//PROJECT NAME: Material
//CLASS NAME: ValidateSourceTrnNumForCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IValidateSourceTrnNumForCopy
	{
		(int? ReturnCode, short? StartLineNum, short? EndLineNum, string Infobar, string FromSite) ValidateSourceTrnNumForCopySp(string SourceTrnNum,
		short? StartLineNum,
		short? EndLineNum,
		string Infobar,
		string FromSite = null);
	}
	
	public class ValidateSourceTrnNumForCopy : IValidateSourceTrnNumForCopy
	{
		readonly IApplicationDB appDB;
		
		public ValidateSourceTrnNumForCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, short? StartLineNum, short? EndLineNum, string Infobar, string FromSite) ValidateSourceTrnNumForCopySp(string SourceTrnNum,
		short? StartLineNum,
		short? EndLineNum,
		string Infobar,
		string FromSite = null)
		{
			TrnNumType _SourceTrnNum = SourceTrnNum;
			TrnLineType _StartLineNum = StartLineNum;
			TrnLineType _EndLineNum = EndLineNum;
			Infobar _Infobar = Infobar;
			SiteType _FromSite = FromSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateSourceTrnNumForCopySp";
				
				appDB.AddCommandParameter(cmd, "SourceTrnNum", _SourceTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartLineNum", _StartLineNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndLineNum", _EndLineNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				StartLineNum = _StartLineNum;
				EndLineNum = _EndLineNum;
				Infobar = _Infobar;
				FromSite = _FromSite;
				
				return (Severity, StartLineNum, EndLineNum, Infobar, FromSite);
			}
		}
	}
}
