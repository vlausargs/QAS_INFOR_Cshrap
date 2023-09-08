//PROJECT NAME: Config
//CLASS NAME: CfgCheckXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgCheckXref : ICfgCheckXref
	{
		readonly IApplicationDB appDB;
		
		public CfgCheckXref(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string pFromSite,
			string pToSite,
			string Infobar) CfgCheckXrefSp(
			string pRefNum,
			int? pLineSuf,
			string pFromSite,
			string pToSite,
			string Infobar)
		{
			JobPoProjReqTrnNumType _pRefNum = pRefNum;
			SuffixPoLineProjTaskReqTrnLineType _pLineSuf = pLineSuf;
			SiteType _pFromSite = pFromSite;
			SiteType _pToSite = pToSite;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgCheckXrefSp";
				
				appDB.AddCommandParameter(cmd, "pRefNum", _pRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLineSuf", _pLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFromSite", _pFromSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pToSite", _pToSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pFromSite = _pFromSite;
				pToSite = _pToSite;
				Infobar = _Infobar;
				
				return (Severity, pFromSite, pToSite, Infobar);
			}
		}
	}
}
