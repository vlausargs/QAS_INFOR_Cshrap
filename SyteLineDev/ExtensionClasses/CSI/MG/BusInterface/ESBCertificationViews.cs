//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBCertificationViews.cs

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
	[IDOExtensionClass("ESBCertificationViews")]
	public class ESBCertificationViews : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBCertificationSp(string EmpNum)
		{
			var iCLM_ESBCertificationExt = new CLM_ESBCertificationFactory().Create(this, true);
			
			var result = iCLM_ESBCertificationExt.CLM_ESBCertificationSp(EmpNum);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBPersonnelCertSp([Optional] string ActionExpression,
		[Optional] string EmpNum,
		[Optional] string Licert,
		[Optional] DateTime? EffDate,
		[Optional] string State,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLoadESBPersonnelCertExt = new LoadESBPersonnelCertFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLoadESBPersonnelCertExt.LoadESBPersonnelCertSp(ActionExpression,
				EmpNum,
				Licert,
				EffDate,
				State,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
