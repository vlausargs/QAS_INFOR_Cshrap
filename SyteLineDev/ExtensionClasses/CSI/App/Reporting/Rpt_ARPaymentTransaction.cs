//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ARPaymentTransaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ARPaymentTransaction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ARPaymentTransactionSp(string PPaymentType = null,
		byte? PDisplayDetail = null,
		string PStartingCustomer = null,
		string PEndingCustomer = null,
		string PStartBnkCode = null,
		string PEndBnkCode = null,
		DateTime? PStartRecDate = null,
		DateTime? PEndRecDate = null,
		int? PStartChkNum = null,
		int? PEndChkNum = null,
		byte? PDisplayHeader = null,
		DateTime? PDepositDateStarting = null,
		DateTime? PDepositDateEnding = null,
		short? PStartRecDateOffset = null,
		short? PEndRecDateOffset = null,
		short? PDepositDateStartingOffset = null,
		short? PDepositDateEndingOffset = null,
		string PStartCrdMemNum = null,
		string PEndCrdMemNum = null,
		byte? Includenull = null,
		string pSite = null,
		string BGUser = null);
	}
	
	public class Rpt_ARPaymentTransaction : IRpt_ARPaymentTransaction
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ARPaymentTransaction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ARPaymentTransactionSp(string PPaymentType = null,
		byte? PDisplayDetail = null,
		string PStartingCustomer = null,
		string PEndingCustomer = null,
		string PStartBnkCode = null,
		string PEndBnkCode = null,
		DateTime? PStartRecDate = null,
		DateTime? PEndRecDate = null,
		int? PStartChkNum = null,
		int? PEndChkNum = null,
		byte? PDisplayHeader = null,
		DateTime? PDepositDateStarting = null,
		DateTime? PDepositDateEnding = null,
		short? PStartRecDateOffset = null,
		short? PEndRecDateOffset = null,
		short? PDepositDateStartingOffset = null,
		short? PDepositDateEndingOffset = null,
		string PStartCrdMemNum = null,
		string PEndCrdMemNum = null,
		byte? Includenull = null,
		string pSite = null,
		string BGUser = null)
		{
			Infobar _PPaymentType = PPaymentType;
			ListYesNoType _PDisplayDetail = PDisplayDetail;
			CustNumType _PStartingCustomer = PStartingCustomer;
			CustNumType _PEndingCustomer = PEndingCustomer;
			BankCodeType _PStartBnkCode = PStartBnkCode;
			BankCodeType _PEndBnkCode = PEndBnkCode;
			DateTimeType _PStartRecDate = PStartRecDate;
			DateTimeType _PEndRecDate = PEndRecDate;
			ArCheckNumType _PStartChkNum = PStartChkNum;
			ArCheckNumType _PEndChkNum = PEndChkNum;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			DateTimeType _PDepositDateStarting = PDepositDateStarting;
			DateTimeType _PDepositDateEnding = PDepositDateEnding;
			DateOffsetType _PStartRecDateOffset = PStartRecDateOffset;
			DateOffsetType _PEndRecDateOffset = PEndRecDateOffset;
			DateOffsetType _PDepositDateStartingOffset = PDepositDateStartingOffset;
			DateOffsetType _PDepositDateEndingOffset = PDepositDateEndingOffset;
			InvNumType _PStartCrdMemNum = PStartCrdMemNum;
			InvNumType _PEndCrdMemNum = PEndCrdMemNum;
			ListYesNoType _Includenull = Includenull;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ARPaymentTransactionSp";
				
				appDB.AddCommandParameter(cmd, "PPaymentType", _PPaymentType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayDetail", _PDisplayDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingCustomer", _PStartingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingCustomer", _PEndingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartBnkCode", _PStartBnkCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndBnkCode", _PEndBnkCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartRecDate", _PStartRecDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndRecDate", _PEndRecDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartChkNum", _PStartChkNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndChkNum", _PEndChkNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDepositDateStarting", _PDepositDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDepositDateEnding", _PDepositDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartRecDateOffset", _PStartRecDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndRecDateOffset", _PEndRecDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDepositDateStartingOffset", _PDepositDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDepositDateEndingOffset", _PDepositDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartCrdMemNum", _PStartCrdMemNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndCrdMemNum", _PEndCrdMemNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Includenull", _Includenull, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
