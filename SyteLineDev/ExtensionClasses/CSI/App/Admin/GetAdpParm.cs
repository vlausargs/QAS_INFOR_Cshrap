//PROJECT NAME: Admin
//CLASS NAME: GetAdpParm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class GetAdpParm : IGetAdpParm
	{
		readonly IApplicationDB appDB;
		
		
		public GetAdpParm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InPath,
		string CompanyCode,
		string InFile,
		int? Prenote,
		string Infobar) GetAdpParmSp(string InPath,
		string CompanyCode,
		string InFile,
		int? Prenote,
		string Infobar)
		{
			OSLocationType _InPath = InPath;
			AdpCompanyCodeType _CompanyCode = CompanyCode;
			OSLocationType _InFile = InFile;
			PrenoteType _Prenote = Prenote;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetAdpParmSp";
				
				appDB.AddCommandParameter(cmd, "InPath", _InPath, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CompanyCode", _CompanyCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InFile", _InFile, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prenote", _Prenote, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InPath = _InPath;
				CompanyCode = _CompanyCode;
				InFile = _InFile;
				Prenote = _Prenote;
				Infobar = _Infobar;
				
				return (Severity, InPath, CompanyCode, InFile, Prenote, Infobar);
			}
		}
	}
}
