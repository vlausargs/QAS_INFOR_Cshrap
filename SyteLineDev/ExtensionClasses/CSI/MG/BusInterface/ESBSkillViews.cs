//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBSkillViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBSkillViews")]
	public class ESBSkillViews : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBSkillSp(string EmpNum)
		{
            var iCLM_ESBSkillExt = new CLM_ESBSkillFactory().Create(this, true);

            var result = iCLM_ESBSkillExt.CLM_ESBSkillSp(EmpNum);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBPersonnelSkillsSp([Optional] string ActionExpression,
		[Optional] string EmpNum,
		[Optional] string Skill,
		[Optional] string CompetencyCode,
		[Optional] DateTime? SkillDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLoadESBPersonnelSkillsExt = new LoadESBPersonnelSkillsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLoadESBPersonnelSkillsExt.LoadESBPersonnelSkillsSp(ActionExpression,
				EmpNum,
				Skill,
				CompetencyCode,
				SkillDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
