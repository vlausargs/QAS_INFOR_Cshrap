//PROJECT NAME: Logistics
//CLASS NAME: ExtInterfaceParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ExtInterfaceParms : IExtInterfaceParms
	{
		readonly IApplicationDB appDB;
		
		
		public ExtInterfaceParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ExpDocDir,
		string ExpDocPrefix,
		string ExpDocExt,
		string Infobar) ExtInterfaceParmsSp(string ExpDocDir,
		string ExpDocPrefix,
		string ExpDocExt,
		string Infobar)
		{
			OSLocationType _ExpDocDir = ExpDocDir;
			OSBaseNameType _ExpDocPrefix = ExpDocPrefix;
			OSExtensionType _ExpDocExt = ExpDocExt;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExtInterfaceParmsSp";
				
				appDB.AddCommandParameter(cmd, "ExpDocDir", _ExpDocDir, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExpDocPrefix", _ExpDocPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExpDocExt", _ExpDocExt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ExpDocDir = _ExpDocDir;
				ExpDocPrefix = _ExpDocPrefix;
				ExpDocExt = _ExpDocExt;
				Infobar = _Infobar;
				
				return (Severity, ExpDocDir, ExpDocPrefix, ExpDocExt, Infobar);
			}
		}
	}
}
