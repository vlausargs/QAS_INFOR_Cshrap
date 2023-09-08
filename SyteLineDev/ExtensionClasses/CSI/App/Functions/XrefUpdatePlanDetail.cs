//PROJECT NAME: Data
//CLASS NAME: XrefUpdatePlanDetail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class XrefUpdatePlanDetail : IXrefUpdatePlanDetail
	{
		readonly IApplicationDB appDB;
		
		public XrefUpdatePlanDetail(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? XrefUpdatePlanDetailSp(
			Guid? PRowP)
		{
			RowPointerType _PRowP = PRowP;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "XrefUpdatePlanDetailSp";
				
				appDB.AddCommandParameter(cmd, "PRowP", _PRowP, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
