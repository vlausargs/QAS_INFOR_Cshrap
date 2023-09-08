//PROJECT NAME: Production
//CLASS NAME: RSQC_RePrintTagsBak.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_RePrintTagsBak : IRSQC_RePrintTagsBak
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public RSQC_RePrintTagsBak(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) RSQC_RePrintTagsBaksp(
			int? i_rcvrnum,
			string i_stat,
			DateTime? i_transdate,
			decimal? i_qty,
			int? i_numtags)
		{
			QCRcvrNumType _i_rcvrnum = i_rcvrnum;
			QCCodeType _i_stat = i_stat;
			DateTimeType _i_transdate = i_transdate;
			QtyUnitType _i_qty = i_qty;
			IntType _i_numtags = i_numtags;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_RePrintTagsBaksp";
				
				appDB.AddCommandParameter(cmd, "i_rcvrnum", _i_rcvrnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_stat", _i_stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_transdate", _i_transdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_qty", _i_qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_numtags", _i_numtags, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
