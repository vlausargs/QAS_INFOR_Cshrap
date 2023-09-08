//PROJECT NAME: Reporting
//CLASS NAME: RPT_RSQC_GagePackingSlip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class RPT_RSQC_GagePackingSlip : IRPT_RSQC_GagePackingSlip
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public RPT_RSQC_GagePackingSlip(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) RPT_RSQC_GagePackingSlipSp(
			string BegGage = null,
			string EndGage = null,
			string BegStat = null,
			string EndStat = null,
			DateTime? BegCalDate = null,
			DateTime? EndCalDate = null,
			int? PrintInternal = null,
			int? PrintExternal = null,
			int? PrintCalNotes = null,
			int? DisplayHeader = null)
		{
			QCCharType _BegGage = BegGage;
			QCCharType _EndGage = EndGage;
			QCCodeType _BegStat = BegStat;
			QCCodeType _EndStat = EndStat;
			DateType _BegCalDate = BegCalDate;
			DateType _EndCalDate = EndCalDate;
			FlagNyType _PrintInternal = PrintInternal;
			FlagNyType _PrintExternal = PrintExternal;
			FlagNyType _PrintCalNotes = PrintCalNotes;
			ListYesNoType _DisplayHeader = DisplayHeader;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RPT_RSQC_GagePackingSlipSp";
				
				appDB.AddCommandParameter(cmd, "BegGage", _BegGage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndGage", _EndGage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegStat", _BegStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndStat", _EndStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegCalDate", _BegCalDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCalDate", _EndCalDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternal", _PrintInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternal", _PrintExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCalNotes", _PrintCalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
