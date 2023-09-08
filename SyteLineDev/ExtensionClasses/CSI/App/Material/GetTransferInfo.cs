//PROJECT NAME: CSIMaterial
//CLASS NAME: GetTransferInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IGetTransferInfo
    {
        int GetTransferInfoSp(TrnNumType TrnNum,
                              ref SiteType FromSite,
                              ref SiteType ToSite,
                              ref WhseType FromWhse,
                              ref WhseType ToWhse,
                              ref TransferStatusType Status,
                              ref PriceCodeType Pricecode,
                              ref TransNatType TransNat,
                              ref TransNat2Type TransNat2,
                              ref DeltermType Delterm,
                              ref ProcessIndType ProcessInd,
                              ref IntersitePostingMethodType SitenetPostingMethod,
                              ref EcCodeType EcCode,
                              ref InfobarType Infobar);
    }

    public class GetTransferInfo : IGetTransferInfo
    {
        readonly IApplicationDB appDB;

        public GetTransferInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetTransferInfoSp(TrnNumType TrnNum,
                                     ref SiteType FromSite,
                                     ref SiteType ToSite,
                                     ref WhseType FromWhse,
                                     ref WhseType ToWhse,
                                     ref TransferStatusType Status,
                                     ref PriceCodeType Pricecode,
                                     ref TransNatType TransNat,
                                     ref TransNat2Type TransNat2,
                                     ref DeltermType Delterm,
                                     ref ProcessIndType ProcessInd,
                                     ref IntersitePostingMethodType SitenetPostingMethod,
                                     ref EcCodeType EcCode,
                                     ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetTransferInfoSp";

                appDB.AddCommandParameter(cmd, "TrnNum", TrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromSite", FromSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ToSite", ToSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FromWhse", FromWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ToWhse", ToWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Status", Status, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Pricecode", Pricecode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TransNat", TransNat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TransNat2", TransNat2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Delterm", Delterm, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ProcessInd", ProcessInd, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SitenetPostingMethod", SitenetPostingMethod, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "EcCode", EcCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
