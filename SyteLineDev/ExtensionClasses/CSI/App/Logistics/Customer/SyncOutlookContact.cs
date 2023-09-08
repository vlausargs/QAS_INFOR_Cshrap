//PROJECT NAME: CSICustomer
//CLASS NAME: SyncOutlookContact.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ISyncOutlookContact
    {
        int SyncOutlookContactSp(ref string RowPointer,
                                 string LName,
                                 string FName,
                                 string Mi,
                                 string SName,
                                 string Job_Title,
                                 string Company,
                                 string Addr__1,
                                 string Addr__2,
                                 string Addr__3,
                                 string Addr__4,
                                 string City,
                                 string State,
                                 string PostalCode,
                                 string Country,
                                 string Office_phone,
                                 string Mobile_phone,
                                 string Home_phone,
                                 string Fax_Num,
                                 string Email);
    }

    public class SyncOutlookContact : ISyncOutlookContact
    {
        readonly IApplicationDB appDB;

        public SyncOutlookContact(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SyncOutlookContactSp(ref string RowPointer,
                                        string LName,
                                        string FName,
                                        string Mi,
                                        string SName,
                                        string Job_Title,
                                        string Company,
                                        string Addr__1,
                                        string Addr__2,
                                        string Addr__3,
                                        string Addr__4,
                                        string City,
                                        string State,
                                        string PostalCode,
                                        string Country,
                                        string Office_phone,
                                        string Mobile_phone,
                                        string Home_phone,
                                        string Fax_Num,
                                        string Email)
        {
            StringType _RowPointer = RowPointer;
            SurnameType _LName = LName;
            GivenNameType _FName = FName;
            InitialType _Mi = Mi;
            SuffixNameType _SName = SName;
            JobTitleType _Job_Title = Job_Title;
            NameType _Company = Company;
            AddressType _Addr__1 = Addr__1;
            AddressType _Addr__2 = Addr__2;
            AddressType _Addr__3 = Addr__3;
            AddressType _Addr__4 = Addr__4;
            CityType _City = City;
            StateType _State = State;
            PostalCodeType _PostalCode = PostalCode;
            CountryType _Country = Country;
            PhoneType _Office_phone = Office_phone;
            PhoneType _Mobile_phone = Mobile_phone;
            PhoneType _Home_phone = Home_phone;
            PhoneType _Fax_Num = Fax_Num;
            EmailType _Email = Email;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SyncOutlookContactSp";

                appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LName", _LName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FName", _FName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Mi", _Mi, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SName", _SName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Job_Title", _Job_Title, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Company", _Company, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Addr##1", _Addr__1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Addr##2", _Addr__2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Addr##3", _Addr__3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Addr##4", _Addr__4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PostalCode", _PostalCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Office_phone", _Office_phone, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Mobile_phone", _Mobile_phone, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Home_phone", _Home_phone, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Fax_Num", _Fax_Num, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                RowPointer = _RowPointer;

                return Severity;
            }
        }
    }
}
