//PROJECT NAME: Reporting
//CLASS NAME: Rpt_FixedAssetDisposition.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_FixedAssetDisposition : IRpt_FixedAssetDisposition
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_FixedAssetDisposition(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_FixedAssetDispositionSp(DateTime? PStartingDisposalDate = null,
		DateTime? PEndingDisposalDate = null,
		string PAssetTypes = "R",
		string PStartingAssetNum = null,
		string PEndingAssetNum = null,
		string PStartingClassCode = null,
		string PEndingClassCode = null,
		string PStartingDepartment = null,
		string PEndingDepartment = null,
		string PStartingLocation = null,
		string PEndingLocation = null,
		int? PStartingDisposalDateOffset = null,
		int? PEndingDisposalDateOffset = null,
		int? PDisplayHeader = 1,
		string pSite = null)
		{
			DateType _PStartingDisposalDate = PStartingDisposalDate;
			DateType _PEndingDisposalDate = PEndingDisposalDate;
			Infobar _PAssetTypes = PAssetTypes;
			FaNumType _PStartingAssetNum = PStartingAssetNum;
			FaNumType _PEndingAssetNum = PEndingAssetNum;
			FaClassType _PStartingClassCode = PStartingClassCode;
			FaClassType _PEndingClassCode = PEndingClassCode;
			DeptType _PStartingDepartment = PStartingDepartment;
			DeptType _PEndingDepartment = PEndingDepartment;
			LocType _PStartingLocation = PStartingLocation;
			LocType _PEndingLocation = PEndingLocation;
			DateOffsetType _PStartingDisposalDateOffset = PStartingDisposalDateOffset;
			DateOffsetType _PEndingDisposalDateOffset = PEndingDisposalDateOffset;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_FixedAssetDispositionSp";
				
				appDB.AddCommandParameter(cmd, "PStartingDisposalDate", _PStartingDisposalDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingDisposalDate", _PEndingDisposalDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAssetTypes", _PAssetTypes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingAssetNum", _PStartingAssetNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingAssetNum", _PEndingAssetNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingClassCode", _PStartingClassCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingClassCode", _PEndingClassCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingDepartment", _PStartingDepartment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingDepartment", _PEndingDepartment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingLocation", _PStartingLocation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingLocation", _PEndingLocation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingDisposalDateOffset", _PStartingDisposalDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingDisposalDateOffset", _PEndingDisposalDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
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
