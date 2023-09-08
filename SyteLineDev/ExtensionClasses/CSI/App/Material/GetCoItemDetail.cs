//PROJECT NAME: CSIMaterial
//CLASS NAME: GetCoItemDetail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IGetCoItemDetail
    {
        int GetCoItemDetailSp(CoNumType CoNum,
                              CoLineType CoLine,
                              CoReleaseType CoRelease,
                              ref CustNumType CoCustNum,
                              ref NameType CoCustName,
                              ref ItemType CoItem,
                              ref DescriptionType CoItemDesc,
                              ref CoitemStatusType CoStat,
                              ref DateType CoDueDate,
                              ref QtyUnitType CoQtyOrderedConv,
                              ref UMType CoUM,
                              ref QtyUnitType CoQtyResv,
                              ref ListYesNoType CoLotTracked,
                              ref ListYesNoType CoSNTracked,
                              ref WhseType CoWhse,
                              ref UMType CoItemUM,
                              ref ListYesNoType CoItemReservable,
                              ref Infobar Infobar,
                              ref ListYesNoType CoTaxFreeMatl);
    }

    public class GetCoItemDetail : IGetCoItemDetail
    {
        readonly IApplicationDB appDB;

        public GetCoItemDetail(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetCoItemDetailSp(CoNumType CoNum,
                                     CoLineType CoLine,
                                     CoReleaseType CoRelease,
                                     ref CustNumType CoCustNum,
                                     ref NameType CoCustName,
                                     ref ItemType CoItem,
                                     ref DescriptionType CoItemDesc,
                                     ref CoitemStatusType CoStat,
                                     ref DateType CoDueDate,
                                     ref QtyUnitType CoQtyOrderedConv,
                                     ref UMType CoUM,
                                     ref QtyUnitType CoQtyResv,
                                     ref ListYesNoType CoLotTracked,
                                     ref ListYesNoType CoSNTracked,
                                     ref WhseType CoWhse,
                                     ref UMType CoItemUM,
                                     ref ListYesNoType CoItemReservable,
                                     ref Infobar Infobar,
                                     ref ListYesNoType CoTaxFreeMatl)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetCoItemDetailSp";

                appDB.AddCommandParameter(cmd, "CoNum", CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLine", CoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoRelease", CoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoCustNum", CoCustNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoCustName", CoCustName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoItem", CoItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoItemDesc", CoItemDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoStat", CoStat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoDueDate", CoDueDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoQtyOrderedConv", CoQtyOrderedConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoUM", CoUM, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoQtyResv", CoQtyResv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoLotTracked", CoLotTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoSNTracked", CoSNTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoWhse", CoWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoItemUM", CoItemUM, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoItemReservable", CoItemReservable, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoTaxFreeMatl", CoTaxFreeMatl, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
