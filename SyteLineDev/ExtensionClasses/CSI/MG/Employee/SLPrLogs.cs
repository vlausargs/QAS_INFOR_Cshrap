//PROJECT NAME: EmployeeExt
//CLASS NAME: SLPrLogs.cs

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
    [IDOExtensionClass("SLPrLogs")]
    public class SLPrLogs : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PrLogAssignCurVarsSp(ref string EmpNum,
                                        ref DateTime? CurStart,
                                        ref DateTime? CurEnd,
                                        ref DateTime? CurDate,
                                        ref string CurEmpNum,
                                        ref string CurEmpName,
                                        ref short? CurEmpSeq,
                                        ref string CurShift,
                                        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iPrLogAssignCurVarsExt = new PrLogAssignCurVarsFactory().Create(appDb);

                EmpNumType oEmpNum = EmpNum;
                DateType oCurStart = CurStart;
                DateType oCurEnd = CurEnd;
                DateType oCurDate = CurDate;
                EmpNumType oCurEmpNum = CurEmpNum;
                EmpNameType oCurEmpName = CurEmpName;
                PrLogSeqType oCurEmpSeq = CurEmpSeq;
                ShiftType oCurShift = CurShift;
                InfobarType oInfobar = Infobar;

                int Severity = iPrLogAssignCurVarsExt.PrLogAssignCurVarsSp(ref oEmpNum,
                                                                           ref oCurStart,
                                                                           ref oCurEnd,
                                                                           ref oCurDate,
                                                                           ref oCurEmpNum,
                                                                           ref oCurEmpName,
                                                                           ref oCurEmpSeq,
                                                                           ref oCurShift,
                                                                           ref oInfobar);

                EmpNum = oEmpNum;
                CurStart = oCurStart;
                CurEnd = oCurEnd;
                CurDate = oCurDate;
                CurEmpNum = oCurEmpNum;
                CurEmpName = oCurEmpName;
                CurEmpSeq = oCurEmpSeq;
                CurShift = oCurShift;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PrLogGetNextTransNumSp(string EmpNum,
                                          short? EmpSeq,
                                          ref decimal? TransNum,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iPrLogGetNextTransNumExt = new PrLogGetNextTransNumFactory().Create(appDb);

                MatlTransNumType oTransNum = TransNum;
                InfobarType oInfobar = Infobar;

                int Severity = iPrLogGetNextTransNumExt.PrLogGetNextTransNumSp(EmpNum,
                                                                               EmpSeq,
                                                                               ref oTransNum,
                                                                               ref oInfobar);

                TransNum = oTransNum;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PrLogUpdateOrAddDeleteCheckSp(string Action,
                                                 string EmpNum,
                                                 short? Seq,
                                                 decimal? TransNum,
                                                 DateTime? NewWorkDate,
                                                 string NewHrType,
                                                 decimal? NewHrs,
                                                 decimal? NewPayRate,
                                                 string AdpParmInterfaceVersion,
                                                 ref string Dept,
                                                 ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iPrLogUpdateOrAddDeleteCheckExt = new PrLogUpdateOrAddDeleteCheckFactory().Create(appDb);

                DeptType oDept = Dept;
                InfobarType oInfobar = Infobar;

                int Severity = iPrLogUpdateOrAddDeleteCheckExt.PrLogUpdateOrAddDeleteCheckSp(Action,
                                                                                             EmpNum,
                                                                                             Seq,
                                                                                             TransNum,
                                                                                             NewWorkDate,
                                                                                             NewHrType,
                                                                                             NewHrs,
                                                                                             NewPayRate,
                                                                                             AdpParmInterfaceVersion,
                                                                                             ref oDept,
                                                                                             ref oInfobar);

                Dept = oDept;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PrLogValidateSeqSp(string EmpNum,
                                      short? EmpSeq,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iPrLogValidateSeqExt = new PrLogValidateSeqFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iPrLogValidateSeqExt.PrLogValidateSeqSp(EmpNum,
                                                                       EmpSeq,
                                                                       ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PrLogEmpDefaultsPayTransSp(string EmpNum,
		                                      string HrType,
		                                      DateTime? WorkDate,
		                                      ref string EmpName,
		                                      ref short? EmpSeq,
		                                      ref string EmpShift,
		                                      ref decimal? TransNum,
		                                      ref decimal? PayRate,
		                                      ref string Infobar,
		                                      [Optional] ref string Acct,
		                                      [Optional] ref string AcctUnit1,
		                                      [Optional] ref string AcctUnit2,
		                                      [Optional] ref string AcctUnit3,
		                                      [Optional] ref string AcctUnit4)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPrLogEmpDefaultsPayTransExt = new PrLogEmpDefaultsPayTransFactory().Create(appDb);
				
				var result = iPrLogEmpDefaultsPayTransExt.PrLogEmpDefaultsPayTransSp(EmpNum,
				                                                                     HrType,
				                                                                     WorkDate,
				                                                                     EmpName,
				                                                                     EmpSeq,
				                                                                     EmpShift,
				                                                                     TransNum,
				                                                                     PayRate,
				                                                                     Infobar,
				                                                                     Acct,
				                                                                     AcctUnit1,
				                                                                     AcctUnit2,
				                                                                     AcctUnit3,
				                                                                     AcctUnit4);
				
				int Severity = result.ReturnCode.Value;
				EmpName = result.EmpName;
				EmpSeq = result.EmpSeq;
				EmpShift = result.EmpShift;
				TransNum = result.TransNum;
				PayRate = result.PayRate;
				Infobar = result.Infobar;
				Acct = result.Acct;
				AcctUnit1 = result.AcctUnit1;
				AcctUnit2 = result.AcctUnit2;
				AcctUnit3 = result.AcctUnit3;
				AcctUnit4 = result.AcctUnit4;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PrLogRefreshEmpDefaultsSp(string EmpNum,
		ref string EmpName,
		ref int? EmpSeq,
		ref string EmpShift,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPrLogRefreshEmpDefaultsExt = new PrLogRefreshEmpDefaultsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPrLogRefreshEmpDefaultsExt.PrLogRefreshEmpDefaultsSp(EmpNum,
				EmpName,
				EmpSeq,
				EmpShift,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				EmpName = result.EmpName;
				EmpSeq = result.EmpSeq;
				EmpShift = result.EmpShift;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
