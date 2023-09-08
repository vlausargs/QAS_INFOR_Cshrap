//PROJECT NAME: CSICustomer
//CLASS NAME: CohDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICohDel
	{
		(int? ReturnCode, int? rCOHsDeleted, string rInfobar) CohDelSp(string pStartingCONum,
		string pEndingCONum,
		DateTime? pStartingCODate,
		DateTime? pEndingCODate,
		string pStartingCustNum,
		string pEndingCustNum,
		int? rCOHsDeleted,
		string rInfobar,
		short? StartingDateOffset = null,
		short? EndingDateOffset = null);
	}
	
	public class CohDel : ICohDel
	{
		readonly IApplicationDB appDB;
		
		public CohDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? rCOHsDeleted, string rInfobar) CohDelSp(string pStartingCONum,
		string pEndingCONum,
		DateTime? pStartingCODate,
		DateTime? pEndingCODate,
		string pStartingCustNum,
		string pEndingCustNum,
		int? rCOHsDeleted,
		string rInfobar,
		short? StartingDateOffset = null,
		short? EndingDateOffset = null)
		{
			CoNumType _pStartingCONum = pStartingCONum;
			CoNumType _pEndingCONum = pEndingCONum;
			DateType _pStartingCODate = pStartingCODate;
			DateType _pEndingCODate = pEndingCODate;
			CustNumType _pStartingCustNum = pStartingCustNum;
			CustNumType _pEndingCustNum = pEndingCustNum;
			IntType _rCOHsDeleted = rCOHsDeleted;
			InfobarType _rInfobar = rInfobar;
			DateOffsetType _StartingDateOffset = StartingDateOffset;
			DateOffsetType _EndingDateOffset = EndingDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CohDelSp";
				
				appDB.AddCommandParameter(cmd, "pStartingCONum", _pStartingCONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingCONum", _pEndingCONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingCODate", _pStartingCODate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingCODate", _pEndingCODate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingCustNum", _pStartingCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingCustNum", _pEndingCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rCOHsDeleted", _rCOHsDeleted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rInfobar", _rInfobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingDateOffset", _StartingDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDateOffset", _EndingDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rCOHsDeleted = _rCOHsDeleted;
				rInfobar = _rInfobar;
				
				return (Severity, rCOHsDeleted, rInfobar);
			}
		}
	}
}
