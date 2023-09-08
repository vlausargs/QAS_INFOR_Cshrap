//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ECNbyItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ECNbyItem
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ECNbyItemSp(string ExOpthBegitem = null,
		string ExOpthEnditem = null,
		string ExOpthBegrevISion = null,
		string ExOpthEndrevISion = null,
		int? ExOptBegECN_num = null,
		int? ExOptENDECN_num = null,
		string SortBy = null,
		byte? DisplayHeader = null,
		string pSite = null);
	}
	
	public class Rpt_ECNbyItem : IRpt_ECNbyItem
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ECNbyItem(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ECNbyItemSp(string ExOpthBegitem = null,
		string ExOpthEnditem = null,
		string ExOpthBegrevISion = null,
		string ExOpthEndrevISion = null,
		int? ExOptBegECN_num = null,
		int? ExOptENDECN_num = null,
		string SortBy = null,
		byte? DisplayHeader = null,
		string pSite = null)
		{
			ItemType _ExOpthBegitem = ExOpthBegitem;
			ItemType _ExOpthEnditem = ExOpthEnditem;
			RevisionType _ExOpthBegrevISion = ExOpthBegrevISion;
			RevisionType _ExOpthEndrevISion = ExOpthEndrevISion;
			EcnNumType _ExOptBegECN_num = ExOptBegECN_num;
			EcnNumType _ExOptENDECN_num = ExOptENDECN_num;
			StringType _SortBy = SortBy;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ECNbyItemSp";
				
				appDB.AddCommandParameter(cmd, "ExOpthBegitem", _ExOpthBegitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpthEnditem", _ExOpthEnditem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpthBegrevISion", _ExOpthBegrevISion, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpthEndrevISion", _ExOpthEndrevISion, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegECN_num", _ExOptBegECN_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDECN_num", _ExOptENDECN_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
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
