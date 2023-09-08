//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsInventoryLevel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface ICLM_ApsInventoryLevel
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_ApsInventoryLevelSp(string PItem,
		DateTime? PStartDate,
		DateTime? PEndDate,
		byte? PExcludePLNs = (byte)0,
		string FilterString = null,
        string Infobar = null);
	}
	
	public class CLM_ApsInventoryLevel : ICLM_ApsInventoryLevel
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ApsInventoryLevel(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_ApsInventoryLevelSp(string PItem,
		DateTime? PStartDate,
		DateTime? PEndDate,
		byte? PExcludePLNs = (byte)0,
		string FilterString = null,
        string Infobar = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ItemType _PItem = PItem;
				DateType _PStartDate = PStartDate;
				DateType _PEndDate = PEndDate;
				ListYesNoType _PExcludePLNs = PExcludePLNs;
				LongListType _FilterString = FilterString;
                InfobarType _Infobar = Infobar;

                using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_ApsInventoryLevelSp";
					
					appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartDate", _PStartDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndDate", _PEndDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PExcludePLNs", _PExcludePLNs, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                    IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    Infobar = _Infobar;

                    return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
				}
			}
			finally
			{
                if (bunchedLoadCollection != null)
                    bunchedLoadCollection.EndBunching();
			}
		}
	}
}
