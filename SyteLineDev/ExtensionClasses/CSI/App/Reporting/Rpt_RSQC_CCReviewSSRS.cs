//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_CCReviewSSRS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_CCReviewSSRS : IRpt_RSQC_CCReviewSSRS
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RSQC_CCReviewSSRS(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_CCReviewSSRSSp(string CompanyName = null,
		string ProductLine = null,
		string begReasonCode = null,
		string endReasonCode = null,
		string begccr = null,
		string endccr = null,
		int? Openccr = null,
		int? closeccr = null,
		int? PrintInternal = null,
		int? PrintExternal = null,
		string psite = null)
		{
			NameType _CompanyName = CompanyName;
			QCCharType _ProductLine = ProductLine;
			QCCharType _begReasonCode = begReasonCode;
			QCCharType _endReasonCode = endReasonCode;
			QCDocNumType _begccr = begccr;
			QCDocNumType _endccr = endccr;
			ListYesNoType _Openccr = Openccr;
			ListYesNoType _closeccr = closeccr;
			ListYesNoType _PrintInternal = PrintInternal;
			ListYesNoType _PrintExternal = PrintExternal;
			SiteType _psite = psite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_CCReviewSSRSSp";
				
				appDB.AddCommandParameter(cmd, "CompanyName", _CompanyName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductLine", _ProductLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begReasonCode", _begReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endReasonCode", _endReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begccr", _begccr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endccr", _endccr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Openccr", _Openccr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "closeccr", _closeccr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternal", _PrintInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternal", _PrintExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "psite", _psite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
