//PROJECT NAME: Employee
//CLASS NAME: PayoutGetAdpParm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class PayoutGetAdpParm : IPayoutGetAdpParm
	{
		readonly IApplicationDB appDB;
		
		
		public PayoutGetAdpParm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string AdpParmInterfaceVersion,
		string AdpParmFileId,
		string AdpOutPath,
		string AdpOutFile,
		string AdpParmCompanyCode,
		string AdpJobLaborAlloc,
		string Infobar) PayoutGetAdpParmSp(decimal? UserID,
		string AdpParmInterfaceVersion = null,
		string AdpParmFileId = null,
		string AdpOutPath = null,
		string AdpOutFile = null,
		string AdpParmCompanyCode = null,
		string AdpJobLaborAlloc = null,
		string Infobar = null)
		{
			TokenType _UserID = UserID;
			AdpVersionType _AdpParmInterfaceVersion = AdpParmInterfaceVersion;
			AdpFileIdType _AdpParmFileId = AdpParmFileId;
			OSLocationType _AdpOutPath = AdpOutPath;
			OSLocationType _AdpOutFile = AdpOutFile;
			AdpCompanyCodeType _AdpParmCompanyCode = AdpParmCompanyCode;
			JobLaborAllocType _AdpJobLaborAlloc = AdpJobLaborAlloc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PayoutGetAdpParmSp";
				
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AdpParmInterfaceVersion", _AdpParmInterfaceVersion, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AdpParmFileId", _AdpParmFileId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AdpOutPath", _AdpOutPath, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AdpOutFile", _AdpOutFile, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AdpParmCompanyCode", _AdpParmCompanyCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AdpJobLaborAlloc", _AdpJobLaborAlloc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AdpParmInterfaceVersion = _AdpParmInterfaceVersion;
				AdpParmFileId = _AdpParmFileId;
				AdpOutPath = _AdpOutPath;
				AdpOutFile = _AdpOutFile;
				AdpParmCompanyCode = _AdpParmCompanyCode;
				AdpJobLaborAlloc = _AdpJobLaborAlloc;
				Infobar = _Infobar;
				
				return (Severity, AdpParmInterfaceVersion, AdpParmFileId, AdpOutPath, AdpOutFile, AdpParmCompanyCode, AdpJobLaborAlloc, Infobar);
			}
		}
	}
}
