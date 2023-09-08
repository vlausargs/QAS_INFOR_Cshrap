//PROJECT NAME: Logistics
//CLASS NAME: EFTImportEFTArpmnt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EFTImportEFTArpmnt : IEFTImportEFTArpmnt
	{
		readonly IApplicationDB appDB;
		
		
		public EFTImportEFTArpmnt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? BatchId,
		int? HeaderNum,
		Guid? RefRowPointer,
		string Infobar) EFTImportEFTArpmntSp(string MapId,
		string Filename,
		string CustNum,
		string CustName,
		string CheckNum,
		DateTime? DepositDate,
		decimal? CheckAmt,
		string RoutingNum,
		string AccountNum,
		string PaymentType,
		string Stat,
		decimal? BatchId,
		int? HeaderNum,
		Guid? RefRowPointer,
		string Infobar)
		{
			EFTMappingIdType _MapId = MapId;
			OSResourceNameType _Filename = Filename;
			CustNumType _CustNum = CustNum;
			NameType _CustName = CustName;
			ReferenceType _CheckNum = CheckNum;
			DateType _DepositDate = DepositDate;
			AmountType _CheckAmt = CheckAmt;
			BankTransitNumType _RoutingNum = RoutingNum;
			BankAccountType _AccountNum = AccountNum;
			ArpmtTypeType _PaymentType = PaymentType;
			ARImportPaymentStatType _Stat = Stat;
			ARImportBatchIdType _BatchId = BatchId;
			ARImportHeaderNumType _HeaderNum = HeaderNum;
			RowPointerType _RefRowPointer = RefRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EFTImportEFTArpmntSp";
				
				appDB.AddCommandParameter(cmd, "MapId", _MapId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Filename", _Filename, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustName", _CustName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNum", _CheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepositDate", _DepositDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckAmt", _CheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RoutingNum", _RoutingNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountNum", _AccountNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PaymentType", _PaymentType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BatchId", _BatchId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "HeaderNum", _HeaderNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefRowPointer", _RefRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BatchId = _BatchId;
				HeaderNum = _HeaderNum;
				RefRowPointer = _RefRowPointer;
				Infobar = _Infobar;
				
				return (Severity, BatchId, HeaderNum, RefRowPointer, Infobar);
			}
		}
	}
}
