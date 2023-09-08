//PROJECT NAME: Reporting
//CLASS NAME: JP_Rpt_TaxControl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class JP_Rpt_TaxControl : IJP_Rpt_TaxControl
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public JP_Rpt_TaxControl(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) JP_Rpt_TaxControlSp(int? DisplayHeader = null,
		string TaxCodeStarting = null,
		string TaxCodeEnding = null,
		DateTime? DateStarting = null,
		DateTime? DateEnding = null,
		string Style = null,
		string pSite = null)
		{
			ListYesNoType _DisplayHeader = DisplayHeader;
			TaxCodeType _TaxCodeStarting = TaxCodeStarting;
			TaxCodeType _TaxCodeEnding = TaxCodeEnding;
			DateType _DateStarting = DateStarting;
			DateType _DateEnding = DateEnding;
			InfobarType _Style = Style;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JP_Rpt_TaxControlSp";
				
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCodeStarting", _TaxCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCodeEnding", _TaxCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateStarting", _DateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateEnding", _DateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Style", _Style, ParameterDirection.Input);
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
