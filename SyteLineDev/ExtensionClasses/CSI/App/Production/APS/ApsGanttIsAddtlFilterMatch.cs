//PROJECT NAME: Production
//CLASS NAME: ApsGanttIsAddtlFilterMatch.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGanttIsAddtlFilterMatch : IApsGanttIsAddtlFilterMatch
	{
		readonly IApplicationDB appDB;
		
		public ApsGanttIsAddtlFilterMatch(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsGanttIsAddtlFilterMatchFn(
			string Job,
			int? Suffix,
			string FilterCustomer,
			string FilterItem,
			string FilterMaterial)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			CustNumType _FilterCustomer = FilterCustomer;
			ItemType _FilterItem = FilterItem;
			ItemType _FilterMaterial = FilterMaterial;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsGanttIsAddtlFilterMatch](@Job, @Suffix, @FilterCustomer, @FilterItem, @FilterMaterial)";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterCustomer", _FilterCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterItem", _FilterItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterMaterial", _FilterMaterial, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
