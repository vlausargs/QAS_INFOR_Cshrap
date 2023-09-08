//PROJECT NAME: CSIVendor
//CLASS NAME: CreateWht.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface ICreateWht
    {
        int CreateWhtSp(string VendNum,
                        ref string WHTType,
                        ref string TaxID,
                        ref string CompanyName,
                        ref string Address1,
                        ref string Address2,
                        ref string Address3,
                        ref string Address4,
                        ref string PostZip);
    }

    public class CreateWht : ICreateWht
    {
        readonly IApplicationDB appDB;

        public CreateWht(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CreateWhtSp(string VendNum,
                               ref string WHTType,
                               ref string TaxID,
                               ref string CompanyName,
                               ref string Address1,
                               ref string Address2,
                               ref string Address3,
                               ref string Address4,
                               ref string PostZip)
        {
            VendNumType _VendNum = VendNum;
            TH_WHTTypeType _WHTType = WHTType;
            TaxRegNumType _TaxID = TaxID;
            NameType _CompanyName = CompanyName;
            AddressType _Address1 = Address1;
            AddressType _Address2 = Address2;
            AddressType _Address3 = Address3;
            AddressType _Address4 = Address4;
            PostalCodeType _PostZip = PostZip;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreateWhtSp";

                appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "WHTType", _WHTType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxID", _TaxID, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CompanyName", _CompanyName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Address1", _Address1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Address2", _Address2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Address3", _Address3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Address4", _Address4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PostZip", _PostZip, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                WHTType = _WHTType;
                TaxID = _TaxID;
                CompanyName = _CompanyName;
                Address1 = _Address1;
                Address2 = _Address2;
                Address3 = _Address3;
                Address4 = _Address4;
                PostZip = _PostZip;

                return Severity;
            }
        }
    }
}
