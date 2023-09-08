//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ChangeOrderDetail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ChangeOrderDetail
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ChangeOrderDetailSp(string pChgStat = null,
		string pPrChgTxtDet = null,
		string pStartPoNum = null,
		string pendPoNum = null,
		int? pStartChgNum = null,
		int? pendChgNum = null,
		string pStartVendor = null,
		string pendVendor = null,
		DateTime? pStartChgDate = null,
		DateTime? pendChgDate = null,
		short? pStartChgDateOffset = null,
		short? pendChgDateOffset = null,
		byte? Showinternal = (byte)1,
		byte? ShowExternal = (byte)1,
		byte? PrintCost = (byte)0,
		byte? DisplayHeader = null,
		string PMessageLanguage = null,
		string pSite = null,
		string BGUser = null);
	}
	
	public class Rpt_ChangeOrderDetail : IRpt_ChangeOrderDetail
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ChangeOrderDetail(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ChangeOrderDetailSp(string pChgStat = null,
		string pPrChgTxtDet = null,
		string pStartPoNum = null,
		string pendPoNum = null,
		int? pStartChgNum = null,
		int? pendChgNum = null,
		string pStartVendor = null,
		string pendVendor = null,
		DateTime? pStartChgDate = null,
		DateTime? pendChgDate = null,
		short? pStartChgDateOffset = null,
		short? pendChgDateOffset = null,
		byte? Showinternal = (byte)1,
		byte? ShowExternal = (byte)1,
		byte? PrintCost = (byte)0,
		byte? DisplayHeader = null,
		string PMessageLanguage = null,
		string pSite = null,
		string BGUser = null)
		{
			StringType _pChgStat = pChgStat;
			StringType _pPrChgTxtDet = pPrChgTxtDet;
			HighLowCharType _pStartPoNum = pStartPoNum;
			HighLowCharType _pendPoNum = pendPoNum;
			GenericIntType _pStartChgNum = pStartChgNum;
			GenericIntType _pendChgNum = pendChgNum;
			HighLowCharType _pStartVendor = pStartVendor;
			HighLowCharType _pendVendor = pendVendor;
			GenericDateType _pStartChgDate = pStartChgDate;
			GenericDateType _pendChgDate = pendChgDate;
			DateOffsetType _pStartChgDateOffset = pStartChgDateOffset;
			DateOffsetType _pendChgDateOffset = pendChgDateOffset;
			FlagNyType _Showinternal = Showinternal;
			FlagNyType _ShowExternal = ShowExternal;
			ListYesNoType _PrintCost = PrintCost;
			ListYesNoType _DisplayHeader = DisplayHeader;
			MessageLanguageType _PMessageLanguage = PMessageLanguage;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ChangeOrderDetailSp";
				
				appDB.AddCommandParameter(cmd, "pChgStat", _pChgStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrChgTxtDet", _pPrChgTxtDet, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartPoNum", _pStartPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pendPoNum", _pendPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartChgNum", _pStartChgNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pendChgNum", _pendChgNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartVendor", _pStartVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pendVendor", _pendVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartChgDate", _pStartChgDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pendChgDate", _pendChgDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartChgDateOffset", _pStartChgDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pendChgDateOffset", _pendChgDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Showinternal", _Showinternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMessageLanguage", _PMessageLanguage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
