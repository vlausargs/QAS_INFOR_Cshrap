//PROJECT NAME: Production
//CLASS NAME: RSQC_XRefChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_XRefChange : IRSQC_XRefChange
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_XRefChange(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? o_change_num) RSQC_XRefChangeSp(string i_change,
		int? i_priority,
		int? o_change_num)
		{
			StringType _i_change = i_change;
			QCIntegerType _i_priority = i_priority;
			QCRcvrNumType _o_change_num = o_change_num;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_XRefChangeSp";
				
				appDB.AddCommandParameter(cmd, "i_change", _i_change, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_priority", _i_priority, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_change_num", _o_change_num, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_change_num = _o_change_num;
				
				return (Severity, o_change_num);
			}
		}
	}
}
