//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroTransPostProjAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSroTransPostProjAcct : ISSSFSSroTransPostProjAcct
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroTransPostProjAcct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ProjMatlAcct,
			string ProjMatlUnit1,
			string ProjMatlUnit2,
			string ProjMatlUnit3,
			string ProjMatlUnit4,
			string ProjLbrAcct,
			string ProjLbrUnit1,
			string ProjLbrUnit2,
			string ProjLbrUnit3,
			string ProjLbrUnit4,
			string ProjFovAcct,
			string ProjFovUnit1,
			string ProjFovUnit2,
			string ProjFovUnit3,
			string ProjFovUnit4,
			string ProjVovAcct,
			string ProjVovUnit1,
			string ProjVovUnit2,
			string ProjVovUnit3,
			string ProjVovUnit4,
			string ProjOutAcct,
			string ProjOutUnit1,
			string ProjOutUnit2,
			string ProjOutUnit3,
			string ProjOutUnit4,
			string ProjExpMatlAcct,
			string ProjExpMatlUnit1,
			string ProjExpMatlUnit2,
			string ProjExpMatlUnit3,
			string ProjExpMatlUnit4,
			string ProjExpLbrAcct,
			string ProjExpLbrUnit1,
			string ProjExpLbrUnit2,
			string ProjExpLbrUnit3,
			string ProjExpLbrUnit4,
			string ProjExpFovAcct,
			string ProjExpFovUnit1,
			string ProjExpFovUnit2,
			string ProjExpFovUnit3,
			string ProjExpFovUnit4,
			string ProjExpVovAcct,
			string ProjExpVovUnit1,
			string ProjExpVovUnit2,
			string ProjExpVovUnit3,
			string ProjExpVovUnit4,
			string ProjExpOutAcct,
			string ProjExpOutUnit1,
			string ProjExpOutUnit2,
			string ProjExpOutUnit3,
			string ProjExpOutUnit4,
			string RevAcct,
			string RevUnit1,
			string RevUnit2,
			string RevUnit3,
			string RevUnit4,
			string SaleDsAcct,
			string SaleDsUnit1,
			string SaleDsUnit2,
			string SaleDsUnit3,
			string SaleDsUnit4,
			string Infobar) SSSFSSroTransPostProjAcctSp(
			string ProjNum,
			int? TaskNum,
			string UnitCode2,
			string CostCode,
			string ProjMatlAcct,
			string ProjMatlUnit1,
			string ProjMatlUnit2,
			string ProjMatlUnit3,
			string ProjMatlUnit4,
			string ProjLbrAcct,
			string ProjLbrUnit1,
			string ProjLbrUnit2,
			string ProjLbrUnit3,
			string ProjLbrUnit4,
			string ProjFovAcct,
			string ProjFovUnit1,
			string ProjFovUnit2,
			string ProjFovUnit3,
			string ProjFovUnit4,
			string ProjVovAcct,
			string ProjVovUnit1,
			string ProjVovUnit2,
			string ProjVovUnit3,
			string ProjVovUnit4,
			string ProjOutAcct,
			string ProjOutUnit1,
			string ProjOutUnit2,
			string ProjOutUnit3,
			string ProjOutUnit4,
			string ProjExpMatlAcct,
			string ProjExpMatlUnit1,
			string ProjExpMatlUnit2,
			string ProjExpMatlUnit3,
			string ProjExpMatlUnit4,
			string ProjExpLbrAcct,
			string ProjExpLbrUnit1,
			string ProjExpLbrUnit2,
			string ProjExpLbrUnit3,
			string ProjExpLbrUnit4,
			string ProjExpFovAcct,
			string ProjExpFovUnit1,
			string ProjExpFovUnit2,
			string ProjExpFovUnit3,
			string ProjExpFovUnit4,
			string ProjExpVovAcct,
			string ProjExpVovUnit1,
			string ProjExpVovUnit2,
			string ProjExpVovUnit3,
			string ProjExpVovUnit4,
			string ProjExpOutAcct,
			string ProjExpOutUnit1,
			string ProjExpOutUnit2,
			string ProjExpOutUnit3,
			string ProjExpOutUnit4,
			string RevAcct,
			string RevUnit1,
			string RevUnit2,
			string RevUnit3,
			string RevUnit4,
			string SaleDsAcct,
			string SaleDsUnit1,
			string SaleDsUnit2,
			string SaleDsUnit3,
			string SaleDsUnit4,
			string Infobar)
		{
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _TaskNum = TaskNum;
			UnitCode2Type _UnitCode2 = UnitCode2;
			CostCodeType _CostCode = CostCode;
			AcctType _ProjMatlAcct = ProjMatlAcct;
			UnitCode1Type _ProjMatlUnit1 = ProjMatlUnit1;
			UnitCode2Type _ProjMatlUnit2 = ProjMatlUnit2;
			UnitCode3Type _ProjMatlUnit3 = ProjMatlUnit3;
			UnitCode4Type _ProjMatlUnit4 = ProjMatlUnit4;
			AcctType _ProjLbrAcct = ProjLbrAcct;
			UnitCode1Type _ProjLbrUnit1 = ProjLbrUnit1;
			UnitCode2Type _ProjLbrUnit2 = ProjLbrUnit2;
			UnitCode3Type _ProjLbrUnit3 = ProjLbrUnit3;
			UnitCode4Type _ProjLbrUnit4 = ProjLbrUnit4;
			AcctType _ProjFovAcct = ProjFovAcct;
			UnitCode1Type _ProjFovUnit1 = ProjFovUnit1;
			UnitCode2Type _ProjFovUnit2 = ProjFovUnit2;
			UnitCode3Type _ProjFovUnit3 = ProjFovUnit3;
			UnitCode4Type _ProjFovUnit4 = ProjFovUnit4;
			AcctType _ProjVovAcct = ProjVovAcct;
			UnitCode1Type _ProjVovUnit1 = ProjVovUnit1;
			UnitCode2Type _ProjVovUnit2 = ProjVovUnit2;
			UnitCode3Type _ProjVovUnit3 = ProjVovUnit3;
			UnitCode4Type _ProjVovUnit4 = ProjVovUnit4;
			AcctType _ProjOutAcct = ProjOutAcct;
			UnitCode1Type _ProjOutUnit1 = ProjOutUnit1;
			UnitCode2Type _ProjOutUnit2 = ProjOutUnit2;
			UnitCode3Type _ProjOutUnit3 = ProjOutUnit3;
			UnitCode4Type _ProjOutUnit4 = ProjOutUnit4;
			AcctType _ProjExpMatlAcct = ProjExpMatlAcct;
			UnitCode1Type _ProjExpMatlUnit1 = ProjExpMatlUnit1;
			UnitCode2Type _ProjExpMatlUnit2 = ProjExpMatlUnit2;
			UnitCode3Type _ProjExpMatlUnit3 = ProjExpMatlUnit3;
			UnitCode4Type _ProjExpMatlUnit4 = ProjExpMatlUnit4;
			AcctType _ProjExpLbrAcct = ProjExpLbrAcct;
			UnitCode1Type _ProjExpLbrUnit1 = ProjExpLbrUnit1;
			UnitCode2Type _ProjExpLbrUnit2 = ProjExpLbrUnit2;
			UnitCode3Type _ProjExpLbrUnit3 = ProjExpLbrUnit3;
			UnitCode4Type _ProjExpLbrUnit4 = ProjExpLbrUnit4;
			AcctType _ProjExpFovAcct = ProjExpFovAcct;
			UnitCode1Type _ProjExpFovUnit1 = ProjExpFovUnit1;
			UnitCode2Type _ProjExpFovUnit2 = ProjExpFovUnit2;
			UnitCode3Type _ProjExpFovUnit3 = ProjExpFovUnit3;
			UnitCode4Type _ProjExpFovUnit4 = ProjExpFovUnit4;
			AcctType _ProjExpVovAcct = ProjExpVovAcct;
			UnitCode1Type _ProjExpVovUnit1 = ProjExpVovUnit1;
			UnitCode2Type _ProjExpVovUnit2 = ProjExpVovUnit2;
			UnitCode3Type _ProjExpVovUnit3 = ProjExpVovUnit3;
			UnitCode4Type _ProjExpVovUnit4 = ProjExpVovUnit4;
			AcctType _ProjExpOutAcct = ProjExpOutAcct;
			UnitCode1Type _ProjExpOutUnit1 = ProjExpOutUnit1;
			UnitCode2Type _ProjExpOutUnit2 = ProjExpOutUnit2;
			UnitCode3Type _ProjExpOutUnit3 = ProjExpOutUnit3;
			UnitCode4Type _ProjExpOutUnit4 = ProjExpOutUnit4;
			AcctType _RevAcct = RevAcct;
			UnitCode1Type _RevUnit1 = RevUnit1;
			UnitCode2Type _RevUnit2 = RevUnit2;
			UnitCode3Type _RevUnit3 = RevUnit3;
			UnitCode4Type _RevUnit4 = RevUnit4;
			AcctType _SaleDsAcct = SaleDsAcct;
			UnitCode1Type _SaleDsUnit1 = SaleDsUnit1;
			UnitCode2Type _SaleDsUnit2 = SaleDsUnit2;
			UnitCode3Type _SaleDsUnit3 = SaleDsUnit3;
			UnitCode4Type _SaleDsUnit4 = SaleDsUnit4;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroTransPostProjAcctSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode2", _UnitCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCode", _CostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjMatlAcct", _ProjMatlAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjMatlUnit1", _ProjMatlUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjMatlUnit2", _ProjMatlUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjMatlUnit3", _ProjMatlUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjMatlUnit4", _ProjMatlUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjLbrAcct", _ProjLbrAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjLbrUnit1", _ProjLbrUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjLbrUnit2", _ProjLbrUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjLbrUnit3", _ProjLbrUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjLbrUnit4", _ProjLbrUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjFovAcct", _ProjFovAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjFovUnit1", _ProjFovUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjFovUnit2", _ProjFovUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjFovUnit3", _ProjFovUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjFovUnit4", _ProjFovUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjVovAcct", _ProjVovAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjVovUnit1", _ProjVovUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjVovUnit2", _ProjVovUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjVovUnit3", _ProjVovUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjVovUnit4", _ProjVovUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjOutAcct", _ProjOutAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjOutUnit1", _ProjOutUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjOutUnit2", _ProjOutUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjOutUnit3", _ProjOutUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjOutUnit4", _ProjOutUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpMatlAcct", _ProjExpMatlAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpMatlUnit1", _ProjExpMatlUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpMatlUnit2", _ProjExpMatlUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpMatlUnit3", _ProjExpMatlUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpMatlUnit4", _ProjExpMatlUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpLbrAcct", _ProjExpLbrAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpLbrUnit1", _ProjExpLbrUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpLbrUnit2", _ProjExpLbrUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpLbrUnit3", _ProjExpLbrUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpLbrUnit4", _ProjExpLbrUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpFovAcct", _ProjExpFovAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpFovUnit1", _ProjExpFovUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpFovUnit2", _ProjExpFovUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpFovUnit3", _ProjExpFovUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpFovUnit4", _ProjExpFovUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpVovAcct", _ProjExpVovAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpVovUnit1", _ProjExpVovUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpVovUnit2", _ProjExpVovUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpVovUnit3", _ProjExpVovUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpVovUnit4", _ProjExpVovUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpOutAcct", _ProjExpOutAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpOutUnit1", _ProjExpOutUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpOutUnit2", _ProjExpOutUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpOutUnit3", _ProjExpOutUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjExpOutUnit4", _ProjExpOutUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RevAcct", _RevAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RevUnit1", _RevUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RevUnit2", _RevUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RevUnit3", _RevUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RevUnit4", _RevUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SaleDsAcct", _SaleDsAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SaleDsUnit1", _SaleDsUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SaleDsUnit2", _SaleDsUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SaleDsUnit3", _SaleDsUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SaleDsUnit4", _SaleDsUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ProjMatlAcct = _ProjMatlAcct;
				ProjMatlUnit1 = _ProjMatlUnit1;
				ProjMatlUnit2 = _ProjMatlUnit2;
				ProjMatlUnit3 = _ProjMatlUnit3;
				ProjMatlUnit4 = _ProjMatlUnit4;
				ProjLbrAcct = _ProjLbrAcct;
				ProjLbrUnit1 = _ProjLbrUnit1;
				ProjLbrUnit2 = _ProjLbrUnit2;
				ProjLbrUnit3 = _ProjLbrUnit3;
				ProjLbrUnit4 = _ProjLbrUnit4;
				ProjFovAcct = _ProjFovAcct;
				ProjFovUnit1 = _ProjFovUnit1;
				ProjFovUnit2 = _ProjFovUnit2;
				ProjFovUnit3 = _ProjFovUnit3;
				ProjFovUnit4 = _ProjFovUnit4;
				ProjVovAcct = _ProjVovAcct;
				ProjVovUnit1 = _ProjVovUnit1;
				ProjVovUnit2 = _ProjVovUnit2;
				ProjVovUnit3 = _ProjVovUnit3;
				ProjVovUnit4 = _ProjVovUnit4;
				ProjOutAcct = _ProjOutAcct;
				ProjOutUnit1 = _ProjOutUnit1;
				ProjOutUnit2 = _ProjOutUnit2;
				ProjOutUnit3 = _ProjOutUnit3;
				ProjOutUnit4 = _ProjOutUnit4;
				ProjExpMatlAcct = _ProjExpMatlAcct;
				ProjExpMatlUnit1 = _ProjExpMatlUnit1;
				ProjExpMatlUnit2 = _ProjExpMatlUnit2;
				ProjExpMatlUnit3 = _ProjExpMatlUnit3;
				ProjExpMatlUnit4 = _ProjExpMatlUnit4;
				ProjExpLbrAcct = _ProjExpLbrAcct;
				ProjExpLbrUnit1 = _ProjExpLbrUnit1;
				ProjExpLbrUnit2 = _ProjExpLbrUnit2;
				ProjExpLbrUnit3 = _ProjExpLbrUnit3;
				ProjExpLbrUnit4 = _ProjExpLbrUnit4;
				ProjExpFovAcct = _ProjExpFovAcct;
				ProjExpFovUnit1 = _ProjExpFovUnit1;
				ProjExpFovUnit2 = _ProjExpFovUnit2;
				ProjExpFovUnit3 = _ProjExpFovUnit3;
				ProjExpFovUnit4 = _ProjExpFovUnit4;
				ProjExpVovAcct = _ProjExpVovAcct;
				ProjExpVovUnit1 = _ProjExpVovUnit1;
				ProjExpVovUnit2 = _ProjExpVovUnit2;
				ProjExpVovUnit3 = _ProjExpVovUnit3;
				ProjExpVovUnit4 = _ProjExpVovUnit4;
				ProjExpOutAcct = _ProjExpOutAcct;
				ProjExpOutUnit1 = _ProjExpOutUnit1;
				ProjExpOutUnit2 = _ProjExpOutUnit2;
				ProjExpOutUnit3 = _ProjExpOutUnit3;
				ProjExpOutUnit4 = _ProjExpOutUnit4;
				RevAcct = _RevAcct;
				RevUnit1 = _RevUnit1;
				RevUnit2 = _RevUnit2;
				RevUnit3 = _RevUnit3;
				RevUnit4 = _RevUnit4;
				SaleDsAcct = _SaleDsAcct;
				SaleDsUnit1 = _SaleDsUnit1;
				SaleDsUnit2 = _SaleDsUnit2;
				SaleDsUnit3 = _SaleDsUnit3;
				SaleDsUnit4 = _SaleDsUnit4;
				Infobar = _Infobar;
				
				return (Severity, ProjMatlAcct, ProjMatlUnit1, ProjMatlUnit2, ProjMatlUnit3, ProjMatlUnit4, ProjLbrAcct, ProjLbrUnit1, ProjLbrUnit2, ProjLbrUnit3, ProjLbrUnit4, ProjFovAcct, ProjFovUnit1, ProjFovUnit2, ProjFovUnit3, ProjFovUnit4, ProjVovAcct, ProjVovUnit1, ProjVovUnit2, ProjVovUnit3, ProjVovUnit4, ProjOutAcct, ProjOutUnit1, ProjOutUnit2, ProjOutUnit3, ProjOutUnit4, ProjExpMatlAcct, ProjExpMatlUnit1, ProjExpMatlUnit2, ProjExpMatlUnit3, ProjExpMatlUnit4, ProjExpLbrAcct, ProjExpLbrUnit1, ProjExpLbrUnit2, ProjExpLbrUnit3, ProjExpLbrUnit4, ProjExpFovAcct, ProjExpFovUnit1, ProjExpFovUnit2, ProjExpFovUnit3, ProjExpFovUnit4, ProjExpVovAcct, ProjExpVovUnit1, ProjExpVovUnit2, ProjExpVovUnit3, ProjExpVovUnit4, ProjExpOutAcct, ProjExpOutUnit1, ProjExpOutUnit2, ProjExpOutUnit3, ProjExpOutUnit4, RevAcct, RevUnit1, RevUnit2, RevUnit3, RevUnit4, SaleDsAcct, SaleDsUnit1, SaleDsUnit2, SaleDsUnit3, SaleDsUnit4, Infobar);
			}
		}
	}
}
