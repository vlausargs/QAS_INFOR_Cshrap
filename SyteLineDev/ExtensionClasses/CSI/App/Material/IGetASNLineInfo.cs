//PROJECT NAME: Material
//CLASS NAME: IGetASNLineInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
    public interface IGetASNLineInfo
    {
            (int? ReturnCode,
            string BolItemItem,
            string BolItemDescription,
            decimal? BolItemQty,
            string BolItemUM,
            decimal? BolItemWeight,
            int? ItemSerialTracked,
            decimal? ItemUnitWeight) 
        GetASNLineInfoSp(string BolItemRefNum,
            string BolItemBolNum,
            int? BolItemRefLine,
            string BolItemItem,
            string BolItemDescription,
            decimal? BolItemQty,
            string BolItemUM,
            decimal? BolItemWeight,
            int? ItemSerialTracked,
            decimal? ItemUnitWeight);
    }
}

