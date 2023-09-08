//PROJECT NAME: Reporting
//CLASS NAME: Rpt_IndentedCurrentBillofMaterial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_IndentedCurrentBillofMaterial
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_IndentedCurrentBillofMaterialSp(string StartingItem = null,
		string EndingItem = null,
		string StartingProCode = null,
		string EndingProCode = null,
		string StartingRevision = null,
		string EndingRevision = null,
		byte? IncludeRevision = (byte)0,
		string MaterialType = null,
		string Source = null,
		string Stocked = null,
		string ABCCode = null,
		DateTime? EffectiveDate = null,
		short? EffectiveDateOffset = null,
		string PageJob = null,
		byte? PrintLevelZero = null,
		byte? DisplayRefer = null,
		byte? DisplayHeader = null,
		byte? PrintAlternateMaterials = null,
		string pSite = null);
	}
	
	public class Rpt_IndentedCurrentBillofMaterial : IRpt_IndentedCurrentBillofMaterial
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_IndentedCurrentBillofMaterial(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_IndentedCurrentBillofMaterialSp(string StartingItem = null,
		string EndingItem = null,
		string StartingProCode = null,
		string EndingProCode = null,
		string StartingRevision = null,
		string EndingRevision = null,
		byte? IncludeRevision = (byte)0,
		string MaterialType = null,
		string Source = null,
		string Stocked = null,
		string ABCCode = null,
		DateTime? EffectiveDate = null,
		short? EffectiveDateOffset = null,
		string PageJob = null,
		byte? PrintLevelZero = null,
		byte? DisplayRefer = null,
		byte? DisplayHeader = null,
		byte? PrintAlternateMaterials = null,
		string pSite = null)
		{
			ItemType _StartingItem = StartingItem;
			ItemType _EndingItem = EndingItem;
			ProductCodeType _StartingProCode = StartingProCode;
			ProductCodeType _EndingProCode = EndingProCode;
			RevisionType _StartingRevision = StartingRevision;
			RevisionType _EndingRevision = EndingRevision;
			ListYesNoType _IncludeRevision = IncludeRevision;
			InfobarType _MaterialType = MaterialType;
			InfobarType _Source = Source;
			InfobarType _Stocked = Stocked;
			InfobarType _ABCCode = ABCCode;
			DateTimeType _EffectiveDate = EffectiveDate;
			DateOffsetType _EffectiveDateOffset = EffectiveDateOffset;
			InfobarType _PageJob = PageJob;
			FlagNyType _PrintLevelZero = PrintLevelZero;
			FlagNyType _DisplayRefer = DisplayRefer;
			FlagNyType _DisplayHeader = DisplayHeader;
			FlagNyType _PrintAlternateMaterials = PrintAlternateMaterials;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_IndentedCurrentBillofMaterialSp";
				
				appDB.AddCommandParameter(cmd, "StartingItem", _StartingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingItem", _EndingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingProCode", _StartingProCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingProCode", _EndingProCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingRevision", _StartingRevision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingRevision", _EndingRevision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeRevision", _IncludeRevision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaterialType", _MaterialType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stocked", _Stocked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABCCode", _ABCCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDate", _EffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDateOffset", _EffectiveDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageJob", _PageJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLevelZero", _PrintLevelZero, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayRefer", _DisplayRefer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintAlternateMaterials", _PrintAlternateMaterials, ParameterDirection.Input);
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
