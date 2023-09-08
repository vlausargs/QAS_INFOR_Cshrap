//PROJECT NAME: CSIMaterial
//CLASS NAME: CyclePost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface ICyclePost
	{
		(ICollectionLoadResponse Data, int? ReturnCode, int? Counter, string Infobar) CyclePostSp(string Stat,
		string Whse,
		int? Counter,
		string Infobar,
		DateTime? PostDate = null);
	}
	
	public class CyclePost : ICyclePost
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CyclePost(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, int? Counter, string Infobar) CyclePostSp(string Stat,
		string Whse,
		int? Counter,
		string Infobar,
		DateTime? PostDate = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				CycleStatusType _Stat = Stat;
				WhseType _Whse = Whse;
				IntType _Counter = Counter;
				InfobarType _Infobar = Infobar;
				DateType _PostDate = PostDate;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CyclePostSp";
					
					appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Counter", _Counter, ParameterDirection.InputOutput);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
					appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    Counter = _Counter;
					Infobar = _Infobar;
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Counter, Infobar);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
