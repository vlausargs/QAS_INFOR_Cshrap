//PROJECT NAME: Reporting
//CLASS NAME: THARpt_WithholdingTaxCert.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class THARpt_WithholdingTaxCert : ITHARpt_WithholdingTaxCert
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public THARpt_WithholdingTaxCert(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) THARpt_WithholdingTaxCertSp(string BankCode,
		string BegVendNum = null,
		string EndVendNum = null,
		DateTime? BegCheckDate = null,
		DateTime? EndCheckDate = null,
		string BegName = null,
		string EndName = null,
		string Infobar = null,
		string pSite = null)
		{
			BankCodeType _BankCode = BankCode;
			VendNumType _BegVendNum = BegVendNum;
			VendNumType _EndVendNum = EndVendNum;
			DateType _BegCheckDate = BegCheckDate;
			DateType _EndCheckDate = EndCheckDate;
			NameType _BegName = BegName;
			NameType _EndName = EndName;
			InfobarType _Infobar = Infobar;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THARpt_WithholdingTaxCertSp";
				
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegVendNum", _BegVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendNum", _EndVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegCheckDate", _BegCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCheckDate", _EndCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegName", _BegName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndName", _EndName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
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
