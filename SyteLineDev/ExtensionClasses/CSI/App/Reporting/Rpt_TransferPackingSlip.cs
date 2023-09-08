//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TransferPackingSlip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_TransferPackingSlip : IRpt_TransferPackingSlip
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_TransferPackingSlip(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_TransferPackingSlipSp(int? MinPackNum = null,
		int? MaxPackNum = null,
		int? PrINTOrderText = 0,
		int? PrINTLineText = 0,
		int? ShowINTernal = 0,
		int? ShowExternal = 0,
		int? DisplayHeader = 0,
		string TrnStat = "TC",
		string TrnitemStat = "TC",
		string OrderStarting = null,
		string OrderEnding = null,
		int? OrderLineStarting = null,
		int? OrderLineEnding = null,
		string SiteStarting = null,
		string SiteEnding = null,
		string FromWhseStarting = null,
		string FromWhseEnding = null,
		string ToWhseStarting = null,
		string ToWhseEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		string pSite = null)
		{
			PackNumType _MinPackNum = MinPackNum;
			PackNumType _MaxPackNum = MaxPackNum;
			ListYesNoType _PrINTOrderText = PrINTOrderText;
			ListYesNoType _PrINTLineText = PrINTLineText;
			FlagNyType _ShowINTernal = ShowINTernal;
			FlagNyType _ShowExternal = ShowExternal;
			FlagNyType _DisplayHeader = DisplayHeader;
			StringType _TrnStat = TrnStat;
			StringType _TrnitemStat = TrnitemStat;
			CoNumType _OrderStarting = OrderStarting;
			CoNumType _OrderEnding = OrderEnding;
			GenericIntType _OrderLineStarting = OrderLineStarting;
			GenericIntType _OrderLineEnding = OrderLineEnding;
			SiteType _SiteStarting = SiteStarting;
			SiteType _SiteEnding = SiteEnding;
			WhseType _FromWhseStarting = FromWhseStarting;
			WhseType _FromWhseEnding = FromWhseEnding;
			WhseType _ToWhseStarting = ToWhseStarting;
			WhseType _ToWhseEnding = ToWhseEnding;
			DateType _DueDateStarting = DueDateStarting;
			DateType _DueDateEnding = DueDateEnding;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_TransferPackingSlipSp";
				
				appDB.AddCommandParameter(cmd, "MinPackNum", _MinPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaxPackNum", _MaxPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrINTOrderText", _PrINTOrderText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrINTLineText", _PrINTLineText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowINTernal", _ShowINTernal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnStat", _TrnStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemStat", _TrnitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderStarting", _OrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderEnding", _OrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderLineStarting", _OrderLineStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderLineEnding", _OrderLineEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteStarting", _SiteStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteEnding", _SiteEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhseStarting", _FromWhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhseEnding", _FromWhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhseStarting", _ToWhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhseEnding", _ToWhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateStarting", _DueDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateEnding", _DueDateEnding, ParameterDirection.Input);
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
