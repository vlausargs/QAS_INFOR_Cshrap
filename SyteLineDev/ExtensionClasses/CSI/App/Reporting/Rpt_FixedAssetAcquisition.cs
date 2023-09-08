//PROJECT NAME: Reporting
//CLASS NAME: Rpt_FixedAssetAcquisition.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_FixedAssetAcquisition
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_FixedAssetAcquisitionSp(DateTime? SAcqDate = null,
		DateTime? EAcqDate = null,
		string DeprCode = null,
		string FaType = null,
		string FaStat = null,
		string SFaNum = null,
		string EFaNum = null,
		string SFaClass = null,
		string EFaClass = null,
		string SLoc = null,
		string ELoc = null,
		string SVendNum = null,
		string EVendNum = null,
		short? SAcqDateOffset = null,
		short? EAcqDateOffset = null,
		byte? DisplayHeader = null,
		string pSite = null);
	}
	
	public class Rpt_FixedAssetAcquisition : IRpt_FixedAssetAcquisition
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_FixedAssetAcquisition(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_FixedAssetAcquisitionSp(DateTime? SAcqDate = null,
		DateTime? EAcqDate = null,
		string DeprCode = null,
		string FaType = null,
		string FaStat = null,
		string SFaNum = null,
		string EFaNum = null,
		string SFaClass = null,
		string EFaClass = null,
		string SLoc = null,
		string ELoc = null,
		string SVendNum = null,
		string EVendNum = null,
		short? SAcqDateOffset = null,
		short? EAcqDateOffset = null,
		byte? DisplayHeader = null,
		string pSite = null)
		{
			DateType _SAcqDate = SAcqDate;
			DateType _EAcqDate = EAcqDate;
			DeprCodeType _DeprCode = DeprCode;
			StringType _FaType = FaType;
			StringType _FaStat = FaStat;
			FaNumType _SFaNum = SFaNum;
			FaNumType _EFaNum = EFaNum;
			FaClassType _SFaClass = SFaClass;
			FaClassType _EFaClass = EFaClass;
			LocType _SLoc = SLoc;
			LocType _ELoc = ELoc;
			VendNumType _SVendNum = SVendNum;
			VendNumType _EVendNum = EVendNum;
			DateOffsetType _SAcqDateOffset = SAcqDateOffset;
			DateOffsetType _EAcqDateOffset = EAcqDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_FixedAssetAcquisitionSp";
				
				appDB.AddCommandParameter(cmd, "SAcqDate", _SAcqDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EAcqDate", _EAcqDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeprCode", _DeprCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FaType", _FaType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FaStat", _FaStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SFaNum", _SFaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EFaNum", _EFaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SFaClass", _SFaClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EFaClass", _EFaClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SLoc", _SLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ELoc", _ELoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SVendNum", _SVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EVendNum", _EVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SAcqDateOffset", _SAcqDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EAcqDateOffset", _EAcqDateOffset, ParameterDirection.Input);
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
