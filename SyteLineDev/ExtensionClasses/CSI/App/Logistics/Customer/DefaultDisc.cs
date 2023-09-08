//PROJECT NAME: Logistics
//CLASS NAME: DefaultDisc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class DefaultDisc : IDefaultDisc
	{
		readonly IApplicationDB appDB;
		
		
		public DefaultDisc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? Disc) DefaultDiscSp(string Item,
		string CustNum,
		string CustType,
		decimal? Disc)
		{
			ItemType _Item = Item;
			CustNumType _CustNum = CustNum;
			CustTypeType _CustType = CustType;
			LineDiscType _Disc = Disc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DefaultDiscSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustType", _CustType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Disc", _Disc, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Disc = _Disc;
				
				return (Severity, Disc);
			}
		}
	}
}
