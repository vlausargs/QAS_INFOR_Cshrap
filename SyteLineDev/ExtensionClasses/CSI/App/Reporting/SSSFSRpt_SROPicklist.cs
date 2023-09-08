//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROPicklist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROPicklist : ISSSFSRpt_SROPicklist
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_SROPicklist(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROPicklistSp(string ExOptBegSRO_Num = null,
		string ExOptEndSRO_Num = null,
		int? ExOptBegSRO_Line = null,
		int? ExOptEndSRO_Line = null,
		int? ExOptBegSRO_Oper = null,
		int? ExOptEndSRO_Oper = null,
		string ExOptBegSRO_Type = null,
		string ExOptEndSRO_Type = null,
		string ExOptacSROStat = null,
		string ExOptacLineStat = null,
		string ExOptacOperStat = null,
		string ExOptacWhse = null,
		string ExOptacTransWhse = null,
		int? ExOptacInclPosted = null,
		int? ExOptacBarcode = null,
		int? ExOptacShowAddr = null,
		int? ExOptacShowAllLoc = null,
		int? ExOptacShowSerials = null,
		int? ExOptacIncSroNotes = null,
		int? ExOptacIncLineNotes = null,
		int? ExOptacIncOperNotes = null,
		int? ExOptacIncCustNotes = null,
		int? ExOptacIntNotes = null,
		int? ExOptacExtNotes = null,
		int? DisplayHeader = null,
		string OrderBy = "I",
		string pSite = null)
		{
			FSSRONumType _ExOptBegSRO_Num = ExOptBegSRO_Num;
			FSSRONumType _ExOptEndSRO_Num = ExOptEndSRO_Num;
			FSSROLineType _ExOptBegSRO_Line = ExOptBegSRO_Line;
			FSSROLineType _ExOptEndSRO_Line = ExOptEndSRO_Line;
			FSSROOperType _ExOptBegSRO_Oper = ExOptBegSRO_Oper;
			FSSROOperType _ExOptEndSRO_Oper = ExOptEndSRO_Oper;
			FSSROTypeType _ExOptBegSRO_Type = ExOptBegSRO_Type;
			FSSROTypeType _ExOptEndSRO_Type = ExOptEndSRO_Type;
			InfobarType _ExOptacSROStat = ExOptacSROStat;
			InfobarType _ExOptacLineStat = ExOptacLineStat;
			InfobarType _ExOptacOperStat = ExOptacOperStat;
			WhseType _ExOptacWhse = ExOptacWhse;
			WhseType _ExOptacTransWhse = ExOptacTransWhse;
			ListYesNoType _ExOptacInclPosted = ExOptacInclPosted;
			ListYesNoType _ExOptacBarcode = ExOptacBarcode;
			ListYesNoType _ExOptacShowAddr = ExOptacShowAddr;
			ListYesNoType _ExOptacShowAllLoc = ExOptacShowAllLoc;
			ListYesNoType _ExOptacShowSerials = ExOptacShowSerials;
			ListYesNoType _ExOptacIncSroNotes = ExOptacIncSroNotes;
			ListYesNoType _ExOptacIncLineNotes = ExOptacIncLineNotes;
			ListYesNoType _ExOptacIncOperNotes = ExOptacIncOperNotes;
			ListYesNoType _ExOptacIncCustNotes = ExOptacIncCustNotes;
			ListYesNoType _ExOptacIntNotes = ExOptacIntNotes;
			ListYesNoType _ExOptacExtNotes = ExOptacExtNotes;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _OrderBy = OrderBy;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_SROPicklistSp";
				
				appDB.AddCommandParameter(cmd, "ExOptBegSRO_Num", _ExOptBegSRO_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndSRO_Num", _ExOptEndSRO_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegSRO_Line", _ExOptBegSRO_Line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndSRO_Line", _ExOptEndSRO_Line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegSRO_Oper", _ExOptBegSRO_Oper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndSRO_Oper", _ExOptEndSRO_Oper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegSRO_Type", _ExOptBegSRO_Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndSRO_Type", _ExOptEndSRO_Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacSROStat", _ExOptacSROStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacLineStat", _ExOptacLineStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacOperStat", _ExOptacOperStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacWhse", _ExOptacWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacTransWhse", _ExOptacTransWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacInclPosted", _ExOptacInclPosted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacBarcode", _ExOptacBarcode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacShowAddr", _ExOptacShowAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacShowAllLoc", _ExOptacShowAllLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacShowSerials", _ExOptacShowSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacIncSroNotes", _ExOptacIncSroNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacIncLineNotes", _ExOptacIncLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacIncOperNotes", _ExOptacIncOperNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacIncCustNotes", _ExOptacIncCustNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacIntNotes", _ExOptacIntNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacExtNotes", _ExOptacExtNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderBy", _OrderBy, ParameterDirection.Input);
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
