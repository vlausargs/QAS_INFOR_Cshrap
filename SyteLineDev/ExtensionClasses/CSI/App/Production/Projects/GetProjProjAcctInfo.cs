//PROJECT NAME: CSIProjects
//CLASS NAME: GetProjProjAcctInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IGetProjProjAcctInfo
	{
		int GetProjProjAcctInfoSp(string ProductCode,
		                          ref string ProjMatlAcct,
		                          ref string ProjMatlAcctUnit1,
		                          ref string ProjMatlAcctUnit2,
		                          ref string ProjMatlAcctUnit3,
		                          ref string ProjMatlAcctUnit4,
		                          ref string ProjMatlAcctDesc,
		                          ref string ProjLabrAcct,
		                          ref string ProjLabrAcctUnit1,
		                          ref string ProjLabrAcctUnit2,
		                          ref string ProjLabrAcctUnit3,
		                          ref string ProjLabrAcctUnit4,
		                          ref string ProjLabrAcctDesc,
		                          ref string ProjOtherAcct,
		                          ref string ProjOtherAcctUnit1,
		                          ref string ProjOtherAcctUnit2,
		                          ref string ProjOtherAcctUnit3,
		                          ref string ProjOtherAcctUnit4,
		                          ref string ProjOtherAcctDesc,
		                          ref string ProjOvhAcct,
		                          ref string ProjOvhAcctUnit1,
		                          ref string ProjOvhAcctUnit2,
		                          ref string ProjOvhAcctUnit3,
		                          ref string ProjOvhAcctUnit4,
		                          ref string ProjOvhAcctDesc,
		                          ref string ProjGaAcct,
		                          ref string ProjGaAcctUnit1,
		                          ref string ProjGaAcctUnit2,
		                          ref string ProjGaAcctUnit3,
		                          ref string ProjGaAcctUnit4,
		                          ref string ProjGaAcctDesc);
	}
	
	public class GetProjProjAcctInfo : IGetProjProjAcctInfo
	{
		readonly IApplicationDB appDB;
		
		public GetProjProjAcctInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetProjProjAcctInfoSp(string ProductCode,
		                                 ref string ProjMatlAcct,
		                                 ref string ProjMatlAcctUnit1,
		                                 ref string ProjMatlAcctUnit2,
		                                 ref string ProjMatlAcctUnit3,
		                                 ref string ProjMatlAcctUnit4,
		                                 ref string ProjMatlAcctDesc,
		                                 ref string ProjLabrAcct,
		                                 ref string ProjLabrAcctUnit1,
		                                 ref string ProjLabrAcctUnit2,
		                                 ref string ProjLabrAcctUnit3,
		                                 ref string ProjLabrAcctUnit4,
		                                 ref string ProjLabrAcctDesc,
		                                 ref string ProjOtherAcct,
		                                 ref string ProjOtherAcctUnit1,
		                                 ref string ProjOtherAcctUnit2,
		                                 ref string ProjOtherAcctUnit3,
		                                 ref string ProjOtherAcctUnit4,
		                                 ref string ProjOtherAcctDesc,
		                                 ref string ProjOvhAcct,
		                                 ref string ProjOvhAcctUnit1,
		                                 ref string ProjOvhAcctUnit2,
		                                 ref string ProjOvhAcctUnit3,
		                                 ref string ProjOvhAcctUnit4,
		                                 ref string ProjOvhAcctDesc,
		                                 ref string ProjGaAcct,
		                                 ref string ProjGaAcctUnit1,
		                                 ref string ProjGaAcctUnit2,
		                                 ref string ProjGaAcctUnit3,
		                                 ref string ProjGaAcctUnit4,
		                                 ref string ProjGaAcctDesc)
		{
			ProductCodeType _ProductCode = ProductCode;
			AcctType _ProjMatlAcct = ProjMatlAcct;
			UnitCode1Type _ProjMatlAcctUnit1 = ProjMatlAcctUnit1;
			UnitCode2Type _ProjMatlAcctUnit2 = ProjMatlAcctUnit2;
			UnitCode3Type _ProjMatlAcctUnit3 = ProjMatlAcctUnit3;
			UnitCode4Type _ProjMatlAcctUnit4 = ProjMatlAcctUnit4;
			DescriptionType _ProjMatlAcctDesc = ProjMatlAcctDesc;
			AcctType _ProjLabrAcct = ProjLabrAcct;
			UnitCode1Type _ProjLabrAcctUnit1 = ProjLabrAcctUnit1;
			UnitCode2Type _ProjLabrAcctUnit2 = ProjLabrAcctUnit2;
			UnitCode3Type _ProjLabrAcctUnit3 = ProjLabrAcctUnit3;
			UnitCode4Type _ProjLabrAcctUnit4 = ProjLabrAcctUnit4;
			DescriptionType _ProjLabrAcctDesc = ProjLabrAcctDesc;
			AcctType _ProjOtherAcct = ProjOtherAcct;
			UnitCode1Type _ProjOtherAcctUnit1 = ProjOtherAcctUnit1;
			UnitCode2Type _ProjOtherAcctUnit2 = ProjOtherAcctUnit2;
			UnitCode3Type _ProjOtherAcctUnit3 = ProjOtherAcctUnit3;
			UnitCode4Type _ProjOtherAcctUnit4 = ProjOtherAcctUnit4;
			DescriptionType _ProjOtherAcctDesc = ProjOtherAcctDesc;
			AcctType _ProjOvhAcct = ProjOvhAcct;
			UnitCode1Type _ProjOvhAcctUnit1 = ProjOvhAcctUnit1;
			UnitCode2Type _ProjOvhAcctUnit2 = ProjOvhAcctUnit2;
			UnitCode3Type _ProjOvhAcctUnit3 = ProjOvhAcctUnit3;
			UnitCode4Type _ProjOvhAcctUnit4 = ProjOvhAcctUnit4;
			DescriptionType _ProjOvhAcctDesc = ProjOvhAcctDesc;
			AcctType _ProjGaAcct = ProjGaAcct;
			UnitCode1Type _ProjGaAcctUnit1 = ProjGaAcctUnit1;
			UnitCode2Type _ProjGaAcctUnit2 = ProjGaAcctUnit2;
			UnitCode3Type _ProjGaAcctUnit3 = ProjGaAcctUnit3;
			UnitCode4Type _ProjGaAcctUnit4 = ProjGaAcctUnit4;
			DescriptionType _ProjGaAcctDesc = ProjGaAcctDesc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetProjProjAcctInfoSp";
				
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjMatlAcct", _ProjMatlAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjMatlAcctUnit1", _ProjMatlAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjMatlAcctUnit2", _ProjMatlAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjMatlAcctUnit3", _ProjMatlAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjMatlAcctUnit4", _ProjMatlAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjMatlAcctDesc", _ProjMatlAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjLabrAcct", _ProjLabrAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjLabrAcctUnit1", _ProjLabrAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjLabrAcctUnit2", _ProjLabrAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjLabrAcctUnit3", _ProjLabrAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjLabrAcctUnit4", _ProjLabrAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjLabrAcctDesc", _ProjLabrAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjOtherAcct", _ProjOtherAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjOtherAcctUnit1", _ProjOtherAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjOtherAcctUnit2", _ProjOtherAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjOtherAcctUnit3", _ProjOtherAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjOtherAcctUnit4", _ProjOtherAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjOtherAcctDesc", _ProjOtherAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjOvhAcct", _ProjOvhAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjOvhAcctUnit1", _ProjOvhAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjOvhAcctUnit2", _ProjOvhAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjOvhAcctUnit3", _ProjOvhAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjOvhAcctUnit4", _ProjOvhAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjOvhAcctDesc", _ProjOvhAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjGaAcct", _ProjGaAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjGaAcctUnit1", _ProjGaAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjGaAcctUnit2", _ProjGaAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjGaAcctUnit3", _ProjGaAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjGaAcctUnit4", _ProjGaAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjGaAcctDesc", _ProjGaAcctDesc, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ProjMatlAcct = _ProjMatlAcct;
				ProjMatlAcctUnit1 = _ProjMatlAcctUnit1;
				ProjMatlAcctUnit2 = _ProjMatlAcctUnit2;
				ProjMatlAcctUnit3 = _ProjMatlAcctUnit3;
				ProjMatlAcctUnit4 = _ProjMatlAcctUnit4;
				ProjMatlAcctDesc = _ProjMatlAcctDesc;
				ProjLabrAcct = _ProjLabrAcct;
				ProjLabrAcctUnit1 = _ProjLabrAcctUnit1;
				ProjLabrAcctUnit2 = _ProjLabrAcctUnit2;
				ProjLabrAcctUnit3 = _ProjLabrAcctUnit3;
				ProjLabrAcctUnit4 = _ProjLabrAcctUnit4;
				ProjLabrAcctDesc = _ProjLabrAcctDesc;
				ProjOtherAcct = _ProjOtherAcct;
				ProjOtherAcctUnit1 = _ProjOtherAcctUnit1;
				ProjOtherAcctUnit2 = _ProjOtherAcctUnit2;
				ProjOtherAcctUnit3 = _ProjOtherAcctUnit3;
				ProjOtherAcctUnit4 = _ProjOtherAcctUnit4;
				ProjOtherAcctDesc = _ProjOtherAcctDesc;
				ProjOvhAcct = _ProjOvhAcct;
				ProjOvhAcctUnit1 = _ProjOvhAcctUnit1;
				ProjOvhAcctUnit2 = _ProjOvhAcctUnit2;
				ProjOvhAcctUnit3 = _ProjOvhAcctUnit3;
				ProjOvhAcctUnit4 = _ProjOvhAcctUnit4;
				ProjOvhAcctDesc = _ProjOvhAcctDesc;
				ProjGaAcct = _ProjGaAcct;
				ProjGaAcctUnit1 = _ProjGaAcctUnit1;
				ProjGaAcctUnit2 = _ProjGaAcctUnit2;
				ProjGaAcctUnit3 = _ProjGaAcctUnit3;
				ProjGaAcctUnit4 = _ProjGaAcctUnit4;
				ProjGaAcctDesc = _ProjGaAcctDesc;
				
				return Severity;
			}
		}
	}
}
