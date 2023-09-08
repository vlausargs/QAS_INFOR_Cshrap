//PROJECT NAME: Admin
//CLASS NAME: ProspectInteractionCalendar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class ProspectInteractionCalendar : IProspectInteractionCalendar
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProspectInteractionCalendar(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ProspectInteractionCalendarSp(DateTime? StartDate,
		DateTime? EndDate,
		string ProspectID,
		string Slsman,
		string SiteRef)
		{
			DateTimeType _StartDate = StartDate;
			DateTimeType _EndDate = EndDate;
			ProspectIDType _ProspectID = ProspectID;
			SlsmanType _Slsman = Slsman;
			SiteType _SiteRef = SiteRef;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProspectInteractionCalendarSp";
				
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProspectID", _ProspectID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
