//PROJECT NAME: POS
//CLASS NAME: SSSPOSConPosP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSConPosP : ISSSPOSConPosP
	{
		readonly IApplicationDB appDB;
		
		
		public SSSPOSConPosP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSPOSConPosPSp(Guid? SessionId = null,
		string RequestingUser = null,
		decimal? UserID = null,
		string CalledFromForm = "POSCheckoutCheckin",
		string PartnerId = null,
		string Drawer = null,
		string Contract = null,
		DateTime? BilledThruDate = null,
		string InvNum = null,
		int? InvSeq = null,
		string InvCred = null,
		string Infobar = null)
		{
			RowPointerType _SessionId = SessionId;
			UsernameType _RequestingUser = RequestingUser;
			TokenType _UserID = UserID;
			DescriptionType _CalledFromForm = CalledFromForm;
			FSPartnerType _PartnerId = PartnerId;
			POSMDrawerType _Drawer = Drawer;
			FSSRONumType _Contract = Contract;
			DateType _BilledThruDate = BilledThruDate;
			InvNumType _InvNum = InvNum;
			InvSeqType _InvSeq = InvSeq;
			StringType _InvCred = InvCred;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSConPosPSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RequestingUser", _RequestingUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFromForm", _CalledFromForm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Drawer", _Drawer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BilledThruDate", _BilledThruDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
