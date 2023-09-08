//PROJECT NAME: Reporting
//CLASS NAME: EXTSSSFSRpt_InvoiceRegisterByAccount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Reporting
{
	public class EXTSSSFSRpt_InvoiceRegisterByAccount : IEXTSSSFSRpt_InvoiceRegisterByAccount
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;
		
		public EXTSSSFSRpt_InvoiceRegisterByAccount(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		
		public ICollectionLoadResponse EXTSSSFSRpt_InvoiceRegisterByAccountFn(
			string AccountStarting,
			string AccountEnding,
			string InvNumStarting,
			string InvNumEnding,
			DateTime? InvoiceDateStarting,
			DateTime? InvoiceDateEnding,
			string SSSFSSROStarting,
			string SSSFSSROEnding,
			string SSSFSContractStarting,
			string SSSFSContractEnding,
			string CustomerStarting,
			string CustomerEnding,
			string StateStarting,
			string StateEnding,
			string ItemStarting,
			string ItemEnding,
			int? TranslateToDomestic,
			int? ShowPrice,
			string TInvSourceSel)
		{
			HighLowCharType _AccountStarting = AccountStarting;
			HighLowCharType _AccountEnding = AccountEnding;
			InvNumType _InvNumStarting = InvNumStarting;
			InvNumType _InvNumEnding = InvNumEnding;
			GenericDateType _InvoiceDateStarting = InvoiceDateStarting;
			GenericDateType _InvoiceDateEnding = InvoiceDateEnding;
			HighLowCharType _SSSFSSROStarting = SSSFSSROStarting;
			HighLowCharType _SSSFSSROEnding = SSSFSSROEnding;
			HighLowCharType _SSSFSContractStarting = SSSFSContractStarting;
			HighLowCharType _SSSFSContractEnding = SSSFSContractEnding;
			HighLowCharType _CustomerStarting = CustomerStarting;
			HighLowCharType _CustomerEnding = CustomerEnding;
			HighLowCharType _StateStarting = StateStarting;
			HighLowCharType _StateEnding = StateEnding;
			HighLowCharType _ItemStarting = ItemStarting;
			HighLowCharType _ItemEnding = ItemEnding;
			FlagNyType _TranslateToDomestic = TranslateToDomestic;
			FlagNyType _ShowPrice = ShowPrice;
			LongListType _TInvSourceSel = TInvSourceSel;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[EXTSSSFSRpt_InvoiceRegisterByAccount](@AccountStarting, @AccountEnding, @InvNumStarting, @InvNumEnding, @InvoiceDateStarting, @InvoiceDateEnding, @SSSFSSROStarting, @SSSFSSROEnding, @SSSFSContractStarting, @SSSFSContractEnding, @CustomerStarting, @CustomerEnding, @StateStarting, @StateEnding, @ItemStarting, @ItemEnding, @TranslateToDomestic, @ShowPrice, @TInvSourceSel)";
				
				appDB.AddCommandParameter(cmd, "AccountStarting", _AccountStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountEnding", _AccountEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNumStarting", _InvNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNumEnding", _InvNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateStarting", _InvoiceDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateEnding", _InvoiceDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SSSFSSROStarting", _SSSFSSROStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SSSFSSROEnding", _SSSFSSROEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SSSFSContractStarting", _SSSFSContractStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SSSFSContractEnding", _SSSFSContractEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StateStarting", _StateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StateEnding", _StateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranslateToDomestic", _TranslateToDomestic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowPrice", _ShowPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TInvSourceSel", _TInvSourceSel, ParameterDirection.Input);
				
				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_EXTSSSFSRpt_InvoiceRegisterByAccount";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);
				
				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
