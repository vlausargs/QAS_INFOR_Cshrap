//PROJECT NAME: Material
//CLASS NAME: IItemPriceChange.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
    public interface IItemPriceChange
    {
        (int? ReturnCode,
        string Infobar) ItemPriceChangeSp(
            string SessionIDChar,
            string FromProductCode,
            string ToProductCode,
            string FromItem,
            string ToItem,
            DateTime? FromEffectDate,
            DateTime? ToEffectDate,
            string FromPriceCode,
            string ToPriceCode,
            string FromCurrCode,
            string ToCurrCode,
            string FromCustNum,
            string ToCustNum,
            string FromCustType,
            string ToCustType,
            string FromEndUserType,
            string ToEndUserType,
            DateTime? FromDueDate,
            DateTime? ToDueDate,
            DateTime? NewEffectDate,
            int? UpdateCreate = 0,
            int? ItmPrc1 = 0,
            int? ItmPrc2 = 0,
            int? ItmPrc3 = 0,
            int? ItmPrc4 = 0,
            int? ItmPrc5 = 0,
            int? ItmPrc6 = 0,
            string PriceType = "I",
            string PriWhole = "PB",
            string AmtType = "A",
            decimal? PriAmt = 0.0M,
            string Infobar = null,
            int? StartingEffectDateOffset = null,
            int? EndingEffectDateOffset = null);
    }
}

