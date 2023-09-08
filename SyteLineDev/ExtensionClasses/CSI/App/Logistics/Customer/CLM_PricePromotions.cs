//PROJECT NAME: Logistics
//CLASS NAME: CLM_PricePromotions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CLM_PricePromotions : ICLM_PricePromotions
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_PricePromotions(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_PricePromotionsSp(string PCoNum = null,
		string PWhse = null,
		string PItem = null,
		DateTime? PCoOrderDate = null,
		string PromotionCode = null,
		string Infobar = null,
		string CustNum = null,
		int? CustSeq = null,
		string Slsman = null,
		int? FIP = 0)
		{
			CoNumType _PCoNum = PCoNum;
			WhseType _PWhse = PWhse;
			ItemType _PItem = PItem;
			DateType _PCoOrderDate = PCoOrderDate;
			PromotionCodeType _PromotionCode = PromotionCode;
			InfobarType _Infobar = Infobar;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			SlsmanType _Slsman = Slsman;
			ListYesNoType _FIP = FIP;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_PricePromotionsSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoOrderDate", _PCoOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromotionCode", _PromotionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FIP", _FIP, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
			}
		}
	}
}
