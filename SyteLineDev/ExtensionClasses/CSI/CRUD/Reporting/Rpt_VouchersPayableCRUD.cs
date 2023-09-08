using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;

namespace CSI.Reporting
{
    public class Rpt_VouchersPayableCRUD : IRpt_VouchersPayableCRUD
    {
        readonly IApplicationDB appDB;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;

        public Rpt_VouchersPayableCRUD(IApplicationDB appDB, ICollectionLoadRequestFactory collectionLoadRequestFactory)
        {
            this.appDB = appDB ?? throw new ArgumentNullException(nameof(appDB));
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_VouchersPayableSp(string AltExtGenSp,
            string POType = null,
            int? TransDomCurr = null,
            int? ShowDetail = null,
            DateTime? CutoffDate = null,
            string PoStarting = null,
            string PoEnding = null,
            string VendorStarting = null,
            string VendorEnding = null,
            int? CutoffDateOffset = null,
            int? DisplayHeader = null,
            string SiteGroup = null,
            string BuilderPoStarting = null,
            string BuilderPoEnding = null,
            int? TaskId = null,
            int? PrintItemOverview = null,
            string BGSessionId = null,
            string pSite = null)
        {
            StringType _POType = POType;
            ListYesNoType _TransDomCurr = TransDomCurr;
            ListYesNoType _ShowDetail = ShowDetail;
            DateType _CutoffDate = CutoffDate;
            PoNumType _PoStarting = PoStarting;
            PoNumType _PoEnding = PoEnding;
            VendNumType _VendorStarting = VendorStarting;
            VendNumType _VendorEnding = VendorEnding;
            DateOffsetType _CutoffDateOffset = CutoffDateOffset;
            ListYesNoType _DisplayHeader = DisplayHeader;
            SiteGroupType _SiteGroup = SiteGroup;
            BuilderPoNumType _BuilderPoStarting = BuilderPoStarting;
            BuilderPoNumType _BuilderPoEnding = BuilderPoEnding;
            TaskNumType _TaskId = TaskId;
            ListYesNoType _PrintItemOverview = PrintItemOverview;
            StringType _BGSessionId = BGSessionId;
            SiteType _pSite = pSite;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "POType", _POType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransDomCurr", _TransDomCurr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShowDetail", _ShowDetail, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CutoffDate", _CutoffDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PoStarting", _PoStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PoEnding", _PoEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "VendorStarting", _VendorStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "VendorEnding", _VendorEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CutoffDateOffset", _CutoffDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BuilderPoStarting", _BuilderPoStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BuilderPoEnding", _BuilderPoEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                var resultSet = dataTableToCollectionLoadResponse.Process(dtReturn);
                var returnCode = (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value;

                return (resultSet, returnCode);
            }
        }

        public ICollectionLoadResponse AddSummaryFields(int? Severity)
        {
            var tv_VchPayTable2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"VendNum","#tv_VchPayTable.VendNum"},
                    {"VendName","#tv_VchPayTable.VendName"},
                    {"ItemNum","#tv_VchPayTable.ItemNum"},
                    {"ItemDesc","#tv_VchPayTable.ItemDesc"},
                    {"PoCurrCode","#tv_VchPayTable.PoCurrCode"},
                    {"CurrDesc","#tv_VchPayTable.CurrDesc"},
                    {"PoNum","#tv_VchPayTable.PoNum"},
                    {"PoLine","#tv_VchPayTable.PoLine"},
                    {"PoRelease","#tv_VchPayTable.PoRelease"},
                    {"PoitemDesc","#tv_VchPayTable.PoitemDesc"},
                    {"RType","#tv_VchPayTable.RType"},
                    {"QtyNotVchd","#tv_VchPayTable.QtyNotVchd"},
                    {"PUM","#tv_VchPayTable.PUM"},
                    {"MatlRcvdAmt","#tv_VchPayTable.MatlRcvdAmt"},
                    {"MatlVchdAmt","#tv_VchPayTable.MatlVchdAmt"},
                    {"VPMatlAmt","#tv_VchPayTable.VPMatlAmt"},
                    {"MatlAdj","#tv_VchPayTable.MatlAdj"},
                    {"LCType","#tv_VchPayTable.LCType"},
                    {"LCAmt","#tv_VchPayTable.LCAmt"},
                    {"LCVchd","#tv_VchPayTable.LCVchd"},
                    {"LCToVch","#tv_VchPayTable.LCToVch"},
                    {"PVRcvdDate","#tv_VchPayTable.PVRcvdDate"},
                    {"PVType","#tv_VchPayTable.PVType"},
                    {"PVQty","#tv_VchPayTable.PVQty"},
                    {"PVItemCost","#tv_VchPayTable.PVItemCost"},
                    {"PVGrnNum","#tv_VchPayTable.PVGrnNum"},
                    {"PVPackNum","#tv_VchPayTable.PVPackNum"},
                    {"LCTypeOrder","#tv_VchPayTable.LCTypeOrder"},
                    {"PoBuilderPoOrigSite","#tv_VchPayTable.PoBuilderPoOrigSite"},
                    {"PoBuilderPoNum","#tv_VchPayTable.PoBuilderPoNum"},
                    {"PoSiteRef","#tv_VchPayTable.PoSiteRef"},
                    {"QtyUnitFormat","#tv_VchPayTable.QtyUnitFormat"},
                    {"QtyUnitPlaces","#tv_VchPayTable.QtyUnitPlaces"},
                    {"AmountFormat","#tv_VchPayTable.AmountFormat"},
                    {"AmountPlaces","#tv_VchPayTable.AmountPlaces"},
                    {"CostPriceFormat","#tv_VchPayTable.CostPriceFormat"},
                    {"CostPricePlaces","#tv_VchPayTable.CostPricePlaces"},
                    {"ItemOverview","#tv_VchPayTable.ItemOverview"},
                    {"DisplayDetailHeading","#tv_VchPayTable.DisplayDetailHeading"},
                    {"FormattedLCAmt","CAST (NULL AS NVARCHAR(100))"},
                    {"FormattedLCVchd","CAST (NULL AS NVARCHAR(100))"},
                    {"FormattedLCToVch","CAST (NULL AS NVARCHAR(100))"},
                    {"FormattedVPMatlAmt","CAST (NULL AS NVARCHAR(100))"},
                    {"FormattedMatlAdj","CAST (NULL AS NVARCHAR(100))"},
                    {"FormattedMatlRcvdAmt","CAST (NULL AS NVARCHAR(100))"},
                    {"FormattedMatlVchdAmt","CAST (NULL AS NVARCHAR(100))"},
                    {"FormattedPVItemCost","CAST (NULL AS NVARCHAR(100))"},
                    {"LCAmtFreight", "CAST (NULL AS DECIMAL)"},
                    {"LCVchdFreight", "CAST (NULL AS DECIMAL)"},
                    {"LCToVchFreight", "CAST (NULL AS DECIMAL)"},
                    {"LCAmtDuty", "CAST (NULL AS DECIMAL)"},
                    {"LCVchdDuty", "CAST (NULL AS DECIMAL)"},
                    {"LCToVchDuty", "CAST (NULL AS DECIMAL)"},
                    {"LCAmtBrokerage", "CAST (NULL AS DECIMAL)"},
                    {"LCVchdBrokerage", "CAST (NULL AS DECIMAL)"},
                    {"LCToVchBrokerage", "CAST (NULL AS DECIMAL)"},
                    {"LCAmtInsurance", "CAST (NULL AS DECIMAL)"},
                    {"LCVchdInsurance", "CAST (NULL AS DECIMAL)"},
                    {"LCToVchInsurance", "CAST (NULL AS DECIMAL)"},
                    {"LCAmtLocalFreight", "CAST (NULL AS DECIMAL)"},
                    {"LCVchdLocalFreight", "CAST (NULL AS DECIMAL)"},
                    {"LCToVchLocalFreight", "CAST (NULL AS DECIMAL)"},
                },
            loadForChange: false,
            lockingType: LockingType.None,
            tableName: "#tv_VchPayTable",
            fromClause: collectionLoadRequestFactory.Clause(""),
            whereClause: collectionLoadRequestFactory.Clause("{0} = 0", Severity),
            orderByClause: collectionLoadRequestFactory.Clause(" PoBuilderPoOrigSite, PoBuilderPoNum, PoNum, PoLine, PoRelease, RType, LCTypeOrder"));
            var tv_VchPayTable2LoadResponse = this.appDB.Load(tv_VchPayTable2LoadRequest);

