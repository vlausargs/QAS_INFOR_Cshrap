//PROJECT NAME: CSIMaterial
//CLASS NAME: PriceChangeErrorInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IPriceChangeErrorInfo
	{
		(int? ReturnCode, byte? ErrorExists, string Infobar) PriceChangeErrorInfoSp(string SessionIDChar = null,
		byte? ErrorExists = (byte)0,
		string Infobar = null);
	}
	
	public class PriceChangeErrorInfo : IPriceChangeErrorInfo
	{
		readonly IApplicationDB appDB;
		
		public PriceChangeErrorInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? ErrorExists, string Infobar) PriceChangeErrorInfoSp(string SessionIDChar = null,
		byte? ErrorExists = (byte)0,
		string Infobar = null)
		{
			StringType _SessionIDChar = SessionIDChar;
			ListYesNoType _ErrorExists = ErrorExists;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PriceChangeErrorInfoSp";
				
				appDB.AddCommandParameter(cmd, "SessionIDChar", _SessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorExists", _ErrorExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ErrorExists = _ErrorExists;
				Infobar = _Infobar;
				
				return (Severity, ErrorExists, Infobar);
			}
		}
	}
}
