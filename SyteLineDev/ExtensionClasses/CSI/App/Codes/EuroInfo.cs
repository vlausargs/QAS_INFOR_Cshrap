//PROJECT NAME: Codes
//CLASS NAME: EuroInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class EuroInfo : IEuroInfo
	{
		readonly IApplicationDB appDB;
		
		
		public EuroInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PEuroUser,
		int? PEuroExists,
		int? PBaseEuro,
		string PEuroCurr,
		string InfoBar) EuroInfoSp(int? DispMsg,
		int? PEuroUser,
		int? PEuroExists,
		int? PBaseEuro,
		string PEuroCurr,
		string InfoBar,
		string Site = null)
		{
			FlagNyType _DispMsg = DispMsg;
			FlagNyType _PEuroUser = PEuroUser;
			FlagNyType _PEuroExists = PEuroExists;
			FlagNyType _PBaseEuro = PBaseEuro;
			CurrCodeType _PEuroCurr = PEuroCurr;
			InfobarType _InfoBar = InfoBar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EuroInfoSp";
				
				appDB.AddCommandParameter(cmd, "DispMsg", _DispMsg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEuroUser", _PEuroUser, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEuroExists", _PEuroExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PBaseEuro", _PBaseEuro, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEuroCurr", _PEuroCurr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PEuroUser = _PEuroUser;
				PEuroExists = _PEuroExists;
				PBaseEuro = _PBaseEuro;
				PEuroCurr = _PEuroCurr;
				InfoBar = _InfoBar;
				
				return (Severity, PEuroUser, PEuroExists, PBaseEuro, PEuroCurr, InfoBar);
			}
		}
	}
}
