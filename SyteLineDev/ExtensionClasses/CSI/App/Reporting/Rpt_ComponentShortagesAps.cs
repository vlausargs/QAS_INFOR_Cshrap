//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ComponentShortagesAps.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ComponentShortagesAps
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ComponentShortagesApsSp(string PlannerCodeStarting,
		string PlannerCodeEnding,
		string ItemStarting,
		string ItemEnding,
		string DemandType,
		string DemandRef,
		DateTime? StartDate,
		DateTime? EndDate,
		byte? DisplayHeader,
		short? ALTNO,
		string pSite = null,
		string BGSessionId = null);
	}

	public class Rpt_ComponentShortagesAps : IRpt_ComponentShortagesAps
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

		public Rpt_ComponentShortagesAps(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ComponentShortagesApsSp(string PlannerCodeStarting,
		string PlannerCodeEnding,
		string ItemStarting,
		string ItemEnding,
		string DemandType,
		string DemandRef,
		DateTime? StartDate,
		DateTime? EndDate,
		byte? DisplayHeader,
		short? ALTNO,
		string pSite = null,
		string BGSessionId = null)
		{
			UserCodeType _PlannerCodeStarting = PlannerCodeStarting;
			UserCodeType _PlannerCodeEnding = PlannerCodeEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			RefType _DemandType = DemandType;
			OrderRefStrType _DemandRef = DemandRef;
			DateType _StartDate = StartDate;
			DateType _EndDate = EndDate;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ApsAltNoType _ALTNO = ALTNO;
			SiteType _pSite = pSite;
			StringType _BGSessionId = BGSessionId;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ComponentShortagesApsSp";

				appDB.AddCommandParameter(cmd, "PlannerCodeStarting", _PlannerCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlannerCodeEnding", _PlannerCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DemandType", _DemandType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DemandRef", _DemandRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ALTNO", _ALTNO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);

				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
