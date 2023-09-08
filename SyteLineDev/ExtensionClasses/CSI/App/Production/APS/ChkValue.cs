//PROJECT NAME: CSIAPS
//CLASS NAME: ChkValue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface IChkValue
	{
		int ChkValueSp(string Param,
		               string Value,
		               short? AltNo,
		               ref string Infobar);
	}
	
	public class ChkValue : IChkValue
	{
		readonly IApplicationDB appDB;
		
		public ChkValue(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ChkValueSp(string Param,
		                      string Value,
		                      short? AltNo,
		                      ref string Infobar)
		{
			ApsFieldType _Param = Param;
			ApsOrderType _Value = Value;
			ApsAltNoType _AltNo = AltNo;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChkValueSp";
				
				appDB.AddCommandParameter(cmd, "Param", _Param, ParameterDirection.Input);
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
