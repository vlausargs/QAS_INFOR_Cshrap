//PROJECT NAME: CSIVendor
//CLASS NAME: DemandingPoCoUnlink.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IDemandingPoCoUnlink
	{
		(int? ReturnCode, string Infobar) DemandingPoCoUnlinkSp(string DemandingPO,
		byte? DeletePO,
		byte? DeleteCO,
		string SourceSite = null,
		string SourceSiteCo = null,
		string Infobar = null);
	}
	
	public class DemandingPoCoUnlink : IDemandingPoCoUnlink
	{
		readonly IApplicationDB appDB;
		
		public DemandingPoCoUnlink(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DemandingPoCoUnlinkSp(string DemandingPO,
		byte? DeletePO,
		byte? DeleteCO,
		string SourceSite = null,
		string SourceSiteCo = null,
		string Infobar = null)
		{
			PoNumType _DemandingPO = DemandingPO;
			ListYesNoType _DeletePO = DeletePO;
			ListYesNoType _DeleteCO = DeleteCO;
			SiteType _SourceSite = SourceSite;
			CoNumType _SourceSiteCo = SourceSiteCo;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DemandingPoCoUnlinkSp";
				
				appDB.AddCommandParameter(cmd, "DemandingPO", _DemandingPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeletePO", _DeletePO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeleteCO", _DeleteCO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceSite", _SourceSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceSiteCo", _SourceSiteCo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
