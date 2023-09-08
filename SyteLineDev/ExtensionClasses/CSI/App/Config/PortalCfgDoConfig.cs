//PROJECT NAME: CSIConfig
//CLASS NAME: PortalCfgDoConfig.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;
using CSI.ExternalContracts.Portals;

namespace CSI.Config
{
	public interface IPortalCfgDoConfig
	{
		int PortalCfgDoConfigSp(string pConfigId,
		                        string pCep,
		                        byte? pCreateJob,
		                        string pRunFrom,
		                        string pRunMode,
		                        byte? pUpdatePrice,
		                        ref byte? DoRefresh,
		                        ref string Infobar,
		                        ref byte? Warning,
		                        ref Guid? SessionID);
	}
	
	public class PortalCfgDoConfig : IPortalCfgDoConfig
	{
		readonly IApplicationDB appDB;
		
		public PortalCfgDoConfig(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PortalCfgDoConfigSp(string pConfigId,
		                               string pCep,
		                               byte? pCreateJob,
		                               string pRunFrom,
		                               string pRunMode,
		                               byte? pUpdatePrice,
		                               ref byte? DoRefresh,
		                               ref string Infobar,
		                               ref byte? Warning,
		                               ref Guid? SessionID)
		{
			ConfigIdType _pConfigId = pConfigId;
			LongListType _pCep = pCep;
			FlagNyType _pCreateJob = pCreateJob;
			LongListType _pRunFrom = pRunFrom;
			LongListType _pRunMode = pRunMode;
			FlagNyType _pUpdatePrice = pUpdatePrice;
			FlagNyType _DoRefresh = DoRefresh;
			InfobarType _Infobar = Infobar;
			FlagNyType _Warning = Warning;
			RowPointerType _SessionID = SessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PortalCfgDoConfigSp";
				
				appDB.AddCommandParameter(cmd, "pConfigId", _pConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCep", _pCep, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCreateJob", _pCreateJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRunFrom", _pRunFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRunMode", _pRunMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUpdatePrice", _pUpdatePrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoRefresh", _DoRefresh, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Warning", _Warning, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DoRefresh = _DoRefresh;
				Infobar = _Infobar;
				Warning = _Warning;
				SessionID = _SessionID;
				
				return Severity;
			}
		}
	}
}
