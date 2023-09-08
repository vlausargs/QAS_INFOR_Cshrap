//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPartReimbAddAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSPartReimbAddAcct : ISSSFSPartReimbAddAcct
	{
		readonly IApplicationDB appDB;
		
		public SSSFSPartReimbAddAcct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSPartReimbAddAcctSp(
			string IAcct,
			string IUnit1,
			string IUnit2,
			string IUnit3,
			string IUnit4,
			decimal? PAmount,
			decimal? PTax)
		{
			AcctType _IAcct = IAcct;
			UnitCode1Type _IUnit1 = IUnit1;
			UnitCode2Type _IUnit2 = IUnit2;
			UnitCode3Type _IUnit3 = IUnit3;
			UnitCode3Type _IUnit4 = IUnit4;
			AmountType _PAmount = PAmount;
			CostPrcType _PTax = PTax;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSPartReimbAddAcctSp";
				
				appDB.AddCommandParameter(cmd, "IAcct", _IAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IUnit1", _IUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IUnit2", _IUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IUnit3", _IUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IUnit4", _IUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAmount", _PAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTax", _PTax, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
