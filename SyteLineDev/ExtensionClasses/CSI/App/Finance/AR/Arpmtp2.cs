//PROJECT NAME: Finance
//CLASS NAME: Arpmtp2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class Arpmtp2 : IArpmtp2
	{
		readonly IApplicationDB appDB;
		
		public Arpmtp2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) Arpmtp2Sp(
			Guid? PArpmtRowPointer,
			string Infobar,
			Guid? PProcessId)
		{
			RowPointerType _PArpmtRowPointer = PArpmtRowPointer;
			InfobarType _Infobar = Infobar;
			RowPointerType _PProcessId = PProcessId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Arpmtp2Sp";
				
				appDB.AddCommandParameter(cmd, "PArpmtRowPointer", _PArpmtRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PProcessId", _PProcessId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
