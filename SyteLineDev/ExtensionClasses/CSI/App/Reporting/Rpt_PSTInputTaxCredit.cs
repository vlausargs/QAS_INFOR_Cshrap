//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PSTInputTaxCredit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PSTInputTaxCredit : IRpt_PSTInputTaxCredit
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PSTInputTaxCredit(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PSTInputTaxCreditSp(int? TaxSystem = null,
		string TaxCode = null,
		DateTime? TaxDateStarting = null,
		DateTime? TaxDateEnding = null,
		int? TaxDateStartingOffset = null,
		int? TaxDateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			TaxSystemType _TaxSystem = TaxSystem;
			TaxCodeType _TaxCode = TaxCode;
			DateType _TaxDateStarting = TaxDateStarting;
			DateType _TaxDateEnding = TaxDateEnding;
			DateOffsetType _TaxDateStartingOffset = TaxDateStartingOffset;
			DateOffsetType _TaxDateEndingOffset = TaxDateEndingOffset;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PSTInputTaxCreditSp";
				
				appDB.AddCommandParameter(cmd, "TaxSystem", _TaxSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode", _TaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxDateStarting", _TaxDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxDateEnding", _TaxDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxDateStartingOffset", _TaxDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxDateEndingOffset", _TaxDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
