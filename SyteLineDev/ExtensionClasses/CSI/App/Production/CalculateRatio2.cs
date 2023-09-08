//PROJECT NAME: Production
//CLASS NAME: CalculateRatio2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CalculateRatio2 : ICalculateRatio2
	{
		readonly IApplicationDB appDB;
		
		
		public CalculateRatio2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PRatio2,
		string Infobar) CalculateRatio2Sp(string PJob,
		int? PSuffix,
		string PItem,
		int? POldRatio2,
		int? PRatio2,
		string Infobar)
		{
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			ItemType _PItem = PItem;
			TotalProdMixQuantityType _POldRatio2 = POldRatio2;
			GenericNoType _PRatio2 = PRatio2;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalculateRatio2Sp";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldRatio2", _POldRatio2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRatio2", _PRatio2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PRatio2 = _PRatio2;
				Infobar = _Infobar;
				
				return (Severity, PRatio2, Infobar);
			}
		}
	}
}
