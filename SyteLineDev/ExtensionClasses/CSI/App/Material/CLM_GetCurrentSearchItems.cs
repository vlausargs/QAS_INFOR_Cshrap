//PROJECT NAME: CSIMaterial
//CLASS NAME: CLM_GetCurrentSearchItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface ICLM_GetCurrentSearchItems
	{
		DataTable CLM_GetCurrentSearchItemsSp(byte? MatchingItemsOnly,
		                                      Guid? RowPointer,
		                                      int? RecordCap,
		                                      string FilterString);
	}
	
	public class CLM_GetCurrentSearchItems : ICLM_GetCurrentSearchItems
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public CLM_GetCurrentSearchItems(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable CLM_GetCurrentSearchItemsSp(byte? MatchingItemsOnly,
		                                             Guid? RowPointer,
		                                             int? RecordCap,
		                                             string FilterString)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ListYesNoType _MatchingItemsOnly = MatchingItemsOnly;
				RowPointerType _RowPointer = RowPointer;
				IntType _RecordCap = RecordCap;
				StringType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_GetCurrentSearchItemsSp";
					
					appDB.AddCommandParameter(cmd, "MatchingItemsOnly", _MatchingItemsOnly, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RecordCap", _RecordCap, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return dtReturn;
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
