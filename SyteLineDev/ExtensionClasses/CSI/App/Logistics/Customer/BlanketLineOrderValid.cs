//PROJECT NAME: CSICustomer
//CLASS NAME: BlanketLineOrderValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IBlanketLineOrderValid
    {
        int BlanketLineOrderValidSp(ref CoNumType CoNum,
                                    ref CustNumType CustNum,
                                    ref Flag CadrCreditHold,
                                    ref GenericDate CoOrderDate,
                                    ref CurrCodeType CadrCurrCode,
                                    ref NameType CadrName,
                                    ref PriceCodeType CoPriceCode,
                                    ref CoStatusType CoStat,
                                    ref GenericDate CoEffDate,
                                    ref GenericDate CoExpDate,
                                    ref SiteType CoOrigSite,
                                    ref Infobar Infobar,
                                    ref InputMaskType CurrCstPrcFormat);
    }

    public class BlanketLineOrderValid : IBlanketLineOrderValid
    {
        readonly IApplicationDB appDB;

        public BlanketLineOrderValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int BlanketLineOrderValidSp(ref CoNumType CoNum,
                                           ref CustNumType CustNum,
                                           ref Flag CadrCreditHold,
                                           ref GenericDate CoOrderDate,
                                           ref CurrCodeType CadrCurrCode,
                                           ref NameType CadrName,
                                           ref PriceCodeType CoPriceCode,
                                           ref CoStatusType CoStat,
                                           ref GenericDate CoEffDate,
                                           ref GenericDate CoExpDate,
                                           ref SiteType CoOrigSite,
                                           ref Infobar Infobar,
                                           ref InputMaskType CurrCstPrcFormat)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BlanketLineOrderValidSp";

                appDB.AddCommandParameter(cmd, "CoNum", CoNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CadrCreditHold", CadrCreditHold, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoOrderDate", CoOrderDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CadrCurrCode", CadrCurrCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CadrName", CadrName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoPriceCode", CoPriceCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoStat", CoStat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoEffDate", CoEffDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoExpDate", CoExpDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoOrigSite", CoOrigSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurrCstPrcFormat", CurrCstPrcFormat, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
