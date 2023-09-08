//PROJECT NAME: CSICustomer
//CLASS NAME: EDICustomerOrderLineValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IEDICustomerOrderLineValid
    {
        int EDICustomerOrderLineValidSp(string CoNum,
                                        short? CoLine,
                                        string CustNum,
                                        DateTime? OrderDate,
                                        ref string Item,
                                        ref string Description,
                                        ref string CustItem,
                                        ref decimal? BlanketQtyConv,
                                        ref decimal? ContPriceConv,
                                        ref string UM,
                                        ref DateTime? EffDate,
                                        ref DateTime? ExpDate,
                                        ref string CoblnStat,
                                        ref string PriceCode,
                                        ref DateTime? DueDate,
                                        ref DateTime? PromiseDate,
                                        ref decimal? PriceConv,
                                        ref string ItemOrgin,
                                        ref decimal? ItemUnitWeight,
                                        ref string ItemCommCode,
                                        ref string FeatStr,
                                        ref string Infobar);
    }

    public class EDICustomerOrderLineValid : IEDICustomerOrderLineValid
    {
        readonly IApplicationDB appDB;

        public EDICustomerOrderLineValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EDICustomerOrderLineValidSp(string CoNum,
                                               short? CoLine,
                                               string CustNum,
                                               DateTime? OrderDate,
                                               ref string Item,
                                               ref string Description,
                                               ref string CustItem,
                                               ref decimal? BlanketQtyConv,
                                               ref decimal? ContPriceConv,
                                               ref string UM,
                                               ref DateTime? EffDate,
                                               ref DateTime? ExpDate,
                                               ref string CoblnStat,
                                               ref string PriceCode,
                                               ref DateTime? DueDate,
                                               ref DateTime? PromiseDate,
                                               ref decimal? PriceConv,
                                               ref string ItemOrgin,
                                               ref decimal? ItemUnitWeight,
                                               ref string ItemCommCode,
                                               ref string FeatStr,
                                               ref string Infobar)
        {
            CoNumType _CoNum = CoNum;
            CoLineType _CoLine = CoLine;
            CustNumType _CustNum = CustNum;
            DateType _OrderDate = OrderDate;
            ItemType _Item = Item;
            DescriptionType _Description = Description;
            CustItemType _CustItem = CustItem;
            QtyTotlType _BlanketQtyConv = BlanketQtyConv;
            CostPrcType _ContPriceConv = ContPriceConv;
            UMType _UM = UM;
            DateType _EffDate = EffDate;
            DateType _ExpDate = ExpDate;
            CoBlnStatusType _CoblnStat = CoblnStat;
            PriceCodeType _PriceCode = PriceCode;
            DateType _DueDate = DueDate;
            DateType _PromiseDate = PromiseDate;
            CostPrcType _PriceConv = PriceConv;
            EcCodeType _ItemOrgin = ItemOrgin;
            ItemWeightType _ItemUnitWeight = ItemUnitWeight;
            CommodityCodeType _ItemCommCode = ItemCommCode;
            FeatStrType _FeatStr = FeatStr;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EDICustomerOrderLineValidSp";

                appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OrderDate", _OrderDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BlanketQtyConv", _BlanketQtyConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ContPriceConv", _ContPriceConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "EffDate", _EffDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ExpDate", _ExpDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoblnStat", _CoblnStat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PriceCode", _PriceCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromiseDate", _PromiseDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemOrgin", _ItemOrgin, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemUnitWeight", _ItemUnitWeight, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemCommCode", _ItemCommCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FeatStr", _FeatStr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Item = _Item;
                Description = _Description;
                CustItem = _CustItem;
                BlanketQtyConv = _BlanketQtyConv;
                ContPriceConv = _ContPriceConv;
                UM = _UM;
                EffDate = _EffDate;
                ExpDate = _ExpDate;
                CoblnStat = _CoblnStat;
                PriceCode = _PriceCode;
                DueDate = _DueDate;
                PromiseDate = _PromiseDate;
                PriceConv = _PriceConv;
                ItemOrgin = _ItemOrgin;
                ItemUnitWeight = _ItemUnitWeight;
                ItemCommCode = _ItemCommCode;
                FeatStr = _FeatStr;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
