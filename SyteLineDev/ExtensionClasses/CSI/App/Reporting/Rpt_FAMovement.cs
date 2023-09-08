//PROJECT NAME: Reporting
//CLASS NAME: Rpt_FAMovement.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_FAMovement : IRpt_FAMovement
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_FAMovement(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_FAMovementSp(DateTime? TransDateStarting = null,
		DateTime? TransDateEnding = null,
		string ClassCodeStarting = null,
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
		int? STransDateOffset = null,
		int? ETransDateOffset = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			DateType _TransDateStarting = TransDateStarting;
			DateType _TransDateEnding = TransDateEnding;
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
			DateOffsetType _STransDateOffset = STransDateOffset;
			DateOffsetType _ETransDateOffset = ETransDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_FAMovementSp";
				
				appDB.AddCommandParameter(cmd, "TransDateStarting", _TransDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEnding", _TransDateEnding, ParameterDirection.Input);
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
				appDB.AddCommandParameter(cmd, "STransDateOffset", _STransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ETransDateOffset", _ETransDateOffset, ParameterDirection.Input);
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
