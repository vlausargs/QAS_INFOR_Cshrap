//PROJECT NAME: CSICustomer
//CLASS NAME: EurRval.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IEurRval
	{
		DataTable EurRvalSp(string PText,
		                    string StartingCurrencyCode,
		                    string EndingCurrencyCode,
		                    ref string Infobar);
	}
	
	public class EurRval : IEurRval
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public EurRval(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable EurRvalSp(string PText,
		                           string StartingCurrencyCode,
		                           string EndingCurrencyCode,
		                           ref string Infobar)
		{
			LongListType _PText = PText;
			CurrCodeType _StartingCurrencyCode = StartingCurrencyCode;
			CurrCodeType _EndingCurrencyCode = EndingCurrencyCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EurRvalSp";
				
				appDB.AddCommandParameter(cmd, "PText", _PText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingCurrencyCode", _StartingCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCurrencyCode", _EndingCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                dtReturn = appDB.ExecuteQuery(cmd);

                Infobar = _Infobar;
				
				return dtReturn;
			}
		}
	}
}
