//PROJECT NAME: CustomerExt
//CLASS NAME: SLChargebacks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLChargebacks")]
    public class SLChargebacks : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ChargebackTypeAccountSp(string ChargebackType,
                                           ref string Account,
                                           ref string Description,
                                           ref string UnitCode1,
                                           ref string UnitCode2,
                                           ref string UnitCode3,
                                           ref string UnitCode4)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iChargebackTypeAccountExt = new ChargebackTypeAccountFactory().Create(appDb);

                AcctType oAccount = Account;
                DescriptionType oDescription = Description;
                UnitCode1Type oUnitCode1 = UnitCode1;
                UnitCode2Type oUnitCode2 = UnitCode2;
                UnitCode3Type oUnitCode3 = UnitCode3;
                UnitCode4Type oUnitCode4 = UnitCode4;

                int Severity = iChargebackTypeAccountExt.ChargebackTypeAccountSp(ChargebackType,
                                                                                 ref oAccount,
                                                                                 ref oDescription,
                                                                                 ref oUnitCode1,
                                                                                 ref oUnitCode2,
                                                                                 ref oUnitCode3,
                                                                                 ref oUnitCode4);

                Account = oAccount;
                Description = oDescription;
                UnitCode1 = oUnitCode1;
                UnitCode2 = oUnitCode2;
                UnitCode3 = oUnitCode3;
                UnitCode4 = oUnitCode4;


                return Severity;
            }
        }
    }
}
