//PROJECT NAME: CSICustomer
//CLASS NAME: EdiCoitemValidateItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IEdiCoitemValidateItem
    {
        int EdiCoitemValidateItemSp(byte? NewRecord,
                                    string CoNum,
                                    short? CoLine,
                                    string Item,
                                    string CustNum,
                                    string CurrCode,
                                    decimal? QtyOrderedConv,
                                    ref string ItemItem,
                                    ref string ItemUM,
                                    ref string ItemDesc,
                                    ref string CustItem,
                                    ref decimal? Price,
                                    ref decimal? Cost,
                                    ref string FeatStr,
                                    ref byte? ItemPlanFlag,
                                    ref string ItemFeatTempl,
                                    ref DateTime? DueDate,
                                    ref string TaxCode1,
                                    ref string TaxCode1Desc,
                                    ref string TaxCode2,
                                    ref string TaxCode2Desc,
                                    ref decimal? DiscPct,
                                    ref decimal? BaseQty,
                                    ref string RefType,
                                    ref string Infobar);
    }

    public class EdiCoitemValidateItem : IEdiCoitemValidateItem
    {
        readonly IApplicationDB appDB;

        public EdiCoitemValidateItem(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EdiCoitemValidateItemSp(byte? NewRecord,
                                           string CoNum,
                                           short? CoLine,
                                           string Item,
                                           string CustNum,
                                           string CurrCode,
                                           decimal? QtyOrderedConv,
                                           ref string ItemItem,
                                           ref string ItemUM,
                                           ref string ItemDesc,
                                           ref string CustItem,
                                           ref decimal? Price,
                                           ref decimal? Cost,
                                           ref string FeatStr,
                                           ref byte? ItemPlanFlag,
                                           ref string ItemFeatTempl,
                                           ref DateTime? DueDate,
                                           ref string TaxCode1,
                                           ref string TaxCode1Desc,
                                           ref string TaxCode2,
                                           ref string TaxCode2Desc,
                                           ref decimal? DiscPct,
                                           ref decimal? BaseQty,
                                           ref string RefType,
                                           ref string Infobar)
        {
            Flag _NewRecord = NewRecord;
            CoNumType _CoNum = CoNum;
            CoLineType _CoLine = CoLine;
            ItemType _Item = Item;
            CustNumType _CustNum = CustNum;
            CurrCodeType _CurrCode = CurrCode;
            QtyUnitNoNegType _QtyOrderedConv = QtyOrderedConv;
            ItemType _ItemItem = ItemItem;
            UMType _ItemUM = ItemUM;
            DescriptionType _ItemDesc = ItemDesc;
            CustItemType _CustItem = CustItem;
            AmountType _Price = Price;
            CostPrcType _Cost = Cost;
            FeatStrType _FeatStr = FeatStr;
            Flag _ItemPlanFlag = ItemPlanFlag;
            FeatTemplateType _ItemFeatTempl = ItemFeatTempl;
            DateType _DueDate = DueDate;
            TaxCodeType _TaxCode1 = TaxCode1;
            DescriptionType _TaxCode1Desc = TaxCode1Desc;
            TaxCodeType _TaxCode2 = TaxCode2;
            DescriptionType _TaxCode2Desc = TaxCode2Desc;
            LineDiscType _DiscPct = DiscPct;
            QtyUnitNoNegType _BaseQty = BaseQty;
            RefTypeIJKPRTType _RefType = RefType;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EdiCoitemValidateItemSp";

                appDB.AddCommandParameter(cmd, "NewRecord", _NewRecord, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyOrderedConv", _QtyOrderedConv, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemItem", _ItemItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemDesc", _ItemDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Price", _Price, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Cost", _Cost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FeatStr", _FeatStr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemPlanFlag", _ItemPlanFlag, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemFeatTempl", _ItemFeatTempl, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode1Desc", _TaxCode1Desc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode2Desc", _TaxCode2Desc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DiscPct", _DiscPct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BaseQty", _BaseQty, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                ItemItem = _ItemItem;
                ItemUM = _ItemUM;
                ItemDesc = _ItemDesc;
                CustItem = _CustItem;
                Price = _Price;
                Cost = _Cost;
                FeatStr = _FeatStr;
                ItemPlanFlag = _ItemPlanFlag;
                ItemFeatTempl = _ItemFeatTempl;
                DueDate = _DueDate;
                TaxCode1 = _TaxCode1;
                TaxCode1Desc = _TaxCode1Desc;
                TaxCode2 = _TaxCode2;
                TaxCode2Desc = _TaxCode2Desc;
                DiscPct = _DiscPct;
                BaseQty = _BaseQty;
                RefType = _RefType;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
