//PROJECT NAME: CSIEmployee
//CLASS NAME: Pr23r.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IPr23r
    {
        DataTable Pr23rSp(DateType YearStartDate,
                          DateType YearEndDate,
                          StringType PIN,
                          StringType EmpID,
                          StringType EmpType,
                          StringType EstabNumber,
                          FlagNyType CreateStateTaxRec,
                          FlagNyType pResubmit,
                          StringType WFID,
                          StringType OtherEIN,
                          StringType Contact,
                          StringType ContactPhone,
                          StringType ContactPhoneExt,
                          StringType ContactEmail,
                          StringType ContactFax,
                          StringType ContactMethod,
                          StringType StateInfo1,
                          StringType StateInfo2,
                          StringType KindofEmployer,
                          StringType EmployerContactName,
                          StringType EmployerContactPhone,
                          StringType EmployerContactPhoneExt,
                          StringType EmployerContactEmail,
                          StringType EmployerContactFax,
                          StringType SubmitterLocationAddress,
                          StringType SubmitterDeliveryAddress);
    }

    public class Pr23r : IPr23r
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public Pr23r(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable Pr23rSp(DateType YearStartDate,
                                 DateType YearEndDate,
                                 StringType PIN,
                                 StringType EmpID,
                                 StringType EmpType,
                                 StringType EstabNumber,
                                 FlagNyType CreateStateTaxRec,
                                 FlagNyType pResubmit,
                                 StringType WFID,
                                 StringType OtherEIN,
                                 StringType Contact,
                                 StringType ContactPhone,
                                 StringType ContactPhoneExt,
                                 StringType ContactEmail,
                                 StringType ContactFax,
                                 StringType ContactMethod,
                                 StringType StateInfo1,
                                 StringType StateInfo2,
                                 StringType KindofEmployer,
                                 StringType EmployerContactName,
                                 StringType EmployerContactPhone,
                                 StringType EmployerContactPhoneExt,
                                 StringType EmployerContactEmail,
                                 StringType EmployerContactFax,
                                 StringType SubmitterLocationAddress,
                                 StringType SubmitterDeliveryAddress)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Pr23rSp";

                appDB.AddCommandParameter(cmd, "YearStartDate", YearStartDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "YearEndDate", YearEndDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PIN", PIN, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EmpID", EmpID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EmpType", EmpType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EstabNumber", EstabNumber, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CreateStateTaxRec", CreateStateTaxRec, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pResubmit", pResubmit, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "WFID", WFID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OtherEIN", OtherEIN, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Contact", Contact, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ContactPhone", ContactPhone, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ContactPhoneExt", ContactPhoneExt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ContactEmail", ContactEmail, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ContactFax", ContactFax, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ContactMethod", ContactMethod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StateInfo1", StateInfo1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StateInfo2", StateInfo2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "KindofEmployer", KindofEmployer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EmployerContactName", EmployerContactName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EmployerContactPhone", EmployerContactPhone, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EmployerContactPhoneExt", EmployerContactPhoneExt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EmployerContactEmail", EmployerContactEmail, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EmployerContactFax", EmployerContactFax, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SubmitterLocationAddress", SubmitterLocationAddress, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SubmitterDeliveryAddress", SubmitterDeliveryAddress, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
