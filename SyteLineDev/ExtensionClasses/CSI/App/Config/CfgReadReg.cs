//PROJECT NAME: Config
//CLASS NAME: CfgReadReg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgReadReg : ICfgReadReg
	{
		readonly IApplicationDB appDB;
		
		public CfgReadReg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PKeyValue,
			string Infobar) CfgReadRegSp(
			string PKey,
			string PKeyValue,
			string Infobar)
		{
			LongListType _PKey = PKey;
			LongListType _PKeyValue = PKeyValue;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgReadRegSp";
				
				appDB.AddCommandParameter(cmd, "PKey", _PKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PKeyValue", _PKeyValue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PKeyValue = _PKeyValue;
				Infobar = _Infobar;
				
				return (Severity, PKeyValue, Infobar);
			}
		}
	}
}
