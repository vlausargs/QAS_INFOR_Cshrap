//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PackingSlip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PackingSlip : IRpt_PackingSlip
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PackingSlip(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PackingSlipSp(string PckCall = null,
		int? MinPackNum = null,
		int? MaxPackNum = null,
		int? PrintOrderText = null,
		int? PrintLineText = null,
		int? PrintDescription = null,
		int? PrintPlanningItemMaterials = null,
		int? IncludeSerialNumbers = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? PrintItemOverview = null,
		int? DisplayHeader = null,
		int? CoTypeRegular = null,
		int? CoTypeBlanket = null,
		string CoStat = null,
		string CoItemStat = null,
		string OrderStarting = null,
		string OrderEnding = null,
		int? OrderLineStarting = null,
		int? OrderReleaseStarting = null,
		int? OrderLineEnding = null,
		int? OrderReleaseEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? OrderDateStarting = null,
		DateTime? OrderDateEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		string pSite = null)
		{
			StringType _PckCall = PckCall;
			PackNumType _MinPackNum = MinPackNum;
			PackNumType _MaxPackNum = MaxPackNum;
			ListYesNoType _PrintOrderText = PrintOrderText;
			ListYesNoType _PrintLineText = PrintLineText;
			ListYesNoType _PrintDescription = PrintDescription;
			ListYesNoType _PrintPlanningItemMaterials = PrintPlanningItemMaterials;
			ListYesNoType _IncludeSerialNumbers = IncludeSerialNumbers;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			FlagNyType _PrintItemOverview = PrintItemOverview;
			FlagNyType _DisplayHeader = DisplayHeader;
			FlagNyType _CoTypeRegular = CoTypeRegular;
			FlagNyType _CoTypeBlanket = CoTypeBlanket;
			StringType _CoStat = CoStat;
			StringType _CoItemStat = CoItemStat;
			CoNumType _OrderStarting = OrderStarting;
			CoNumType _OrderEnding = OrderEnding;
			GenericIntType _OrderLineStarting = OrderLineStarting;
			GenericIntType _OrderReleaseStarting = OrderReleaseStarting;
			GenericIntType _OrderLineEnding = OrderLineEnding;
			GenericIntType _OrderReleaseEnding = OrderReleaseEnding;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			DateType _OrderDateStarting = OrderDateStarting;
			DateType _OrderDateEnding = OrderDateEnding;
			DateType _DueDateStarting = DueDateStarting;
			DateType _DueDateEnding = DueDateEnding;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PackingSlipSp";
				
				appDB.AddCommandParameter(cmd, "PckCall", _PckCall, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MinPackNum", _MinPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaxPackNum", _MaxPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrderText", _PrintOrderText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLineText", _PrintLineText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDescription", _PrintDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPlanningItemMaterials", _PrintPlanningItemMaterials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeSerialNumbers", _IncludeSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoTypeRegular", _CoTypeRegular, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoTypeBlanket", _CoTypeBlanket, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoStat", _CoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoItemStat", _CoItemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderStarting", _OrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderEnding", _OrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderLineStarting", _OrderLineStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderReleaseStarting", _OrderReleaseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderLineEnding", _OrderLineEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderReleaseEnding", _OrderReleaseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateStarting", _OrderDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateEnding", _OrderDateEnding, ParameterDirection.Input);
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
