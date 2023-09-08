//PROJECT NAME: Material
//CLASS NAME: GetInvSiteGrp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class GetInvSiteGrp : IGetInvSiteGrp
	{
		readonly IApplicationDB appDB;
		
		
		public GetInvSiteGrp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InvSiteGrp) GetInvSiteGrpSp(decimal? Userid,
		string InvSiteGrp)
		{
			TokenType _Userid = Userid;
			SiteGroupType _InvSiteGrp = InvSiteGrp;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetInvSiteGrpSp";
				
				appDB.AddCommandParameter(cmd, "Userid", _Userid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvSiteGrp", _InvSiteGrp, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InvSiteGrp = _InvSiteGrp;
				
				return (Severity, InvSiteGrp);
			}
		}
	}
}
