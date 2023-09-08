//PROJECT NAME: Reporting
//CLASS NAME: Rpt_IndentedCostedBillofMaterial.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;
using CSI.Adapters;
using CSI.Data.Cache;
using CSI.Data.Utilities;

namespace CSI.Reporting
{
    public class Rpt_IndentedCostedBillofMaterial : IRpt_IndentedCostedBillofMaterial
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IGetWinRegDecGroup iGetWinRegDecGroup;
        readonly IFixMaskForCrystal iFixMaskForCrystal;
        readonly IApplyDateOffset iApplyDateOffset;
        readonly IScalarFunction scalarFunction;
        readonly IConvertToUtil convertToUtil;
        readonly IVariableUtil variableUtil;
        readonly IGetSiteDate iGetSiteDate;
        readonly IStringUtil stringUtil;
        readonly IHighString highString;
        readonly ILowString lowString;
        readonly IGetCode iGetCode;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IRpt_IndentedCostedBillofMaterialCRUD iRpt_IndentedCostedBillofMaterialCRUD;

        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IApplicationDB appDB;

        readonly IRecordStreamFactory recordStreamFactory;
        readonly ICache mgSessionVariableBasedCache;
        readonly IQueryLanguage queryLanguage;
        readonly ISortOrderFactory sortOrderFactory;
        readonly LoadType loadType = LoadType.First;
        readonly int pageSize;

        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDefineProcessVariable defineProcessVariable;
        readonly IGetVariable getVariable;
        readonly IBookmarkFactory bookmarkFactory;

        readonly int recordCap;

        readonly IDefineVariable defineVariable;

        public Rpt_IndentedCostedBillofMaterial(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IGetWinRegDecGroup iGetWinRegDecGroup,
            IFixMaskForCrystal iFixMaskForCrystal,
            IApplyDateOffset iApplyDateOffset,
            IScalarFunction scalarFunction,
            IConvertToUtil convertToUtil,
            IVariableUtil variableUtil,
            IGetSiteDate iGetSiteDate,
            IStringUtil stringUtil,
            IHighString highString,
            ILowString lowString,
            IGetCode iGetCode,
            ISQLValueComparerUtil sQLUtil,
            IRpt_IndentedCostedBillofMaterialCRUD iRpt_IndentedCostedBillofMaterialCRUD,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IApplicationDB appDB,
            IRecordStreamFactory recordStreamFactory,
            ISortOrderFactory sortOrderFactory,
            IQueryLanguage queryLanguage,
            ICache mgSessionVariableBasedCache,
            CachePageSize cachePageSize,
            IBunchedLoadCollection bunchedLoadCollection,
            IDefineProcessVariable defineProcessVariable,
            IGetVariable getVariable,
            IBookmarkFactory bookmarkFactory,

            IDefineVariable defineVariable)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iGetWinRegDecGroup = iGetWinRegDecGroup;
            this.iFixMaskForCrystal = iFixMaskForCrystal;
            this.iApplyDateOffset = iApplyDateOffset;
            this.scalarFunction = scalarFunction;
            this.convertToUtil = convertToUtil;
            this.variableUtil = variableUtil;
            this.iGetSiteDate = iGetSiteDate;
            this.stringUtil = stringUtil;
            this.highString = highString;
            this.lowString = lowString;
            this.iGetCode = iGetCode;
            this.sQLUtil = sQLUtil;
            this.iRpt_IndentedCostedBillofMaterialCRUD = iRpt_IndentedCostedBillofMaterialCRUD;

            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.appDB = appDB;
            this.recordStreamFactory = recordStreamFactory;
            this.sortOrderFactory = sortOrderFactory;
            this.queryLanguage = queryLanguage;
            this.mgSessionVariableBasedCache = mgSessionVariableBasedCache;
            this.pageSize = Convert.ToInt32(cachePageSize);


            this.bookmarkFactory = bookmarkFactory;
            this.getVariable = getVariable;
            this.defineProcessVariable = defineProcessVariable;
            this.bunchedLoadCollection = bunchedLoadCollection;

            recordCap = bunchedLoadCollection.RecordCap;
            if (recordCap == -1)
            {
                recordCap = 200;
            }
            loadType = bunchedLoadCollection.LoadType;

