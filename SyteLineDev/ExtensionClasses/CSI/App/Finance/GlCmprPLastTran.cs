//PROJECT NAME: CSIFinance
//CLASS NAME: GlCmprPLastTran.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
	public interface IGlCmprPLastTran
	{
		int GlCmprPLastTranSp(decimal? PUserID,
		                      byte? PLock,
		                      ref string Infobar);
	}
	
	public class GlCmprPLastTran : IGlCmprPLastTran
	{
		readonly IApplicationDB appDB;
		
		public GlCmprPLastTran(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GlCmprPLastTranSp(decimal? PUserID,
		                             byte? PLock,
		                             ref string Infobar)
		{
			TokenType _PUserID = PUserID;
			FlagNyType _PLock = PLock;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GlCmprPLastTranSp";
				
				appDB.AddCommandParameter(cmd, "PUserID", _PUserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLock", _PLock, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
