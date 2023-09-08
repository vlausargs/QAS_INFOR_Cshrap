//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtdValidArpmtdType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArpmtdValidArpmtdType
    {
        int ArpmtdValidArpmtdTypeSp(CustNumType PArpmtCustNum,
                                    ArpmtTypeType PArpmtType,
                                    ArCheckNumType PArpmtCheckNum,
                                    StringType PArpmtdType,
                                    ref FlagNyType PTAvailCustDrft,
                                    ref InvNumType PArpmtdInvNum,
                                    ref CoNumType PArpmtdCoNum,
                                    ref SiteType PArpmtdSite,
                                    ref NameType PApplCustName,
                                    ref AmountType PArpmtdForAmtApplied,
                                    ref CustNumType PArpmtdApplyCustNum,
                                    ref InfobarType Infobar);
    }

    public class ArpmtdValidArpmtdType : IArpmtdValidArpmtdType
    {
        readonly IApplicationDB appDB;

        public ArpmtdValidArpmtdType(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArpmtdValidArpmtdTypeSp(CustNumType PArpmtCustNum,
                                           ArpmtTypeType PArpmtType,
                                           ArCheckNumType PArpmtCheckNum,
                                           StringType PArpmtdType,
                                           ref FlagNyType PTAvailCustDrft,
                                           ref InvNumType PArpmtdInvNum,
                                           ref CoNumType PArpmtdCoNum,
                                           ref SiteType PArpmtdSite,
                                           ref NameType PApplCustName,
                                           ref AmountType PArpmtdForAmtApplied,
                                           ref CustNumType PArpmtdApplyCustNum,
                                           ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArpmtdValidArpmtdTypeSp";

                appDB.AddCommandParameter(cmd, "PArpmtCustNum", PArpmtCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtType", PArpmtType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtCheckNum", PArpmtCheckNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtdType", PArpmtdType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PTAvailCustDrft", PTAvailCustDrft, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PArpmtdInvNum", PArpmtdInvNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PArpmtdCoNum", PArpmtdCoNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PArpmtdSite", PArpmtdSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PApplCustName", PApplCustName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PArpmtdForAmtApplied", PArpmtdForAmtApplied, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PArpmtdApplyCustNum", PArpmtdApplyCustNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
