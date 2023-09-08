//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_PackageLabels.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICLM_PackageLabels
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PackageLabelsSp(decimal? ShipmentID,
		string UbLabelBy,
		string UbSite,
		string FilterString = null);
	}
	
	public class CLM_PackageLabels : ICLM_PackageLabels
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_PackageLabels(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_PackageLabelsSp(decimal? ShipmentID,
		string UbLabelBy,
		string UbSite,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ShipmentIDType _ShipmentID = ShipmentID;
				StringType _UbLabelBy = UbLabelBy;
				SiteType _UbSite = UbSite;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_PackageLabelsSp";
					
					appDB.AddCommandParameter(cmd, "ShipmentID", _ShipmentID, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "UbLabelBy", _UbLabelBy, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "UbSite", _UbSite, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
