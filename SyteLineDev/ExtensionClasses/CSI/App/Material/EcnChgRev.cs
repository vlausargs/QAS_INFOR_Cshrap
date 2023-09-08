//PROJECT NAME: Material
//CLASS NAME: EcnChgRev.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class EcnChgRev : IEcnChgRev
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public EcnChgRev(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) EcnChgRevSp(string SelectedItem,
		string NewRev,
		string NewDrawing,
		int? RunMode,
		string Infobar,
		string CalledFrom = null,
		int? CopyUetValues = 0)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ItemType _SelectedItem = SelectedItem;
				RevisionType _NewRev = NewRev;
				DrawingNbrType _NewDrawing = NewDrawing;
				FlagNyType _RunMode = RunMode;
				InfobarType _Infobar = Infobar;
				StringType _CalledFrom = CalledFrom;
				ListYesNoType _CopyUetValues = CopyUetValues;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "EcnChgRevSp";
					
					appDB.AddCommandParameter(cmd, "SelectedItem", _SelectedItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "NewRev", _NewRev, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "NewDrawing", _NewDrawing, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RunMode", _RunMode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
					appDB.AddCommandParameter(cmd, "CalledFrom", _CalledFrom, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CopyUetValues", _CopyUetValues, ParameterDirection.Input);
					
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
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
