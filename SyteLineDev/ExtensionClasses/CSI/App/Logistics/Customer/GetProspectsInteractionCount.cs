//PROJECT NAME: CSICustomer
//CLASS NAME: GetProspectsInteractionCount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetProspectsInteractionCount
	{
		(int? ReturnCode, int? InteractionCount, string Infobar) GetProspectsInteractionCountSp(string ProspectId,
		string Slsman,
		int? InteractionCount,
		string SiteRef,
		string Infobar = null);
	}
	
	public class GetProspectsInteractionCount : IGetProspectsInteractionCount
	{
		readonly IApplicationDB appDB;
		
		public GetProspectsInteractionCount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? InteractionCount, string Infobar) GetProspectsInteractionCountSp(string ProspectId,
		string Slsman,
		int? InteractionCount,
		string SiteRef,
		string Infobar = null)
		{
			ProspectIDType _ProspectId = ProspectId;
			SlsmanType _Slsman = Slsman;
			IntType _InteractionCount = InteractionCount;
			SiteType _SiteRef = SiteRef;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetProspectsInteractionCountSp";
				
				appDB.AddCommandParameter(cmd, "ProspectId", _ProspectId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InteractionCount", _InteractionCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InteractionCount = _InteractionCount;
				Infobar = _Infobar;
				
				return (Severity, InteractionCount, Infobar);
			}
		}
	}
}
