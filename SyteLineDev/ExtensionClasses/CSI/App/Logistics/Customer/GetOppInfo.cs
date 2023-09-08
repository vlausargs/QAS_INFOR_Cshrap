//PROJECT NAME: Logistics
//CLASS NAME: GetOppInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetOppInfo : IGetOppInfo
	{
		readonly IApplicationDB appDB;
		
		
		public GetOppInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Slsperson,
		string TerritoryCode,
		string TerritoryDesc,
		string CurrencyID,
		string Infobar) GetOppInfoSp(string CustNum,
		string ProspectID,
		string Slsperson,
		string TerritoryCode,
		string TerritoryDesc,
		string CurrencyID,
		string Infobar)
		{
			CustNumType _CustNum = CustNum;
			ProspectIDType _ProspectID = ProspectID;
			SlsmanType _Slsperson = Slsperson;
			TerritoryCodeType _TerritoryCode = TerritoryCode;
			TerritoryType _TerritoryDesc = TerritoryDesc;
			CurrCodeType _CurrencyID = CurrencyID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetOppInfoSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProspectID", _ProspectID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Slsperson", _Slsperson, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TerritoryCode", _TerritoryCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TerritoryDesc", _TerritoryDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrencyID", _CurrencyID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Slsperson = _Slsperson;
				TerritoryCode = _TerritoryCode;
				TerritoryDesc = _TerritoryDesc;
				CurrencyID = _CurrencyID;
				Infobar = _Infobar;
				
				return (Severity, Slsperson, TerritoryCode, TerritoryDesc, CurrencyID, Infobar);
			}
		}
	}
}
