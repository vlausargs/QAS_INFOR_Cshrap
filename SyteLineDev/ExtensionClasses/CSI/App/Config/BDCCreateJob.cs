//PROJECT NAME: Config
//CLASS NAME: BDCCreateJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class BDCCreateJob : IBDCCreateJob
	{
		readonly IApplicationDB appDB;
		
		
		public BDCCreateJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) BDCCreateJobSp(string sConfigID,
		string sOrderType,
		string Infobar)
		{
			ConfigIdType _sConfigID = sConfigID;
			ConfigAttrValueType _sOrderType = sOrderType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BDCCreateJobSp";
				
				appDB.AddCommandParameter(cmd, "sConfigID", _sConfigID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sOrderType", _sOrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
