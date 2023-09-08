//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TaxInvoicedParametric.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_TaxInvoicedParametric : IRpt_TaxInvoicedParametric
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_TaxInvoicedParametric(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_TaxInvoicedParametricSP(int? taxsystem = null,
		string taxjur = null,
		DateTime? Begininvstaxinvdate = null,
		DateTime? Endinvstaxinvdate = null,
		int? BegininvstaxinvdateOffset = null,
		int? EndinvstaxinvdateOffset = null,
		int? Showdetail = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null)
		{
			TaxSystemType _taxsystem = taxsystem;
			TaxJurType _taxjur = taxjur;
			DateType _Begininvstaxinvdate = Begininvstaxinvdate;
			DateType _Endinvstaxinvdate = Endinvstaxinvdate;
			DateOffsetType _BegininvstaxinvdateOffset = BegininvstaxinvdateOffset;
			DateOffsetType _EndinvstaxinvdateOffset = EndinvstaxinvdateOffset;
			ListYesNoType _Showdetail = Showdetail;
			ListYesNoType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_TaxInvoicedParametricSP";
				
				appDB.AddCommandParameter(cmd, "taxsystem", _taxsystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "taxjur", _taxjur, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Begininvstaxinvdate", _Begininvstaxinvdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Endinvstaxinvdate", _Endinvstaxinvdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegininvstaxinvdateOffset", _BegininvstaxinvdateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndinvstaxinvdateOffset", _EndinvstaxinvdateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Showdetail", _Showdetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
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
