//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROMargin.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROMargin : ISSSFSRpt_SROMargin
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_SROMargin(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROMarginSP(string SRONumBeg = null,
		string SRONumEnd = null,
		string CustNumBeg = null,
		string CustNumEnd = null,
		string SerNumBeg = null,
		string SerNumEnd = null,
		string IncNumBeg = null,
		string IncNumEnd = null,
		DateTime? TransDateBeg = null,
		DateTime? TransDateEnd = null,
		string RegionBeg = null,
		string RegionEnd = null,
		int? MatDetail = 0,
		int? LabDetail = 0,
		int? MiscDetail = 0,
		int? SROPageBreak = 0,
		int? TransDateOffSetBeg = null,
		string SortBy = "S",
		int? DisplayHeader = 0,
		DateTime? PostDateBeg = null,
		DateTime? PostDateEnd = null,
		int? PostDateOffSetBeg = null,
		int? ExBillCodeC = 0,
		int? ExBillCodeN = 0,
		int? ExBillCodeR = 0,
		int? ExBillCodeL = 0,
		int? ExBillCodeW = 0,
		int? ExBillCodeU = 0,
		DateTime? CloseDateBeg = null,
		DateTime? CloseDateEnd = null,
		string pSite = null)
		{
			FSSRONumType _SRONumBeg = SRONumBeg;
			FSSRONumType _SRONumEnd = SRONumEnd;
			CustNumType _CustNumBeg = CustNumBeg;
			CustNumType _CustNumEnd = CustNumEnd;
			SerNumType _SerNumBeg = SerNumBeg;
			SerNumType _SerNumEnd = SerNumEnd;
			FSIncNumType _IncNumBeg = IncNumBeg;
			FSIncNumType _IncNumEnd = IncNumEnd;
			DateType _TransDateBeg = TransDateBeg;
			DateType _TransDateEnd = TransDateEnd;
			FSRegionType _RegionBeg = RegionBeg;
			FSRegionType _RegionEnd = RegionEnd;
			ListYesNoType _MatDetail = MatDetail;
			ListYesNoType _LabDetail = LabDetail;
			ListYesNoType _MiscDetail = MiscDetail;
			ListYesNoType _SROPageBreak = SROPageBreak;
			DateOffsetType _TransDateOffSetBeg = TransDateOffSetBeg;
			UnusedCharType _SortBy = SortBy;
			ListYesNoType _DisplayHeader = DisplayHeader;
			DateType _PostDateBeg = PostDateBeg;
			DateType _PostDateEnd = PostDateEnd;
			DateOffsetType _PostDateOffSetBeg = PostDateOffSetBeg;
			ListYesNoType _ExBillCodeC = ExBillCodeC;
			ListYesNoType _ExBillCodeN = ExBillCodeN;
			ListYesNoType _ExBillCodeR = ExBillCodeR;
			ListYesNoType _ExBillCodeL = ExBillCodeL;
			ListYesNoType _ExBillCodeW = ExBillCodeW;
			ListYesNoType _ExBillCodeU = ExBillCodeU;
			DateType _CloseDateBeg = CloseDateBeg;
			DateType _CloseDateEnd = CloseDateEnd;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_SROMarginSP";
				
				appDB.AddCommandParameter(cmd, "SRONumBeg", _SRONumBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONumEnd", _SRONumEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNumBeg", _CustNumBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNumEnd", _CustNumEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNumBeg", _SerNumBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNumEnd", _SerNumEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncNumBeg", _IncNumBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncNumEnd", _IncNumEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateBeg", _TransDateBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEnd", _TransDateEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RegionBeg", _RegionBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RegionEnd", _RegionEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatDetail", _MatDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LabDetail", _LabDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscDetail", _MiscDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROPageBreak", _SROPageBreak, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateOffSetBeg", _TransDateOffSetBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostDateBeg", _PostDateBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostDateEnd", _PostDateEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostDateOffSetBeg", _PostDateOffSetBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBillCodeC", _ExBillCodeC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBillCodeN", _ExBillCodeN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBillCodeR", _ExBillCodeR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBillCodeL", _ExBillCodeL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBillCodeW", _ExBillCodeW, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBillCodeU", _ExBillCodeU, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CloseDateBeg", _CloseDateBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CloseDateEnd", _CloseDateEnd, ParameterDirection.Input);
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
