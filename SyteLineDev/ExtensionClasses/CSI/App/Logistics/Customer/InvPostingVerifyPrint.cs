//PROJECT NAME: Logistics
//CLASS NAME: InvPostingVerifyPrint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InvPostingVerifyPrint : IInvPostingVerifyPrint
	{
		readonly IApplicationDB appDB;
		
		
		public InvPostingVerifyPrint(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? PSessionID,
		string Infobar) InvPostingVerifyPrintSp(Guid? PSessionID,
		string Infobar,
		string ToSite = null)
		{
			RowPointer _PSessionID = PSessionID;
			Infobar _Infobar = Infobar;
			SiteType _ToSite = ToSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvPostingVerifyPrintSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PSessionID = _PSessionID;
				Infobar = _Infobar;
				
				return (Severity, PSessionID, Infobar);
			}
		}
	}
}
