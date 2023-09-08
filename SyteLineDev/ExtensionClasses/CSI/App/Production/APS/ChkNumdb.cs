//PROJECT NAME: CSIAPS
//CLASS NAME: ChkNumdb.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface IChkNumdb
	{
		int ChkNumdbSp(int? Value,
		               short? AltNo,
		               ref string Infobar);
	}
	
	public class ChkNumdb : IChkNumdb
	{
		readonly IApplicationDB appDB;
		
		public ChkNumdb(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ChkNumdbSp(int? Value,
		                      short? AltNo,
		                      ref string Infobar)
		{
			ApsIntType _Value = Value;
			ApsAltNoType _AltNo = AltNo;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChkNumdbSp";
				
				appDB.AddCommandParameter(cmd, "Value", _Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
