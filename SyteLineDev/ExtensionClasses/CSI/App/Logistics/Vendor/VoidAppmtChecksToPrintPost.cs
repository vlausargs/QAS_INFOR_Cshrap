//PROJECT NAME: Logistics
//CLASS NAME: VoidAppmtChecksToPrintPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VoidAppmtChecksToPrintPost : IVoidAppmtChecksToPrintPost
	{
		readonly IApplicationDB appDB;
		
		
		public VoidAppmtChecksToPrintPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) VoidAppmtChecksToPrintPostSp(Guid? PSessionID,
		decimal? PUserID,
		string PPayCode,
		string PBankCode,
		string Infobar)
		{
			RowPointerType _PSessionID = PSessionID;
			TokenType _PUserID = PUserID;
			AppmtPayTypeType _PPayCode = PPayCode;
			BankCodeType _PBankCode = PBankCode;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VoidAppmtChecksToPrintPostSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUserID", _PUserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayCode", _PPayCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
