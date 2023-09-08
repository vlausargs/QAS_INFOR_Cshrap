//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SroEstimate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_SroEstimate : ISSSFSRpt_SroEstimate
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_SroEstimate(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SroEstimateSp(string ExOptBegSRO_Num = null,
		string ExOptEndSRO_Num = null,
		int? ExOptBegSRO_Line = null,
		int? ExOptEndSRO_Line = null,
		int? ExOptBegSRO_Oper = null,
		int? ExOptEndSRO_Oper = null,
		string ExOptBegCust_Num = null,
		string ExOptEndCust_Num = null,
		DateTime? ExOptacEstDate = null,
		DateTime? ExOptacValidThru = null,
		int? ExOptFreightMisc = null,
		int? ExOptacCalcTax = null,
		int? ExOptacIncSroNotes = null,
		int? ExOptacIncLineNotes = null,
		int? ExOptacIncOperNotes = null,
		int? ExOptacIncCustNotes = null,
		int? ExOptacIntNotes = null,
		int? ExOptacExtNotes = null,
		int? ExOptacDisplayHeader = null,
		int? ExOptacIncTransNotes = null,
		string pSite = null)
		{
			FSSRONumType _ExOptBegSRO_Num = ExOptBegSRO_Num;
			FSSRONumType _ExOptEndSRO_Num = ExOptEndSRO_Num;
			FSSROLineType _ExOptBegSRO_Line = ExOptBegSRO_Line;
			FSSROLineType _ExOptEndSRO_Line = ExOptEndSRO_Line;
			FSSROOperType _ExOptBegSRO_Oper = ExOptBegSRO_Oper;
			FSSROOperType _ExOptEndSRO_Oper = ExOptEndSRO_Oper;
			CustNumType _ExOptBegCust_Num = ExOptBegCust_Num;
			CustNumType _ExOptEndCust_Num = ExOptEndCust_Num;
			DateType _ExOptacEstDate = ExOptacEstDate;
			DateType _ExOptacValidThru = ExOptacValidThru;
			ListYesNoType _ExOptFreightMisc = ExOptFreightMisc;
			ListYesNoType _ExOptacCalcTax = ExOptacCalcTax;
			ListYesNoType _ExOptacIncSroNotes = ExOptacIncSroNotes;
			ListYesNoType _ExOptacIncLineNotes = ExOptacIncLineNotes;
			ListYesNoType _ExOptacIncOperNotes = ExOptacIncOperNotes;
			ListYesNoType _ExOptacIncCustNotes = ExOptacIncCustNotes;
			ListYesNoType _ExOptacIntNotes = ExOptacIntNotes;
			ListYesNoType _ExOptacExtNotes = ExOptacExtNotes;
			ListYesNoType _ExOptacDisplayHeader = ExOptacDisplayHeader;
			ListYesNoType _ExOptacIncTransNotes = ExOptacIncTransNotes;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_SroEstimateSp";
				
				appDB.AddCommandParameter(cmd, "ExOptBegSRO_Num", _ExOptBegSRO_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndSRO_Num", _ExOptEndSRO_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegSRO_Line", _ExOptBegSRO_Line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndSRO_Line", _ExOptEndSRO_Line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegSRO_Oper", _ExOptBegSRO_Oper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndSRO_Oper", _ExOptEndSRO_Oper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegCust_Num", _ExOptBegCust_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndCust_Num", _ExOptEndCust_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacEstDate", _ExOptacEstDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacValidThru", _ExOptacValidThru, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptFreightMisc", _ExOptFreightMisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacCalcTax", _ExOptacCalcTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacIncSroNotes", _ExOptacIncSroNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacIncLineNotes", _ExOptacIncLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacIncOperNotes", _ExOptacIncOperNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacIncCustNotes", _ExOptacIncCustNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacIntNotes", _ExOptacIntNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacExtNotes", _ExOptacExtNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacDisplayHeader", _ExOptacDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacIncTransNotes", _ExOptacIncTransNotes, ParameterDirection.Input);
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
