//PROJECT NAME: Reporting
//CLASS NAME: THARpt_WithholdingTaxDetails.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class THARpt_WithholdingTaxDetails : ITHARpt_WithholdingTaxDetails
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public THARpt_WithholdingTaxDetails(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) THARpt_WithholdingTaxDetailsSp(string StartingTaxCode = null,
		string EndingTaxCode = null,
		DateTime? DistDateStart = null,
		DateTime? DistDateEnd = null,
		string StartingVendor = null,
		string EndingVendor = null,
		int? WithhodingTaxType = 1,
		int? DistDateStartingOffset = null,
		int? DistDateEndingOffset = null,
		string WhtType = null,
		int? Reprint = null,
		string pSite = null)
		{
			TaxCodeType _StartingTaxCode = StartingTaxCode;
			TaxCodeType _EndingTaxCode = EndingTaxCode;
			DateType _DistDateStart = DistDateStart;
			DateType _DistDateEnd = DistDateEnd;
			VendNumType _StartingVendor = StartingVendor;
			VendNumType _EndingVendor = EndingVendor;
			IntType _WithhodingTaxType = WithhodingTaxType;
			DateOffsetType _DistDateStartingOffset = DistDateStartingOffset;
			DateOffsetType _DistDateEndingOffset = DistDateEndingOffset;
			StringType _WhtType = WhtType;
			IntType _Reprint = Reprint;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THARpt_WithholdingTaxDetailsSp";
				
				appDB.AddCommandParameter(cmd, "StartingTaxCode", _StartingTaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTaxCode", _EndingTaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistDateStart", _DistDateStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistDateEnd", _DistDateEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingVendor", _StartingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVendor", _EndingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WithhodingTaxType", _WithhodingTaxType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistDateStartingOffset", _DistDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistDateEndingOffset", _DistDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhtType", _WhtType, ParameterDirection.Input);
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
