//PROJECT NAME: FinanceExt
//CLASS NAME: SLFsbs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLFsbs")]
    public class SLFsbs : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MultiFSBGetFiscalYearStartAndEndDateSp(string FSBName,
                                                          short? FiscalYear,
                                                          ref DateTime? FiscalYearStartDate,
                                                          ref DateTime? FiscalYearEndDate,
                                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLFsbsExt = new MultiFSBGetFiscalYearStartAndEndDateFactory().Create(appDb);

                DateType oFiscalYearStartDate = FiscalYearStartDate;
                DateType oFiscalYearEndDate = FiscalYearEndDate;
                InfobarType oInfobar = Infobar;

                int Severity = iSLFsbsExt.MultiFSBGetFiscalYearStartAndEndDateSp(FSBName,
                                                                                 FiscalYear,
                                                                                 ref oFiscalYearStartDate,
                                                                                 ref oFiscalYearEndDate,
                                                                                 ref oInfobar);

                FiscalYearStartDate = oFiscalYearStartDate;
                FiscalYearEndDate = oFiscalYearEndDate;
                Infobar = oInfobar;


                return Severity;
            }
        }
    }
}
