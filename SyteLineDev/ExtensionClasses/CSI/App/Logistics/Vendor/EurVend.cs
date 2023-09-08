//PROJECT NAME: CSIVendor
//CLASS NAME: EurVend.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IEurVend
	{
		DataTable EurVendSp(ref string Infobar,
		                    string pStartVendNum1,
		                    string pStartVendNum2,
		                    string pStartVendNum3,
		                    string pStartVendNum4,
		                    string pStartVendNum5,
		                    string pStartVendNum6,
		                    string pStartVendNum7,
		                    string pStartVendNum8,
		                    string pStartVendNum9,
		                    string pStartVendNum10,
		                    string pEndVendNum1,
		                    string pEndVendNum2,
		                    string pEndVendNum3,
		                    string pEndVendNum4,
		                    string pEndVendNum5,
		                    string pEndVendNum6,
		                    string pEndVendNum7,
		                    string pEndVendNum8,
		                    string pEndVendNum9,
		                    string pEndVendNum10,
		                    string pCurrCode,
		                    byte? pCommit);
	}
	
	public class EurVend : IEurVend
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public EurVend(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable EurVendSp(ref string Infobar,
		                           string pStartVendNum1,
		                           string pStartVendNum2,
		                           string pStartVendNum3,
		                           string pStartVendNum4,
		                           string pStartVendNum5,
		                           string pStartVendNum6,
		                           string pStartVendNum7,
		                           string pStartVendNum8,
		                           string pStartVendNum9,
		                           string pStartVendNum10,
		                           string pEndVendNum1,
		                           string pEndVendNum2,
		                           string pEndVendNum3,
		                           string pEndVendNum4,
		                           string pEndVendNum5,
		                           string pEndVendNum6,
		                           string pEndVendNum7,
		                           string pEndVendNum8,
		                           string pEndVendNum9,
		                           string pEndVendNum10,
		                           string pCurrCode,
		                           byte? pCommit)
		{
			InfobarType _Infobar = Infobar;
			VendNumType _pStartVendNum1 = pStartVendNum1;
			VendNumType _pStartVendNum2 = pStartVendNum2;
			VendNumType _pStartVendNum3 = pStartVendNum3;
			VendNumType _pStartVendNum4 = pStartVendNum4;
			VendNumType _pStartVendNum5 = pStartVendNum5;
			VendNumType _pStartVendNum6 = pStartVendNum6;
			VendNumType _pStartVendNum7 = pStartVendNum7;
			VendNumType _pStartVendNum8 = pStartVendNum8;
			VendNumType _pStartVendNum9 = pStartVendNum9;
			VendNumType _pStartVendNum10 = pStartVendNum10;
			VendNumType _pEndVendNum1 = pEndVendNum1;
			VendNumType _pEndVendNum2 = pEndVendNum2;
			VendNumType _pEndVendNum3 = pEndVendNum3;
			VendNumType _pEndVendNum4 = pEndVendNum4;
			VendNumType _pEndVendNum5 = pEndVendNum5;
			VendNumType _pEndVendNum6 = pEndVendNum6;
			VendNumType _pEndVendNum7 = pEndVendNum7;
			VendNumType _pEndVendNum8 = pEndVendNum8;
			VendNumType _pEndVendNum9 = pEndVendNum9;
			VendNumType _pEndVendNum10 = pEndVendNum10;
			CurrCodeType _pCurrCode = pCurrCode;
			Flag _pCommit = pCommit;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EurVendSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pStartVendNum1", _pStartVendNum1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartVendNum2", _pStartVendNum2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartVendNum3", _pStartVendNum3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartVendNum4", _pStartVendNum4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartVendNum5", _pStartVendNum5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartVendNum6", _pStartVendNum6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartVendNum7", _pStartVendNum7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartVendNum8", _pStartVendNum8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartVendNum9", _pStartVendNum9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartVendNum10", _pStartVendNum10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendNum1", _pEndVendNum1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendNum2", _pEndVendNum2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendNum3", _pEndVendNum3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendNum4", _pEndVendNum4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendNum5", _pEndVendNum5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendNum6", _pEndVendNum6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendNum7", _pEndVendNum7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendNum8", _pEndVendNum8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendNum9", _pEndVendNum9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendNum10", _pEndVendNum10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurrCode", _pCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCommit", _pCommit, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                Infobar = _Infobar;
				
				return dtReturn;
			}
		}
	}
}
