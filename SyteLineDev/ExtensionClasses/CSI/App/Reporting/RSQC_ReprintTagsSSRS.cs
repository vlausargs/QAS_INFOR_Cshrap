//PROJECT NAME: Reporting
//CLASS NAME: RSQC_ReprintTagsSSRS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class RSQC_ReprintTagsSSRS : IRSQC_ReprintTagsSSRS
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public RSQC_ReprintTagsSSRS(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) RSQC_ReprintTagsSSRSSp(int? i_rcvrnum,
		string i_stat,
		DateTime? i_transdate,
		decimal? i_qtychar,
		int? i_numtags,
		string psite)
		{
			QCRcvrNumType _i_rcvrnum = i_rcvrnum;
			QCCodeType _i_stat = i_stat;
			DateTimeType _i_transdate = i_transdate;
            /* dec DATATYPE NOT FOUND*/QtyTotlType _i_qtychar = i_qtychar;
			IntType _i_numtags = i_numtags;
			SiteType _psite = psite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_ReprintTagsSSRSSp";
				
				appDB.AddCommandParameter(cmd, "i_rcvrnum", _i_rcvrnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_stat", _i_stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_transdate", _i_transdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_qtychar", _i_qtychar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_numtags", _i_numtags, ParameterDirection.Input);
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
