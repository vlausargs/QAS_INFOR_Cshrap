//PROJECT NAME: Logistics
//CLASS NAME: ICUpdateUserInitial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IICUpdateUserInitial
	{
		(int? ReturnCode, string Infobar) ICUpdateUserInitialSp(string UserInitial,
		string Infobar);
	}
	
	public class ICUpdateUserInitial : IICUpdateUserInitial
	{
		IApplicationDB appDB;
		
		public ICUpdateUserInitial(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ICUpdateUserInitialSp(string UserInitial,
		string Infobar)
		{
			UserCodeType _UserInitial = UserInitial;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ICUpdateUserInitialSp";
				
				appDB.AddCommandParameter(cmd, "UserInitial", _UserInitial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
