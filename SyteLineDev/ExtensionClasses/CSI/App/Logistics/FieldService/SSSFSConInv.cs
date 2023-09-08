//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInv : ISSSFSConInv
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSConInv(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string StartInvNum,
		string EndInvNum,
		string Infobar) SSSFSConInvSp(string StartContract,
		string EndContract,
		int? StartContLine,
		int? EndContLine,
		string StartServType,
		string EndServType,
		string StartCustNum,
		string EndCustNum,
		int? InclAnnually,
		int? InclSemiAnnually,
		int? InclQuarterly,
		int? InclBiMonthly,
		int? InclMonthly,
		int? InclOneTime,
		int? InclElapsedTime,
		string BillFreqList = null,
		DateTime? RenewByDate = null,
		DateTime? InvDate = null,
		int? DisplayFixed = null,
		string CalledFromForm = null,
		string Mode = null,
		Guid? SessionId = null,
		string ContractStatus = null,
		string RequestingUser = null,
		decimal? UserID = null,
		string PartnerId = null,
		string Drawer = null,
		string StartInvNum = null,
		string EndInvNum = null,
		string Infobar = null,
		int? PrintZero = 0)
		{
			FSContractType _StartContract = StartContract;
			FSContractType _EndContract = EndContract;
			FSContLineType _StartContLine = StartContLine;
			FSContLineType _EndContLine = EndContLine;
			FSContServTypeType _StartServType = StartServType;
			FSContServTypeType _EndServType = EndServType;
			CustNumType _StartCustNum = StartCustNum;
			CustNumType _EndCustNum = EndCustNum;
			ListYesNoType _InclAnnually = InclAnnually;
			ListYesNoType _InclSemiAnnually = InclSemiAnnually;
			ListYesNoType _InclQuarterly = InclQuarterly;
			ListYesNoType _InclBiMonthly = InclBiMonthly;
			ListYesNoType _InclMonthly = InclMonthly;
			ListYesNoType _InclOneTime = InclOneTime;
			ListYesNoType _InclElapsedTime = InclElapsedTime;
			LongListType _BillFreqList = BillFreqList;
			DateType _RenewByDate = RenewByDate;
			DateType _InvDate = InvDate;
			ListYesNoType _DisplayFixed = DisplayFixed;
			DescriptionType _CalledFromForm = CalledFromForm;
			StringType _Mode = Mode;
			RowPointerType _SessionId = SessionId;
			FSContStatType _ContractStatus = ContractStatus;
			StringType _RequestingUser = RequestingUser;
			TokenType _UserID = UserID;
			FSPartnerType _PartnerId = PartnerId;
			POSMDrawerType _Drawer = Drawer;
			InvNumType _StartInvNum = StartInvNum;
			InvNumType _EndInvNum = EndInvNum;
			Infobar _Infobar = Infobar;
			ListYesNoType _PrintZero = PrintZero;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvSp";
				
				appDB.AddCommandParameter(cmd, "StartContract", _StartContract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndContract", _EndContract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartContLine", _StartContLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndContLine", _EndContLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartServType", _StartServType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndServType", _EndServType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCustNum", _StartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclAnnually", _InclAnnually, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclSemiAnnually", _InclSemiAnnually, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclQuarterly", _InclQuarterly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclBiMonthly", _InclBiMonthly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclMonthly", _InclMonthly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclOneTime", _InclOneTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclElapsedTime", _InclElapsedTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillFreqList", _BillFreqList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RenewByDate", _RenewByDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayFixed", _DisplayFixed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFromForm", _CalledFromForm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContractStatus", _ContractStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RequestingUser", _RequestingUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Drawer", _Drawer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvNum", _StartInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndInvNum", _EndInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrintZero", _PrintZero, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				StartInvNum = _StartInvNum;
				EndInvNum = _EndInvNum;
				Infobar = _Infobar;
				
				return (Severity, StartInvNum, EndInvNum, Infobar);
			}
		}
	}
}
