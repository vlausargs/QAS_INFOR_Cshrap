//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInv2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInv2 : ISSSFSConInv2
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInv2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InvNum,
			int? InvSeq,
			string InvCred,
			string Infobar) SSSFSConInv2Sp(
			Guid? SessionId,
			string Contract,
			DateTime? RenewByDate,
			DateTime? InvDate,
			string Mode = null,
			string CalledFromForm = null,
			string RequestingUser = null,
			decimal? UserID = null,
			string PartnerId = null,
			string Drawer = null,
			string InvNum = null,
			int? InvSeq = null,
			string InvCred = null,
			string Infobar = null,
			int? PrintZero = 0)
		{
			RowPointerType _SessionId = SessionId;
			FSContractType _Contract = Contract;
			DateType _RenewByDate = RenewByDate;
			DateType _InvDate = InvDate;
			StringType _Mode = Mode;
			DescriptionType _CalledFromForm = CalledFromForm;
			StringType _RequestingUser = RequestingUser;
			TokenType _UserID = UserID;
			FSPartnerType _PartnerId = PartnerId;
			POSMDrawerType _Drawer = Drawer;
			InvNumType _InvNum = InvNum;
			InvSeqType _InvSeq = InvSeq;
			StringType _InvCred = InvCred;
			InfobarType _Infobar = Infobar;
			ListYesNoType _PrintZero = PrintZero;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInv2Sp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RenewByDate", _RenewByDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFromForm", _CalledFromForm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RequestingUser", _RequestingUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Drawer", _Drawer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrintZero", _PrintZero, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InvNum = _InvNum;
				InvSeq = _InvSeq;
				InvCred = _InvCred;
				Infobar = _Infobar;
				
				return (Severity, InvNum, InvSeq, InvCred, Infobar);
			}
		}
	}
}
