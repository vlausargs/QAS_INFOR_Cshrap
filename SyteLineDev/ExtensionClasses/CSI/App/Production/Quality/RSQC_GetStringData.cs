//PROJECT NAME: Production
//CLASS NAME: RSQC_GetStringData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetStringData : IRSQC_GetStringData
	{
		readonly IApplicationDB appDB;
		
		public RSQC_GetStringData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string o_text) RSQC_GetStringDataSp(
			string i_string,
			string o_text)
		{
			ObjectNameType _i_string = i_string;
			InfobarType _o_text = o_text;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetStringDataSp";
				
				appDB.AddCommandParameter(cmd, "i_string", _i_string, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_text", _o_text, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_text = _o_text;
				
				return (Severity, o_text);
			}
		}
	}
}
