//PROJECT NAME: Logistics
//CLASS NAME: VchPreRegisterVar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VchPreRegisterVar : IVchPreRegisterVar
	{
		readonly IApplicationDB appDB;
		
		
		public VchPreRegisterVar(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string SuspenseAcct,
		string SuspenseAcctDesc,
		string SuspenseAcctUnit1,
		string SuspenseAcctUnit2,
		string SuspenseAcctUnit3,
		string SuspenseAcctUnit4,
		string UnMatchedAcct,
		string UnMatchedAcctDesc,
		string UnMatchedAcctUnit1,
		string UnMatchedAcctUnit2,
		string UnMatchedAcctUnit3,
		string UnMatchedAcctUnit4,
		string FreightAcct,
		string FreightAcctDesc,
		string FreightAcctUnit1,
		string FreightAcctUnit2,
		string FreightAcctUnit3,
		string FreightAcctUnit4,
		string MiscAcct,
		string MiscAcctDesc,
		string MiscAcctUnit1,
		string MiscAcctUnit2,
		string MiscAcctUnit3,
		string MiscAcctUnit4) VchPreRegisterVarSP(string SuspenseAcct,
		string SuspenseAcctDesc,
		string SuspenseAcctUnit1,
		string SuspenseAcctUnit2,
		string SuspenseAcctUnit3,
		string SuspenseAcctUnit4,
		string UnMatchedAcct,
		string UnMatchedAcctDesc,
		string UnMatchedAcctUnit1,
		string UnMatchedAcctUnit2,
		string UnMatchedAcctUnit3,
		string UnMatchedAcctUnit4,
		string FreightAcct,
		string FreightAcctDesc,
		string FreightAcctUnit1,
		string FreightAcctUnit2,
		string FreightAcctUnit3,
		string FreightAcctUnit4,
		string MiscAcct,
		string MiscAcctDesc,
		string MiscAcctUnit1,
		string MiscAcctUnit2,
		string MiscAcctUnit3,
		string MiscAcctUnit4)
		{
			AcctType _SuspenseAcct = SuspenseAcct;
			DescriptionType _SuspenseAcctDesc = SuspenseAcctDesc;
			UnitCode1Type _SuspenseAcctUnit1 = SuspenseAcctUnit1;
			UnitCode2Type _SuspenseAcctUnit2 = SuspenseAcctUnit2;
			UnitCode3Type _SuspenseAcctUnit3 = SuspenseAcctUnit3;
			UnitCode4Type _SuspenseAcctUnit4 = SuspenseAcctUnit4;
			AcctType _UnMatchedAcct = UnMatchedAcct;
			DescriptionType _UnMatchedAcctDesc = UnMatchedAcctDesc;
			UnitCode1Type _UnMatchedAcctUnit1 = UnMatchedAcctUnit1;
			UnitCode2Type _UnMatchedAcctUnit2 = UnMatchedAcctUnit2;
			UnitCode3Type _UnMatchedAcctUnit3 = UnMatchedAcctUnit3;
			UnitCode4Type _UnMatchedAcctUnit4 = UnMatchedAcctUnit4;
			AcctType _FreightAcct = FreightAcct;
			DescriptionType _FreightAcctDesc = FreightAcctDesc;
			UnitCode1Type _FreightAcctUnit1 = FreightAcctUnit1;
			UnitCode2Type _FreightAcctUnit2 = FreightAcctUnit2;
			UnitCode3Type _FreightAcctUnit3 = FreightAcctUnit3;
			UnitCode4Type _FreightAcctUnit4 = FreightAcctUnit4;
			AcctType _MiscAcct = MiscAcct;
			DescriptionType _MiscAcctDesc = MiscAcctDesc;
			UnitCode1Type _MiscAcctUnit1 = MiscAcctUnit1;
			UnitCode2Type _MiscAcctUnit2 = MiscAcctUnit2;
			UnitCode3Type _MiscAcctUnit3 = MiscAcctUnit3;
			UnitCode4Type _MiscAcctUnit4 = MiscAcctUnit4;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VchPreRegisterVarSP";
				
				appDB.AddCommandParameter(cmd, "SuspenseAcct", _SuspenseAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SuspenseAcctDesc", _SuspenseAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SuspenseAcctUnit1", _SuspenseAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SuspenseAcctUnit2", _SuspenseAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SuspenseAcctUnit3", _SuspenseAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SuspenseAcctUnit4", _SuspenseAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnMatchedAcct", _UnMatchedAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnMatchedAcctDesc", _UnMatchedAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnMatchedAcctUnit1", _UnMatchedAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnMatchedAcctUnit2", _UnMatchedAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnMatchedAcctUnit3", _UnMatchedAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnMatchedAcctUnit4", _UnMatchedAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FreightAcct", _FreightAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FreightAcctDesc", _FreightAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FreightAcctUnit1", _FreightAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FreightAcctUnit2", _FreightAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FreightAcctUnit3", _FreightAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FreightAcctUnit4", _FreightAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MiscAcct", _MiscAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MiscAcctDesc", _MiscAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MiscAcctUnit1", _MiscAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MiscAcctUnit2", _MiscAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MiscAcctUnit3", _MiscAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MiscAcctUnit4", _MiscAcctUnit4, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SuspenseAcct = _SuspenseAcct;
				SuspenseAcctDesc = _SuspenseAcctDesc;
				SuspenseAcctUnit1 = _SuspenseAcctUnit1;
				SuspenseAcctUnit2 = _SuspenseAcctUnit2;
				SuspenseAcctUnit3 = _SuspenseAcctUnit3;
				SuspenseAcctUnit4 = _SuspenseAcctUnit4;
				UnMatchedAcct = _UnMatchedAcct;
				UnMatchedAcctDesc = _UnMatchedAcctDesc;
				UnMatchedAcctUnit1 = _UnMatchedAcctUnit1;
				UnMatchedAcctUnit2 = _UnMatchedAcctUnit2;
				UnMatchedAcctUnit3 = _UnMatchedAcctUnit3;
				UnMatchedAcctUnit4 = _UnMatchedAcctUnit4;
				FreightAcct = _FreightAcct;
				FreightAcctDesc = _FreightAcctDesc;
				FreightAcctUnit1 = _FreightAcctUnit1;
				FreightAcctUnit2 = _FreightAcctUnit2;
				FreightAcctUnit3 = _FreightAcctUnit3;
				FreightAcctUnit4 = _FreightAcctUnit4;
				MiscAcct = _MiscAcct;
				MiscAcctDesc = _MiscAcctDesc;
				MiscAcctUnit1 = _MiscAcctUnit1;
				MiscAcctUnit2 = _MiscAcctUnit2;
				MiscAcctUnit3 = _MiscAcctUnit3;
				MiscAcctUnit4 = _MiscAcctUnit4;
				
				return (Severity, SuspenseAcct, SuspenseAcctDesc, SuspenseAcctUnit1, SuspenseAcctUnit2, SuspenseAcctUnit3, SuspenseAcctUnit4, UnMatchedAcct, UnMatchedAcctDesc, UnMatchedAcctUnit1, UnMatchedAcctUnit2, UnMatchedAcctUnit3, UnMatchedAcctUnit4, FreightAcct, FreightAcctDesc, FreightAcctUnit1, FreightAcctUnit2, FreightAcctUnit3, FreightAcctUnit4, MiscAcct, MiscAcctDesc, MiscAcctUnit1, MiscAcctUnit2, MiscAcctUnit3, MiscAcctUnit4);
			}
		}
	}
}
