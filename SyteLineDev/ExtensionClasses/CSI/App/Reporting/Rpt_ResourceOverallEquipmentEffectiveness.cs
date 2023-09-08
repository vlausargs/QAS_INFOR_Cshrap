//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ResourceOverallEquipmentEffectiveness.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ResourceOverallEquipmentEffectiveness : IRpt_ResourceOverallEquipmentEffectiveness
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ResourceOverallEquipmentEffectiveness(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ResourceOverallEquipmentEffectivenessSp(string RgrpType = null,
		string StartResourceGroup = null,
		string EndResourceGroup = null,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		int? StartDateOffset = null,
		int? EndDateOffset = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			ApsCodeType _RgrpType = RgrpType;
			ApsResgroupType _StartResourceGroup = StartResourceGroup;
			ApsResgroupType _EndResourceGroup = EndResourceGroup;
			DateTimeType _StartDate = StartDate;
			DateTimeType _EndDate = EndDate;
			DateOffsetType _StartDateOffset = StartDateOffset;
			DateOffsetType _EndDateOffset = EndDateOffset;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ResourceOverallEquipmentEffectivenessSp";
				
				appDB.AddCommandParameter(cmd, "RgrpType", _RgrpType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartResourceGroup", _StartResourceGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndResourceGroup", _EndResourceGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDateOffset", _StartDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDateOffset", _EndDateOffset, ParameterDirection.Input);
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
