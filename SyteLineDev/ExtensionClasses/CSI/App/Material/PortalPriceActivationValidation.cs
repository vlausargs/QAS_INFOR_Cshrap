//PROJECT NAME: CSIMaterial
//CLASS NAME: PortalPriceActivationValidation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IPortalPriceActivationValidation
	{
		(int? ReturnCode, string Infobar) PortalPriceActivationValidationSp(string Site = null,
		string Process = "P",
		string Infobar = null,
		int? BGTaskID = null);
	}
	
	public class PortalPriceActivationValidation : IPortalPriceActivationValidation
	{
		readonly IApplicationDB appDB;
		
		public PortalPriceActivationValidation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PortalPriceActivationValidationSp(string Site = null,
		string Process = "P",
		string Infobar = null,
		int? BGTaskID = null)
		{
			SiteType _Site = Site;
			StringType _Process = Process;
			InfobarType _Infobar = Infobar;
			GenericNoType _BGTaskID = BGTaskID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PortalPriceActivationValidationSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Process", _Process, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BGTaskID", _BGTaskID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
