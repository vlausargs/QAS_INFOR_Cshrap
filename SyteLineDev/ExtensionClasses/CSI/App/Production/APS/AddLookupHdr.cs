//PROJECT NAME: Production
//CLASS NAME: AddLookupHdr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class AddLookupHdr : IAddLookupHdr
	{
		readonly IApplicationDB appDB;
		
		
		public AddLookupHdr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) AddLookupHdrSp(string Tabid,
		string MatrixType,
		string Infobar)
		{
			ApsLtableType _Tabid = Tabid;
			ApsLtypeType _MatrixType = MatrixType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AddLookupHdrSp";
				
				appDB.AddCommandParameter(cmd, "Tabid", _Tabid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatrixType", _MatrixType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
