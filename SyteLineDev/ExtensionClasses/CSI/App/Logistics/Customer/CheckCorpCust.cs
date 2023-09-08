//PROJECT NAME: CSICustomer
//CLASS NAME: CheckCorpCust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICheckCorpCust
	{
		(int? ReturnCode, string CorpCustName, string Address, string Infobar) CheckCorpCustSp(string CorpCust,
		string CustNum,
		string NewCurrCode,
		string CorpCustName,
		string Address,
		string Infobar,
		string PSite = null);
	}
	
	public class CheckCorpCust : ICheckCorpCust
	{
		readonly IApplicationDB appDB;
		
		public CheckCorpCust(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CorpCustName, string Address, string Infobar) CheckCorpCustSp(string CorpCust,
		string CustNum,
		string NewCurrCode,
		string CorpCustName,
		string Address,
		string Infobar,
		string PSite = null)
		{
			CustNumType _CorpCust = CorpCust;
			CustNumType _CustNum = CustNum;
			CurrCodeType _NewCurrCode = NewCurrCode;
			NameType _CorpCustName = CorpCustName;
			LongAddress _Address = Address;
			InfobarType _Infobar = Infobar;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckCorpCustSp";
				
				appDB.AddCommandParameter(cmd, "CorpCust", _CorpCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewCurrCode", _NewCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CorpCustName", _CorpCustName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Address", _Address, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CorpCustName = _CorpCustName;
				Address = _Address;
				Infobar = _Infobar;
				
				return (Severity, CorpCustName, Address, Infobar);
			}
		}
	}
}
