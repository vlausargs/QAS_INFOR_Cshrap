//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLTAValidateResourceId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLTAValidateResourceId
	{
		int FTSLTAValidateResourceIdSp(short? OnlyAllowResource,
		                               short? AllowMultiuseResource,
		                               string Job,
		                               short? Suffix,
		                               string Operation,
		                               string Rgid,
		                               string MachineResource,
		                               ref string Infobar);
	}
	
	public class FTSLTAValidateResourceId : IFTSLTAValidateResourceId
	{
		readonly IApplicationDB appDB;
		
		public FTSLTAValidateResourceId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLTAValidateResourceIdSp(short? OnlyAllowResource,
		                                      short? AllowMultiuseResource,
		                                      string Job,
		                                      short? Suffix,
		                                      string Operation,
		                                      string Rgid,
		                                      string MachineResource,
		                                      ref string Infobar)
		{
			UserFlagType _OnlyAllowResource = OnlyAllowResource;
			UserFlagType _AllowMultiuseResource = AllowMultiuseResource;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			PoNumType _Operation = Operation;
			ReferenceType _Rgid = Rgid;
			ReferenceType _MachineResource = MachineResource;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLTAValidateResourceIdSp";
				
				appDB.AddCommandParameter(cmd, "OnlyAllowResource", _OnlyAllowResource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllowMultiuseResource", _AllowMultiuseResource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Operation", _Operation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Rgid", _Rgid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineResource", _MachineResource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
