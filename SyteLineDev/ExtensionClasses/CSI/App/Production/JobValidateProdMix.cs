//PROJECT NAME: CSIProduct
//CLASS NAME: JobValidateProdMix.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface IJobValidateProdMix
	{
		int JobValidateProdMixSp(string PProdMix,
		                         string PJob,
		                         short? PSuffix,
		                         string PItem,
		                         decimal? PQtyReleased,
		                         ref string Infobar);
	}
	
	public class JobValidateProdMix : IJobValidateProdMix
	{
		readonly IApplicationDB appDB;
		
		public JobValidateProdMix(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int JobValidateProdMixSp(string PProdMix,
		                                string PJob,
		                                short? PSuffix,
		                                string PItem,
		                                decimal? PQtyReleased,
		                                ref string Infobar)
		{
			ProdMixType _PProdMix = PProdMix;
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			ItemType _PItem = PItem;
			QtyUnitType _PQtyReleased = PQtyReleased;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobValidateProdMixSp";
				
				appDB.AddCommandParameter(cmd, "PProdMix", _PProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyReleased", _PQtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