            this.defineVariable = defineVariable;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        Rpt_IndentedCostedBillofMaterialSp(
            string ItemStarting = null,
            string ItemEnding = null,
            string ProCodeStarting = null,
            string ProCodeEnding = null,
            string AlternateIDStarting = null,
            string AlternateIDEnding = null,
            string MaterialType = null,
            string Source = null,
            string Stocked = null,
            string ABCCode = null,
            DateTime? EffDate = null,
            string PrBetweenLevel0 = null,
            int? PrLevelZero = null,
            int? DisplayHeader = null,
            int? PrintAlternate = null,
            int? EffDateOffSet = null,
            string pSite = null)
        {

            #region Variable definition

            ICollectionLoadResponse Data = null;

            int? Severity = 0;

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            Guid? RptSessionID = null;
            string item = null;
            string Job = null;
            string description = null;
            string pmtCode = null;
            int? Suff = null;
            decimal? LotSize = null;
            decimal? Matl = null;
            decimal? Labor = null;
            decimal? Ovhd = null;
            decimal? CompOutside = null;
            string um = null;
            string tpmt = null;
            decimal? tQty = null;
            string QtyPerFormat = null;
            int? PlacesQtyPer = null;
            string tum = null;
            string tunit = null;
            decimal? tLot = null;
            string tType = null;
            decimal? tMatl = null;
            decimal? tOvhd = null;
            string tDesc = null;
            decimal? tLabor = null;
            decimal? tOuts = null;
            int? tLevel = null;
            string Level = null;
            decimal? tParentLot = null;
            DateTime? tEffD = null;
            string tItem = null;
            string tJob = null;
            int? tSuff = null;
            string jitem = null;
            decimal? jmatlQtyConv = null;
            string jum = null;
            string jmatlType = null;
            string junits = null;
            string jdescription = null;
            decimal? jcost = null;
            int? jlevel = null;
            decimal? convFactor = null;
            string punit = null;
            string ptype = null;
            int? check = null;
            string CstPrcFormat = null;
            int? PlacesCp = null;
            string bom_alternate_id = null;
            int? job_suffix = null;
            int? CostItemAtWhse = null;
            string DefaultWhse = null;
            int? LevelItemCount = null;
            int? Level3 = null;
            int? CurrLevel3 = null;
            int? check3 = null;
            string item3 = null;
            int? Level1 = null;
            string item1 = null;
            string job1 = null;
            int? suffix1 = null;
            decimal? matlqtyconv1 = null;
            string um1 = null;
            string matltype1 = null;
            string units1 = null;
            string description1 = null;
            decimal? cost1 = null;
            int? Stocked2 = null;
            ICollectionLoadRequest itemCursorLoadRequestForCursor = null;
            ICollectionLoadResponse aCursorLoadResponseForCursor = null;
            int aCursor_CursorFetch_Status = -1;
            int aCursor_CursorCounter = -1;
            ICollectionLoadResponse jobmatlCursorLoadResponseForCursor = null;
            int jobmatlCursor_CursorFetch_Status = -1;
            int jobmatlCursor_CursorCounter = -1;

            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();

            try
            {


                var unionUtil = new UnionUtil(UnionType.UnionAll);


                #endregion  Variable definition

                if (this.iRpt_IndentedCostedBillofMaterialCRUD.ForExists_Optional_Module())
                {
                    this.iRpt_IndentedCostedBillofMaterialCRUD.DeclareTable_ALTGEN();

                    this.iRpt_IndentedCostedBillofMaterialCRUD.InsertOptional_Module1();

                    while (this.iRpt_IndentedCostedBillofMaterialCRUD.ForExists_Tv_ALTGEN())
                    {
                        (ALTGEN_SpName, rowCount) = this.iRpt_IndentedCostedBillofMaterialCRUD.LoadTv_ALTGEN1(ALTGEN_SpName);
                        var ALTGEN = this.iRpt_IndentedCostedBillofMaterialCRUD.AltExtGen_Rpt_IndentedCostedBillofMaterialSp(ALTGEN_SpName,
                            ItemStarting,
                            ItemEnding,
                            ProCodeStarting,
                            ProCodeEnding,
                            AlternateIDStarting,
                            AlternateIDEnding,
                            MaterialType,
                            Source,
                            Stocked,
                            ABCCode,
                            EffDate,
                            PrBetweenLevel0,
                            PrLevelZero,
                            DisplayHeader,
                            PrintAlternate,
                            EffDateOffSet,
                            pSite);
                        ALTGEN_Severity = ALTGEN.ReturnCode;

                        if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                        {
                            return (ALTGEN.Data, ALTGEN_Severity);

                        }
                        this.iRpt_IndentedCostedBillofMaterialCRUD.DeleteTv_ALTGEN2(ALTGEN_SpName);
                    }
                }
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_IndentedCostedBillofMaterialSp") != null)
                {
                    var EXTGEN = this.iRpt_IndentedCostedBillofMaterialCRUD.AltExtGen_Rpt_IndentedCostedBillofMaterialSp("dbo.EXTGEN_Rpt_IndentedCostedBillofMaterialSp",
                        ItemStarting,
                        ItemEnding,
                        ProCodeStarting,
                        ProCodeEnding,
                        AlternateIDStarting,
                        AlternateIDEnding,
                        MaterialType,
                        Source,
                        Stocked,
                        ABCCode,
                        EffDate,
                        PrBetweenLevel0,
                        PrLevelZero,
                        DisplayHeader,
                        PrintAlternate,
                        EffDateOffSet,
                        pSite);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity);
                    }
                }

