//PROJECT NAME: Reporting
//CLASS NAME: RPT_RSQC_QcGageCalibration.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class RPT_RSQC_QcGageCalibration : IRPT_RSQC_QcGageCalibration
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public RPT_RSQC_QcGageCalibration(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) RPT_RSQC_QcGageCalibrationSp(
			string pSortBy = null,
			string pStartGage = null,
			string pEndGage = null,
			DateTime? pStartLastCalDate = null,
			DateTime? pEndLastCalDate = null,
			DateTime? pStartNextCalDate = null,
			DateTime? pEndNextCalDate = null,
			string pStartLocation = null,
			string pEndLocation = null,
			string pStartGageType = null,
			string pEndGageType = null,
			int? DisplayHeader = null)
		{
			StringType _pSortBy = pSortBy;
			StringType _pStartGage = pStartGage;
			StringType _pEndGage = pEndGage;
			GenericDateType _pStartLastCalDate = pStartLastCalDate;
			GenericDateType _pEndLastCalDate = pEndLastCalDate;
			GenericDateType _pStartNextCalDate = pStartNextCalDate;
			GenericDateType _pEndNextCalDate = pEndNextCalDate;
			StringType _pStartLocation = pStartLocation;
			StringType _pEndLocation = pEndLocation;
			StringType _pStartGageType = pStartGageType;
			StringType _pEndGageType = pEndGageType;
			FlagNyType _DisplayHeader = DisplayHeader;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RPT_RSQC_QcGageCalibrationSp";
				
				appDB.AddCommandParameter(cmd, "pSortBy", _pSortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartGage", _pStartGage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndGage", _pEndGage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartLastCalDate", _pStartLastCalDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndLastCalDate", _pEndLastCalDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartNextCalDate", _pStartNextCalDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndNextCalDate", _pEndNextCalDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartLocation", _pStartLocation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndLocation", _pEndLocation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartGageType", _pStartGageType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndGageType", _pEndGageType, ParameterDirection.Input);
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
