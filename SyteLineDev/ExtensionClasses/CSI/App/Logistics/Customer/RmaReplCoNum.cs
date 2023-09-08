//PROJECT NAME: Logistics
//CLASS NAME: RmaReplCoNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaReplCoNum : IRmaReplCoNum
	{
		readonly IApplicationDB appDB;
		
		
		public RmaReplCoNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PCoNum,
		string Infobar) RmaReplCoNumSp(string PRmaNum,
		string PCoNum,
		string Infobar)
		{
			RmaNumType _PRmaNum = PRmaNum;
			CoNumType _PCoNum = PCoNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RmaReplCoNumSp";
				
				appDB.AddCommandParameter(cmd, "PRmaNum", _PRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PCoNum = _PCoNum;
				Infobar = _Infobar;
				
				return (Severity, PCoNum, Infobar);
			}
		}
	}
}
