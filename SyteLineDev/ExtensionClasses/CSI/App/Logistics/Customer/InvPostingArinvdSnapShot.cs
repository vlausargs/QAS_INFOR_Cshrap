//PROJECT NAME: Logistics
//CLASS NAME: InvPostingArinvdSnapShot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InvPostingArinvdSnapShot : IInvPostingArinvdSnapShot
	{
		readonly IApplicationDB appDB;
		
		
		public InvPostingArinvdSnapShot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) InvPostingArinvdSnapShotSp(Guid? PSessionID,
		string Infobar,
		string ToSite = null)
		{
			RowPointer _PSessionID = PSessionID;
			Infobar _Infobar = Infobar;
			SiteType _ToSite = ToSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvPostingArinvdSnapShotSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
