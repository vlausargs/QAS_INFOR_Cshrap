//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InventoryBalance.cs

using System;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;
using CSI.Admin;
using CSI.Material;
using CSI.Data.Cache;
using System.Collections.Generic;

namespace CSI.Reporting
{
    public class Rpt_InventoryBalance : IRpt_InventoryBalance
    {
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IGetWinRegDecGroup iGetWinRegDecGroup;
        readonly IFixMaskForCrystal iFixMaskForCrystal;
        readonly IApplyDateOffset iApplyDateOffset;
        readonly IIsFeatureActive iIsFeatureActive;
        readonly IDefineVariable iDefineVariable;
        readonly IScalarFunction scalarFunction;
        readonly IConvertToUtil convertToUtil;
        readonly IHighString highString;
        readonly ILowCharacter lowCharacter;
        readonly IGetSiteDate iGetSiteDate;
        readonly IDateTimeUtil dateTimeUtil;
        readonly IStringUtil stringUtil;
        readonly IHighDate iHighDate;
        readonly IDayEndOf iDayEndOf;
        readonly IMtCodes iMtCodes;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IRpt_InventoryBalanceCRUD iRpt_InventoryBalanceCRUD;
        readonly int recordCap;
        readonly LoadType loadType;

        public Rpt_InventoryBalance(
            IBunchedLoadCollection bunchedLoadCollection,
            IGetWinRegDecGroup iGetWinRegDecGroup,
            IFixMaskForCrystal iFixMaskForCrystal,
            IApplyDateOffset iApplyDateOffset,
            IIsFeatureActive iIsFeatureActive,
            IDefineVariable iDefineVariable,
            IScalarFunction scalarFunction,
            IConvertToUtil convertToUtil,
            IHighString highString,
            ILowCharacter lowCharacter,
            IGetSiteDate iGetSiteDate,
            IDateTimeUtil dateTimeUtil,
            IStringUtil stringUtil,
            IHighDate iHighDate,
            IDayEndOf iDayEndOf,
            IMtCodes iMtCodes,
            ISQLValueComparerUtil sQLUtil,
            IRpt_InventoryBalanceCRUD iRpt_InventoryBalanceCRUD)
        {
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.iGetWinRegDecGroup = iGetWinRegDecGroup;
            this.iFixMaskForCrystal = iFixMaskForCrystal;
            this.iApplyDateOffset = iApplyDateOffset;
            this.iIsFeatureActive = iIsFeatureActive;
            this.iDefineVariable = iDefineVariable;
            this.scalarFunction = scalarFunction;
            this.convertToUtil = convertToUtil;
            this.highString = highString;
            this.lowCharacter = lowCharacter;
            this.iGetSiteDate = iGetSiteDate;
            this.dateTimeUtil = dateTimeUtil;
            this.stringUtil = stringUtil;
            this.iHighDate = iHighDate;
            this.iDayEndOf = iDayEndOf;
            this.iMtCodes = iMtCodes;
            this.sQLUtil = sQLUtil;
            this.iRpt_InventoryBalanceCRUD = iRpt_InventoryBalanceCRUD;
            this.recordCap = bunchedLoadCollection.RecordCap == -1 ? 200 : bunchedLoadCollection.RecordCap;
            this.loadType = bunchedLoadCollection.LoadType;
            
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        Rpt_InventoryBalanceSp(
            string ProductCodeStarting = null,
            string ProductCodeEnding = null,
            string ItemStarting = null,
            string ItemEnding = null,
            string WhseStarting = null,
            string WhseEnding = null,
            string LocStarting = null,
            string LocEnding = null,
            DateTime? TransDateStarting = null,
            DateTime? TransDateEnding = null,
            string ReasonCodeStarting = null,
            string ReasonCodeEnding = null,
            int? SummaryDtl = 0,
            int? OneItmPerPg = null,
            int? IncludeMoveTrn = null,
            int? IncludeNonNetStk = null,
            int? DisplayHeader = null,
            int? TransDateStartingOffset = null,
            int? TransDateEndingOffset = null,
            string pSite = null,
            string MessageLanguage = null,
            string DocumentNumStarting = null,
            string DocumentNumEnding = null,
            Guid? ProcessId = null)
        { 
            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();

            try
            {
                ICollectionLoadResponse Data = null;
                string ALTGEN_SpName = null;
                int? ALTGEN_Severity = null;
                int? rowCount = null;
                int? AllReasonCode = null;
                int? AllItem = null;
                int? AllWhse = null;
                int? AllLoc = null;
                int? AllProdCode = null;
                int? AllDocumentNum = null;
                string LowChar = null;
                int? CostItemAtWhse = null;
                string Infobar = null;
                DateTime? TransDateEndingOutput = null;
                int? Severity = null;
                string Site = null;
                DateTime? Today = null;
                int? iTemp = null;
                string XDomCurrency = null;
                int? DecimalPlaces = null;
                int? IntPosition = null;
                string DomCurrencyFormat = null;
                int? DomCurrencyPlaces = null;
                string DomTotCurrencyFormat = null;
                int? DomTotCurrencyPlaces = null;
                string CostPriceFormat = null;
                int? CostPricePlaces = null;
                string UnitQtyFormat = null;
                int? UnitQtyPlaces = null;
                ItemType _item = DBNull.Value;
                CostPrcType _cost = DBNull.Value;
                string ProductName = null;
                string FeatureRS8938 = null;
                int? FeatureRS8938Active = null;
                string FeatureInfoBar = null;
                if (this.iRpt_InventoryBalanceCRUD.Optional_ModuleForExists())
                {
                    this.iRpt_InventoryBalanceCRUD.DeclareAltgenTable();
                    this.iRpt_InventoryBalanceCRUD.InsertOptional_Module1();

                    while (this.iRpt_InventoryBalanceCRUD.Tv_ALTGENForExists())
                    {
                        (ALTGEN_SpName, rowCount) = this.iRpt_InventoryBalanceCRUD.LoadTv_ALTGEN1(ALTGEN_SpName);
                        var ALTGEN = this.iRpt_InventoryBalanceCRUD.AltExtGen_Rpt_InventoryBalanceSp(ALTGEN_SpName,
                            ProductCodeStarting,
                            ProductCodeEnding,
                            ItemStarting,
                            ItemEnding,
                            WhseStarting,
                            WhseEnding,
                            LocStarting,
                            LocEnding,
                            TransDateStarting,
                            TransDateEnding,
                            ReasonCodeStarting,
                            ReasonCodeEnding,
                            SummaryDtl,
                            OneItmPerPg,
                            IncludeMoveTrn,
                            IncludeNonNetStk,
                            DisplayHeader,
                            TransDateStartingOffset,
                            TransDateEndingOffset,
                            pSite,
                            MessageLanguage,
                            DocumentNumStarting,
                            DocumentNumEnding);
                        ALTGEN_Severity = ALTGEN.ReturnCode;

                        if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                        {
                            return (ALTGEN.Data, ALTGEN_Severity);

                        }
                        this.iRpt_InventoryBalanceCRUD.DeleteTv_ALTGEN2(ALTGEN_SpName);

                    }

                }
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_InventoryBalanceSp") != null)
                {
                    var EXTGEN = this.iRpt_InventoryBalanceCRUD.AltExtGen_Rpt_InventoryBalanceSp("dbo.EXTGEN_Rpt_InventoryBalanceSp",
                        ProductCodeStarting,
                        ProductCodeEnding,
                        ItemStarting,
                        ItemEnding,
                        WhseStarting,
                        WhseEnding,
                        LocStarting,
                        LocEnding,
                        TransDateStarting,
                        TransDateEnding,
                        ReasonCodeStarting,
                        ReasonCodeEnding,
                        SummaryDtl,
                        OneItmPerPg,
                        IncludeMoveTrn,
                        IncludeNonNetStk,
                        DisplayHeader,
                        TransDateStartingOffset,
                        TransDateEndingOffset,
                        pSite,
                        MessageLanguage,
                        DocumentNumStarting,
                        DocumentNumEnding);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity);
                    }
                }

                this.iRpt_InventoryBalanceCRUD.SetXact_Abort();
                this.iRpt_InventoryBalanceCRUD.SetIsolationLevel();

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: DefineVariableSp
                var DefineVariable = this.iDefineVariable.DefineVariableSp(
                    VariableName: "MessageLanguage",
                    VariableValue: MessageLanguage,
                    Infobar: Infobar);
                Infobar = DefineVariable.Infobar;

                #endregion ExecuteMethodCall

                LowChar = convertToUtil.ToString(lowCharacter.LowCharacterFn());
                AllReasonCode = convertToUtil.ToInt32((ReasonCodeStarting == null && ReasonCodeEnding == null ? 1 : 0));
                AllItem = convertToUtil.ToInt32((ItemStarting == null && ItemEnding == null ? 1 : 0));
                AllWhse = convertToUtil.ToInt32((WhseStarting == null && WhseEnding == null ? 1 : 0));
                AllLoc = convertToUtil.ToInt32((LocStarting == null && LocEnding == null ? 1 : 0));
                AllProdCode = convertToUtil.ToInt32((ProductCodeStarting == null && ProductCodeEnding == null ? 1 : 0));
                AllDocumentNum = convertToUtil.ToInt32((DocumentNumStarting == null && DocumentNumEnding == null ? 1 : 0));
                WhseStarting = stringUtil.IsNull(
                    WhseStarting,
                    LowChar);
                WhseEnding = stringUtil.IsNull(
                    WhseEnding,
                    this.highString.HighStringFn("WhseType"));
                LocStarting = stringUtil.IsNull(
                    LocStarting,
                    LowChar);
                LocEnding = stringUtil.IsNull(
                    LocEnding,
                    this.highString.HighStringFn("LocType"));
                OneItmPerPg = (int?)(stringUtil.IsNull(
                    OneItmPerPg,
                    0));
                IncludeMoveTrn = (int?)(stringUtil.IsNull(
                    IncludeMoveTrn,
                    0));
                IncludeNonNetStk = (int?)(stringUtil.IsNull(
                    IncludeNonNetStk,
                    0));
                DisplayHeader = (int?)(stringUtil.IsNull(
                    DisplayHeader,
                    0));
                DocumentNumStarting = stringUtil.IsNull(
                    DocumentNumStarting,
                    LowChar);
                DocumentNumEnding = stringUtil.IsNull(
                    DocumentNumEnding,
                    this.highString.HighStringFn("DocumentNumType"));
                TransDateEndingOutput = convertToUtil.ToDateTime(TransDateEnding);

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
                var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(
                    Date: TransDateStarting,
                    Offset: TransDateStartingOffset,
                    IsEndDate: 0);
                TransDateStarting = ApplyDateOffset.Date;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
                var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(
                    Date: TransDateEnding,
                    Offset: TransDateEndingOffset,
                    IsEndDate: 1);
                TransDateEnding = ApplyDateOffset1.Date;

                #endregion ExecuteMethodCall

                Severity = 0;
                if (loadType == LoadType.First)
                {
                    //this temp table is a table variable in old stored procedure version.
                    this.iRpt_InventoryBalanceCRUD.DeclareTmpInvrptSummSetTable();

                    this.iRpt_InventoryBalanceCRUD.DeclareTmpItemTable();

                    //this temp table is a table variable in old stored procedure version.
                    this.iRpt_InventoryBalanceCRUD.DeclareTmpSumTable();
                    //this temp table is a table variable in old stored procedure version.
                    this.iRpt_InventoryBalanceCRUD.DeclareTmpLotLocTable();
                    //this temp table is a table variable in old stored procedure version.
                    this.iRpt_InventoryBalanceCRUD.DeclareTmpItemLocTable();
                    //this temp table is a table variable in old stored procedure version.
                    this.iRpt_InventoryBalanceCRUD.DeclareTmpItemLifoTable();
                    this.iRpt_InventoryBalanceCRUD.DeclareTmpMatltranTable();                   
                }
                (Site, rowCount) = this.iRpt_InventoryBalanceCRUD.LoadParms(Site);
                (XDomCurrency, DomCurrencyPlaces, DomCurrencyFormat, DomTotCurrencyFormat, CostPricePlaces, CostPriceFormat, rowCount) = this.iRpt_InventoryBalanceCRUD.LoadCurrparms(XDomCurrency, DomCurrencyFormat, DomCurrencyPlaces, DomTotCurrencyFormat, CostPriceFormat, CostPricePlaces);
                (UnitQtyFormat, UnitQtyPlaces, rowCount) = this.iRpt_InventoryBalanceCRUD.LoadINVPARMS(UnitQtyFormat, UnitQtyPlaces);
                DomCurrencyFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                    DomCurrencyFormat,
                    this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                DomTotCurrencyFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                    DomTotCurrencyFormat,
                    this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                CostPriceFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                    CostPriceFormat,
                    this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                UnitQtyFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                    UnitQtyFormat,
                    this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                DecimalPlaces = 0;
                IntPosition = convertToUtil.ToInt32(stringUtil.CharIndex(
                    ".",
                    DomTotCurrencyFormat));
                if (sQLUtil.SQLGreaterThan(IntPosition, 0) == true)
                {
                    iTemp = convertToUtil.ToInt32(stringUtil.Len(DomTotCurrencyFormat));
                    DecimalPlaces = convertToUtil.ToInt32(stringUtil.Len(stringUtil.Substring(
                        DomTotCurrencyFormat,
                        IntPosition + 1,
                        iTemp)));

                }
                DomTotCurrencyPlaces = DecimalPlaces;
                (CostItemAtWhse, rowCount) = this.iRpt_InventoryBalanceCRUD.LoadDbo_Invparms(CostItemAtWhse);

                if (loadType == LoadType.First)
                {
                    this.iRpt_InventoryBalanceCRUD.InsertTmpItem(CostItemAtWhse,
                        AllItem,
                        AllDocumentNum,
                        IncludeNonNetStk,
                        WhseStarting,
                        WhseEnding,
                        ProductCodeStarting,
                        ProductCodeEnding,
                        ItemStarting,
                        ItemEnding,
                        LocStarting,
                        LocEnding,
                        DocumentNumStarting,
                        DocumentNumEnding);     

                    this.iRpt_InventoryBalanceCRUD.InsertLotloc(WhseStarting, WhseEnding, LocStarting, LocEnding);
                   
                    this.iRpt_InventoryBalanceCRUD.InsertItemloc(WhseStarting, WhseEnding, LocStarting, LocEnding, IncludeNonNetStk);

                    this.iRpt_InventoryBalanceCRUD.InsertItemLifo(CostItemAtWhse, WhseStarting, WhseEnding);

                    Today = convertToUtil.ToDateTime(this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE")));

                    this.iRpt_InventoryBalanceCRUD.InsertToSum(IncludeNonNetStk);
                   
                    this.iRpt_InventoryBalanceCRUD.InsertToSum1();
                   
                    this.iRpt_InventoryBalanceCRUD.InsertToSum2(WhseStarting, WhseEnding, LocStarting, LocEnding, IncludeNonNetStk);

                    this.iRpt_InventoryBalanceCRUD.UpdateItem();

                    this.iRpt_InventoryBalanceCRUD.InsertMatltran(
                        IncludeNonNetStk,
                        AllWhse,
                        LowChar,
                        AllLoc,
                        AllReasonCode,
                        AllDocumentNum,
                        TransDateStarting,
                        Today,
                        WhseStarting,
                        WhseEnding,
                        LocStarting,
                        LocEnding,
                        ReasonCodeStarting,
                        ReasonCodeEnding,
                        DocumentNumStarting,
                        DocumentNumEnding);


                    this.iRpt_InventoryBalanceCRUD.DeclareTmpTranSumTable();

                    this.iRpt_InventoryBalanceCRUD.InsertTranSum1(DomCurrencyPlaces);

                    this.iRpt_InventoryBalanceCRUD.UpdateTransum2(DomCurrencyPlaces);

                    /*Needs to load at least one column from the table: #tv_SUM for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    this.iRpt_InventoryBalanceCRUD.DeleteTv_SUM3();

                    this.iRpt_InventoryBalanceCRUD.InsertSum4(TransDateStarting);

                    this.iRpt_InventoryBalanceCRUD.UpdateItem1();

                    this.iRpt_InventoryBalanceCRUD.UpdateItem2();

                    this.iRpt_InventoryBalanceCRUD.UpdateItem3();

                    if (sQLUtil.SQLBool(sQLUtil.SQLEqual(SummaryDtl, 0)))
                    {
                        this.iRpt_InventoryBalanceCRUD.Tnsert_Invrpt_Summ_Set(TransDateStarting, TransDateEnding, IncludeMoveTrn);
                        this.iRpt_InventoryBalanceCRUD.Insert_Invrpt_Summ_Set_others();
                    }
                    else
                    {
                        this.iRpt_InventoryBalanceCRUD.DeclareTmpMatltranInfoTable();

                        this.iRpt_InventoryBalanceCRUD.InsertMatltraninfo1(Site, TransDateStarting, TransDateEnding);
                        
                        this.iRpt_InventoryBalanceCRUD.InsertMatltranInfoTemp();

                        this.iRpt_InventoryBalanceCRUD.InsertMatltraninfo2(Site);


                        #region CRUD ExecuteMethodCall

                        //Please Generate the bounce for this stored procedure: MtCodesSp
                        var MtCodes = this.iMtCodes.MtCodesSp(
                            HyperspeedMode: 1,
                            Infobar: Infobar);
                        Infobar = MtCodes.Infobar;

                        #endregion ExecuteMethodCall

                    }
                }
                ProductName = "CSI";
                FeatureRS8938 = "RS8938";
                FeatureRS8938Active = 1;

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: IsFeatureActiveSp
                var IsFeatureActive = this.iIsFeatureActive.IsFeatureActiveSp(
                    ProductName: ProductName,
                    FeatureID: FeatureRS8938,
                    FeatureActive: FeatureRS8938Active,
                    InfoBar: FeatureInfoBar);
                Severity = IsFeatureActive.ReturnCode;
                FeatureRS8938Active = IsFeatureActive.FeatureActive;
                FeatureInfoBar = IsFeatureActive.InfoBar;

                #endregion ExecuteMethodCall

                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                {
                    return (Data, Severity);
                }

                if(loadType == LoadType.First)
                { 
                    if (sQLUtil.SQLBool(sQLUtil.SQLEqual(SummaryDtl, 0)))
                    {
                        this.iRpt_InventoryBalanceCRUD.Insert_Invrpt_Det_Summ_Merged(ProcessId);
                    }
                    else
                    {
                        if (sQLUtil.SQLBool(sQLUtil.SQLEqual(SummaryDtl, 1)))
                        {
                            this.iRpt_InventoryBalanceCRUD.InsertMatltranInfo3(ProcessId);
                            /*Needs to load at least one column from the table: #tv_invrpt_det_summ_merged for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                            this.iRpt_InventoryBalanceCRUD.DeleteTv_Invrpt_Det_Summ_Merged1(IncludeMoveTrn, ProcessId);

                            this.iRpt_InventoryBalanceCRUD.InsertInvrpt_Det_Summ_Merged(ProcessId);

                            this.iRpt_InventoryBalanceCRUD.UpdateTv_Invrpt_Det_Summ_Merged2(ProcessId);                            
                        }

                    }

                }

                if (sQLUtil.SQLEqual(dateTimeUtil.DateDiff("Day", TransDateEnding, this.iHighDate.HighDateFn()), 0) == true)
                {
                    TransDateEndingOutput = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(scalarFunction.Execute<DateTime>("GETDATE")));
                }
               
                Data = this.iRpt_InventoryBalanceCRUD.SelectTv_Invrpt_Det_Summ_Merged3(TransDateStarting,
                TransDateEndingOutput,
                DomCurrencyFormat,
                DomCurrencyPlaces,
                DomTotCurrencyFormat,
                DomTotCurrencyPlaces,
                CostPriceFormat,
                CostPricePlaces,
                UnitQtyFormat,
                UnitQtyPlaces,
                FeatureRS8938Active,
                ProcessId,
                loadType,
                recordCap);

                if(recordCap == 0 || Data.Items.Count <= recordCap)
                {
                   this.iRpt_InventoryBalanceCRUD.CleanupInventoryBalanceResult(ProcessId);
                }

                return (Data, Severity);
            }
            finally
            {
                if (bunchedLoadCollection != null)
                    bunchedLoadCollection.EndBunching();
            }
        }

    }
}
