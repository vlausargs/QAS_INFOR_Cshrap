//PROJECT NAME: Logistics
//CLASS NAME: ARDistribDomAmts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ARDistribDomAmts : IARDistribDomAmts
	{
		readonly IApplicationDB appDB;
		
		
		public ARDistribDomAmts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ARDistribDomAmtsSp(Guid? pRowPointer,
		string Infobar)
		{
			RowPointerType _pRowPointer = pRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARDistribDomAmtsSp";
				
				appDB.AddCommandParameter(cmd, "pRowPointer", _pRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
