//PROJECT NAME: Production
//CLASS NAME: ApsSHIFTEXDIDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSHIFTEXDIDel : IApsSHIFTEXDIDel
	{
		readonly IApplicationDB appDB;
		
		
		public ApsSHIFTEXDIDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSHIFTEXDIDelSp(int? AltNo,
		Guid? RowPointer)
		{
			ApsAltNoType _AltNo = AltNo;
			RowPointerType _RowPointer = RowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSHIFTEXDIDelSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
