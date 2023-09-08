//PROJECT NAME: CSICodes
//CLASS NAME: PortalAccountCorrection.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IPortalAccountCorrection
	{
		int PortalAccountCorrectionSp(string Username,
		                              string CustVendNum,
		                              string Portal,
		                              ref string Infobar);
	}
	
	public class PortalAccountCorrection : IPortalAccountCorrection
	{
		readonly IApplicationDB appDB;
		
		public PortalAccountCorrection(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PortalAccountCorrectionSp(string Username,
		                                     string CustVendNum,
		                                     string Portal,
		                                     ref string Infobar)
		{
			UsernameType _Username = Username;
			CustNumType _CustVendNum = CustVendNum;
			ShortDescType _Portal = Portal;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PortalAccountCorrectionSp";
				
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustVendNum", _CustVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Portal", _Portal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
