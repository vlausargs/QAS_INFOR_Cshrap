//PROJECT NAME: Data
//CLASS NAME: TaxSumR.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TaxSumR : ITaxSumR
	{
		readonly IApplicationDB appDB;
		
		public TaxSumR(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? TaxSumRSp(
			Guid? InvHdrRowPointer,
			int? TransDomCurr)
		{
			RowPointerType _InvHdrRowPointer = InvHdrRowPointer;
			ListYesNoType _TransDomCurr = TransDomCurr;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TaxSumRSp";
				
				appDB.AddCommandParameter(cmd, "InvHdrRowPointer", _InvHdrRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDomCurr", _TransDomCurr, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
