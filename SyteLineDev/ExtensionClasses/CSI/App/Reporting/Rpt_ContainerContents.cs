//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ContainerContents.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ContainerContents : IRpt_ContainerContents
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ContainerContents(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ContainerContentsSp(string PWhseStarting = null,
		string PWhseEnding = null,
		string PLocationStarting = null,
		string PLocationEnding = null,
		string PContainerStarting = null,
		string PContainerEnding = null,
		string PItemStarting = null,
		string PItemEnding = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			WhseType _PWhseStarting = PWhseStarting;
			WhseType _PWhseEnding = PWhseEnding;
			LocType _PLocationStarting = PLocationStarting;
			LocType _PLocationEnding = PLocationEnding;
			ContainerNumType _PContainerStarting = PContainerStarting;
			ContainerNumType _PContainerEnding = PContainerEnding;
			ItemType _PItemStarting = PItemStarting;
			ItemType _PItemEnding = PItemEnding;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ContainerContentsSp";
				
				appDB.AddCommandParameter(cmd, "PWhseStarting", _PWhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhseEnding", _PWhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLocationStarting", _PLocationStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLocationEnding", _PLocationEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PContainerStarting", _PContainerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PContainerEnding", _PContainerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemStarting", _PItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemEnding", _PItemEnding, ParameterDirection.Input);
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
