//PROJECT NAME: Production
//CLASS NAME: ApsOrderDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsOrderDel : IApsOrderDel
	{
		readonly IApplicationDB appDB;
		
		
		public ApsOrderDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsOrderDelSp(Guid? Rowp,
		string POrd,
		int? AltNo)
		{
			RowPointerType _Rowp = Rowp;
			ApsOrderType _POrd = POrd;
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsOrderDelSp";
				
				appDB.AddCommandParameter(cmd, "Rowp", _Rowp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrd", _POrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
