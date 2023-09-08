//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSPartnerCreateUtil.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
    public interface ISSSFSPartnerCreateUtil
    {
        int SSSFSPartnerCreateUtilSp(CustNumType StartCustNum,
                                     CustNumType EndCustNum,
                                     ListYesNoType InclCust,
                                     VendNumType StartVendNum,
                                     VendNumType EndVendNum,
                                     ListYesNoType InclVend,
                                     EmpNumType StartEmpNum,
                                     EmpNumType EndEmpNum,
                                     ListYesNoType InclEmp,
                                     HoursOffType SunHrs,
                                     HoursOffType MonHrs,
                                     HoursOffType TueHrs,
                                     HoursOffType WedHrs,
                                     HoursOffType ThuHrs,
                                     HoursOffType FriHrs,
                                     HoursOffType SatHrs,
                                     DeptType Dept,
                                     ListYesNoType OverrideDept,
                                     WhseType Whse,
                                     CostPrcType Cost,
                                     CostPrcType Rate,
                                     FSReimbMethodType ReimbMethod,
                                     ListYesNoType ReimbMatl,
                                     ListYesNoType ReimbLabor,
                                     ref Infobar Infobar);
    }

    public class SSSFSPartnerCreateUtil : ISSSFSPartnerCreateUtil
    {
        readonly IApplicationDB appDB;

        public SSSFSPartnerCreateUtil(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSPartnerCreateUtilSp(CustNumType StartCustNum,
                                            CustNumType EndCustNum,
                                            ListYesNoType InclCust,
                                            VendNumType StartVendNum,
                                            VendNumType EndVendNum,
                                            ListYesNoType InclVend,
                                            EmpNumType StartEmpNum,
                                            EmpNumType EndEmpNum,
                                            ListYesNoType InclEmp,
                                            HoursOffType SunHrs,
                                            HoursOffType MonHrs,
                                            HoursOffType TueHrs,
                                            HoursOffType WedHrs,
                                            HoursOffType ThuHrs,
                                            HoursOffType FriHrs,
                                            HoursOffType SatHrs,
                                            DeptType Dept,
                                            ListYesNoType OverrideDept,
                                            WhseType Whse,
                                            CostPrcType Cost,
                                            CostPrcType Rate,
                                            FSReimbMethodType ReimbMethod,
                                            ListYesNoType ReimbMatl,
                                            ListYesNoType ReimbLabor,
                                            ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSPartnerCreateUtilSp";

                appDB.AddCommandParameter(cmd, "StartCustNum", StartCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndCustNum", EndCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InclCust", InclCust, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartVendNum", StartVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndVendNum", EndVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InclVend", InclVend, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartEmpNum", StartEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndEmpNum", EndEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InclEmp", InclEmp, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SunHrs", SunHrs, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MonHrs", MonHrs, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TueHrs", TueHrs, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "WedHrs", WedHrs, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ThuHrs", ThuHrs, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FriHrs", FriHrs, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SatHrs", SatHrs, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Dept", Dept, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OverrideDept", OverrideDept, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Cost", Cost, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Rate", Rate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReimbMethod", ReimbMethod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReimbMatl", ReimbMatl, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReimbLabor", ReimbLabor, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

