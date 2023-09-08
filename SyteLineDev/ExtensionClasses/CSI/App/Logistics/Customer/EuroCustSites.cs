//PROJECT NAME: Logistics
//CLASS NAME: EuroCustSites.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EuroCustSites : IEuroCustSites
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public EuroCustSites(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string rInfobar) EuroCustSitesSp(string pBeginCustNum1,
		string pEndCustNum1,
		string pBeginCustNum2 = null,
		string pEndCustNum2 = null,
		string pBeginCustNum3 = null,
		string pEndCustNum3 = null,
		string pBeginCustNum4 = null,
		string pEndCustNum4 = null,
		string pBeginCustNum5 = null,
		string pEndCustNum5 = null,
		string pBeginCustNum6 = null,
		string pEndCustNum6 = null,
		string pBeginCustNum7 = null,
		string pEndCustNum7 = null,
		string pBeginCustNum8 = null,
		string pEndCustNum8 = null,
		string pBeginCustNum9 = null,
		string pEndCustNum9 = null,
		string pBeginCustNum10 = null,
		string pEndCustNum10 = null,
		string pFromCurrencyCode = null,
		string rInfobar = null)
		{
			CustNumType _pBeginCustNum1 = pBeginCustNum1;
			CustNumType _pEndCustNum1 = pEndCustNum1;
			CustNumType _pBeginCustNum2 = pBeginCustNum2;
			CustNumType _pEndCustNum2 = pEndCustNum2;
			CustNumType _pBeginCustNum3 = pBeginCustNum3;
			CustNumType _pEndCustNum3 = pEndCustNum3;
			CustNumType _pBeginCustNum4 = pBeginCustNum4;
			CustNumType _pEndCustNum4 = pEndCustNum4;
			CustNumType _pBeginCustNum5 = pBeginCustNum5;
			CustNumType _pEndCustNum5 = pEndCustNum5;
			CustNumType _pBeginCustNum6 = pBeginCustNum6;
			CustNumType _pEndCustNum6 = pEndCustNum6;
			CustNumType _pBeginCustNum7 = pBeginCustNum7;
			CustNumType _pEndCustNum7 = pEndCustNum7;
			CustNumType _pBeginCustNum8 = pBeginCustNum8;
			CustNumType _pEndCustNum8 = pEndCustNum8;
			CustNumType _pBeginCustNum9 = pBeginCustNum9;
			CustNumType _pEndCustNum9 = pEndCustNum9;
			CustNumType _pBeginCustNum10 = pBeginCustNum10;
			CustNumType _pEndCustNum10 = pEndCustNum10;
			CurrCodeType _pFromCurrencyCode = pFromCurrencyCode;
			InfobarType _rInfobar = rInfobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EuroCustSitesSp";
				
				appDB.AddCommandParameter(cmd, "pBeginCustNum1", _pBeginCustNum1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCustNum1", _pEndCustNum1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBeginCustNum2", _pBeginCustNum2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCustNum2", _pEndCustNum2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBeginCustNum3", _pBeginCustNum3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCustNum3", _pEndCustNum3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBeginCustNum4", _pBeginCustNum4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCustNum4", _pEndCustNum4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBeginCustNum5", _pBeginCustNum5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCustNum5", _pEndCustNum5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBeginCustNum6", _pBeginCustNum6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCustNum6", _pEndCustNum6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBeginCustNum7", _pBeginCustNum7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCustNum7", _pEndCustNum7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBeginCustNum8", _pBeginCustNum8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCustNum8", _pEndCustNum8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBeginCustNum9", _pBeginCustNum9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCustNum9", _pEndCustNum9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBeginCustNum10", _pBeginCustNum10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCustNum10", _pEndCustNum10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFromCurrencyCode", _pFromCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rInfobar", _rInfobar, ParameterDirection.InputOutput);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				rInfobar = _rInfobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, rInfobar);
			}
		}
	}
}
