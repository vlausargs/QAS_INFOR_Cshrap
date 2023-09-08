//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_CustInspecStatSSRS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_CustInspecStatSSRS : IRpt_RSQC_CustInspecStatSSRS
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RSQC_CustInspecStatSSRS(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_CustInspecStatSSRSSp(DateTime? CutoffDate = null,
		string BegCust = null,
		string EndCust = null,
		string BegOrder = null,
		string EndOrder = null,
		string BegItem = null,
		string EndItem = null,
		string BegWhse = null,
		string EndWhse = null,
		string CoType = null,
		string COStat = null,
		string COLineStat = null,
		int? ShowDetail = null,
		int? ShipEarly = null,
		int? DisplayHeader = null,
		string psite = null)
		{
			DateType _CutoffDate = CutoffDate;
			CustNumType _BegCust = BegCust;
			CustNumType _EndCust = EndCust;
			CoNumType _BegOrder = BegOrder;
			CoNumType _EndOrder = EndOrder;
			ItemType _BegItem = BegItem;
			ItemType _EndItem = EndItem;
			WhseType _BegWhse = BegWhse;
			WhseType _EndWhse = EndWhse;
			StringType _CoType = CoType;
			StringType _COStat = COStat;
			StringType _COLineStat = COLineStat;
			ListYesNoType _ShowDetail = ShowDetail;
			ListYesNoType _ShipEarly = ShipEarly;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _psite = psite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_CustInspecStatSSRSSp";
				
				appDB.AddCommandParameter(cmd, "CutoffDate", _CutoffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegCust", _BegCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCust", _EndCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegOrder", _BegOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrder", _EndOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegItem", _BegItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegWhse", _BegWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndWhse", _EndWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoType", _CoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "COStat", _COStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "COLineStat", _COLineStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDetail", _ShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipEarly", _ShipEarly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
