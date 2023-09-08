//PROJECT NAME: EmployeeExt
//CLASS NAME: SLEmpPrBanks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Employee
{
    [IDOExtensionClass("SLEmpPrBanks")]
    public class SLEmpPrBanks : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int DirDepSaveRankSp(string PEmpNum,
                                    ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iDirDepSaveRankExt = new DirDepSaveRankFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iDirDepSaveRankExt.DirDepSaveRankSp(PEmpNum,
                                                                   ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateDirDepAccountSp(string EmpNum,
                                           int? BankNum,
                                           string DepAccount,
                                           short? Rank,
                                           ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iValidateDirDepAccountExt = new ValidateDirDepAccountFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iValidateDirDepAccountExt.ValidateDirDepAccountSp(EmpNum,
                                                                                 BankNum,
                                                                                 DepAccount,
                                                                                 Rank,
                                                                                 ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateDirDepRankSp(string EmpNum,
		                                short? NewRank,
		                                [Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateDirDepRankExt = new ValidateDirDepRankFactory().Create(appDb);
				
				var result = iValidateDirDepRankExt.ValidateDirDepRankSp(EmpNum,
				                                                         NewRank,
				                                                         Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PostSaveSp(string PEmpNum,
		                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDirDepPostSaveExt = new DirDepPostSaveFactory().Create(appDb);
				
				var result = iDirDepPostSaveExt.DirDepPostSaveSp(PEmpNum,
				                                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
