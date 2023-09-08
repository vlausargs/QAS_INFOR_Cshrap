//PROJECT NAME: AdminExt
//CLASS NAME: SLUserStartFormSubForms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Admin
{
    [IDOExtensionClass("SLUserStartFormSubForms")]
    public class SLUserStartFormSubForms : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_UserStartFormSubFormsSp(string Username,
		                                             [Optional] string FilterString,
		                                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_UserStartFormSubFormsExt = new CLM_UserStartFormSubFormsFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_UserStartFormSubFormsExt.CLM_UserStartFormSubFormsSp(Username,
				                                                                       FilterString,
				                                                                       Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateUserStartFormSubFormSp(string Username,
		string SubFormName,
		int? SubFormInstanceId,
		int? Selected,
		decimal? Sequence,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdateUserStartFormSubFormExt = new UpdateUserStartFormSubFormFactory().Create(appDb);
				
				var result = iUpdateUserStartFormSubFormExt.UpdateUserStartFormSubFormSp(Username,
				SubFormName,
				SubFormInstanceId,
				Selected,
				Sequence,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
