//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ResourceGroupBottlenecksAps.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ResourceGroupBottlenecksAps : IRpt_ResourceGroupBottlenecksAps
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ResourceGroupBottlenecksAps(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ResourceGroupBottlenecksApsSp(string GroupStarting,
		string GroupEnding,
		DateTime? StartDate,
		DateTime? EndDate,
		int? ExcludeInfinite,
		int? ListDelays,
		int? DisplayHeader,
		int? ALTNO,
		string pSite = null)
		{
			ApsResgroupType _GroupStarting = GroupStarting;
			ApsResgroupType _GroupEnding = GroupEnding;
			DateType _StartDate = StartDate;
			DateType _EndDate = EndDate;
			ListYesNoType _ExcludeInfinite = ExcludeInfinite;
			ListYesNoType _ListDelays = ListDelays;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ApsAltNoType _ALTNO = ALTNO;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ResourceGroupBottlenecksApsSp";
				
				appDB.AddCommandParameter(cmd, "GroupStarting", _GroupStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GroupEnding", _GroupEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExcludeInfinite", _ExcludeInfinite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ListDelays", _ListDelays, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ALTNO", _ALTNO, ParameterDirection.Input);
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
