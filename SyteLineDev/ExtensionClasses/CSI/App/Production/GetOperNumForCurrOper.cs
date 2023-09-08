//PROJECT NAME: Production
//CLASS NAME: GetOperNumForCurrOper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class GetOperNumForCurrOper : IGetOperNumForCurrOper
	{
		readonly IApplicationDB appDB;
		
		
		public GetOperNumForCurrOper(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? OperNum,
		string Infobar) GetOperNumForCurrOperSp(string Item,
		int? OperNum,
		string Infobar,
		string AlternateID = null)
		{
			ItemType _Item = Item;
			OperNumType _OperNum = OperNum;
			Infobar _Infobar = Infobar;
			MO_BOMAlternateType _AlternateID = AlternateID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetOperNumForCurrOperSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AlternateID", _AlternateID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OperNum = _OperNum;
				Infobar = _Infobar;
				
				return (Severity, OperNum, Infobar);
			}
		}
	}
}
