//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLICValidateResourceId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLICValidateResourceId
	{
		int FTSLICValidateResourceIdSp(short? DisplayResourceId,
		                               short? OnlyAllowResource,
		                               short? AllowMultiuseResource,
		                               short? TTImplemented,
		                               string Job,
		                               short? Suffix,
		                               int? Operation,
		                               string Rgid,
		                               string MachineResource,
		                               short? IsAllowMultiuseResource,
		                               ref string Infobar);
	}
	
	public class FTSLICValidateResourceId : IFTSLICValidateResourceId
	{
		readonly IApplicationDB appDB;
		
		public FTSLICValidateResourceId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLICValidateResourceIdSp(short? DisplayResourceId,
		                                      short? OnlyAllowResource,
		                                      short? AllowMultiuseResource,
		                                      short? TTImplemented,
		                                      string Job,
		                                      short? Suffix,
		                                      int? Operation,
		                                      string Rgid,
		                                      string MachineResource,
		                                      short? IsAllowMultiuseResource,
		                                      ref string Infobar)
		{
			UserFlagType _DisplayResourceId = DisplayResourceId;
			UserFlagType _OnlyAllowResource = OnlyAllowResource;
			UserFlagType _AllowMultiuseResource = AllowMultiuseResource;
			UserFlagType _TTImplemented = TTImplemented;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _Operation = Operation;
			ReasonClassType _Rgid = Rgid;
			ReasonClassType _MachineResource = MachineResource;
			UserFlagType _IsAllowMultiuseResource = IsAllowMultiuseResource;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLICValidateResourceIdSp";
				
				appDB.AddCommandParameter(cmd, "DisplayResourceId", _DisplayResourceId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OnlyAllowResource", _OnlyAllowResource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllowMultiuseResource", _AllowMultiuseResource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTImplemented", _TTImplemented, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Operation", _Operation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Rgid", _Rgid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineResource", _MachineResource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsAllowMultiuseResource", _IsAllowMultiuseResource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
