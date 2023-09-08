//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MailingLabels.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_MailingLabels : IRpt_MailingLabels
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_MailingLabels(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_MailingLabelsSp(string GenerateLabelFor = null,
		string CEVType = null,
		int? SortByPostCode = null,
		int? PrintCountry = null,
		string PrintWhichCustomerContact = null,
		string NameStarting = null,
		string NameEnding = null,
		string CEVStarting = null,
		string CEVEnding = null,
		string ProvinceStateStarting = null,
		string ProvinceStateEnding = null,
		string PostalZipStarting = null,
		string PostalZipEnding = null,
		string pSite = null)
		{
			Infobar _GenerateLabelFor = GenerateLabelFor;
			Infobar _CEVType = CEVType;
			FlagNyType _SortByPostCode = SortByPostCode;
			FlagNyType _PrintCountry = PrintCountry;
			Infobar _PrintWhichCustomerContact = PrintWhichCustomerContact;
			NameType _NameStarting = NameStarting;
			NameType _NameEnding = NameEnding;
			CoCustPoProjRmaTrnVendNumType _CEVStarting = CEVStarting;
			CoCustPoProjRmaTrnVendNumType _CEVEnding = CEVEnding;
			StateType _ProvinceStateStarting = ProvinceStateStarting;
			StateType _ProvinceStateEnding = ProvinceStateEnding;
			PostalCodeType _PostalZipStarting = PostalZipStarting;
			PostalCodeType _PostalZipEnding = PostalZipEnding;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_MailingLabelsSp";
				
				appDB.AddCommandParameter(cmd, "GenerateLabelFor", _GenerateLabelFor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CEVType", _CEVType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortByPostCode", _SortByPostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCountry", _PrintCountry, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintWhichCustomerContact", _PrintWhichCustomerContact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NameStarting", _NameStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NameEnding", _NameEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CEVStarting", _CEVStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CEVEnding", _CEVEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProvinceStateStarting", _ProvinceStateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProvinceStateEnding", _ProvinceStateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostalZipStarting", _PostalZipStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostalZipEnding", _PostalZipEnding, ParameterDirection.Input);
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
