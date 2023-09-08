//PROJECT NAME: Data
//CLASS NAME: EdiInPoVal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiInPoVal : IEdiInPoVal
	{
		readonly IApplicationDB appDB;
		
		public EdiInPoVal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EdiInPoValSP(
			Guid? EdiVinvRowPointer,
			Guid? VendTpRowPointer,
			string lrStat,
			string CallFrom)
		{
			RowPointerType _EdiVinvRowPointer = EdiVinvRowPointer;
			RowPointerType _VendTpRowPointer = VendTpRowPointer;
			StringType _lrStat = lrStat;
			StringType _CallFrom = CallFrom;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiInPoValSP";
				
				appDB.AddCommandParameter(cmd, "EdiVinvRowPointer", _EdiVinvRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendTpRowPointer", _VendTpRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "lrStat", _lrStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallFrom", _CallFrom, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
