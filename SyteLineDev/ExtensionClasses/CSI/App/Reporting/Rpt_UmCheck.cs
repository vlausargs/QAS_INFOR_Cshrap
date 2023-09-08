//PROJECT NAME: Reporting
//CLASS NAME: Rpt_UmCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_UmCheck : IRpt_UmCheck
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_UmCheck(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_UmCheckSp(string Selection,
		string OldUM,
		string NewUM,
		string Item,
		string ConvType,
		string CustVendType,
		decimal? ConvFactor,
		decimal? ConvDivisor,
		int? RptFlag,
		string pSite = null)
		{
			LongListType _Selection = Selection;
			UMType _OldUM = OldUM;
			UMType _NewUM = NewUM;
			ItemType _Item = Item;
			UMConvTypeType _ConvType = ConvType;
			VendNumType _CustVendType = CustVendType;
			UMConvFactorType _ConvFactor = ConvFactor;
			UMConvFactorType _ConvDivisor = ConvDivisor;
			ListYesNoType _RptFlag = RptFlag;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_UmCheckSp";
				
				appDB.AddCommandParameter(cmd, "Selection", _Selection, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldUM", _OldUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewUM", _NewUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvType", _ConvType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustVendType", _CustVendType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvFactor", _ConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvDivisor", _ConvDivisor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RptFlag", _RptFlag, ParameterDirection.Input);
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
