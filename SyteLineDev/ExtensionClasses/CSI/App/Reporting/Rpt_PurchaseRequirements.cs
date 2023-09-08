//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PurchaseRequirements.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PurchaseRequirements : IRpt_PurchaseRequirements
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PurchaseRequirements(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PurchaseRequirementsSp(string WhseStarting = null,
		string WhseEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string PlanCodeStarting = null,
		string PlanCodeEnding = null,
		string MatlType = null,
		string Source = null,
		string Stocked = null,
		string ABCCode = null,
		int? ShowDepl = null,
		int? ShowRepl = null,
		int? TimePhaseDetail = null,
		string COStatus = null,
		string POStatus = null,
		string PSStatus = null,
		string JobStatus = null,
		int? DisplayHeader = null,
		string SROStatus = null,
		int? IncOrderMinMult = null,
		string pSite = null)
		{
			WhseType _WhseStarting = WhseStarting;
			WhseType _WhseEnding = WhseEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			ProductCodeType _ProductCodeStarting = ProductCodeStarting;
			ProductCodeType _ProductCodeEnding = ProductCodeEnding;
			UserCodeType _PlanCodeStarting = PlanCodeStarting;
			UserCodeType _PlanCodeEnding = PlanCodeEnding;
			InfobarType _MatlType = MatlType;
			InfobarType _Source = Source;
			StringType _Stocked = Stocked;
			InfobarType _ABCCode = ABCCode;
			FlagNyType _ShowDepl = ShowDepl;
			FlagNyType _ShowRepl = ShowRepl;
			FlagNyType _TimePhaseDetail = TimePhaseDetail;
			InfobarType _COStatus = COStatus;
			InfobarType _POStatus = POStatus;
			InfobarType _PSStatus = PSStatus;
			InfobarType _JobStatus = JobStatus;
			FlagNyType _DisplayHeader = DisplayHeader;
			InfobarType _SROStatus = SROStatus;
			FlagNyType _IncOrderMinMult = IncOrderMinMult;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PurchaseRequirementsSp";
				
				appDB.AddCommandParameter(cmd, "WhseStarting", _WhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseEnding", _WhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanCodeStarting", _PlanCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanCodeEnding", _PlanCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlType", _MatlType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stocked", _Stocked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABCCode", _ABCCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDepl", _ShowDepl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowRepl", _ShowRepl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TimePhaseDetail", _TimePhaseDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "COStatus", _COStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POStatus", _POStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSStatus", _PSStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobStatus", _JobStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROStatus", _SROStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncOrderMinMult", _IncOrderMinMult, ParameterDirection.Input);
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
