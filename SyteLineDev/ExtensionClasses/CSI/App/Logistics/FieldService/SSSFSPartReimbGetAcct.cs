//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPartReimbGetAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSPartReimbGetAcct : ISSSFSPartReimbGetAcct
	{
		readonly IApplicationDB appDB;
		
		public SSSFSPartReimbGetAcct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PAcct,
			string PUnit1,
			string PUnit2,
			string PUnit3,
			string PUnit4) SSSFSPartReimbGetAcctSp(
			string PType,
			string PCatType,
			string IAcct,
			string IUnit1,
			string IUnit2,
			string IUnit3,
			string IUnit4,
			string IVendNum,
			string PAcct,
			string PUnit1,
			string PUnit2,
			string PUnit3,
			string PUnit4)
		{
			LongListType _PType = PType;
			EndUserTypeType _PCatType = PCatType;
			AcctType _IAcct = IAcct;
			UnitCode1Type _IUnit1 = IUnit1;
			UnitCode2Type _IUnit2 = IUnit2;
			UnitCode3Type _IUnit3 = IUnit3;
			UnitCode3Type _IUnit4 = IUnit4;
			VendNumType _IVendNum = IVendNum;
			AcctType _PAcct = PAcct;
			UnitCode1Type _PUnit1 = PUnit1;
			UnitCode2Type _PUnit2 = PUnit2;
			UnitCode3Type _PUnit3 = PUnit3;
			UnitCode4Type _PUnit4 = PUnit4;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSPartReimbGetAcctSp";
				
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCatType", _PCatType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IAcct", _IAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IUnit1", _IUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IUnit2", _IUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IUnit3", _IUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IUnit4", _IUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IVendNum", _IVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnit1", _PUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnit2", _PUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnit3", _PUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnit4", _PUnit4, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAcct = _PAcct;
				PUnit1 = _PUnit1;
				PUnit2 = _PUnit2;
				PUnit3 = _PUnit3;
				PUnit4 = _PUnit4;
				
				return (Severity, PAcct, PUnit1, PUnit2, PUnit3, PUnit4);
			}
		}
	}
}