                this.iRpt_IndentedCostedBillofMaterialCRUD.SetTransaction();

                (CostItemAtWhse, DefaultWhse, rowCount) = this.iRpt_IndentedCostedBillofMaterialCRUD.LoadDbo_Invparms(RptSessionID, pSite, CostItemAtWhse, DefaultWhse);

                this.iRpt_IndentedCostedBillofMaterialCRUD.DeclareTable_loop();
                this.iRpt_IndentedCostedBillofMaterialCRUD.DeclareTable_loop2();

                (PlacesQtyPer, QtyPerFormat, rowCount) = this.iRpt_IndentedCostedBillofMaterialCRUD.LoadInvparms(QtyPerFormat, PlacesQtyPer);
                QtyPerFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                    QtyPerFormat,
                    this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                (CstPrcFormat, PlacesCp, rowCount) = this.iRpt_IndentedCostedBillofMaterialCRUD.LoadCurrency(CstPrcFormat, PlacesCp);
                CstPrcFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                    CstPrcFormat,
                    this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                Stocked = stringUtil.IsNull(
                    Stocked,
                    "B");
                Stocked2 = convertToUtil.ToInt32((sQLUtil.SQLEqual(Stocked, "Y") == true ? 1 :
                sQLUtil.SQLEqual(Stocked, "N") == true ? 0 : -1));
                ItemStarting = stringUtil.IsNull(
                    ItemStarting,
                    lowString.LowStringFn("ItemType"));
                ItemEnding = stringUtil.IsNull(
                    ItemEnding,
                    highString.HighStringFn("ItemType"));
                ProCodeStarting = stringUtil.IsNull(
                    ProCodeStarting,
                    lowString.LowStringFn("ProductCodeType"));
                ProCodeEnding = stringUtil.IsNull(
                    ProCodeEnding,
                    highString.HighStringFn("ProductCodeType"));
                AlternateIDStarting = stringUtil.IsNull(
                    AlternateIDStarting,
                    lowString.LowStringFn("MO_BOMAlternateType"));
                AlternateIDEnding = stringUtil.IsNull(
                    AlternateIDEnding,
                    highString.HighStringFn("MO_BOMAlternateType"));
                MaterialType = stringUtil.IsNull(
                    MaterialType,
                    "MTFO");
                Source = stringUtil.IsNull(
                    Source,
                    "PMT");
                ABCCode = stringUtil.IsNull(
                    ABCCode,
                    "ABC");
                EffDate = convertToUtil.ToDateTime(stringUtil.IsNull(
                    EffDate,
                    this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE"))));
                PrBetweenLevel0 = stringUtil.IsNull(
                    PrBetweenLevel0,
                    "S");
                PrLevelZero = (int?)(stringUtil.IsNull(
                    PrLevelZero,
                    1));
                PrintAlternate = (int?)(stringUtil.IsNull(
                    PrintAlternate,
                    0));
                LevelItemCount = 0;

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
                var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(
                    Date: EffDate,
                    Offset: EffDateOffSet,
                    IsEndDate: 0);
                EffDate = ApplyDateOffset.Date;

                #endregion ExecuteMethodCall

                Dictionary<string, SortOrderDirection> dicSortOrder = new Dictionary<string, SortOrderDirection>();
                dicSortOrder.Add("job.MO_bom_alternate_id", SortOrderDirection.Ascending);
                dicSortOrder.Add("item.item", SortOrderDirection.Ascending);

                if (sQLUtil.SQLEqual(CostItemAtWhse, 1) == true)
                {
                    #region Cursor Statement
                    itemCursorLoadRequestForCursor = this.iRpt_IndentedCostedBillofMaterialCRUD.SelectItem(ItemStarting, ItemEnding, ProCodeStarting, ProCodeEnding, AlternateIDStarting, AlternateIDEnding, MaterialType, Source, ABCCode, PrintAlternate, Stocked2, DefaultWhse);
                    #endregion Cursor Statement

                    dicSortOrder.Add("itemwhse.whse", SortOrderDirection.Ascending);
                }
                else
                {
                    #region Cursor Statement
                    itemCursorLoadRequestForCursor = this.iRpt_IndentedCostedBillofMaterialCRUD.SelectItem1(ItemStarting, ItemEnding, ProCodeStarting, ProCodeEnding, AlternateIDStarting, AlternateIDEnding, MaterialType, Source, ABCCode, PrintAlternate, Stocked2);
                    #endregion Cursor Statement
                }

                dicSortOrder.Add("item.job", SortOrderDirection.Ascending);
                dicSortOrder.Add("job.suffix", SortOrderDirection.Ascending);

                ISortOrder itemSortOrder = sortOrderFactory.Create(dicSortOrder);


                int count = 0;

                using (IRecordStream coitemRecordStream = recordStreamFactory.Create(appDB, queryLanguage, mgSessionVariableBasedCache, collectionLoadRequestFactory,
                        itemCursorLoadRequestForCursor, itemSortOrder, SQLPagedRecordStreamBookmarkID.MyReport_Rpt, pageSize, loadType))
                {

                    while (coitemRecordStream.Read())
                    {
                        IRecordReadOnly coitemRow = coitemRecordStream.Current;

                        item = coitemRow.GetValue<string>(0);
                        Job = coitemRow.GetValue<string>(1);
                        description = coitemRow.GetValue<string>(2);
                        pmtCode = coitemRow.GetValue<string>(3);
                        Suff = coitemRow.GetValue<int?>(4);
                        LotSize = coitemRow.GetValue<decimal?>(5);
                        Matl = coitemRow.GetValue<decimal?>(6);
                        Labor = coitemRow.GetValue<decimal?>(7);
                        Ovhd = coitemRow.GetValue<decimal?>(8);
                        CompOutside = coitemRow.GetValue<decimal?>(9);
                        bom_alternate_id = coitemRow.GetValue<string>(10);
                        job_suffix = coitemRow.GetValue<int?>(11);

                        check = 0;

                        if (sQLUtil.SQLEqual(PrLevelZero, 1) == true)
                        {
                            if (this.iRpt_IndentedCostedBillofMaterialCRUD.ForExists_Jobmatl(item))
                            {
                                check = 1;
                            }

                        }
                        if (sQLUtil.SQLEqual(check, 0) == true)
                        {
                            tLevel = 0;
                            LevelItemCount = (int?)(LevelItemCount + 1);
                            tItem = item;
                            tQty = 1M;
                            tum = "";
                            tunit = " ";
                            tType = " ";
                            tParentLot = LotSize;
                            tEffD = convertToUtil.ToDateTime(EffDate);
                            tJob = Job;
                            tDesc = description;
                            tpmt = pmtCode;
                            tSuff = Suff;
                            tLot = LotSize;
                            tMatl = Matl;
                            tLabor = Labor;
                            tOvhd = Ovhd;
                            tOuts = CompOutside;
                            Level = stringUtil.Concat(stringUtil.Char(1), " ", stringUtil.Space(tLevel), Convert.ToString(tLevel));

                            var nonTableLoadResponse = this.iRpt_IndentedCostedBillofMaterialCRUD.SelectNontable(Level, tItem, tpmt, tQty, tum, tunit, tLot, tType, tMatl, tOvhd, tDesc, tLabor, tOuts, QtyPerFormat, PlacesQtyPer, CstPrcFormat, PlacesCp, bom_alternate_id, LevelItemCount);

                            unionUtil.Add(nonTableLoadResponse);
                            count += nonTableLoadResponse.Items.Count;

                            Level3 = 1;
                            CurrLevel3 = 1;
                            item3 = tItem;

                            this.iRpt_IndentedCostedBillofMaterialCRUD.DeleteTv_Loop();
                            this.iRpt_IndentedCostedBillofMaterialCRUD.InsertLoop(Level3, EffDate, tJob, job_suffix);

                            check3 = 0;

                            while ((sQLUtil.SQLEqual(check3, 0) == true))
                            {
                                check3 = 1;
                                #region Cursor Statement
                                aCursorLoadResponseForCursor = this.iRpt_IndentedCostedBillofMaterialCRUD.SelectTv_Loop1();
                                #endregion Cursor Statement

                                aCursor_CursorFetch_Status = aCursorLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
                                aCursor_CursorCounter = -1;

                                aCursor_CursorCounter++;
                                if (aCursorLoadResponseForCursor.Items.Count > aCursor_CursorCounter)
                                {
                                    Level1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<int?>(0);
                                    item1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<string>(1);
                                    job1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<string>(2);
                                    suffix1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<int?>(3);
                                    matlqtyconv1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<decimal?>(4);
                                    um1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<string>(5);
                                    matltype1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<string>(6);
                                    units1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<string>(7);
                                    description1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<string>(8);
                                    cost1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<decimal?>(9);
                                }
                                aCursor_CursorFetch_Status = (aCursor_CursorCounter == aCursorLoadResponseForCursor.Items.Count ? -1 : 0);

                                this.iRpt_IndentedCostedBillofMaterialCRUD.DeleteTv_LoopTwo();

                                var tempUnionUtil = new UnionUtil(UnionType.UnionAll); ;

                                while ((sQLUtil.SQLEqual(aCursor_CursorFetch_Status, 0) == true))
                                {
                                    var nonTable1LoadResponse = this.iRpt_IndentedCostedBillofMaterialCRUD.SelectNontable1(Level1, item1, job1, suffix1, matlqtyconv1, um1, matltype1, units1, description1, cost1);

                                    tempUnionUtil.Add(nonTable1LoadResponse);

                                    if (sQLUtil.SQLEqual(Level1, CurrLevel3) == true)
                                    {
                                        var jobmatl1LoadResponse = this.iRpt_IndentedCostedBillofMaterialCRUD.SelectJobmatl1(EffDate, item1);
                                        foreach (var jobmatl1Item in jobmatl1LoadResponse.Items)
                                        {
                                            jobmatl1Item.SetValue<int?>("level", CurrLevel3 + 1);
                                        };

                                        tempUnionUtil.Add(jobmatl1LoadResponse);

                                        if ((sQLUtil.SQLNotEqual(jobmatl1LoadResponse.Items.Count, 0) == true))
                                        {
                                            check3 = 0;
                                        }

                                    }

                                    aCursor_CursorCounter++;
                                    if (aCursorLoadResponseForCursor.Items.Count > aCursor_CursorCounter)
                                    {
                                        Level1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<int?>(0);
                                        item1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<string>(1);
                                        job1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<string>(2);
                                        suffix1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<int?>(3);
                                        matlqtyconv1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<decimal?>(4);
                                        um1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<string>(5);
                                        matltype1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<string>(6);
                                        units1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<string>(7);
                                        description1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<string>(8);
                                        cost1 = aCursorLoadResponseForCursor.Items[aCursor_CursorCounter].GetValue<decimal?>(9);
                                    }

                                    aCursor_CursorFetch_Status = (aCursor_CursorCounter == aCursorLoadResponseForCursor.Items.Count ? -1 : 0);

                                }

                                this.iRpt_IndentedCostedBillofMaterialCRUD.InsertJobmatl1(tempUnionUtil.Process());

                                //Deallocate Cursor aCursor
                                CurrLevel3 = convertToUtil.ToInt32(CurrLevel3 + 1);

                                this.iRpt_IndentedCostedBillofMaterialCRUD.DeleteTv_Loop2();

                                this.iRpt_IndentedCostedBillofMaterialCRUD.InsertLoop1();
                            }

                            #region Cursor Statement
                            jobmatlCursorLoadResponseForCursor = this.iRpt_IndentedCostedBillofMaterialCRUD.SelectTv_Loop3();
                            #endregion Cursor Statement
                            jobmatlCursor_CursorFetch_Status = jobmatlCursorLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
                            jobmatlCursor_CursorCounter = -1;

                            jobmatlCursor_CursorCounter++;
                            if (jobmatlCursorLoadResponseForCursor.Items.Count > jobmatlCursor_CursorCounter)
                            {
                                jlevel = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<int?>(0);
                                jitem = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<string>(1);
                                jmatlQtyConv = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<decimal?>(2);
                                jum = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<string>(3);
                                jmatlType = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<string>(4);
                                junits = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<string>(5);
                                jdescription = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<string>(6);
                                jcost = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<decimal?>(7);
                            }
                            jobmatlCursor_CursorFetch_Status = (jobmatlCursor_CursorCounter == jobmatlCursorLoadResponseForCursor.Items.Count ? -1 : 0);
                            
                            while ((sQLUtil.SQLEqual(jobmatlCursor_CursorFetch_Status, 0) == true))
                            {

                                #region CRUD ExecuteMethodCall

                                //Please Generate the bounce for this stored procedure: GetCodeSp
                                var GetCode = this.iGetCode.GetCodeSp(
                                    PClass: "item.matl_type",
                                    PCode: jmatlType,
                                    PDesc: ptype);
                                ptype = GetCode.PDesc;

                                #endregion ExecuteMethodCall

                                #region CRUD ExecuteMethodCall

                                //Please Generate the bounce for this stored procedure: GetCodeSp
                                var GetCode1 = this.iGetCode.GetCodeSp(
                                    PClass: "jobmatl.units",
                                    PCode: junits,
                                    PDesc: punit);
                                punit = GetCode1.PDesc;

                                #endregion ExecuteMethodCall

                                tLevel = jlevel;
                                tItem = jitem;
                                tQty = jmatlQtyConv;
                                tum = jum;
                                tunit = punit;
                                tType = ptype;
                                tParentLot = LotSize;
                                tEffD = convertToUtil.ToDateTime(EffDate);
                                if (this.iRpt_IndentedCostedBillofMaterialCRUD.ForExists_Item2(tItem))
                                {
                                    if (sQLUtil.SQLEqual(CostItemAtWhse, 1) == true)
                                    {
                                        (tJob, tDesc, tpmt, tSuff, tLot, tMatl, tLabor, tOvhd, tOuts, um, rowCount) = this.iRpt_IndentedCostedBillofMaterialCRUD.LoadItem3(tItem, um, tpmt, tLot, tMatl, tOvhd, tDesc, tLabor, tOuts, tJob, tSuff, DefaultWhse);
                                    }
                                    else
                                    {
                                        (tJob, tDesc, tpmt, tSuff, tLot, tMatl, tLabor, tOvhd, tOuts, um, rowCount) = this.iRpt_IndentedCostedBillofMaterialCRUD.LoadItem4(tItem, um, tpmt, tLot, tMatl, tOvhd, tDesc, tLabor, tOuts, tJob, tSuff);
                                    }
                                    if (tum != null && sQLUtil.SQLNotEqual(tum, um) == true)
                                    {
                                        convFactor = 1M;
                                        (convFactor, rowCount) = this.iRpt_IndentedCostedBillofMaterialCRUD.LoadU_M_Conv(um, tum, tItem, convFactor);
                                        if (sQLUtil.SQLEqual(this.iRpt_IndentedCostedBillofMaterialCRUD.LoadU_M_Conv(um, tum, tItem, convFactor).rowCount, 0) == true)
                                        {
                                            (convFactor, rowCount) = this.iRpt_IndentedCostedBillofMaterialCRUD.LoadU_M_Conv1(um, tum, tItem, convFactor);
                                            if (sQLUtil.SQLEqual(this.iRpt_IndentedCostedBillofMaterialCRUD.LoadU_M_Conv1(um, tum, tItem, convFactor).rowCount, 0) == true)
                                            {
                                                (convFactor, rowCount) = this.iRpt_IndentedCostedBillofMaterialCRUD.LoadU_M_Conv2(um, tum, convFactor);
                                                if (sQLUtil.SQLEqual(this.iRpt_IndentedCostedBillofMaterialCRUD.LoadU_M_Conv2(um, tum, convFactor).rowCount, 0) == true)
                                                {
                                                    (convFactor, rowCount) = this.iRpt_IndentedCostedBillofMaterialCRUD.LoadU_M_Conv3(um, tum, convFactor);
                                                }
                                            }
                                        }
                                        tMatl = (decimal?)(tMatl / convFactor);
                                        tLabor = (decimal?)(tLabor / convFactor);
                                        tOvhd = (decimal?)(tOvhd / convFactor);
                                        tOuts = (decimal?)(tOuts / convFactor);
                                    }
                                    if (sQLUtil.SQLEqual(stringUtil.Substring(
                                            tunit,
                                            1,
                                            1), "L") == true)
                                    {
                                        tMatl = (decimal?)(tMatl / tParentLot);
                                        tLabor = (decimal?)(tLabor / tParentLot);
                                        tOvhd = (decimal?)(tOvhd / tParentLot);
                                        tOuts = (decimal?)(tOuts / tParentLot);
                                    }
                                }
                                else
                                {
                                    tJob = "";
                                    tDesc = jdescription;
                                    tpmt = null;
                                    tSuff = null;
                                    tLot = null;
                                    tMatl = jcost;
                                    tLabor = 0;
                                    tOvhd = 0;
                                    tOuts = 0;
                                    tParentLot = 0;
                                }
                                Level = stringUtil.Concat(stringUtil.Char(1), " ", stringUtil.Space(tLevel), Convert.ToString(tLevel));

                                var nonTable3LoadResponse = this.iRpt_IndentedCostedBillofMaterialCRUD.SelectNontable3(Level, tItem, tpmt, tQty, tum, tunit, tLot, tType, tMatl, tOvhd, tDesc, tLabor, tOuts, QtyPerFormat, PlacesQtyPer, CstPrcFormat, PlacesCp, bom_alternate_id, LevelItemCount);

                                unionUtil.Add(nonTable3LoadResponse);
                                count += nonTable3LoadResponse.Items.Count;

                                jobmatlCursor_CursorCounter++;
                                if (jobmatlCursorLoadResponseForCursor.Items.Count > jobmatlCursor_CursorCounter)
                                {
                                    jlevel = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<int?>(0);
                                    jitem = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<string>(1);
                                    jmatlQtyConv = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<decimal?>(2);
                                    jum = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<string>(3);
                                    jmatlType = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<string>(4);
                                    junits = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<string>(5);
                                    jdescription = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<string>(6);
                                    jcost = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<decimal?>(7);
                                }
                                jobmatlCursor_CursorFetch_Status = (jobmatlCursor_CursorCounter == jobmatlCursorLoadResponseForCursor.Items.Count ? -1 : 0);

                            }
                            //Deallocate Cursor jobmatlCursor
                        }

                        if (count > recordCap && recordCap > 0)
                        {
                            var nonTable4LoadResponse = this.iRpt_IndentedCostedBillofMaterialCRUD.SelectNontable3(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
                            unionUtil.Add(nonTable4LoadResponse);
                            break;
                        }
                    }
                    //Deallocate Cursor itemCursor
                }

                Data = unionUtil.Process();

                if (recordCap > 0)
                {
                    defineProcessVariable.DefineProcessVariableSp("RecordCap", (Data.Items.Count - 1).ToString(), null);
                    (int? returnCode, string variableValue, string infobar) = getVariable.GetVariableSp(Enum.GetName(typeof(SQLPagedRecordStreamBookmarkID), SQLPagedRecordStreamBookmarkID.MyReport_Rpt), "", 0, "", "");
                    defineProcessVariable.DefineProcessVariableSp("Bookmark", variableValue, infobar);
                }

                int? sequence = null;
                if (loadType == LoadType.First)
                {
                    sequence = 1;
                }
                else
                {
                    (int? returnCode0, string varValue, string bar) = getVariable.GetVariableSp("sequence", "0", 0, "", "");
                    sequence = int.Parse(varValue);
                }

                foreach (var dataItem in Data.Items)
                {
                    dataItem.SetValue<int?>("sequence", sequence);
                    sequence++;
                }

                defineVariable.DefineVariableSp("sequence", sequence.ToString(), null);

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
