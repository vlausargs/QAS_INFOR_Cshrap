//PROJECT NAME: Reporting
//CLASS NAME: THARpt_InputVAT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class THARpt_InputVAT : ITHARpt_InputVAT
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public THARpt_InputVAT(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) THARpt_InputVATSp(string BegTaxCode,
		string EndTaxCode,
		DateTime? BegDistDate,
		DateTime? EndDistDate,
		DateTime? BegInvDate,
		DateTime? EndInvDate,
		string BegVendNum,
		string EndVendNum,
		string CompName,
		string Addr1,
		string Addr2,
		string Addr3,
		string Addr4,
		string TaxID,
		string Description = null,
		int? DisplayHeader = null,
		int? DisplaySummaryInvoice = null,
		string Infobar = null,
		string pSite = null,
        int ? UnpostedVAT = 0,
        int? PostedVAT = 1,
        string BranchId = null)
		{
			TaxCodeType _BegTaxCode = BegTaxCode;
			TaxCodeType _EndTaxCode = EndTaxCode;
			DateType _BegDistDate = BegDistDate;
			DateType _EndDistDate = EndDistDate;
			DateType _BegInvDate = BegInvDate;
			DateType _EndInvDate = EndInvDate;
			VendNumType _BegVendNum = BegVendNum;
			VendNumType _EndVendNum = EndVendNum;
			NameType _CompName = CompName;
			AddressType _Addr1 = Addr1;
			AddressType _Addr2 = Addr2;
			AddressType _Addr3 = Addr3;
			AddressType _Addr4 = Addr4;
			TaxRegNumType _TaxID = TaxID;
			DescriptionType _Description = Description;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _DisplaySummaryInvoice = DisplaySummaryInvoice;
			InfobarType _Infobar = Infobar;
			SiteType _pSite = pSite;
            ListYesNoType _UnpostedVAT = UnpostedVAT;
            ListYesNoType _PostedVAT = PostedVAT;
            BranchIdType _BranchId = BranchId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THARpt_InputVATSp";
				
				appDB.AddCommandParameter(cmd, "BegTaxCode", _BegTaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTaxCode", _EndTaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegDistDate", _BegDistDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDistDate", _EndDistDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegInvDate", _BegInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvDate", _EndInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegVendNum", _BegVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendNum", _EndVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompName", _CompName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr1", _Addr1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr2", _Addr2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr3", _Addr3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr4", _Addr4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxID", _TaxID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplaySummaryInvoice", _DisplaySummaryInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UnpostedVAT", _UnpostedVAT, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PostedVAT", _PostedVAT, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BranchId", _BranchId, ParameterDirection.Input);

                IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
