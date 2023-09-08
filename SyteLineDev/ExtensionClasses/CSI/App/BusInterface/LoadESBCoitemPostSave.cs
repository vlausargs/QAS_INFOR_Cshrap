//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBCoitemPostSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBCoitemPostSave
	{
		int LoadESBCoitemPostSaveSp(ref string Infobar);
	}
	
	public class LoadESBCoitemPostSave : ILoadESBCoitemPostSave
	{
		readonly IApplicationDB appDB;
		
		public LoadESBCoitemPostSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBCoitemPostSaveSp(ref string Infobar)
		{
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBCoitemPostSaveSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
