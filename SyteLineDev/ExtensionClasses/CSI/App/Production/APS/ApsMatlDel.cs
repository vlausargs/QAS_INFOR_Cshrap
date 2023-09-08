//PROJECT NAME: Production
//CLASS NAME: ApsMatlDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsMatlDel : IApsMatlDel
	{
		readonly IApplicationDB appDB;
		
		
		public ApsMatlDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsMatlDelSp(Guid? Rowp,
		string PMatl,
		int? AltNo)
		{
			RowPointerType _Rowp = Rowp;
			ApsMaterialType _PMatl = PMatl;
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsMatlDelSp";
				
				appDB.AddCommandParameter(cmd, "Rowp", _Rowp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMatl", _PMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