            foreach (var tv_VchPayTable2Item in tv_VchPayTable2LoadResponse.Items)
            {
                var lcAmt = tv_VchPayTable2Item.GetValue<decimal?>("LCAmt");
                var lcVchd = tv_VchPayTable2Item.GetValue<decimal?>("LCVchd");
                var lcToVch = tv_VchPayTable2Item.GetValue<decimal?>("LCToVch");
                var amountFormat = tv_VchPayTable2Item.GetValue<string>("AmountFormat");
                var amountPlaces = tv_VchPayTable2Item.GetValue<int?>("AmountPlaces");

                tv_VchPayTable2Item.SetValue<string>("FormattedLCAmt", RoundFormatProperty(lcAmt, amountFormat, amountPlaces));
                tv_VchPayTable2Item.SetValue<string>("FormattedLCVchd", RoundFormatProperty(lcVchd, amountFormat, amountPlaces));
                tv_VchPayTable2Item.SetValue<string>("FormattedLCToVch", RoundFormatProperty(lcToVch, amountFormat, amountPlaces));
                tv_VchPayTable2Item.SetValue<string>("FormattedVPMatlAmt", RoundFormatProperty(tv_VchPayTable2Item.GetValue<decimal?>("VPMatlAmt"), amountFormat, amountPlaces));
                tv_VchPayTable2Item.SetValue<string>("FormattedMatlAdj", RoundFormatProperty(tv_VchPayTable2Item.GetValue<decimal?>("MatlAdj"), amountFormat, amountPlaces));
                tv_VchPayTable2Item.SetValue<string>("FormattedMatlRcvdAmt", RoundFormatProperty(tv_VchPayTable2Item.GetValue<decimal?>("MatlRcvdAmt"), amountFormat, amountPlaces));
                tv_VchPayTable2Item.SetValue<string>("FormattedMatlVchdAmt", RoundFormatProperty(tv_VchPayTable2Item.GetValue<decimal?>("MatlVchdAmt"), amountFormat, amountPlaces));
                tv_VchPayTable2Item.SetValue<string>("FormattedPVItemCost", RoundFormatProperty(tv_VchPayTable2Item.GetValue<decimal?>("PVItemCost"), tv_VchPayTable2Item.GetValue<string>("CostPriceFormat"), tv_VchPayTable2Item.GetValue<int?>("CostPricePlaces")));

                var lcType = tv_VchPayTable2Item.GetValue<string>("LCType").TrimEnd();
                if (lcType == "F")
                {
                    tv_VchPayTable2Item.SetValue<decimal?>("LCAmtFreight", lcAmt);
                    tv_VchPayTable2Item.SetValue<decimal?>("LCVchdFreight", lcVchd);
                    tv_VchPayTable2Item.SetValue<decimal?>("LCToVchFreight", lcToVch);
                }
                if (lcType == "D")
                {
                    tv_VchPayTable2Item.SetValue<decimal?>("LCAmtDuty", lcAmt);
                    tv_VchPayTable2Item.SetValue<decimal?>("LCVchdDuty", lcVchd);
                    tv_VchPayTable2Item.SetValue<decimal?>("LCToVchDuty", lcToVch);
                }
                if (lcType == "B")
                {
                    tv_VchPayTable2Item.SetValue<decimal?>("LCAmtBrokerage", lcAmt);
                    tv_VchPayTable2Item.SetValue<decimal?>("LCVchdBrokerage", lcVchd);
                    tv_VchPayTable2Item.SetValue<decimal?>("LCToVchBrokerage", lcToVch);
                }
                if (lcType == "I")
                {
                    tv_VchPayTable2Item.SetValue<decimal?>("LCAmtInsurance", lcAmt);
                    tv_VchPayTable2Item.SetValue<decimal?>("LCVchdInsurance", lcVchd);
                    tv_VchPayTable2Item.SetValue<decimal?>("LCToVchInsurance", lcToVch);
                }
                if (lcType == "L")
                {
                    tv_VchPayTable2Item.SetValue<decimal?>("LCAmtLocalFreight", lcAmt);
                    tv_VchPayTable2Item.SetValue<decimal?>("LCVchdLocalFreight", lcVchd);
                    tv_VchPayTable2Item.SetValue<decimal?>("LCToVchLocalFreight", lcToVch);
                }
            };
            return tv_VchPayTable2LoadResponse;
        }

        private string RoundFormatProperty(decimal? PropertyValue, string PropertyFormat, int? RoundtoDecimalPlaces)
        {
            decimal propValue = PropertyValue ?? 0;
            int roundToDecimalPlaces = RoundtoDecimalPlaces ?? 0;
            string propFormat = $"{{0:{PropertyFormat}}}";
            return String.Format(propFormat, Math.Round(propValue, roundToDecimalPlaces));
        }
    }
}
