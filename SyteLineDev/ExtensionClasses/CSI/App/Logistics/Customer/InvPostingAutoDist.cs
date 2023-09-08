//PROJECT NAME: Logistics
//CLASS NAME: InvPostingAutoDist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InvPostingAutoDist : IInvPostingAutoDist
	{
		readonly IApplicationDB appDB;
		
		
		public InvPostingAutoDist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) InvPostingAutoDistSp(Guid? PSessionID,
		string PCustNum,
		string PInvNum,
		int? PInvSeq,
		string Infobar,
		string ToSite = null)
		{
			RowPointer _PSessionID = PSessionID;
			CustNumType _PCustNum = PCustNum;
			InvNumType _PInvNum = PInvNum;
			ArInvSeqType _PInvSeq = PInvSeq;
			Infobar _Infobar = Infobar;
			SiteType _ToSite = ToSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvPostingAutoDistSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvSeq", _PInvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
