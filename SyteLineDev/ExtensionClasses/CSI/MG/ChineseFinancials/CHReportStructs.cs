//PROJECT NAME: ChineseFinancialsExt
//CLASS NAME: CHReportStructs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance.Chinese;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.ChineseFinancials
{
    [IDOExtensionClass("CHReportStructs")]
    public class CHReportStructs : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CHSMultiBucketSp(decimal? BookKey,
                                    string BookType,
                                    string BeginAccount,
                                    string EndAccount,
                                    string BegUnit1,
                                    string EndUnit1,
                                    string BegUnit2,
                                    string EndUnit2,
                                    string BegUnit3,
                                    string EndUnit3,
                                    string BegUnit4,
                                    string EndUnit4,
                                    DateTime? BeginDate,
                                    DateTime? EndDate,
                                    byte? PrintDayTotal,
                                    byte? IncludeZeroBalAccount,
                                    Guid? RptSessionID,
                                    ref int? BGTaskCount)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCHSMultiBucketExt = new CHSMultiBucketFactory().Create(appDb);

                IntType oBGTaskCount = BGTaskCount;

                int Severity = iCHSMultiBucketExt.CHSMultiBucketSp(BookKey,
                                                                   BookType,
                                                                   BeginAccount,
                                                                   EndAccount,
                                                                   BegUnit1,
                                                                   EndUnit1,
                                                                   BegUnit2,
                                                                   EndUnit2,
                                                                   BegUnit3,
                                                                   EndUnit3,
                                                                   BegUnit4,
                                                                   EndUnit4,
                                                                   BeginDate,
                                                                   EndDate,
                                                                   PrintDayTotal,
                                                                   IncludeZeroBalAccount,
                                                                   RptSessionID,
                                                                   ref oBGTaskCount);

                BGTaskCount = oBGTaskCount;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CHSLoadCurrencyNameSp(string Code,
                                         ref string Description,
                                         ref string InfoBar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCHSLoadCurrencyNameExt = new CHSLoadCurrencyNameFactory().Create(appDb);

                DescriptionType oDescription = Description;
                InfobarType oInfoBar = InfoBar;

                int Severity = iCHSLoadCurrencyNameExt.CHSLoadCurrencyNameSp(Code,
                                                                             ref oDescription,
                                                                             ref oInfoBar);

                Description = oDescription;
                InfoBar = oInfoBar;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CHSCheckBookNameSp(string BookName, ref string Infobar)
        {
            var iCHSCheckBookNameExt = new CHSCheckBookNameFactory().Create(this, true);

            var result = iCHSCheckBookNameExt.CHSCheckBookNameSp(BookName, Infobar);

            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CHSCheckAccountCodeSp(string Acct, ref string InfoBar)
        {
            var iCHSCheckAccountCodeExt = new CHSCheckAccountCodeFactory().Create(this, true);

            var result = iCHSCheckAccountCodeExt.CHSCheckAccountCodeSp(Acct, InfoBar);

            InfoBar = result.InfoBar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CHSAccountUnitAccessibilitySp(string Account,
                                                 ref string AccessUnit1,
                                                 ref string AccessUnit2,
                                                 ref string AccessUnit3,
                                                 ref string AccessUnit4,
                                                 ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCHSAccountUnitAccessibilityExt = new CHSAccountUnitAccessibilityFactory().Create(appDb);

                UnitCodeAccessType oAccessUnit1 = AccessUnit1;
                UnitCodeAccessType oAccessUnit2 = AccessUnit2;
                UnitCodeAccessType oAccessUnit3 = AccessUnit3;
                UnitCodeAccessType oAccessUnit4 = AccessUnit4;
                InfobarType oInfobar = Infobar;

                int Severity = iCHSAccountUnitAccessibilityExt.CHSAccountUnitAccessibilitySp(Account,
                                                                                             ref oAccessUnit1,
                                                                                             ref oAccessUnit2,
                                                                                             ref oAccessUnit3,
                                                                                             ref oAccessUnit4,
                                                                                             ref oInfobar);

                AccessUnit1 = oAccessUnit1;
                AccessUnit2 = oAccessUnit2;
                AccessUnit3 = oAccessUnit3;
                AccessUnit4 = oAccessUnit4;
                Infobar = oInfobar;


                return Severity;
            }
        }
    }
}

