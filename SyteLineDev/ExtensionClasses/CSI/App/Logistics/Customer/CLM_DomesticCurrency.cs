//PROJECT NAME: Logistics
//CLASS NAME: CLM_DomesticCurrency.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CLM_DomesticCurrency : ICLM_DomesticCurrency
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_DomesticCurrency(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_DomesticCurrencySp(string CurrCode,
		int? UseBuyRate = 0,
		decimal? TRate = null,
		DateTime? PossibleDate = null,
		decimal? Amount1 = null,
		decimal? Amount2 = null,
		decimal? Amount3 = null,
		decimal? Amount4 = null,
		decimal? Amount5 = null,
		decimal? Amount6 = null,
		decimal? Amount7 = null,
		decimal? Amount8 = null,
		decimal? Amount9 = null,
		decimal? Amount10 = null,
		decimal? Amount11 = null,
		decimal? Amount12 = null,
		decimal? Amount13 = null,
		decimal? Amount14 = null,
		decimal? Amount15 = null,
		decimal? Amount16 = null,
		decimal? Amount17 = null,
		decimal? Amount18 = null,
		decimal? Amount19 = null,
		decimal? Amount20 = null,
		decimal? Amount21 = null,
		decimal? Amount22 = null,
		decimal? Amount23 = null,
		decimal? Amount24 = null,
		decimal? Amount25 = null,
		decimal? Amount26 = null,
		decimal? Amount27 = null,
		decimal? Amount28 = null,
		decimal? Amount29 = null,
		decimal? Amount30 = null,
		decimal? Amount31 = null,
		decimal? Amount32 = null,
		decimal? Amount33 = null,
		decimal? Amount34 = null,
		decimal? Amount35 = null,
		decimal? Amount36 = null,
		decimal? Amount37 = null,
		decimal? Amount38 = null,
		decimal? Amount39 = null,
		decimal? Amount40 = null)
		{
			CurrCodeType _CurrCode = CurrCode;
			Flag _UseBuyRate = UseBuyRate;
			ExchRateType _TRate = TRate;
			GenericDate _PossibleDate = PossibleDate;
			AmountType _Amount1 = Amount1;
			AmountType _Amount2 = Amount2;
			AmountType _Amount3 = Amount3;
			AmountType _Amount4 = Amount4;
			AmountType _Amount5 = Amount5;
			AmountType _Amount6 = Amount6;
			AmountType _Amount7 = Amount7;
			AmountType _Amount8 = Amount8;
			AmountType _Amount9 = Amount9;
			AmountType _Amount10 = Amount10;
			AmountType _Amount11 = Amount11;
			AmountType _Amount12 = Amount12;
			AmountType _Amount13 = Amount13;
			AmountType _Amount14 = Amount14;
			AmountType _Amount15 = Amount15;
			AmountType _Amount16 = Amount16;
			AmountType _Amount17 = Amount17;
			AmountType _Amount18 = Amount18;
			AmountType _Amount19 = Amount19;
			AmountType _Amount20 = Amount20;
			AmountType _Amount21 = Amount21;
			AmountType _Amount22 = Amount22;
			AmountType _Amount23 = Amount23;
			AmountType _Amount24 = Amount24;
			AmountType _Amount25 = Amount25;
			AmountType _Amount26 = Amount26;
			AmountType _Amount27 = Amount27;
			AmountType _Amount28 = Amount28;
			AmountType _Amount29 = Amount29;
			AmountType _Amount30 = Amount30;
			AmountType _Amount31 = Amount31;
			AmountType _Amount32 = Amount32;
			AmountType _Amount33 = Amount33;
			AmountType _Amount34 = Amount34;
			AmountType _Amount35 = Amount35;
			AmountType _Amount36 = Amount36;
			AmountType _Amount37 = Amount37;
			AmountType _Amount38 = Amount38;
			AmountType _Amount39 = Amount39;
			AmountType _Amount40 = Amount40;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_DomesticCurrencySp";
				
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseBuyRate", _UseBuyRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRate", _TRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PossibleDate", _PossibleDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount1", _Amount1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount2", _Amount2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount3", _Amount3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount4", _Amount4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount5", _Amount5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount6", _Amount6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount7", _Amount7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount8", _Amount8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount9", _Amount9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount10", _Amount10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount11", _Amount11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount12", _Amount12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount13", _Amount13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount14", _Amount14, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount15", _Amount15, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount16", _Amount16, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount17", _Amount17, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount18", _Amount18, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount19", _Amount19, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount20", _Amount20, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount21", _Amount21, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount22", _Amount22, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount23", _Amount23, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount24", _Amount24, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount25", _Amount25, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount26", _Amount26, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount27", _Amount27, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount28", _Amount28, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount29", _Amount29, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount30", _Amount30, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount31", _Amount31, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount32", _Amount32, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount33", _Amount33, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount34", _Amount34, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount35", _Amount35, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount36", _Amount36, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount37", _Amount37, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount38", _Amount38, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount39", _Amount39, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount40", _Amount40, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
