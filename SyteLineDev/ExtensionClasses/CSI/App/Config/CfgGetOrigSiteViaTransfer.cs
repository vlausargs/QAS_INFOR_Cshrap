//PROJECT NAME: Config
//CLASS NAME: CfgGetOrigSiteViaTransfer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgGetOrigSiteViaTransfer : ICfgGetOrigSiteViaTransfer
	{
		readonly IApplicationDB appDB;
		
		
		public CfgGetOrigSiteViaTransfer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string pOrigSite,
		string Infobar) CfgGetOrigSiteViaTransferSp(string pCep,
		string pCoNum,
		int? pCoLine,
		string pTrnNum,
		int? pTrnLine,
		string pOrigSite,
		string Infobar)
		{
			LongListType _pCep = pCep;
			CoNumType _pCoNum = pCoNum;
			CoLineType _pCoLine = pCoLine;
			TrnNumType _pTrnNum = pTrnNum;
			TrnLineType _pTrnLine = pTrnLine;
			SiteType _pOrigSite = pOrigSite;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgGetOrigSiteViaTransferSp";
				
				appDB.AddCommandParameter(cmd, "pCep", _pCep, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoLine", _pCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTrnNum", _pTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTrnLine", _pTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOrigSite", _pOrigSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pOrigSite = _pOrigSite;
				Infobar = _Infobar;
				
				return (Severity, pOrigSite, Infobar);
			}
		}
	}
}
