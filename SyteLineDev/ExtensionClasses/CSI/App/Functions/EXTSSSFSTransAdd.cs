//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSTransAdd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSTransAdd : IEXTSSSFSTransAdd
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSTransAdd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EXTSSSFSTransAddSp(
			DateTime? ShipDate,
			DateTime? RcvDate,
			string Item,
			string Infobar)
		{
			DateType _ShipDate = ShipDate;
			DateType _RcvDate = RcvDate;
			ItemType _Item = Item;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSTransAddSp";
				
				appDB.AddCommandParameter(cmd, "ShipDate", _ShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RcvDate", _RcvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
