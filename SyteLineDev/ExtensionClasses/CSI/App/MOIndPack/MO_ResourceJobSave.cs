//PROJECT NAME: CSIMOIndPack
//CLASS NAME: MO_ResourceJobSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.MOIndPack
{
	public interface IMO_ResourceJobSave
	{
		int MO_ResourceJobSaveSp(string RESID,
		                         string Item,
		                         string Job,
		                         short? Suffix,
		                         decimal? QtyPerCycle);
	}
	
	public class MO_ResourceJobSave : IMO_ResourceJobSave
	{
		readonly IApplicationDB appDB;
		
		public MO_ResourceJobSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int MO_ResourceJobSaveSp(string RESID,
		                                string Item,
		                                string Job,
		                                short? Suffix,
		                                decimal? QtyPerCycle)
		{
			ApsResourceType _RESID = RESID;
			ItemType _Item = Item;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			QtyUnitType _QtyPerCycle = QtyPerCycle;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MO_ResourceJobSaveSp";
				
				appDB.AddCommandParameter(cmd, "RESID", _RESID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyPerCycle", _QtyPerCycle, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
