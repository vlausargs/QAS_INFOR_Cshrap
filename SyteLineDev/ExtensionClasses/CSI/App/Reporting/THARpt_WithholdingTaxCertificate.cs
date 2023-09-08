//PROJECT NAME: Reporting
//CLASS NAME: THARpt_WithholdingTaxCertificate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class THARpt_WithholdingTaxCertificate : ITHARpt_WithholdingTaxCertificate
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public THARpt_WithholdingTaxCertificate(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) THARpt_WithholdingTaxCertificateSp(string StartingBankCode = null,
		string StartingVendor = null,
		string EndingVendor = null,
		string StartingTHVendInvNum = null,
		string EndingTHVendInvNum = null,
		DateTime? StartingWHTDate = null,
		DateTime? EndingWHTDate = null,
		int? WHTDateStartingOffset = null,
		int? WHTDateEndingOffset = null,
		int? Reprint = null,
		string pSite = null)
		{
			BankCodeType _StartingBankCode = StartingBankCode;
			VendNumType _StartingVendor = StartingVendor;
			VendNumType _EndingVendor = EndingVendor;
			VendInvNumType _StartingTHVendInvNum = StartingTHVendInvNum;
			VendInvNumType _EndingTHVendInvNum = EndingTHVendInvNum;
			DateType _StartingWHTDate = StartingWHTDate;
			DateType _EndingWHTDate = EndingWHTDate;
			DateOffsetType _WHTDateStartingOffset = WHTDateStartingOffset;
			DateOffsetType _WHTDateEndingOffset = WHTDateEndingOffset;
			IntType _Reprint = Reprint;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THARpt_WithholdingTaxCertificateSp";
				
				appDB.AddCommandParameter(cmd, "StartingBankCode", _StartingBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingVendor", _StartingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVendor", _EndingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingTHVendInvNum", _StartingTHVendInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTHVendInvNum", _EndingTHVendInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingWHTDate", _StartingWHTDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingWHTDate", _EndingWHTDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WHTDateStartingOffset", _WHTDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WHTDateEndingOffset", _WHTDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Reprint", _Reprint, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
