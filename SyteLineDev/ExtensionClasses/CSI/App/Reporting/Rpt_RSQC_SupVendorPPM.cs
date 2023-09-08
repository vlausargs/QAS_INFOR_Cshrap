//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_SupVendorPPM.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_SupVendorPPM : IRpt_RSQC_SupVendorPPM
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RSQC_SupVendorPPM(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_SupVendorPPMSp(
			string begitem = null,
			string enditem = null,
			string begvend = null,
			string endvend = null,
			DateTime? begtdate = null,
			DateTime? endtdate = null,
			string sortby = null,
			int? displayheader = null)
		{
			ItemType _begitem = begitem;
			ItemType _enditem = enditem;
			VendNumType _begvend = begvend;
			VendNumType _endvend = endvend;
			DateType _begtdate = begtdate;
			DateType _endtdate = endtdate;
			StringType _sortby = sortby;
			ListYesNoType _displayheader = displayheader;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_SupVendorPPMSp";
				
				appDB.AddCommandParameter(cmd, "begitem", _begitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "enditem", _enditem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begvend", _begvend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endvend", _endvend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begtdate", _begtdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endtdate", _endtdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sortby", _sortby, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "displayheader", _displayheader, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
