//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroValidCustCurrency.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSroValidCustCurrency
	{
		(int? ReturnCode, string iCustNum,
		string Infobar) SSSFSSroValidCustCurrencySp(string iSroNum,
		int? iSroLine = null,
		int? iSroOper = null,
		string iCustNum = null,
		string Infobar = null);
	}
	
	public class SSSFSSroValidCustCurrency : ISSSFSSroValidCustCurrency
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroValidCustCurrency(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string iCustNum,
		string Infobar) SSSFSSroValidCustCurrencySp(string iSroNum,
		int? iSroLine = null,
		int? iSroOper = null,
		string iCustNum = null,
		string Infobar = null)
		{
			FSSRONumType _iSroNum = iSroNum;
			FSSROLineType _iSroLine = iSroLine;
			FSSROOperType _iSroOper = iSroOper;
			CustNumType _iCustNum = iCustNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroValidCustCurrencySp";
				
				appDB.AddCommandParameter(cmd, "iSroNum", _iSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroLine", _iSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroOper", _iSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCustNum", _iCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				iCustNum = _iCustNum;
				Infobar = _Infobar;
				
				return (Severity, iCustNum, Infobar);
			}
		}
	}
}
