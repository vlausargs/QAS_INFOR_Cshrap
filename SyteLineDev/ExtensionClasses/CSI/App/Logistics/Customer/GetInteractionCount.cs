//PROJECT NAME: CSICustomer
//CLASS NAME: GetInteractionCount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetInteractionCount
	{
		(int? ReturnCode, int? InteractionCount, string Infobar) GetInteractionCountSp(string RefNumId,
		string InteractionType,
		int? InteractionCount,
		string Infobar = null,
		string SiteRef = null);
	}
	
	public class GetInteractionCount : IGetInteractionCount
	{
		readonly IApplicationDB appDB;
		
		public GetInteractionCount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? InteractionCount, string Infobar) GetInteractionCountSp(string RefNumId,
		string InteractionType,
		int? InteractionCount,
		string Infobar = null,
		string SiteRef = null)
		{
			CustNumType _RefNumId = RefNumId;
			InteractionTypeType _InteractionType = InteractionType;
			IntType _InteractionCount = InteractionCount;
			InfobarType _Infobar = Infobar;
			SiteType _SiteRef = SiteRef;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetInteractionCountSp";
				
				appDB.AddCommandParameter(cmd, "RefNumId", _RefNumId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InteractionType", _InteractionType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InteractionCount", _InteractionCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InteractionCount = _InteractionCount;
				Infobar = _Infobar;
				
				return (Severity, InteractionCount, Infobar);
			}
		}
	}
}
