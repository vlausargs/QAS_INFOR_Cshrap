//PROJECT NAME: Reporting
//CLASS NAME: Rpt_FixedAssetCurrentDepreciation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_FixedAssetCurrentDepreciation
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_FixedAssetCurrentDepreciationSp(string DepSchedule = null,
		byte? DisplayHeader = (byte)1,
		string pSite = null);
	}
	
	public class Rpt_FixedAssetCurrentDepreciation : IRpt_FixedAssetCurrentDepreciation
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_FixedAssetCurrentDepreciation(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_FixedAssetCurrentDepreciationSp(string DepSchedule = null,
		byte? DisplayHeader = (byte)1,
		string pSite = null)
		{
			DeprCodeType _DepSchedule = DepSchedule;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_FixedAssetCurrentDepreciationSp";
				
				appDB.AddCommandParameter(cmd, "DepSchedule", _DepSchedule, ParameterDirection.Input);
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
