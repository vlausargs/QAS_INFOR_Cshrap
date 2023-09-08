//PROJECT NAME: Logistics
//CLASS NAME: CpSoDi.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CpSoDi : ICpSoDi
	{
		readonly IApplicationDB appDB;
		
		public CpSoDi(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string DeleteSiteList,
			string Infobar) CpSoDiSp(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string CoOrigSite,
			int? HasPrt,
			int? HasCfg,
			string DeleteSiteList,
			string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			SiteType _CoOrigSite = CoOrigSite;
			ListYesNoType _HasPrt = HasPrt;
			ListYesNoType _HasCfg = HasCfg;
			LongList _DeleteSiteList = DeleteSiteList;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CpSoDiSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoOrigSite", _CoOrigSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HasPrt", _HasPrt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HasCfg", _HasCfg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeleteSiteList", _DeleteSiteList, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DeleteSiteList = _DeleteSiteList;
				Infobar = _Infobar;
				
				return (Severity, DeleteSiteList, Infobar);
			}
		}
	}
}
