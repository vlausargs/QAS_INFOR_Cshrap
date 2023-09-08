//PROJECT NAME: CSIReport
//CLASS NAME: MO_Rpt_JobMaterialsPercentageValidation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IMO_Rpt_JobMaterialsPercentageValidation
	{
		(ICollectionLoadResponse Data, int? ReturnCode) MO_Rpt_JobMaterialsPercentageValidationSp(string PJobStarting = null,
		string PJobEnding = null,
		string PEstimateJobStarting = null,
		string PEstimateJobEnding = null,
		string PItemStarting = null,
		string PItemEnding = null,
		string PAlternateIDStarting = null,
		string PAlternateIDEnding = null,
		string PAlternateItemStarting = null,
		string PAlternateItemEnding = null,
		byte? PJobBOM = (byte)0,
		byte? PEstimateJobBOM = (byte)0,
		byte? PCurrentBOM = (byte)0,
		byte? PAlternateBOM = (byte)0,
		string pSite = null);
	}
	
	public class MO_Rpt_JobMaterialsPercentageValidation : IMO_Rpt_JobMaterialsPercentageValidation
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public MO_Rpt_JobMaterialsPercentageValidation(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) MO_Rpt_JobMaterialsPercentageValidationSp(string PJobStarting = null,
		string PJobEnding = null,
		string PEstimateJobStarting = null,
		string PEstimateJobEnding = null,
		string PItemStarting = null,
		string PItemEnding = null,
		string PAlternateIDStarting = null,
		string PAlternateIDEnding = null,
		string PAlternateItemStarting = null,
		string PAlternateItemEnding = null,
		byte? PJobBOM = (byte)0,
		byte? PEstimateJobBOM = (byte)0,
		byte? PCurrentBOM = (byte)0,
		byte? PAlternateBOM = (byte)0,
		string pSite = null)
		{
			JobType _PJobStarting = PJobStarting;
			JobType _PJobEnding = PJobEnding;
			JobType _PEstimateJobStarting = PEstimateJobStarting;
			JobType _PEstimateJobEnding = PEstimateJobEnding;
			ItemType _PItemStarting = PItemStarting;
			ItemType _PItemEnding = PItemEnding;
			MO_BOMAlternateType _PAlternateIDStarting = PAlternateIDStarting;
			MO_BOMAlternateType _PAlternateIDEnding = PAlternateIDEnding;
			ItemType _PAlternateItemStarting = PAlternateItemStarting;
			ItemType _PAlternateItemEnding = PAlternateItemEnding;
			ListYesNoType _PJobBOM = PJobBOM;
			ListYesNoType _PEstimateJobBOM = PEstimateJobBOM;
			ListYesNoType _PCurrentBOM = PCurrentBOM;
			ListYesNoType _PAlternateBOM = PAlternateBOM;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MO_Rpt_JobMaterialsPercentageValidationSp";
				
				appDB.AddCommandParameter(cmd, "PJobStarting", _PJobStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobEnding", _PJobEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEstimateJobStarting", _PEstimateJobStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEstimateJobEnding", _PEstimateJobEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemStarting", _PItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemEnding", _PItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAlternateIDStarting", _PAlternateIDStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAlternateIDEnding", _PAlternateIDEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAlternateItemStarting", _PAlternateItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAlternateItemEnding", _PAlternateItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobBOM", _PJobBOM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEstimateJobBOM", _PEstimateJobBOM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrentBOM", _PCurrentBOM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAlternateBOM", _PAlternateBOM, ParameterDirection.Input);
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
