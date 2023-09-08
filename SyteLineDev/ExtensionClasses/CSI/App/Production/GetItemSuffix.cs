//PROJECT NAME: CSIProduct
//CLASS NAME: GetItemSuffix.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface IGetItemSuffix
	{
		int GetItemSuffixSp(string Job,
		                    ref string Item,
		                    ref short? Suffix,
		                    ref decimal? QtyRequired,
		                    ref DateTime? DateRequired);
	}
	
	public class GetItemSuffix : IGetItemSuffix
	{
		readonly IApplicationDB appDB;
		
		public GetItemSuffix(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetItemSuffixSp(string Job,
		                           ref string Item,
		                           ref short? Suffix,
		                           ref decimal? QtyRequired,
		                           ref DateTime? DateRequired)
		{
			JobType _Job = Job;
			ItemType _Item = Item;
			SuffixType _Suffix = Suffix;
			QtyUnitType _QtyRequired = QtyRequired;
			DateType _DateRequired = DateRequired;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetItemSuffixSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyRequired", _QtyRequired, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DateRequired", _DateRequired, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				Suffix = _Suffix;
				QtyRequired = _QtyRequired;
				DateRequired = _DateRequired;
				
				return Severity;
			}
		}
	}
}
