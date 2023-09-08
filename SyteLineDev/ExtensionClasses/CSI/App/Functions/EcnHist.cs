//PROJECT NAME: Data
//CLASS NAME: EcnHist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EcnHist : IEcnHist
	{
		readonly IApplicationDB appDB;
		
		public EcnHist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EcnHistSp(
			Guid? EcnRowPointer,
			string Infobar)
		{
			RowPointer _EcnRowPointer = EcnRowPointer;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EcnHistSp";
				
				appDB.AddCommandParameter(cmd, "EcnRowPointer", _EcnRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
