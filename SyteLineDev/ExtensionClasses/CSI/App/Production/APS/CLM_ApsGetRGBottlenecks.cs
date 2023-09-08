//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetRGBottlenecks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetRGBottlenecks
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetRGBottlenecksSp(string Group,
		string GroupType,
		byte? ExcludeInfinite,
		DateTime? StartDate,
		DateTime? EndDate,
		short? AltNo,
		string WildCardChar,
		string FilterString = null);
	}
	
	public class CLM_ApsGetRGBottlenecks : ICLM_ApsGetRGBottlenecks
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ApsGetRGBottlenecks(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetRGBottlenecksSp(string Group,
		string GroupType,
		byte? ExcludeInfinite,
		DateTime? StartDate,
		DateTime? EndDate,
		short? AltNo,
		string WildCardChar,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ApsResgroupType _Group = Group;
				ApsCodeType _GroupType = GroupType;
				ListYesNoType _ExcludeInfinite = ExcludeInfinite;
				DateType _StartDate = StartDate;
				DateType _EndDate = EndDate;
				ApsAltNoType _AltNo = AltNo;
				StringType _WildCardChar = WildCardChar;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_ApsGetRGBottlenecksSp";
					
					appDB.AddCommandParameter(cmd, "Group", _Group, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "GroupType", _GroupType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ExcludeInfinite", _ExcludeInfinite, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "WildCardChar", _WildCardChar, ParameterDirection.Input);
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
