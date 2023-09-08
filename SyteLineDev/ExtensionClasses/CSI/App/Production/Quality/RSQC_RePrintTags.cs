//PROJECT NAME: Production
//CLASS NAME: RSQC_RePrintTags.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_RePrintTags : IRSQC_RePrintTags
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public RSQC_RePrintTags(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) RSQC_RePrintTagssp(
			int? i_rcvrnum,
			string i_stat,
			DateTime? i_transdate,
			decimal? i_qtychar,
			int? i_numtags)
		{
			QCRcvrNumType _i_rcvrnum = i_rcvrnum;
			QCCodeType _i_stat = i_stat;
			DateTimeType _i_transdate = i_transdate;
			/* dec DATATYPE NOT FOUND*/ 
			DecimalType _i_qtychar = i_qtychar;
			IntType _i_numtags = i_numtags;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_RePrintTagssp";
				
				appDB.AddCommandParameter(cmd, "i_rcvrnum", _i_rcvrnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_stat", _i_stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_transdate", _i_transdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_qtychar", _i_qtychar, ParameterDirection.Input);
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
