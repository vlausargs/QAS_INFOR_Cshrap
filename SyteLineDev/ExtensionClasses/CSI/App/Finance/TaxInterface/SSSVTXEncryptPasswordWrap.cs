//PROJECT NAME: Finance
//CLASS NAME: SSSVTXEncryptPasswordWrap.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data.CreditCard;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXEncryptPasswordWrap : ISSSVTXEncryptPasswordWrap
	{
		readonly IApplicationDB appDB;
        readonly ICreditCardUtil iCreditCardUtil;

        public SSSVTXEncryptPasswordWrap(IApplicationDB appDB, ICreditCardUtil iCreditCardUtil)
		{
			this.appDB = appDB;
            this.iCreditCardUtil = iCreditCardUtil;
		}
		
		public (int? ReturnCode, string EncryptedPassword,
		string Infobar) SSSVTXEncryptPasswordWrapSp(string Password,
		string EncryptedPassword,
		string Infobar)
		{
			PasswordType _Password = Password;
			EncryptedClientPasswordType _EncryptedPassword = EncryptedPassword;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{

                int? Severity = null;
                Severity = 0;
                Infobar = null;
                if (!iCreditCardUtil.EncryptValue(Password, out EncryptedPassword, out Infobar))
                {
                    Severity = 16;
                }


                return (Severity, EncryptedPassword, Infobar);
			}
		}
	}
}
