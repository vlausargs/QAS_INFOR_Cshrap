//PROJECT NAME: FSPlusPartnerExt
//CLASS NAME: FSSchedFilterParts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Partner;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusPartner
{
    [IDOExtensionClass("FSSchedFilterParts")]
    public class FSSchedFilterParts : ExtensionClassBase
    {		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSchedPartnerFilterDeleteSp(string FilterName,
		                                           string Username,
		                                           ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSchedPartnerFilterDeleteExt = new SSSFSSchedPartnerFilterDeleteFactory().Create(appDb);
				
				var result = iSSSFSSchedPartnerFilterDeleteExt.SSSFSSchedPartnerFilterDeleteSp(FilterName,
				                                                                               Username,
				                                                                               Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSchedPartnerFilterSaveSp(string FilterName,
		                                         string Username,
		                                         int? FilterType,
		                                         string PartnerList,
		                                         string CertList,
		                                         string SkillList,
		                                         string DeptList,
		                                         byte? UseCoverage,
		                                         string Country,
		                                         string State,
		                                         string City,
		                                         string Zip,
		                                         string County,
		                                         string Region,
		                                         ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSchedPartnerFilterSaveExt = new SSSFSSchedPartnerFilterSaveFactory().Create(appDb);
				
				var result = iSSSFSSchedPartnerFilterSaveExt.SSSFSSchedPartnerFilterSaveSp(FilterName,
				                                                                           Username,
				                                                                           FilterType,
				                                                                           PartnerList,
				                                                                           CertList,
				                                                                           SkillList,
				                                                                           DeptList,
				                                                                           UseCoverage,
				                                                                           Country,
				                                                                           State,
				                                                                           City,
				                                                                           Zip,
				                                                                           County,
				                                                                           Region,
				                                                                           Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
