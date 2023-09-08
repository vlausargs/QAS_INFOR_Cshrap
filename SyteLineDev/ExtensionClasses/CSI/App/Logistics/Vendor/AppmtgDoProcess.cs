//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtgDoProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IAppmtgDoProcess
    {
        DataTable AppmtgDoProcessSp(string ExOptszSiteGroup,
                                    DateTime? ExOptprPaymentDate,
                                    string ExOptprPaymentType,
                                    string ExOptgoInvDueDisc,
                                    string ExOptdfDiscMethod,
                                    byte? ExOptgoInclCommissions,
                                    byte? ExOptdfDelPaydis,
                                    string ExBegVendNum,
                                    string ExEndVendNum,
                                    string ExBegBankCode,
                                    string ExEndBankCode,
                                    DateTime? ExBegAgeDate,
                                    DateTime? ExEndAgeDate,
                                    byte? ExOverPaymentBankCode,
                                    string ExPaymentBankCode,
                                    string THPaymentNumberPrefix);
    }

    public class AppmtgDoProcess : IAppmtgDoProcess
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public AppmtgDoProcess(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable AppmtgDoProcessSp(string ExOptszSiteGroup,
                                           DateTime? ExOptprPaymentDate,
                                           string ExOptprPaymentType,
                                           string ExOptgoInvDueDisc,
                                           string ExOptdfDiscMethod,
                                           byte? ExOptgoInclCommissions,
                                           byte? ExOptdfDelPaydis,
                                           string ExBegVendNum,
                                           string ExEndVendNum,
                                           string ExBegBankCode,
                                           string ExEndBankCode,
                                           DateTime? ExBegAgeDate,
                                           DateTime? ExEndAgeDate,
                                           byte? ExOverPaymentBankCode,
                                           string ExPaymentBankCode,
                                           string THPaymentNumberPrefix)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                SiteGroupType _ExOptszSiteGroup = ExOptszSiteGroup;
                DateType _ExOptprPaymentDate = ExOptprPaymentDate;
                StringType _ExOptprPaymentType = ExOptprPaymentType;
                StringType _ExOptgoInvDueDisc = ExOptgoInvDueDisc;
                StringType _ExOptdfDiscMethod = ExOptdfDiscMethod;
                FlagNyType _ExOptgoInclCommissions = ExOptgoInclCommissions;
                FlagNyType _ExOptdfDelPaydis = ExOptdfDelPaydis;
                VendNumType _ExBegVendNum = ExBegVendNum;
                VendNumType _ExEndVendNum = ExEndVendNum;
                BankCodeType _ExBegBankCode = ExBegBankCode;
                BankCodeType _ExEndBankCode = ExEndBankCode;
                DateType _ExBegAgeDate = ExBegAgeDate;
                DateType _ExEndAgeDate = ExEndAgeDate;
                FlagNyType _ExOverPaymentBankCode = ExOverPaymentBankCode;
                BankCodeType _ExPaymentBankCode = ExPaymentBankCode;
                THPrefixType _THPaymentNumberPrefix = THPaymentNumberPrefix;

                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AppmtgDoProcessSp";

                    appDB.AddCommandParameter(cmd, "ExOptszSiteGroup", _ExOptszSiteGroup, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ExOptprPaymentDate", _ExOptprPaymentDate, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ExOptprPaymentType", _ExOptprPaymentType, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ExOptgoInvDueDisc", _ExOptgoInvDueDisc, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ExOptdfDiscMethod", _ExOptdfDiscMethod, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ExOptgoInclCommissions", _ExOptgoInclCommissions, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ExOptdfDelPaydis", _ExOptdfDelPaydis, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ExBegVendNum", _ExBegVendNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ExEndVendNum", _ExEndVendNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ExBegBankCode", _ExBegBankCode, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ExEndBankCode", _ExEndBankCode, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ExBegAgeDate", _ExBegAgeDate, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ExEndAgeDate", _ExEndAgeDate, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ExOverPaymentBankCode", _ExOverPaymentBankCode, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ExPaymentBankCode", _ExPaymentBankCode, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "THPaymentNumberPrefix", _THPaymentNumberPrefix, ParameterDirection.Input);

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return dtReturn;
                }
            }
            finally
            {
                bunchedLoadCollection.EndBunching();
            }
        }
    }
}
