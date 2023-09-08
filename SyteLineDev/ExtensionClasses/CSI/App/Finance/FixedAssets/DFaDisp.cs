//PROJECT NAME: CSIFinance
//CLASS NAME: DFaDisp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.FixedAssets
{
    public interface IDFaDisp
    {
        int DFaDispSp(FaNumType pFaNum,
                      ref AmountType pFaPurchaseAmount,
                      ref AmountType pFaEnhancementAmount,
                      ref AmountType pCurrentValue,
                      ref AmountType pAccumDeprec,
                      ref AcctType pAccumAcct,
                      ref DescriptionType pAccumAcctDescription,
                      ref DescriptionType pGLAssetAcctDescription,
                      ref DescriptionType pDepDescription,
                      ref AcctType pGLAssetAcct,
                      ref FaClassType pFaClassCode,
                      ref DescriptionType pFaDescription,
                      ref FaStatusType pFaStatus,
                      ref DeptType pDepartment,
                      ref UnitCode1Type pGLAssetAcctUnit1,
                      ref UnitCode2Type pGLAssetAcctUnit2,
                      ref UnitCode3Type pGLAssetAcctUnit3,
                      ref UnitCode4Type pGLAssetAcctUnit4,
                      ref UnitCode1Type pAccumAcctUnit1,
                      ref UnitCode2Type pAccumAcctUnit2,
                      ref UnitCode3Type pAccumAcctUnit3,
                      ref UnitCode4Type pAccumAcctUnit4);
    }

    public class DFaDisp : IDFaDisp
    {
        readonly IApplicationDB appDB;

        public DFaDisp(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int DFaDispSp(FaNumType pFaNum,
                             ref AmountType pFaPurchaseAmount,
                             ref AmountType pFaEnhancementAmount,
                             ref AmountType pCurrentValue,
                             ref AmountType pAccumDeprec,
                             ref AcctType pAccumAcct,
                             ref DescriptionType pAccumAcctDescription,
                             ref DescriptionType pGLAssetAcctDescription,
                             ref DescriptionType pDepDescription,
                             ref AcctType pGLAssetAcct,
                             ref FaClassType pFaClassCode,
                             ref DescriptionType pFaDescription,
                             ref FaStatusType pFaStatus,
                             ref DeptType pDepartment,
                             ref UnitCode1Type pGLAssetAcctUnit1,
                             ref UnitCode2Type pGLAssetAcctUnit2,
                             ref UnitCode3Type pGLAssetAcctUnit3,
                             ref UnitCode4Type pGLAssetAcctUnit4,
                             ref UnitCode1Type pAccumAcctUnit1,
                             ref UnitCode2Type pAccumAcctUnit2,
                             ref UnitCode3Type pAccumAcctUnit3,
                             ref UnitCode4Type pAccumAcctUnit4)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DFaDispSp";

                appDB.AddCommandParameter(cmd, "pFaNum", pFaNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pFaPurchaseAmount", pFaPurchaseAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pFaEnhancementAmount", pFaEnhancementAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pCurrentValue", pCurrentValue, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pAccumDeprec", pAccumDeprec, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pAccumAcct", pAccumAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pAccumAcctDescription", pAccumAcctDescription, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pGLAssetAcctDescription", pGLAssetAcctDescription, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pDepDescription", pDepDescription, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pGLAssetAcct", pGLAssetAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pFaClassCode", pFaClassCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pFaDescription", pFaDescription, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pFaStatus", pFaStatus, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pDepartment", pDepartment, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pGLAssetAcctUnit1", pGLAssetAcctUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pGLAssetAcctUnit2", pGLAssetAcctUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pGLAssetAcctUnit3", pGLAssetAcctUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pGLAssetAcctUnit4", pGLAssetAcctUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pAccumAcctUnit1", pAccumAcctUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pAccumAcctUnit2", pAccumAcctUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pAccumAcctUnit3", pAccumAcctUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pAccumAcctUnit4", pAccumAcctUnit4, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}