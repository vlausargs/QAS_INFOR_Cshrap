//PROJECT NAME: CSICustomer
//CLASS NAME: GetLastInteractionID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetLastInteractionID
	{
		(int? ReturnCode, decimal? InteractionId, string Site, string Infobar) GetLastInteractionIDSp(string RefNumId,
		string InteractionType,
		string SiteGroup,
		decimal? InteractionId,
		string Site,
		string Infobar = null);
		decimal? GetLastInteractionIDFn(
			string CustNum,
			string InteractionType);

	}
	
	public class GetLastInteractionID : IGetLastInteractionID
	{
		readonly IApplicationDB appDB;
		
		public GetLastInteractionID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? InteractionId, string Site, string Infobar) GetLastInteractionIDSp(string RefNumId,
		string InteractionType,
		string SiteGroup,
		decimal? InteractionId,
		string Site,
		string Infobar = null)
		{
			RefNumIdType _RefNumId = RefNumId;
			InteractionTypeType _InteractionType = InteractionType;
			SiteGroupType _SiteGroup = SiteGroup;
			InteractionIdType _InteractionId = InteractionId;
			SiteType _Site = Site;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetLastInteractionIDSp";
				
				appDB.AddCommandParameter(cmd, "RefNumId", _RefNumId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InteractionType", _InteractionType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InteractionId", _InteractionId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InteractionId = _InteractionId;
				Site = _Site;
				Infobar = _Infobar;
				
				return (Severity, InteractionId, Site, Infobar);
			}
		}

		public decimal? GetLastInteractionIDFn(
			string CustNum,
			string InteractionType)
		{
			CustNumType _CustNum = CustNum;
			InteractionTypeType _InteractionType = InteractionType;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetLastInteractionID](@CustNum, @InteractionType)";

				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InteractionType", _InteractionType, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<decimal?>(cmd);

				return Output;
			}
		}
	}
}
