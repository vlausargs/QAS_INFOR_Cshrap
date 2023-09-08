//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQPOCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQPOCreate : ISSSRFQPOCreate
	{
		readonly IApplicationDB appDB;
		
		
		public SSSRFQPOCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSRFQPOCreateSp(string iPONum,
		string Infobar)
		{
			PoNumType _iPONum = iPONum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQPOCreateSp";
				
				appDB.AddCommandParameter(cmd, "iPONum", _iPONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
