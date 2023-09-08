//PROJECT NAME: Reporting
//CLASS NAME: Rpt_FixedAssetClassification.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_FixedAssetClassification
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_FixedAssetClassificationSp(string ClassCodeStarting = null,
		string ClassCodeEnding = null,
		string ExOptdfFaType = null,
		string ExOptdfFaStat = null,
		string AssetStarting = null,
		string AssetEnding = null,
		string VendorStarting = null,
		string VendorEnding = null,
		string LocationStarting = null,
		string LocationEnding = null,
		string DepartmentStarting = null,
		string DepartmentEnding = null,
		string SortBy = null,
		byte? DisplayHeader = null,
		string DeprCode2 = null,
		string DeprCode3 = null,
		string DeprCode4 = null,
		string pSite = null);
	}
	
	public class Rpt_FixedAssetClassification : IRpt_FixedAssetClassification
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_FixedAssetClassification(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_FixedAssetClassificationSp(string ClassCodeStarting = null,
		string ClassCodeEnding = null,
		string ExOptdfFaType = null,
		string ExOptdfFaStat = null,
		string AssetStarting = null,
		string AssetEnding = null,
		string VendorStarting = null,
		string VendorEnding = null,
		string LocationStarting = null,
		string LocationEnding = null,
		string DepartmentStarting = null,
		string DepartmentEnding = null,
		string SortBy = null,
		byte? DisplayHeader = null,
		string DeprCode2 = null,
		string DeprCode3 = null,
		string DeprCode4 = null,
		string pSite = null)
		{
			FaClassType _ClassCodeStarting = ClassCodeStarting;
			FaClassType _ClassCodeEnding = ClassCodeEnding;
			Infobar _ExOptdfFaType = ExOptdfFaType;
			Infobar _ExOptdfFaStat = ExOptdfFaStat;
			FaNumType _AssetStarting = AssetStarting;
			FaNumType _AssetEnding = AssetEnding;
			VendNumType _VendorStarting = VendorStarting;
			VendNumType _VendorEnding = VendorEnding;
			LocType _LocationStarting = LocationStarting;
			LocType _LocationEnding = LocationEnding;
			DeptType _DepartmentStarting = DepartmentStarting;
			DeptType _DepartmentEnding = DepartmentEnding;
			StringType _SortBy = SortBy;
			ListYesNoType _DisplayHeader = DisplayHeader;
			DeprCodeType _DeprCode2 = DeprCode2;
			DeprCodeType _DeprCode3 = DeprCode3;
			DeprCodeType _DeprCode4 = DeprCode4;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_FixedAssetClassificationSp";
				
				appDB.AddCommandParameter(cmd, "ClassCodeStarting", _ClassCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ClassCodeEnding", _ClassCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfFaType", _ExOptdfFaType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfFaStat", _ExOptdfFaStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AssetStarting", _AssetStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AssetEnding", _AssetEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorStarting", _VendorStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorEnding", _VendorEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocationStarting", _LocationStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocationEnding", _LocationEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepartmentStarting", _DepartmentStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepartmentEnding", _DepartmentEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeprCode2", _DeprCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeprCode3", _DeprCode3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeprCode4", _DeprCode4, ParameterDirection.Input);
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
