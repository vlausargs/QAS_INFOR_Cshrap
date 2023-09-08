//PROJECT NAME: FSPlusPartnerExt
//CLASS NAME: FSSchedColors.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Partner;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.FSPlusPartner
{
    [IDOExtensionClass("FSSchedColors")]
    public class FSSchedColors : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable SSSFSSchedColorCodingSp(string iRefType)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iSSSFSSchedColorCodingExt = new SSSFSSchedColorCodingFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iSSSFSSchedColorCodingExt.SSSFSSchedColorCodingSp(iRefType);

                return dt;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSchedColorSaveSp(string RefType,
		                                 string RefNum,
		                                 int? BackColor,
		                                 int? ForeColor)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSchedColorSaveExt = new SSSFSSchedColorSaveFactory().Create(appDb);
				
				int Severity = iSSSFSSchedColorSaveExt.SSSFSSchedColorSaveSp(RefType,
				                                                             RefNum,
				                                                             BackColor,
				                                                             ForeColor);
				
				return Severity;
			}
		}
    }
}