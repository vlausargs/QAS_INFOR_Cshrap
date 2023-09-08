//PROJECT NAME: FinanceExt
//CLASS NAME: SLFamasters.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using CSI.Finance.FixedAssets;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLFamasters")]
    public class SLFamasters : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int VerifyFaClassDeptSp(string PFaClass,
                                        string PDept,
                                        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLFamastersExt = new VerifyFaClassDeptFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iSLFamastersExt.VerifyFaClassDeptSp(PFaClass,
                                                                   PDept,
                                                                   ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int IsFixAssetExistSp(string FaNum,
                                     ref byte? IsExist,
                                     ref string FaClass,
                                     ref string FaDept,
                                     ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLFamastersExt = new IsFixAssetExistFactory().Create(appDb);

                ListYesNoType oIsExist = IsExist;
                FaClassType oFaClass = FaClass;
                DeptType oFaDept = FaDept;
                InfobarType oInfobar = Infobar;

                int Severity = iSLFamastersExt.IsFixAssetExistSp(FaNum,
                                                                 ref oIsExist,
                                                                 ref oFaClass,
                                                                 ref oFaDept,
                                                                 ref oInfobar);

                IsExist = oIsExist;
                FaClass = oFaClass;
                FaDept = oFaDept;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetFADeprInfoSp(string pFaNum,
                                   ref byte? pFixedAssetDeprExist,
                                   ref byte? pNotAllUnitAccumDeprIsZero)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLFamastersExt = new GetFADeprInfoFactory().Create(appDb);

                ListYesNoType opFixedAssetDeprExist = pFixedAssetDeprExist;
                ListYesNoType opNotAllUnitAccumDeprIsZero = pNotAllUnitAccumDeprIsZero;

                int Severity = iSLFamastersExt.GetFADeprInfoSp(pFaNum,
                                                               ref opFixedAssetDeprExist,
                                                               ref opNotAllUnitAccumDeprIsZero);

                pFixedAssetDeprExist = opFixedAssetDeprExist;
                pNotAllUnitAccumDeprIsZero = opNotAllUnitAccumDeprIsZero;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateParentFaNumSp(string FaNum,
                                         string ParentFaNum,
                                         ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iValidateParentFaNumExt = new ValidateParentFaNumFactory().Create(appDb);

                var result = iValidateParentFaNumExt.ValidateParentFaNumSp(FaNum,
                                                                           ParentFaNum,
                                                                           Infobar);

                int Severity = result.ReturnCode.Value;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int UpdateCurrentPeriodDepreciationToZeroSp(string pFaNum,
        ref int? pNeedToUpdateCurPerDepr)
        {
            var iUpdateCurrentPeriodDepreciationToZeroExt = this.GetService<IUpdateCurrentPeriodDepreciationToZero>();

            var result = iUpdateCurrentPeriodDepreciationToZeroExt.UpdateCurrentPeriodDepreciationToZeroSp(pFaNum,
            pNeedToUpdateCurPerDepr);
            int Severity = result.ReturnCode.Value;
            pNeedToUpdateCurPerDepr = result.pNeedToUpdateCurPerDepr;
            return Severity;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int UpdateUnitToDeprSp(string FaNum,
        int? UsefulLife,
        int? UsefulLifeMonth,
        ref int? UpdateUnitsToDepr,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iUpdateUnitToDeprExt = new UpdateUnitToDeprFactory().Create(appDb);

                var result = iUpdateUnitToDeprExt.UpdateUnitToDeprSp(FaNum,
                UsefulLife,
                UsefulLifeMonth,
                UpdateUnitsToDepr,
                Infobar);

                int Severity = result.ReturnCode.Value;
                UpdateUnitsToDepr = result.UpdateUnitsToDepr;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_FixedAssetDetailTranSp([Optional] string Ref)
        {
            var iCLM_FixedAssetDetailTranExt = new CLM_FixedAssetDetailTranFactory().Create(this, true);

            var result = iCLM_FixedAssetDetailTranExt.CLM_FixedAssetDetailTranSp(Ref);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable GetAvailableParentFaNumSp(string FaNum)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iGetAvailableParentFaNumExt = new GetAvailableParentFaNumFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iGetAvailableParentFaNumExt.GetAvailableParentFaNumSp(FaNum);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }
    }
}