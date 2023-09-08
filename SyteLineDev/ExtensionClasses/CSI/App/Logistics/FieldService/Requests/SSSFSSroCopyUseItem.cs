//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroCopyUseIt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSroCopyUseIt
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSSroCopyUseItem(string iTemplateSroNum,
		int? iTemplateSroLine,
		string iItem,
		byte? ChkShowAllOper,
		string iSerNum,
		string Infobar,
		string FilterString = null);
	}
	
	public class SSSFSSroCopyUseIt : ISSSFSSroCopyUseIt
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSSroCopyUseIt(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSSroCopyUseItem(string iTemplateSroNum,
		int? iTemplateSroLine,
		string iItem,
		byte? ChkShowAllOper,
		string iSerNum,
		string Infobar,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				FSSRONumType _iTemplateSroNum = iTemplateSroNum;
				FSSROLineType _iTemplateSroLine = iTemplateSroLine;
				ItemType _iItem = iItem;
				ListYesNoType _ChkShowAllOper = ChkShowAllOper;
				SerNumType _iSerNum = iSerNum;
				Infobar _Infobar = Infobar;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "SSSFSSroCopyUseItem";
					
					appDB.AddCommandParameter(cmd, "iTemplateSroNum", _iTemplateSroNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "iTemplateSroLine", _iTemplateSroLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "iItem", _iItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ChkShowAllOper", _ChkShowAllOper, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "iSerNum", _iSerNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
