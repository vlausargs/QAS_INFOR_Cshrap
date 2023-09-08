//PROJECT NAME: FSPlusSROExt
//CLASS NAME: FSDeposits.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Requests;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.FSPlusSRO
{
    [IDOExtensionClass("FSDeposits")]
    public class FSDeposits : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSDepositValidSroSp(string SroNum,
                                          ref string CustNum,
                                          ref decimal? DepositAmt,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSDepositValidSroExt = new SSSFSDepositValidSroFactory().Create(appDb);

                CustNumType oCustNum = CustNum;
                AmountType oDepositAmt = DepositAmt;
                InfobarType oInfobar = Infobar;

                int Severity = iSSSFSDepositValidSroExt.SSSFSDepositValidSroSp(SroNum,
                                                                               ref oCustNum,
                                                                               ref oDepositAmt,
                                                                               ref oInfobar);

                CustNum = oCustNum;
                DepositAmt = oDepositAmt;
                Infobar = oInfobar;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSDepositValidCustSp(string CustNum,
                                           ref decimal? DepositAmt,
                                           ref string Infobar,
                                           ref string CurAmtFormat,
                                           ref string CurCstPriceFormat)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSDepositValidCustExt = new SSSFSDepositValidCustFactory().Create(appDb);

                AmountType oDepositAmt = DepositAmt;
                InfobarType oInfobar = Infobar;
                InputMaskType oCurAmtFormat = CurAmtFormat;
                InputMaskType oCurCstPriceFormat = CurCstPriceFormat;

                int Severity = iSSSFSDepositValidCustExt.SSSFSDepositValidCustSp(CustNum,
                                                                                 ref oDepositAmt,
                                                                                 ref oInfobar,
                                                                                 ref oCurAmtFormat,
                                                                                 ref oCurCstPriceFormat);

                DepositAmt = oDepositAmt;
                Infobar = oInfobar;
                CurAmtFormat = oCurAmtFormat;
                CurCstPriceFormat = oCurCstPriceFormat;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSDepositInitSp(ref string CreditAcct,
                                      ref string CreditAcctUnit1,
                                      ref string CreditAcctUnit2,
                                      ref string CreditAcctUnit3,
                                      ref string CreditAcctUnit4,
                                      ref string DebitAcct,
                                      ref string DebitAcctUnit1,
                                      ref string DebitAcctUnit2,
                                      ref string DebitAcctUnit3,
                                      ref string DebitAcctUnit4,
                                      ref string CreditChtAccessUnit1,
                                      ref string CreditChtAccessUnit2,
                                      ref string CreditChtAccessUnit3,
                                      ref string CreditChtAccessUnit4,
                                      ref string CreditChtDescription,
                                      ref string DebitChtAccessUnit1,
                                      ref string DebitChtAccessUnit2,
                                      ref string DebitChtAccessUnit3,
                                      ref string DebitChtAccessUnit4,
                                      ref string DebitChtDescription,
                                      ref byte? CreditChtIsControl,
                                      ref byte? DebitChtIsControl,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSDepositInitExt = new SSSFSDepositInitFactory().Create(appDb);

                AcctType oCreditAcct = CreditAcct;
                UnitCode1Type oCreditAcctUnit1 = CreditAcctUnit1;
                UnitCode2Type oCreditAcctUnit2 = CreditAcctUnit2;
                UnitCode3Type oCreditAcctUnit3 = CreditAcctUnit3;
                UnitCode4Type oCreditAcctUnit4 = CreditAcctUnit4;
                AcctType oDebitAcct = DebitAcct;
                UnitCode1Type oDebitAcctUnit1 = DebitAcctUnit1;
                UnitCode2Type oDebitAcctUnit2 = DebitAcctUnit2;
                UnitCode3Type oDebitAcctUnit3 = DebitAcctUnit3;
                UnitCode4Type oDebitAcctUnit4 = DebitAcctUnit4;
                UnitCodeAccessType oCreditChtAccessUnit1 = CreditChtAccessUnit1;
                UnitCodeAccessType oCreditChtAccessUnit2 = CreditChtAccessUnit2;
                UnitCodeAccessType oCreditChtAccessUnit3 = CreditChtAccessUnit3;
                UnitCodeAccessType oCreditChtAccessUnit4 = CreditChtAccessUnit4;
                DescriptionType oCreditChtDescription = CreditChtDescription;
                UnitCodeAccessType oDebitChtAccessUnit1 = DebitChtAccessUnit1;
                UnitCodeAccessType oDebitChtAccessUnit2 = DebitChtAccessUnit2;
                UnitCodeAccessType oDebitChtAccessUnit3 = DebitChtAccessUnit3;
                UnitCodeAccessType oDebitChtAccessUnit4 = DebitChtAccessUnit4;
                DescriptionType oDebitChtDescription = DebitChtDescription;
                ListYesNoType oCreditChtIsControl = CreditChtIsControl;
                ListYesNoType oDebitChtIsControl = DebitChtIsControl;
                InfobarType oInfobar = Infobar;

                int Severity = iSSSFSDepositInitExt.SSSFSDepositInitSp(ref oCreditAcct,
                                                                       ref oCreditAcctUnit1,
                                                                       ref oCreditAcctUnit2,
                                                                       ref oCreditAcctUnit3,
                                                                       ref oCreditAcctUnit4,
                                                                       ref oDebitAcct,
                                                                       ref oDebitAcctUnit1,
                                                                       ref oDebitAcctUnit2,
                                                                       ref oDebitAcctUnit3,
                                                                       ref oDebitAcctUnit4,
                                                                       ref oCreditChtAccessUnit1,
                                                                       ref oCreditChtAccessUnit2,
                                                                       ref oCreditChtAccessUnit3,
                                                                       ref oCreditChtAccessUnit4,
                                                                       ref oCreditChtDescription,
                                                                       ref oDebitChtAccessUnit1,
                                                                       ref oDebitChtAccessUnit2,
                                                                       ref oDebitChtAccessUnit3,
                                                                       ref oDebitChtAccessUnit4,
                                                                       ref oDebitChtDescription,
                                                                       ref oCreditChtIsControl,
                                                                       ref oDebitChtIsControl,
                                                                       ref oInfobar);

                CreditAcct = oCreditAcct;
                CreditAcctUnit1 = oCreditAcctUnit1;
                CreditAcctUnit2 = oCreditAcctUnit2;
                CreditAcctUnit3 = oCreditAcctUnit3;
                CreditAcctUnit4 = oCreditAcctUnit4;
                DebitAcct = oDebitAcct;
                DebitAcctUnit1 = oDebitAcctUnit1;
                DebitAcctUnit2 = oDebitAcctUnit2;
                DebitAcctUnit3 = oDebitAcctUnit3;
                DebitAcctUnit4 = oDebitAcctUnit4;
                CreditChtAccessUnit1 = oCreditChtAccessUnit1;
                CreditChtAccessUnit2 = oCreditChtAccessUnit2;
                CreditChtAccessUnit3 = oCreditChtAccessUnit3;
                CreditChtAccessUnit4 = oCreditChtAccessUnit4;
                CreditChtDescription = oCreditChtDescription;
                DebitChtAccessUnit1 = oDebitChtAccessUnit1;
                DebitChtAccessUnit2 = oDebitChtAccessUnit2;
                DebitChtAccessUnit3 = oDebitChtAccessUnit3;
                DebitChtAccessUnit4 = oDebitChtAccessUnit4;
                DebitChtDescription = oDebitChtDescription;
                CreditChtIsControl = oCreditChtIsControl;
                DebitChtIsControl = oDebitChtIsControl;
                Infobar = oInfobar;


                return Severity;
            }
        }
    }
}
