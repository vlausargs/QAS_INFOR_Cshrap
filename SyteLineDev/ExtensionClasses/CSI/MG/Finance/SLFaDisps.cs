//PROJECT NAME: FinanceExt
//CLASS NAME: SLFaDisps.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Finance.FixedAssets;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLFaDisps")]
    public class SLFaDisps : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int DFaDispSp(string pFaNum,
                             ref decimal? pFaPurchaseAmount,
                             ref decimal? pFaEnhancementAmount,
                             ref decimal? pCurrentValue,
                             ref decimal? pAccumDeprec,
                             ref string pAccumAcct,
                             ref string pAccumAcctDescription,
                             ref string pGLAssetAcctDescription,
                             ref string pDepDescription,
                             ref string pGLAssetAcct,
                             ref string pFaClassCode,
                             ref string pFaDescription,
                             ref string pFaStatus,
                             ref string pDepartment,
                             ref string pGLAssetAcctUnit1,
                             ref string pGLAssetAcctUnit2,
                             ref string pGLAssetAcctUnit3,
                             ref string pGLAssetAcctUnit4,
                             ref string pAccumAcctUnit1,
                             ref string pAccumAcctUnit2,
                             ref string pAccumAcctUnit3,
                             ref string pAccumAcctUnit4)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLFaDispsExt = new DFaDispFactory().Create(appDb);

                AmountType opFaPurchaseAmount = pFaPurchaseAmount;
                AmountType opFaEnhancementAmount = pFaEnhancementAmount;
                AmountType opCurrentValue = pCurrentValue;
                AmountType opAccumDeprec = pAccumDeprec;
                AcctType opAccumAcct = pAccumAcct;
                DescriptionType opAccumAcctDescription = pAccumAcctDescription;
                DescriptionType opGLAssetAcctDescription = pGLAssetAcctDescription;
                DescriptionType opDepDescription = pDepDescription;
                AcctType opGLAssetAcct = pGLAssetAcct;
                FaClassType opFaClassCode = pFaClassCode;
                DescriptionType opFaDescription = pFaDescription;
                FaStatusType opFaStatus = pFaStatus;
                DeptType opDepartment = pDepartment;
                UnitCode1Type opGLAssetAcctUnit1 = pGLAssetAcctUnit1;
                UnitCode2Type opGLAssetAcctUnit2 = pGLAssetAcctUnit2;
                UnitCode3Type opGLAssetAcctUnit3 = pGLAssetAcctUnit3;
                UnitCode4Type opGLAssetAcctUnit4 = pGLAssetAcctUnit4;
                UnitCode1Type opAccumAcctUnit1 = pAccumAcctUnit1;
                UnitCode2Type opAccumAcctUnit2 = pAccumAcctUnit2;
                UnitCode3Type opAccumAcctUnit3 = pAccumAcctUnit3;
                UnitCode4Type opAccumAcctUnit4 = pAccumAcctUnit4;

                int Severity = iSLFaDispsExt.DFaDispSp(pFaNum,
                                                       ref opFaPurchaseAmount,
                                                       ref opFaEnhancementAmount,
                                                       ref opCurrentValue,
                                                       ref opAccumDeprec,
                                                       ref opAccumAcct,
                                                       ref opAccumAcctDescription,
                                                       ref opGLAssetAcctDescription,
                                                       ref opDepDescription,
                                                       ref opGLAssetAcct,
                                                       ref opFaClassCode,
                                                       ref opFaDescription,
                                                       ref opFaStatus,
                                                       ref opDepartment,
                                                       ref opGLAssetAcctUnit1,
                                                       ref opGLAssetAcctUnit2,
                                                       ref opGLAssetAcctUnit3,
                                                       ref opGLAssetAcctUnit4,
                                                       ref opAccumAcctUnit1,
                                                       ref opAccumAcctUnit2,
                                                       ref opAccumAcctUnit3,
                                                       ref opAccumAcctUnit4);

                pFaPurchaseAmount = opFaPurchaseAmount;
                pFaEnhancementAmount = opFaEnhancementAmount;
                pCurrentValue = opCurrentValue;
                pAccumDeprec = opAccumDeprec;
                pAccumAcct = opAccumAcct;
                pAccumAcctDescription = opAccumAcctDescription;
                pGLAssetAcctDescription = opGLAssetAcctDescription;
                pDepDescription = opDepDescription;
                pGLAssetAcct = opGLAssetAcct;
                pFaClassCode = opFaClassCode;
                pFaDescription = opFaDescription;
                pFaStatus = opFaStatus;
                pDepartment = opDepartment;
                pGLAssetAcctUnit1 = opGLAssetAcctUnit1;
                pGLAssetAcctUnit2 = opGLAssetAcctUnit2;
                pGLAssetAcctUnit3 = opGLAssetAcctUnit3;
                pGLAssetAcctUnit4 = opGLAssetAcctUnit4;
                pAccumAcctUnit1 = opAccumAcctUnit1;
                pAccumAcctUnit2 = opAccumAcctUnit2;
                pAccumAcctUnit3 = opAccumAcctUnit3;
                pAccumAcctUnit4 = opAccumAcctUnit4;


                return Severity;
            }
        }
    }
}
