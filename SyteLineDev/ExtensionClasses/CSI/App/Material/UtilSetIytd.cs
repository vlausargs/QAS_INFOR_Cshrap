//PROJECT NAME: Material
//CLASS NAME: UtilSetIytd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IUtilSetIytd
	{
		(int? ReturnCode, int? CounterItem, int? CounterItemWhse, string Infobar) UtilSetIytdSp(byte? IytdPtd,
		                                                                                        byte? IytdYtd,
		                                                                                        string BeginItem,
		                                                                                        string EndItem,
		                                                                                        int? CounterItem,
		                                                                                        int? CounterItemWhse,
		                                                                                        string Infobar);
	}
	
	public class UtilSetIytd : IUtilSetIytd
	{
		readonly IApplicationDB appDB;
		
		public UtilSetIytd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CounterItem, int? CounterItemWhse, string Infobar) UtilSetIytdSp(byte? IytdPtd,
		                                                                                               byte? IytdYtd,
		                                                                                               string BeginItem,
		                                                                                               string EndItem,
		                                                                                               int? CounterItem,
		                                                                                               int? CounterItemWhse,
		                                                                                               string Infobar)
		{
			ByteType _IytdPtd = IytdPtd;
			ByteType _IytdYtd = IytdYtd;
			ItemType _BeginItem = BeginItem;
			ItemType _EndItem = EndItem;
			IntType _CounterItem = CounterItem;
			IntType _CounterItemWhse = CounterItemWhse;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UtilSetIytdSp";
				
				appDB.AddCommandParameter(cmd, "IytdPtd", _IytdPtd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IytdYtd", _IytdYtd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginItem", _BeginItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CounterItem", _CounterItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CounterItemWhse", _CounterItemWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CounterItem = _CounterItem;
				CounterItemWhse = _CounterItemWhse;
				Infobar = _Infobar;
				
				return (Severity, CounterItem, CounterItemWhse, Infobar);
			}
		}
	}
}
