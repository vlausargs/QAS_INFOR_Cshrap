//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedTeamLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSchedTeamLoad : ISSSFSSchedTeamLoad
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;
		
		public SSSFSSchedTeamLoad(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		
		public ICollectionLoadResponse SSSFSSchedTeamLoadFn(
			string PartnerId,
			DateTime? SchedDate,
			decimal? Hrs,
			int? CheckConflicts,
			Guid? RowPointer)
		{
			FSPartnerType _PartnerId = PartnerId;
			DateTimeType _SchedDate = SchedDate;
			HoursOffType _Hrs = Hrs;
			ListYesNoType _CheckConflicts = CheckConflicts;
			RowPointerType _RowPointer = RowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[SSSFSSchedTeamLoad](@PartnerId, @SchedDate, @Hrs, @CheckConflicts, @RowPointer)";
				
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SchedDate", _SchedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Hrs", _Hrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckConflicts", _CheckConflicts, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				
				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_SSSFSSchedTeamLoad";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);
				
				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
