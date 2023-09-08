//PROJECT NAME: CSIProjects
//CLASS NAME: GetProjDistAcctInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IGetProjDistAcctInfo
	{
		int GetProjDistAcctInfoSp(string ProductCode,
		                          ref string DisCgsAcct,
		                          ref string DisCgsAcctUnit1,
		                          ref string DisCgsAcctUnit2,
		                          ref string DisCgsAcctUnit3,
		                          ref string DisCgsAcctUnit4,
		                          ref string DisCgsAcctDesc,
		                          ref string DisCgsLbrAcct,
		                          ref string DisCgsLbrAcctUnit1,
		                          ref string DisCgsLbrAcctUnit2,
		                          ref string DisCgsLbrAcctUnit3,
		                          ref string DisCgsLbrAcctUnit4,
		                          ref string DisCgsLbrAcctDesc,
		                          ref string DisCgsOutAcct,
		                          ref string DisCgsOutAcctUnit1,
		                          ref string DisCgsOutAcctUnit2,
		                          ref string DisCgsOutAcctUnit3,
		                          ref string DisCgsOutAcctUnit4,
		                          ref string DisCgsOutAcctDesc,
		                          ref string DisCgsVovhdAcct,
		                          ref string DisCgsVovhdAcctUnit1,
		                          ref string DisCgsVovhdAcctUnit2,
		                          ref string DisCgsVovhdAcctUnit3,
		                          ref string DisCgsVovhdAcctUnit4,
		                          ref string DisCgsVovhdAcctDesc,
		                          ref string DisCgsFovhdAcct,
		                          ref string DisCgsFovhdAcctUnit1,
		                          ref string DisCgsFovhdAcctUnit2,
		                          ref string DisCgsFovhdAcctUnit3,
		                          ref string DisCgsFovhdAcctUnit4,
		                          ref string DisCgsFovhdAcctDesc);
	}
	
	public class GetProjDistAcctInfo : IGetProjDistAcctInfo
	{
		readonly IApplicationDB appDB;
		
		public GetProjDistAcctInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetProjDistAcctInfoSp(string ProductCode,
		                                 ref string DisCgsAcct,
		                                 ref string DisCgsAcctUnit1,
		                                 ref string DisCgsAcctUnit2,
		                                 ref string DisCgsAcctUnit3,
		                                 ref string DisCgsAcctUnit4,
		                                 ref string DisCgsAcctDesc,
		                                 ref string DisCgsLbrAcct,
		                                 ref string DisCgsLbrAcctUnit1,
		                                 ref string DisCgsLbrAcctUnit2,
		                                 ref string DisCgsLbrAcctUnit3,
		                                 ref string DisCgsLbrAcctUnit4,
		                                 ref string DisCgsLbrAcctDesc,
		                                 ref string DisCgsOutAcct,
		                                 ref string DisCgsOutAcctUnit1,
		                                 ref string DisCgsOutAcctUnit2,
		                                 ref string DisCgsOutAcctUnit3,
		                                 ref string DisCgsOutAcctUnit4,
		                                 ref string DisCgsOutAcctDesc,
		                                 ref string DisCgsVovhdAcct,
		                                 ref string DisCgsVovhdAcctUnit1,
		                                 ref string DisCgsVovhdAcctUnit2,
		                                 ref string DisCgsVovhdAcctUnit3,
		                                 ref string DisCgsVovhdAcctUnit4,
		                                 ref string DisCgsVovhdAcctDesc,
		                                 ref string DisCgsFovhdAcct,
		                                 ref string DisCgsFovhdAcctUnit1,
		                                 ref string DisCgsFovhdAcctUnit2,
		                                 ref string DisCgsFovhdAcctUnit3,
		                                 ref string DisCgsFovhdAcctUnit4,
		                                 ref string DisCgsFovhdAcctDesc)
		{
			ProductCodeType _ProductCode = ProductCode;
			AcctType _DisCgsAcct = DisCgsAcct;
			UnitCode1Type _DisCgsAcctUnit1 = DisCgsAcctUnit1;
			UnitCode2Type _DisCgsAcctUnit2 = DisCgsAcctUnit2;
			UnitCode3Type _DisCgsAcctUnit3 = DisCgsAcctUnit3;
			UnitCode4Type _DisCgsAcctUnit4 = DisCgsAcctUnit4;
			DescriptionType _DisCgsAcctDesc = DisCgsAcctDesc;
			AcctType _DisCgsLbrAcct = DisCgsLbrAcct;
			UnitCode1Type _DisCgsLbrAcctUnit1 = DisCgsLbrAcctUnit1;
			UnitCode2Type _DisCgsLbrAcctUnit2 = DisCgsLbrAcctUnit2;
			UnitCode3Type _DisCgsLbrAcctUnit3 = DisCgsLbrAcctUnit3;
			UnitCode4Type _DisCgsLbrAcctUnit4 = DisCgsLbrAcctUnit4;
			DescriptionType _DisCgsLbrAcctDesc = DisCgsLbrAcctDesc;
			AcctType _DisCgsOutAcct = DisCgsOutAcct;
			UnitCode1Type _DisCgsOutAcctUnit1 = DisCgsOutAcctUnit1;
			UnitCode2Type _DisCgsOutAcctUnit2 = DisCgsOutAcctUnit2;
			UnitCode3Type _DisCgsOutAcctUnit3 = DisCgsOutAcctUnit3;
			UnitCode4Type _DisCgsOutAcctUnit4 = DisCgsOutAcctUnit4;
			DescriptionType _DisCgsOutAcctDesc = DisCgsOutAcctDesc;
			AcctType _DisCgsVovhdAcct = DisCgsVovhdAcct;
			UnitCode1Type _DisCgsVovhdAcctUnit1 = DisCgsVovhdAcctUnit1;
			UnitCode2Type _DisCgsVovhdAcctUnit2 = DisCgsVovhdAcctUnit2;
			UnitCode3Type _DisCgsVovhdAcctUnit3 = DisCgsVovhdAcctUnit3;
			UnitCode4Type _DisCgsVovhdAcctUnit4 = DisCgsVovhdAcctUnit4;
			DescriptionType _DisCgsVovhdAcctDesc = DisCgsVovhdAcctDesc;
			AcctType _DisCgsFovhdAcct = DisCgsFovhdAcct;
			UnitCode1Type _DisCgsFovhdAcctUnit1 = DisCgsFovhdAcctUnit1;
			UnitCode2Type _DisCgsFovhdAcctUnit2 = DisCgsFovhdAcctUnit2;
			UnitCode3Type _DisCgsFovhdAcctUnit3 = DisCgsFovhdAcctUnit3;
			UnitCode4Type _DisCgsFovhdAcctUnit4 = DisCgsFovhdAcctUnit4;
			DescriptionType _DisCgsFovhdAcctDesc = DisCgsFovhdAcctDesc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetProjDistAcctInfoSp";
				
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisCgsAcct", _DisCgsAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsAcctUnit1", _DisCgsAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsAcctUnit2", _DisCgsAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsAcctUnit3", _DisCgsAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsAcctUnit4", _DisCgsAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsAcctDesc", _DisCgsAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsLbrAcct", _DisCgsLbrAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsLbrAcctUnit1", _DisCgsLbrAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsLbrAcctUnit2", _DisCgsLbrAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsLbrAcctUnit3", _DisCgsLbrAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsLbrAcctUnit4", _DisCgsLbrAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsLbrAcctDesc", _DisCgsLbrAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsOutAcct", _DisCgsOutAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsOutAcctUnit1", _DisCgsOutAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsOutAcctUnit2", _DisCgsOutAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsOutAcctUnit3", _DisCgsOutAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsOutAcctUnit4", _DisCgsOutAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsOutAcctDesc", _DisCgsOutAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsVovhdAcct", _DisCgsVovhdAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsVovhdAcctUnit1", _DisCgsVovhdAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsVovhdAcctUnit2", _DisCgsVovhdAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsVovhdAcctUnit3", _DisCgsVovhdAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsVovhdAcctUnit4", _DisCgsVovhdAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsVovhdAcctDesc", _DisCgsVovhdAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsFovhdAcct", _DisCgsFovhdAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsFovhdAcctUnit1", _DisCgsFovhdAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsFovhdAcctUnit2", _DisCgsFovhdAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsFovhdAcctUnit3", _DisCgsFovhdAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsFovhdAcctUnit4", _DisCgsFovhdAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisCgsFovhdAcctDesc", _DisCgsFovhdAcctDesc, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DisCgsAcct = _DisCgsAcct;
				DisCgsAcctUnit1 = _DisCgsAcctUnit1;
				DisCgsAcctUnit2 = _DisCgsAcctUnit2;
				DisCgsAcctUnit3 = _DisCgsAcctUnit3;
				DisCgsAcctUnit4 = _DisCgsAcctUnit4;
				DisCgsAcctDesc = _DisCgsAcctDesc;
				DisCgsLbrAcct = _DisCgsLbrAcct;
				DisCgsLbrAcctUnit1 = _DisCgsLbrAcctUnit1;
				DisCgsLbrAcctUnit2 = _DisCgsLbrAcctUnit2;
				DisCgsLbrAcctUnit3 = _DisCgsLbrAcctUnit3;
				DisCgsLbrAcctUnit4 = _DisCgsLbrAcctUnit4;
				DisCgsLbrAcctDesc = _DisCgsLbrAcctDesc;
				DisCgsOutAcct = _DisCgsOutAcct;
				DisCgsOutAcctUnit1 = _DisCgsOutAcctUnit1;
				DisCgsOutAcctUnit2 = _DisCgsOutAcctUnit2;
				DisCgsOutAcctUnit3 = _DisCgsOutAcctUnit3;
				DisCgsOutAcctUnit4 = _DisCgsOutAcctUnit4;
				DisCgsOutAcctDesc = _DisCgsOutAcctDesc;
				DisCgsVovhdAcct = _DisCgsVovhdAcct;
				DisCgsVovhdAcctUnit1 = _DisCgsVovhdAcctUnit1;
				DisCgsVovhdAcctUnit2 = _DisCgsVovhdAcctUnit2;
				DisCgsVovhdAcctUnit3 = _DisCgsVovhdAcctUnit3;
				DisCgsVovhdAcctUnit4 = _DisCgsVovhdAcctUnit4;
				DisCgsVovhdAcctDesc = _DisCgsVovhdAcctDesc;
				DisCgsFovhdAcct = _DisCgsFovhdAcct;
				DisCgsFovhdAcctUnit1 = _DisCgsFovhdAcctUnit1;
				DisCgsFovhdAcctUnit2 = _DisCgsFovhdAcctUnit2;
				DisCgsFovhdAcctUnit3 = _DisCgsFovhdAcctUnit3;
				DisCgsFovhdAcctUnit4 = _DisCgsFovhdAcctUnit4;
				DisCgsFovhdAcctDesc = _DisCgsFovhdAcctDesc;
				
				return Severity;
			}
		}
	}
}
