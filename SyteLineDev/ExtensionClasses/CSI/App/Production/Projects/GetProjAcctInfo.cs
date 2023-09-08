//PROJECT NAME: CSIProjects
//CLASS NAME: GetProjAcctInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IGetProjAcctInfo
	{
		int GetProjAcctInfoSp(string ProductCode,
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
		                      ref string DisCgsFovhdAcctDesc,
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
		                      ref string ProjGaAcctDesc,
		                      string ProjEndUserType);
	}
	
	public class GetProjAcctInfo : IGetProjAcctInfo
	{
		readonly IApplicationDB appDB;
		
		public GetProjAcctInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetProjAcctInfoSp(string ProductCode,
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
		                             ref string DisCgsFovhdAcctDesc,
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
		                             ref string ProjGaAcctDesc,
		                             string ProjEndUserType)
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
			EndUserType _ProjEndUserType = ProjEndUserType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetProjAcctInfoSp";
				
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
				appDB.AddCommandParameter(cmd, "ProjEndUserType", _ProjEndUserType, ParameterDirection.Input);
				
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
