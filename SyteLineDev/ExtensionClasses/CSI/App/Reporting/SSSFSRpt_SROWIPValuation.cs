//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROWIPValuation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROWIPValuation : ISSSFSRpt_SROWIPValuation
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_SROWIPValuation(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROWIPValuationSp(string BegProductCode = null,
		string EndProductCode = null,
		string BegItem = null,
		string EndItem = null,
		string BegSroNum = null,
		string EndSroNum = null,
		int? BegSroLine = null,
		int? EndSroLine = null,
		int? BegSroOper = null,
		int? EndSroOper = null,
		string BegOperCode = null,
		string EndOperCode = null,
		DateTime? BegOpenDate = null,
		DateTime? EndOpenDate = null,
		string BegSroType = null,
		string EndSroType = null,
		int? InclOpen = 1,
		int? InclInvoice = 1,
		int? InclDetail = 0,
		string pSite = null)
		{
			ProductCodeType _BegProductCode = BegProductCode;
			ProductCodeType _EndProductCode = EndProductCode;
			ItemType _BegItem = BegItem;
			ItemType _EndItem = EndItem;
			FSSRONumType _BegSroNum = BegSroNum;
			FSSRONumType _EndSroNum = EndSroNum;
			FSSROLineType _BegSroLine = BegSroLine;
			FSSROLineType _EndSroLine = EndSroLine;
			FSSROOperType _BegSroOper = BegSroOper;
			FSSROOperType _EndSroOper = EndSroOper;
			FSOperCodeType _BegOperCode = BegOperCode;
			FSOperCodeType _EndOperCode = EndOperCode;
			DateType _BegOpenDate = BegOpenDate;
			DateType _EndOpenDate = EndOpenDate;
			FSSROTypeType _BegSroType = BegSroType;
			FSSROTypeType _EndSroType = EndSroType;
			ListYesNoType _InclOpen = InclOpen;
			ListYesNoType _InclInvoice = InclInvoice;
			ListYesNoType _InclDetail = InclDetail;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_SROWIPValuationSp";
				
				appDB.AddCommandParameter(cmd, "BegProductCode", _BegProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndProductCode", _EndProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegItem", _BegItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegSroNum", _BegSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSroNum", _EndSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegSroLine", _BegSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSroLine", _EndSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegSroOper", _BegSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSroOper", _EndSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegOperCode", _BegOperCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOperCode", _EndOperCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegOpenDate", _BegOpenDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOpenDate", _EndOpenDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegSroType", _BegSroType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSroType", _EndSroType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclOpen", _InclOpen, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclInvoice", _InclInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclDetail", _InclDetail, ParameterDirection.Input);
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
