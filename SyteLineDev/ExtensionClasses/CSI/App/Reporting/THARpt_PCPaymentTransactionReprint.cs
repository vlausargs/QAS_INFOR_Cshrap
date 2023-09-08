//PROJECT NAME: Reporting
//CLASS NAME: THARpt_PCPaymentTransactionReprint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class THARpt_PCPaymentTransactionReprint : ITHARpt_PCPaymentTransactionReprint
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public THARpt_PCPaymentTransactionReprint(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) THARpt_PCPaymentTransactionReprintSp(string PSessionID,
		string FormID,
		string PPayCode,
		string PSBankCode,
		string PEBankCode,
		string PSortNameNum,
		int? DisplayHeader = null,
		int? PDistDetail = null,
		string PStartingVendNum = null,
		string PEndingVendNum = null,
		string PStartingVendName = null,
		string PEndingVendName = null,
		DateTime? PPayDateStarting = null,
		DateTime? PPayDateEnding = null,
		int? SCheckNumber = null,
		int? ECheckNumber = null,
		int? PSPayDateOffset = null,
		int? PEPayDateOffset = null,
		int? internalNotes = null,
		int? ExternalNotes = null,
		string PSite = null)
		{
			StringType _PSessionID = PSessionID;
			StringType _FormID = FormID;
			StringType _PPayCode = PPayCode;
			BankCodeType _PSBankCode = PSBankCode;
			BankCodeType _PEBankCode = PEBankCode;
			LongDescType _PSortNameNum = PSortNameNum;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _PDistDetail = PDistDetail;
			VendNumType _PStartingVendNum = PStartingVendNum;
			VendNumType _PEndingVendNum = PEndingVendNum;
			NameType _PStartingVendName = PStartingVendName;
			NameType _PEndingVendName = PEndingVendName;
			DateType _PPayDateStarting = PPayDateStarting;
			DateType _PPayDateEnding = PPayDateEnding;
			ApCheckNumType _SCheckNumber = SCheckNumber;
			ApCheckNumType _ECheckNumber = ECheckNumber;
			DateOffsetType _PSPayDateOffset = PSPayDateOffset;
			DateOffsetType _PEPayDateOffset = PEPayDateOffset;
			ListYesNoType _internalNotes = internalNotes;
			ListYesNoType _ExternalNotes = ExternalNotes;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THARpt_PCPaymentTransactionReprintSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FormID", _FormID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayCode", _PPayCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSBankCode", _PSBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEBankCode", _PEBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSortNameNum", _PSortNameNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDistDetail", _PDistDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendNum", _PStartingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendNum", _PEndingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendName", _PStartingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendName", _PEndingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayDateStarting", _PPayDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayDateEnding", _PPayDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SCheckNumber", _SCheckNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECheckNumber", _ECheckNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSPayDateOffset", _PSPayDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEPayDateOffset", _PEPayDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "internalNotes", _internalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExternalNotes", _ExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
