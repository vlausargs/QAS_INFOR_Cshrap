//PROJECT NAME: Material
//CLASS NAME: UtilRevDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IUtilRevDel
	{
		(int? ReturnCode, int? CounterItem, string Infobar) UtilRevDelSp(string SelectedItem,
		                                                                 string StartingRev,
		                                                                 string EndingRev,
		                                                                 int? CounterItem,
		                                                                 string Infobar);
	}
	
	public class UtilRevDel : IUtilRevDel
	{
		readonly IApplicationDB appDB;
		
		public UtilRevDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CounterItem, string Infobar) UtilRevDelSp(string SelectedItem,
		                                                                        string StartingRev,
		                                                                        string EndingRev,
		                                                                        int? CounterItem,
		                                                                        string Infobar)
		{
			ItemType _SelectedItem = SelectedItem;
			RevisionType _StartingRev = StartingRev;
			RevisionType _EndingRev = EndingRev;
			IntType _CounterItem = CounterItem;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UtilRevDelSp";
				
				appDB.AddCommandParameter(cmd, "SelectedItem", _SelectedItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingRev", _StartingRev, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingRev", _EndingRev, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CounterItem", _CounterItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CounterItem = _CounterItem;
				Infobar = _Infobar;
				
				return (Severity, CounterItem, Infobar);
			}
		}
	}
}
