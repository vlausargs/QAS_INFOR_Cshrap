//PROJECT NAME: MaterialExt
//CLASS NAME: SLItemCompliances.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
	[IDOExtensionClass("SLItemCompliances")]
	public class SLItemCompliances : CSIExtensionClassBase
	{


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckJobItemComplianceSp(string pJob,
		                                    short? pSuffix,
		                                    ref string Infobar,
		                                    [Optional] string pItem,
		                                    [Optional] string pRevision)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCheckJobItemComplianceExt = new CheckJobItemComplianceFactory().Create(appDb);
				
				var result = iCheckJobItemComplianceExt.CheckJobItemComplianceSp(pJob,
				                                                                 pSuffix,
				                                                                 Infobar,
				                                                                 pItem,
				                                                                 pRevision);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ItemComplianceAssignmentSp([Optional, DefaultParameterValue((byte)0)] byte? ProcessAll,
		[Optional] string ComplianceProgramId,
		[Optional, DefaultParameterValue("N")] string Mode,
		[Optional] DateTime? EffectDate)
		{
            var iCLM_ItemComplianceAssignmentExt = new CLM_ItemComplianceAssignmentFactory().Create(this, true);

            var result = iCLM_ItemComplianceAssignmentExt.CLM_ItemComplianceAssignmentSp(ProcessAll,
                ComplianceProgramId,
                Mode,
                EffectDate);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SetItemComplianceStatusSp([Optional, DefaultParameterValue(0)] int? ProcessAll,
		[Optional] string ComplianceProgramId,
		[Optional, DefaultParameterValue("N")] string Mode,
		ref string Infobar,
		[Optional] DateTime? EffectDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSetItemComplianceStatusExt = new SetItemComplianceStatusFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSetItemComplianceStatusExt.SetItemComplianceStatusSp(ProcessAll,
				ComplianceProgramId,
				Mode,
				Infobar,
				EffectDate);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
