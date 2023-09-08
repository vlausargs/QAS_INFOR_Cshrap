//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateResourceByGroup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLValidateResourceByGroup
	{
		(int? ReturnCode, string InfoBar) FTSLValidateResourceByGroupSp(string ResourceID,
		string ResourceGroup,
		string InfoBar);
	}
	
	public class FTSLValidateResourceByGroup : IFTSLValidateResourceByGroup
	{
		readonly IApplicationDB appDB;
		
		public FTSLValidateResourceByGroup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) FTSLValidateResourceByGroupSp(string ResourceID,
		string ResourceGroup,
		string InfoBar)
		{
			ApsResourceType _ResourceID = ResourceID;
			ApsResgroupType _ResourceGroup = ResourceGroup;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLValidateResourceByGroupSp";
				
				appDB.AddCommandParameter(cmd, "ResourceID", _ResourceID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceGroup", _ResourceGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
