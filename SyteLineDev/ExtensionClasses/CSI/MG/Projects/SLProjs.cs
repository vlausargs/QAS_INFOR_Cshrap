//PROJECT NAME: ProjectsExt
//CLASS NAME: SLProjs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Projects;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Logistics.Customer;
using CSI.Data.RecordSets;
using CSI.POS;

namespace CSI.MG.Projects
{
    [IDOExtensionClass("SLProjs")]
    public class SLProjs : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetProjAcctInfoSp(string ProductCode,
		                             ref string DisCgsAcct,
		                             ref string DisCgsAcctUnit1,
		                             ref string DisCgsAcctUnit2,
		                             ref string DisCgsAcctUnit3,
		                             ref string DisCgsAcctUnit4,
		                             ref string DisCgsAcctDesc,
		                             ref string DisCgsLbrAcct,
		                             ref string DisCgsLbrAcctUnit1,
		                             ref string DisCgsLbrAcctUnit2,
		                             ref string DisCgsLbrAcctUnit3,
		                             ref string DisCgsLbrAcctUnit4,
		                             ref string DisCgsLbrAcctDesc,
		                             ref string DisCgsOutAcct,
		                             ref string DisCgsOutAcctUnit1,
		                             ref string DisCgsOutAcctUnit2,
		                             ref string DisCgsOutAcctUnit3,
		                             ref string DisCgsOutAcctUnit4,
		                             ref string DisCgsOutAcctDesc,
		                             ref string DisCgsVovhdAcct,
		                             ref string DisCgsVovhdAcctUnit1,
		                             ref string DisCgsVovhdAcctUnit2,
		                             ref string DisCgsVovhdAcctUnit3,
		                             ref string DisCgsVovhdAcctUnit4,
		                             ref string DisCgsVovhdAcctDesc,
		                             ref string DisCgsFovhdAcct,
		                             ref string DisCgsFovhdAcctUnit1,
		                             ref string DisCgsFovhdAcctUnit2,
		                             ref string DisCgsFovhdAcctUnit3,
		                             ref string DisCgsFovhdAcctUnit4,
		                             ref string DisCgsFovhdAcctDesc,
		                             ref string ProjMatlAcct,
		                             ref string ProjMatlAcctUnit1,
		                             ref string ProjMatlAcctUnit2,
		                             ref string ProjMatlAcctUnit3,
		                             ref string ProjMatlAcctUnit4,
		                             ref string ProjMatlAcctDesc,
		                             ref string ProjLabrAcct,
		                             ref string ProjLabrAcctUnit1,
		                             ref string ProjLabrAcctUnit2,
		                             ref string ProjLabrAcctUnit3,
		                             ref string ProjLabrAcctUnit4,
		                             ref string ProjLabrAcctDesc,
		                             ref string ProjOtherAcct,
		                             ref string ProjOtherAcctUnit1,
		                             ref string ProjOtherAcctUnit2,
		                             ref string ProjOtherAcctUnit3,
		                             ref string ProjOtherAcctUnit4,
		                             ref string ProjOtherAcctDesc,
		                             ref string ProjOvhAcct,
		                             ref string ProjOvhAcctUnit1,
		                             ref string ProjOvhAcctUnit2,
		                             ref string ProjOvhAcctUnit3,
		                             ref string ProjOvhAcctUnit4,
		                             ref string ProjOvhAcctDesc,
		                             ref string ProjGaAcct,
		                             ref string ProjGaAcctUnit1,
		                             ref string ProjGaAcctUnit2,
		                             ref string ProjGaAcctUnit3,
		                             ref string ProjGaAcctUnit4,
		                             ref string ProjGaAcctDesc,
		                             string ProjEndUserType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetProjAcctInfoExt = new GetProjAcctInfoFactory().Create(appDb);
				
				int Severity = iGetProjAcctInfoExt.GetProjAcctInfoSp(ProductCode,
				                                                     ref DisCgsAcct,
				                                                     ref DisCgsAcctUnit1,
				                                                     ref DisCgsAcctUnit2,
				                                                     ref DisCgsAcctUnit3,
				                                                     ref DisCgsAcctUnit4,
				                                                     ref DisCgsAcctDesc,
				                                                     ref DisCgsLbrAcct,
				                                                     ref DisCgsLbrAcctUnit1,
				                                                     ref DisCgsLbrAcctUnit2,
				                                                     ref DisCgsLbrAcctUnit3,
				                                                     ref DisCgsLbrAcctUnit4,
				                                                     ref DisCgsLbrAcctDesc,
				                                                     ref DisCgsOutAcct,
				                                                     ref DisCgsOutAcctUnit1,
				                                                     ref DisCgsOutAcctUnit2,
				                                                     ref DisCgsOutAcctUnit3,
				                                                     ref DisCgsOutAcctUnit4,
				                                                     ref DisCgsOutAcctDesc,
				                                                     ref DisCgsVovhdAcct,
				                                                     ref DisCgsVovhdAcctUnit1,
				                                                     ref DisCgsVovhdAcctUnit2,
				                                                     ref DisCgsVovhdAcctUnit3,
				                                                     ref DisCgsVovhdAcctUnit4,
				                                                     ref DisCgsVovhdAcctDesc,
				                                                     ref DisCgsFovhdAcct,
				                                                     ref DisCgsFovhdAcctUnit1,
				                                                     ref DisCgsFovhdAcctUnit2,
				                                                     ref DisCgsFovhdAcctUnit3,
				                                                     ref DisCgsFovhdAcctUnit4,
				                                                     ref DisCgsFovhdAcctDesc,
				                                                     ref ProjMatlAcct,
				                                                     ref ProjMatlAcctUnit1,
				                                                     ref ProjMatlAcctUnit2,
				                                                     ref ProjMatlAcctUnit3,
				                                                     ref ProjMatlAcctUnit4,
				                                                     ref ProjMatlAcctDesc,
				                                                     ref ProjLabrAcct,
				                                                     ref ProjLabrAcctUnit1,
				                                                     ref ProjLabrAcctUnit2,
				                                                     ref ProjLabrAcctUnit3,
				                                                     ref ProjLabrAcctUnit4,
				                                                     ref ProjLabrAcctDesc,
				                                                     ref ProjOtherAcct,
				                                                     ref ProjOtherAcctUnit1,
				                                                     ref ProjOtherAcctUnit2,
				                                                     ref ProjOtherAcctUnit3,
				                                                     ref ProjOtherAcctUnit4,
				                                                     ref ProjOtherAcctDesc,
				                                                     ref ProjOvhAcct,
				                                                     ref ProjOvhAcctUnit1,
				                                                     ref ProjOvhAcctUnit2,
				                                                     ref ProjOvhAcctUnit3,
				                                                     ref ProjOvhAcctUnit4,
				                                                     ref ProjOvhAcctDesc,
				                                                     ref ProjGaAcct,
				                                                     ref ProjGaAcctUnit1,
				                                                     ref ProjGaAcctUnit2,
				                                                     ref ProjGaAcctUnit3,
				                                                     ref ProjGaAcctUnit4,
				                                                     ref ProjGaAcctDesc,
				                                                     ProjEndUserType);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetProjDistAcctInfoSp(string ProductCode,
		                                 ref string DisCgsAcct,
		                                 ref string DisCgsAcctUnit1,
		                                 ref string DisCgsAcctUnit2,
		                                 ref string DisCgsAcctUnit3,
		                                 ref string DisCgsAcctUnit4,
		                                 ref string DisCgsAcctDesc,
		                                 ref string DisCgsLbrAcct,
		                                 ref string DisCgsLbrAcctUnit1,
		                                 ref string DisCgsLbrAcctUnit2,
		                                 ref string DisCgsLbrAcctUnit3,
		                                 ref string DisCgsLbrAcctUnit4,
		                                 ref string DisCgsLbrAcctDesc,
		                                 ref string DisCgsOutAcct,
		                                 ref string DisCgsOutAcctUnit1,
		                                 ref string DisCgsOutAcctUnit2,
		                                 ref string DisCgsOutAcctUnit3,
		                                 ref string DisCgsOutAcctUnit4,
		                                 ref string DisCgsOutAcctDesc,
		                                 ref string DisCgsVovhdAcct,
		                                 ref string DisCgsVovhdAcctUnit1,
		                                 ref string DisCgsVovhdAcctUnit2,
		                                 ref string DisCgsVovhdAcctUnit3,
		                                 ref string DisCgsVovhdAcctUnit4,
		                                 ref string DisCgsVovhdAcctDesc,
		                                 ref string DisCgsFovhdAcct,
		                                 ref string DisCgsFovhdAcctUnit1,
		                                 ref string DisCgsFovhdAcctUnit2,
		                                 ref string DisCgsFovhdAcctUnit3,
		                                 ref string DisCgsFovhdAcctUnit4,
		                                 ref string DisCgsFovhdAcctDesc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetProjDistAcctInfoExt = new GetProjDistAcctInfoFactory().Create(appDb);
				
				int Severity = iGetProjDistAcctInfoExt.GetProjDistAcctInfoSp(ProductCode,
				                                                             ref DisCgsAcct,
				                                                             ref DisCgsAcctUnit1,
				                                                             ref DisCgsAcctUnit2,
				                                                             ref DisCgsAcctUnit3,
				                                                             ref DisCgsAcctUnit4,
				                                                             ref DisCgsAcctDesc,
				                                                             ref DisCgsLbrAcct,
				                                                             ref DisCgsLbrAcctUnit1,
				                                                             ref DisCgsLbrAcctUnit2,
				                                                             ref DisCgsLbrAcctUnit3,
				                                                             ref DisCgsLbrAcctUnit4,
				                                                             ref DisCgsLbrAcctDesc,
				                                                             ref DisCgsOutAcct,
				                                                             ref DisCgsOutAcctUnit1,
				                                                             ref DisCgsOutAcctUnit2,
				                                                             ref DisCgsOutAcctUnit3,
				                                                             ref DisCgsOutAcctUnit4,
				                                                             ref DisCgsOutAcctDesc,
				                                                             ref DisCgsVovhdAcct,
				                                                             ref DisCgsVovhdAcctUnit1,
				                                                             ref DisCgsVovhdAcctUnit2,
				                                                             ref DisCgsVovhdAcctUnit3,
				                                                             ref DisCgsVovhdAcctUnit4,
				                                                             ref DisCgsVovhdAcctDesc,
				                                                             ref DisCgsFovhdAcct,
				                                                             ref DisCgsFovhdAcctUnit1,
				                                                             ref DisCgsFovhdAcctUnit2,
				                                                             ref DisCgsFovhdAcctUnit3,
				                                                             ref DisCgsFovhdAcctUnit4,
				                                                             ref DisCgsFovhdAcctDesc);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetProjInitDataBindingSp(ref string RetCode,
		                                    ref byte? AutoInvMs,
		                                    ref string WipRelMethod,
		                                    ref string RevCalcMethod,
		                                    ref decimal? RevCalcPct,
		                                    ref decimal? RevCalcAmt,
		                                    ref string CostCalcMethod,
		                                    ref decimal? CostCalcPct,
		                                    ref decimal? CostCalcAmt,
		                                    ref string InvMethod,
		                                    ref string TaxCode1,
		                                    ref string TaxCode1Desc,
		                                    ref string TaxCode2,
		                                    ref string TaxCode2Desc,
		                                    ref byte? VarTaxFreeImports)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetProjInitDataBindingExt = new GetProjInitDataBindingFactory().Create(appDb);
				
				int Severity = iGetProjInitDataBindingExt.GetProjInitDataBindingSp(ref RetCode,
				                                                                   ref AutoInvMs,
				                                                                   ref WipRelMethod,
				                                                                   ref RevCalcMethod,
				                                                                   ref RevCalcPct,
				                                                                   ref RevCalcAmt,
				                                                                   ref CostCalcMethod,
				                                                                   ref CostCalcPct,
				                                                                   ref CostCalcAmt,
				                                                                   ref InvMethod,
				                                                                   ref TaxCode1,
				                                                                   ref TaxCode1Desc,
				                                                                   ref TaxCode2,
				                                                                   ref TaxCode2Desc,
				                                                                   ref VarTaxFreeImports);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetProjInitDataSp(ref string RetCode,
		                             ref byte? AutoInvMs,
		                             ref string WipRelMethod,
		                             ref string RevCalcMethod,
		                             ref decimal? RevCalcPct,
		                             ref decimal? RevCalcAmt,
		                             ref string CostCalcMethod,
		                             ref decimal? CostCalcPct,
		                             ref decimal? CostCalcAmt,
		                             ref string InvMethod,
		                             ref string TaxCode1,
		                             ref string TaxCode1Desc,
		                             ref string TaxCode2,
		                             ref string TaxCode2Desc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetProjInitDataExt = new GetProjInitDataFactory().Create(appDb);
				
				int Severity = iGetProjInitDataExt.GetProjInitDataSp(ref RetCode,
				                                                     ref AutoInvMs,
				                                                     ref WipRelMethod,
				                                                     ref RevCalcMethod,
				                                                     ref RevCalcPct,
				                                                     ref RevCalcAmt,
				                                                     ref CostCalcMethod,
				                                                     ref CostCalcPct,
				                                                     ref CostCalcAmt,
				                                                     ref InvMethod,
				                                                     ref TaxCode1,
				                                                     ref TaxCode1Desc,
				                                                     ref TaxCode2,
				                                                     ref TaxCode2Desc);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetProjProjAcctInfoSp(string ProductCode,
		                                 ref string ProjMatlAcct,
		                                 ref string ProjMatlAcctUnit1,
		                                 ref string ProjMatlAcctUnit2,
		                                 ref string ProjMatlAcctUnit3,
		                                 ref string ProjMatlAcctUnit4,
		                                 ref string ProjMatlAcctDesc,
		                                 ref string ProjLabrAcct,
		                                 ref string ProjLabrAcctUnit1,
		                                 ref string ProjLabrAcctUnit2,
		                                 ref string ProjLabrAcctUnit3,
		                                 ref string ProjLabrAcctUnit4,
		                                 ref string ProjLabrAcctDesc,
		                                 ref string ProjOtherAcct,
		                                 ref string ProjOtherAcctUnit1,
		                                 ref string ProjOtherAcctUnit2,
		                                 ref string ProjOtherAcctUnit3,
		                                 ref string ProjOtherAcctUnit4,
		                                 ref string ProjOtherAcctDesc,
		                                 ref string ProjOvhAcct,
		                                 ref string ProjOvhAcctUnit1,
		                                 ref string ProjOvhAcctUnit2,
		                                 ref string ProjOvhAcctUnit3,
		                                 ref string ProjOvhAcctUnit4,
		                                 ref string ProjOvhAcctDesc,
		                                 ref string ProjGaAcct,
		                                 ref string ProjGaAcctUnit1,
		                                 ref string ProjGaAcctUnit2,
		                                 ref string ProjGaAcctUnit3,
		                                 ref string ProjGaAcctUnit4,
		                                 ref string ProjGaAcctDesc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetProjProjAcctInfoExt = new GetProjProjAcctInfoFactory().Create(appDb);
				
				int Severity = iGetProjProjAcctInfoExt.GetProjProjAcctInfoSp(ProductCode,
				                                                             ref ProjMatlAcct,
				                                                             ref ProjMatlAcctUnit1,
				                                                             ref ProjMatlAcctUnit2,
				                                                             ref ProjMatlAcctUnit3,
				                                                             ref ProjMatlAcctUnit4,
				                                                             ref ProjMatlAcctDesc,
				                                                             ref ProjLabrAcct,
				                                                             ref ProjLabrAcctUnit1,
				                                                             ref ProjLabrAcctUnit2,
				                                                             ref ProjLabrAcctUnit3,
				                                                             ref ProjLabrAcctUnit4,
				                                                             ref ProjLabrAcctDesc,
				                                                             ref ProjOtherAcct,
				                                                             ref ProjOtherAcctUnit1,
				                                                             ref ProjOtherAcctUnit2,
				                                                             ref ProjOtherAcctUnit3,
				                                                             ref ProjOtherAcctUnit4,
				                                                             ref ProjOtherAcctDesc,
				                                                             ref ProjOvhAcct,
				                                                             ref ProjOvhAcctUnit1,
				                                                             ref ProjOvhAcctUnit2,
				                                                             ref ProjOvhAcctUnit3,
				                                                             ref ProjOvhAcctUnit4,
				                                                             ref ProjOvhAcctDesc,
				                                                             ref ProjGaAcct,
				                                                             ref ProjGaAcctUnit1,
				                                                             ref ProjGaAcctUnit2,
				                                                             ref ProjGaAcctUnit3,
				                                                             ref ProjGaAcctUnit4,
				                                                             ref ProjGaAcctDesc);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MilestoneButtonEnableSp(string WBSNum,
		                                   ref byte? EnableButton,
		                                   ref byte? EnableEstButton)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMilestoneButtonEnableExt = new MilestoneButtonEnableFactory().Create(appDb);
				
				int Severity = iMilestoneButtonEnableExt.MilestoneButtonEnableSp(WBSNum,
				                                                                 ref EnableButton,
				                                                                 ref EnableEstButton);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjDateChangedSp(string ProjNum,
		                             string CurrCode,
		                             DateTime? ProjDate,
		                             ref decimal? ExchRate,
		                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProjDateChangedExt = new ProjDateChangedFactory().Create(appDb);
				
				int Severity = iProjDateChangedExt.ProjDateChangedSp(ProjNum,
				                                                     CurrCode,
				                                                     ProjDate,
				                                                     ref ExchRate,
				                                                     ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjectManagerAlertsSp(ref int? PastDueProjects,
		                                  ref int? PastDueProjectTasks,
		                                  ref int? EstimatesToExpire,
		                                  ref int? NumberOfUserTasks,
		                                  ref int? NumberOfEventMessages)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProjectManagerAlertsExt = new ProjectManagerAlertsFactory().Create(appDb);
				
				int Severity = iProjectManagerAlertsExt.ProjectManagerAlertsSp(ref PastDueProjects,
				                                                               ref PastDueProjectTasks,
				                                                               ref EstimatesToExpire,
				                                                               ref NumberOfUserTasks,
				                                                               ref NumberOfEventMessages);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjStatusValidSp(string ProjNum,
		                             string ProjType,
		                             string OldStatus,
		                             string NewStatus,
		                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProjStatusValidExt = new ProjStatusValidFactory().Create(appDb);
				
				int Severity = iProjStatusValidExt.ProjStatusValidSp(ProjNum,
				                                                     ProjType,
				                                                     OldStatus,
				                                                     NewStatus,
				                                                     ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateAutoNominateInvoiceSp(ref byte? AutoNominateInvoice)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdateAutoNominateInvoiceExt = new UpdateAutoNominateInvoiceFactory().Create(appDb);
				
				int Severity = iUpdateAutoNominateInvoiceExt.UpdateAutoNominateInvoiceSp(ref AutoNominateInvoice);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateProjInfoByCustSp(string CustNum,
		                                  int? CustSeq,
		                                  string ProjType,
		                                  byte? TaxSyst1Enable,
		                                  string TaxMode1,
		                                  byte? TaxSyst2Enable,
		                                  string TaxMode2,
		                                  DateTime? OrderDate,
		                                  ref string TaxCode1,
		                                  ref string TaxCode1Desc,
		                                  ref string TaxCode2,
		                                  ref string TaxCode2Desc,
		                                  ref string CurrCode,
		                                  ref byte? Fixed,
		                                  ref string InvTermsCode,
		                                  ref string BillToAddress,
		                                  ref string ShipToAddress,
		                                  ref byte? CreditHold,
		                                  ref string TransNat,
		                                  ref string TransNat2,
		                                  ref string Delterm,
		                                  ref string ProcessInd,
		                                  ref string Infobar,
		                                  ref string ShipToCountry,
		                                  ref string EndUserType,
		                                  ref string EndUserTypeDesc,
		                                  ref decimal? ExchRate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdateProjInfoByCustExt = new UpdateProjInfoByCustFactory().Create(appDb);
				
				int Severity = iUpdateProjInfoByCustExt.UpdateProjInfoByCustSp(CustNum,
				                                                               CustSeq,
				                                                               ProjType,
				                                                               TaxSyst1Enable,
				                                                               TaxMode1,
				                                                               TaxSyst2Enable,
				                                                               TaxMode2,
				                                                               OrderDate,
				                                                               ref TaxCode1,
				                                                               ref TaxCode1Desc,
				                                                               ref TaxCode2,
				                                                               ref TaxCode2Desc,
				                                                               ref CurrCode,
				                                                               ref Fixed,
				                                                               ref InvTermsCode,
				                                                               ref BillToAddress,
				                                                               ref ShipToAddress,
				                                                               ref CreditHold,
				                                                               ref TransNat,
				                                                               ref TransNat2,
				                                                               ref Delterm,
				                                                               ref ProcessInd,
				                                                               ref Infobar,
				                                                               ref ShipToCountry,
				                                                               ref EndUserType,
				                                                               ref EndUserTypeDesc,
				                                                               ref ExchRate);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateTargetProjNumForCopySp(string ToProjType,
		                                          ref string ToProjNum,
		                                          string FromProjType,
		                                          string FromProjNum,
		                                          ref int? StartTaskNum,
		                                          ref int? EndTaskNum,
		                                          string CopyOption,
		                                          ref string Prompt,
		                                          ref string PromptButtons,
		                                          ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateTargetProjNumForCopyExt = new ValidateTargetProjNumForCopyFactory().Create(appDb);
				
				int Severity = iValidateTargetProjNumForCopyExt.ValidateTargetProjNumForCopySp(ToProjType,
				                                                                               ref ToProjNum,
				                                                                               FromProjType,
				                                                                               FromProjNum,
				                                                                               ref StartTaskNum,
				                                                                               ref EndTaskNum,
				                                                                               CopyOption,
				                                                                               ref Prompt,
				                                                                               ref PromptButtons,
				                                                                               ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CreateProjInvMsTTSp(Guid? ProcessID,
		                               [Optional] string StartingProjNum,
		                               [Optional] string EndingProjNum,
		                               [Optional] string StartingInvMsNum,
		                               [Optional] string EndingInvMsNum,
		                               byte? EndPeriod,
		                               short? FiscalYear)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCreateProjInvMsTTExt = new CreateProjInvMsTTFactory().Create(appDb);
				
				var result = iCreateProjInvMsTTExt.CreateProjInvMsTTSp(ProcessID,
				                                                       StartingProjNum,
				                                                       EndingProjNum,
				                                                       StartingInvMsNum,
				                                                       EndingInvMsNum,
				                                                       EndPeriod,
				                                                       FiscalYear);
				
				
				return result.Value;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FormatProspectAddressSp(string ProspectId,
		                                   ref string ProAddress,
		                                   ref string Infobar,
		                                   [Optional] ref string DerCurrCode,
		                                   [Optional] ref string TaxCode1,
		                                   [Optional] ref string TaxCode2)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFormatProspectAddressExt = new FormatProspectAddressFactory().Create(appDb);
				
				var result = iFormatProspectAddressExt.FormatProspectAddressSp(ProspectId,
				                                                               ProAddress,
				                                                               Infobar,
				                                                               DerCurrCode,
				                                                               TaxCode1,
				                                                               TaxCode2);
				
				int Severity = result.ReturnCode.Value;
				ProAddress = result.ProAddress;
				Infobar = result.Infobar;
				DerCurrCode = result.DerCurrCode;
				TaxCode1 = result.TaxCode1;
				TaxCode2 = result.TaxCode2;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfileProjNomInvSp([Optional] string StartingProjNum,
		                                     [Optional] string EndingProjNum,
		                                     [Optional] Guid? ProcessID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iProfileProjNomInvExt = new ProfileProjNomInvFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iProfileProjNomInvExt.ProfileProjNomInvSp(StartingProjNum,
				                                                       EndingProjNum,
				                                                       ProcessID);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfileReprintProjInvSp([Optional] string InvoiceStarting,
		                                         [Optional] string InvoiceEnding,
		                                         [Optional] DateTime? InvoiceDateStarting,
		                                         [Optional] DateTime? InvoiceDateEnding,
		                                         [Optional] string ProjectStarting,
		                                         [Optional] string ProjectEnding,
		                                         [Optional] string CustomerStarting,
		                                         [Optional] string CustomerEnding)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iProfileReprintProjInvExt = new ProfileReprintProjInvFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iProfileReprintProjInvExt.ProfileReprintProjInvSp(InvoiceStarting,
				                                                               InvoiceEnding,
				                                                               InvoiceDateStarting,
				                                                               InvoiceDateEnding,
				                                                               ProjectStarting,
				                                                               ProjectEnding,
				                                                               CustomerStarting,
				                                                               CustomerEnding);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjInvPostSp([Optional] string StartingProjNum,
		                         [Optional] string EndingProjNum,
		                         [Optional] string StartingInvMsNum,
		                         [Optional] string EndingInvMsNum,
		                         [Optional] byte? EndPeriod,
		                         [Optional] short? FiscalYear,
		                         [Optional] DateTime? PostDate,
		                         [Optional] string PostLevel,
		                         [Optional] byte? XLateToDomestic,
		                         [Optional] byte? DoPost,
		                         [Optional] string Username,
		                         [Optional] string BGSessionId,
		                         [Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProjInvPostExt = new ProjInvPostFactory().Create(appDb);
				
				var result = iProjInvPostExt.ProjInvPostSp(StartingProjNum,
				                                           EndingProjNum,
				                                           StartingInvMsNum,
				                                           EndingInvMsNum,
				                                           EndPeriod,
				                                           FiscalYear,
				                                           PostDate,
				                                           PostLevel,
				                                           XLateToDomestic,
				                                           DoPost,
				                                           Username,
				                                           BGSessionId,
				                                           Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProjWIPReliefSp(string Process,
		                                 string FromProjNum,
		                                 string ToProjNum,
		                                 int? FromTaskNum,
		                                 int? ToTaskNum,
		                                 DateTime? WipStartDate,
		                                 DateTime? PostDate,
		                                 string PrintLevel,
		                                 string PostLevel,
		                                 [Optional, DefaultParameterValue((byte)0)] byte? WipAdjFlag,
		[Optional, DefaultParameterValue(0)] decimal? WipAdjTotLabrAdj,
		[Optional, DefaultParameterValue(0)] decimal? WipAdjTotMatlAdj,
		[Optional, DefaultParameterValue(0)] decimal? WipAdjTotOtherAdj,
		[Optional, DefaultParameterValue(0)] decimal? WipAdjTotOvrhdAdj,
		[Optional, DefaultParameterValue(0)] decimal? WipAdjTotGaAdj)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iProjWIPReliefExt = new ProjWIPReliefFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iProjWIPReliefExt.ProjWIPReliefSp(Process,
				                                               FromProjNum,
				                                               ToProjNum,
				                                               FromTaskNum,
				                                               ToTaskNum,
				                                               WipStartDate,
				                                               PostDate,
				                                               PrintLevel,
				                                               PostLevel,
				                                               WipAdjFlag,
				                                               WipAdjTotLabrAdj,
				                                               WipAdjTotMatlAdj,
				                                               WipAdjTotOtherAdj,
				                                               WipAdjTotOvrhdAdj,
				                                               WipAdjTotGaAdj);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetProjInfoByCustSp(string CustNum,
		int? CustSeq,
		string ProjType,
		int? TaxSyst1Enable,
		string TaxMode1,
		int? TaxSyst2Enable,
		string TaxMode2,
		ref string TaxCode1,
		ref string TaxCode1Desc,
		ref string TaxCode2,
		ref string TaxCode2Desc,
		ref string CurrCode,
		ref int? Fixed,
		ref string InvTermsCode,
		ref string BillToAddress,
		ref string ShipToAddress,
		ref int? CreditHold,
		ref string TransNat,
		ref string TransNat2,
		ref string Delterm,
		ref string ProcessInd,
		ref string Infobar,
		ref string ShipToCountry,
		ref string EndUserType,
		ref string EndUserTypeDesc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetProjInfoByCustExt = new GetProjInfoByCustFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetProjInfoByCustExt.GetProjInfoByCustSp(CustNum,
				CustSeq,
				ProjType,
				TaxSyst1Enable,
				TaxMode1,
				TaxSyst2Enable,
				TaxMode2,
				TaxCode1,
				TaxCode1Desc,
				TaxCode2,
				TaxCode2Desc,
				CurrCode,
				Fixed,
				InvTermsCode,
				BillToAddress,
				ShipToAddress,
				CreditHold,
				TransNat,
				TransNat2,
				Delterm,
				ProcessInd,
				Infobar,
				ShipToCountry,
				EndUserType,
				EndUserTypeDesc);
				
				int Severity = result.ReturnCode.Value;
				TaxCode1 = result.TaxCode1;
				TaxCode1Desc = result.TaxCode1Desc;
				TaxCode2 = result.TaxCode2;
				TaxCode2Desc = result.TaxCode2Desc;
				CurrCode = result.CurrCode;
				Fixed = result.Fixed;
				InvTermsCode = result.InvTermsCode;
				BillToAddress = result.BillToAddress;
				ShipToAddress = result.ShipToAddress;
				CreditHold = result.CreditHold;
				TransNat = result.TransNat;
				TransNat2 = result.TransNat2;
				Delterm = result.Delterm;
				ProcessInd = result.ProcessInd;
				Infobar = result.Infobar;
				ShipToCountry = result.ShipToCountry;
				EndUserType = result.EndUserType;
				EndUserTypeDesc = result.EndUserTypeDesc;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProcessMilestoneEventsSp(string PProjNum,
		[Optional, DefaultParameterValue(0)] int? IsInvoicePosted,
		[Optional, DefaultParameterValue(0)] int? ChkProjMSOnOblig,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProcessMilestoneEventsExt = new ProcessMilestoneEventsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProcessMilestoneEventsExt.ProcessMilestoneEventsSp(PProjNum,
				IsInvoicePosted,
				ChkProjMSOnOblig,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjCostRollupSp(string FromProjNum,
		string ToProjNum,
		string ProjStatList,
		string CostCodeOrMileStone,
		int? CalcRevenue,
		ref string Infobar,
		[Optional] int? TaskNum,
		[Optional] int? Seq)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProjCostRollupExt = new ProjCostRollupFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProjCostRollupExt.ProjCostRollupSp(FromProjNum,
				ToProjNum,
				ProjStatList,
				CostCodeOrMileStone,
				CalcRevenue,
				Infobar,
				TaskNum,
				Seq);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjNextKeyDelSp(string ProjNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProjNextKeyDelExt = new ProjNextKeyDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProjNextKeyDelExt.ProjNextKeyDelSp(ProjNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RevenueMilestoneProgressSp(string PProjectNumStarting,
		string PProjectNumEnding,
		string PRevMSNumStarting,
		string PRevMSNumEnding,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RevenueMilestoneProgressExt = new Rpt_RevenueMilestoneProgressFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RevenueMilestoneProgressExt.Rpt_RevenueMilestoneProgressSp(PProjectNumStarting,
				PProjectNumEnding,
				PRevMSNumStarting,
				PRevMSNumEnding,
				PSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ProjectMetricTopPlanCostSp([Optional, DefaultParameterValue(5)] int? Count)
		{
			var iCLM_ProjectMetricTopPlanCostExt = new CLM_ProjectMetricTopPlanCostFactory().Create(this, true);
			
			var result = iCLM_ProjectMetricTopPlanCostExt.CLM_ProjectMetricTopPlanCostSp(Count);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ProjectMetricTopRevenueSp([Optional, DefaultParameterValue(5)] int? Count)
		{
			var iCLM_ProjectMetricTopRevenueExt = new CLM_ProjectMetricTopRevenueFactory().Create(this, true);
			
			var result = iCLM_ProjectMetricTopRevenueExt.CLM_ProjectMetricTopRevenueSp(Count);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CreatePickHeaderSp(string TPckCall,
		string ProjNum,
		string CustNum,
		int? CustSeq,
		string ShipCode,
		int? QtyPackages,
		decimal? Weight,
		DateTime? PackDate,
		int? DoLines,
		int? FromTaskNum,
		int? ToTaskNum,
		int? FromSeq,
		int? ToSeq,
		ref int? PackNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCreatePickHeaderExt = new CreatePickHeaderFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCreatePickHeaderExt.CreatePickHeaderSp(TPckCall,
				ProjNum,
				CustNum,
				CustSeq,
				ShipCode,
				QtyPackages,
				Weight,
				PackDate,
				DoLines,
				FromTaskNum,
				ToTaskNum,
				FromSeq,
				ToSeq,
				PackNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PackNum = result.PackNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProjPercentCompleteSp(string ProjNum,
		[Optional, DefaultParameterValue(0)] int? FromRpt,
		[Optional, DefaultParameterValue("P")] string CostCodeType,
		[Optional] ref decimal? CostToComplete)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProjPercentCompleteExt = new ProjPercentCompleteFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProjPercentCompleteExt.ProjPercentCompleteSp(ProjNum,
				FromRpt,
				CostCodeType,
				CostToComplete);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				CostToComplete = result.CostToComplete;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FormatShipToAddress(string CustNum,
		int? CustSeq,
		ref string BillToAddress,
		ref string ShipToAddress,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFormatAddressExt = new FormatAddressFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFormatAddressExt.FormatAddressSp(CustNum,
				CustSeq,
				BillToAddress,
				ShipToAddress,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				BillToAddress = result.BillToAddress;
				ShipToAddress = result.ShipToAddress;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateExchRateInfoByCustSp(string CustNum,
		ref int? CurAllowOver,
		ref int? CurpAllowOver)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iUpdateExchRateInfoByCustExt = new UpdateExchRateInfoByCustFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iUpdateExchRateInfoByCustExt.UpdateExchRateInfoByCustSp(CustNum,
				CurAllowOver,
				CurpAllowOver);
				
				int Severity = result.ReturnCode.Value;
				CurAllowOver = result.CurAllowOver;
				CurpAllowOver = result.CurpAllowOver;
				return Severity;
			}
		}
    }
}
