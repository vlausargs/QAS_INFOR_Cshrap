//PROJECT NAME: Logistics
//CLASS NAME: GetKeyLength.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetKeyLength : IGetKeyLength
	{
		readonly IApplicationDB appDB;
		
		
		public GetKeyLength(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? KeyLength,
		string Infobar) GetKeyLengthSp(string KeyName,
		int? KeyLength,
		string Infobar)
		{
			StringType _KeyName = KeyName;
			IntType _KeyLength = KeyLength;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetKeyLengthSp";
				
				appDB.AddCommandParameter(cmd, "KeyName", _KeyName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KeyLength", _KeyLength, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				KeyLength = _KeyLength;
				Infobar = _Infobar;
				
				return (Severity, KeyLength, Infobar);
			}
		}
	}
}
