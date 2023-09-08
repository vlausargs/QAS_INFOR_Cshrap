//PROJECT NAME: Data
//CLASS NAME: ecniItemDescription.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ecniItemDescription : IecniItemDescription
	{
		readonly IApplicationDB appDB;
		
		public ecniItemDescription(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ecniItemDescriptionFn(
			string EcnItemType,
			string Job,
			int? Suffix,
			string Item)
		{
			EcnitemTypeType _EcnItemType = EcnItemType;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ecniItemDescription](@EcnItemType, @Job, @Suffix, @Item)";
				
				appDB.AddCommandParameter(cmd, "EcnItemType", _EcnItemType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
