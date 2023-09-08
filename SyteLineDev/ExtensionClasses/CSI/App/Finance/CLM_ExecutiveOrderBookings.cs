//PROJECT NAME: CSIFinance
//CLASS NAME: CLM_ExecutiveOrderBookings.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface ICLM_ExecutiveOrderBookings
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ExecutiveOrderBookingsSp(string View,
		byte? Detail,
		string SiteGroup,
		DateTime? DateStarting,
		DateTime? DateEnding,
		string FilterString = null);
	}
	
	public class CLM_ExecutiveOrderBookings : ICLM_ExecutiveOrderBookings
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ExecutiveOrderBookings(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ExecutiveOrderBookingsSp(string View,
		byte? Detail,
		string SiteGroup,
		DateTime? DateStarting,
		DateTime? DateEnding,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				StringType _View = View;
				ListYesNoType _Detail = Detail;
				SiteGroupType _SiteGroup = SiteGroup;
				DateType _DateStarting = DateStarting;
				DateType _DateEnding = DateEnding;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_ExecutiveOrderBookingsSp";
					
					appDB.AddCommandParameter(cmd, "View", _View, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Detail", _Detail, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "DateStarting", _DateStarting, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "DateEnding", _DateEnding, ParameterDirection.Input);
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
