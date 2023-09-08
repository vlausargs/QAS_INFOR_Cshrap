//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GSTInputTaxCredit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_GSTInputTaxCredit : IRpt_GSTInputTaxCredit
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_GSTInputTaxCredit(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_GSTInputTaxCreditSp(int? TTaxSystem = null,
		string TTaxCode = null,
		DateTime? TaxPreDateStarting = null,
		DateTime? TaxPreDateEnding = null,
		int? TaxPreDateStartingOffset = null,
		int? TaxPreDateEndingOffset = null,
		int? PDisplayHeader = null,
		string BGSessionId = null,
		string pSite = null,
		string BGUser = null)
		{
			TaxSystemType _TTaxSystem = TTaxSystem;
			TaxCodeType _TTaxCode = TTaxCode;
			DateType _TaxPreDateStarting = TaxPreDateStarting;
			DateType _TaxPreDateEnding = TaxPreDateEnding;
			DateOffsetType _TaxPreDateStartingOffset = TaxPreDateStartingOffset;
			DateOffsetType _TaxPreDateEndingOffset = TaxPreDateEndingOffset;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_GSTInputTaxCreditSp";
				
				appDB.AddCommandParameter(cmd, "TTaxSystem", _TTaxSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTaxCode", _TTaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxPreDateStarting", _TaxPreDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxPreDateEnding", _TaxPreDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxPreDateStartingOffset", _TaxPreDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxPreDateEndingOffset", _TaxPreDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
