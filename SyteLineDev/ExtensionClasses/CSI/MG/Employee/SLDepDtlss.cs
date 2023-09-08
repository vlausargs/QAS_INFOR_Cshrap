//PROJECT NAME: EmployeeExt
//CLASS NAME: SLDepDtlss.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Employee
{
    [IDOExtensionClass("SLDepDtlss")]
    public class SLDepDtlss : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable DepPrintDoProcessSp(DateTime? pBegTransDate,
                                             DateTime? pEndTransDate,
                                             decimal? pAchCoId1,
                                             decimal? pAchCoId5,
                                             string pAchOname,
                                             string pFileName,
                                             byte? pDuplicateTape,
                                             DateTime? pCreateDate,
                                             byte? pCreateSeq,
                                             ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iDepPrintDoProcessExt = new DepPrintDoProcessFactory().Create(appDb, bunchedLoadCollection);

                InfobarType oInfobar = Infobar;

                DataTable dt = iDepPrintDoProcessExt.DepPrintDoProcessSp(pBegTransDate,
                                                                         pEndTransDate,
                                                                         pAchCoId1,
                                                                         pAchCoId5,
                                                                         pAchOname,
                                                                         pFileName,
                                                                         pDuplicateTape,
                                                                         pCreateDate,
                                                                         pCreateSeq,
                                                                         ref oInfobar);

                Infobar = oInfobar;


                return dt;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int DepPrintInitSp(ref DateTime? pBegTransDate,
                                  ref DateTime? pEndTransDate,
                                  ref decimal? pAchCoId1,
                                  ref decimal? pAchCoId5,
                                  ref string pAchOname,
                                  ref string pFileName,
                                  ref byte? pDuplicateTape,
                                  ref DateTime? pCreateDate,
                                  ref byte? pCreateSeq,
                                  ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iDepPrintInitExt = new DepPrintInitFactory().Create(appDb);

                DateType opBegTransDate = pBegTransDate;
                DateType opEndTransDate = pEndTransDate;
                AchIdType opAchCoId1 = pAchCoId1;
                AchIdType opAchCoId5 = pAchCoId5;
                AchNameType opAchOname = pAchOname;
                WideTextType opFileName = pFileName;
                FlagNyType opDuplicateTape = pDuplicateTape;
                DateType opCreateDate = pCreateDate;
                DepDtlCreateSeqType opCreateSeq = pCreateSeq;
                InfobarType oInfobar = Infobar;

                int Severity = iDepPrintInitExt.DepPrintInitSp(ref opBegTransDate,
                                                               ref opEndTransDate,
                                                               ref opAchCoId1,
                                                               ref opAchCoId5,
                                                               ref opAchOname,
                                                               ref opFileName,
                                                               ref opDuplicateTape,
                                                               ref opCreateDate,
                                                               ref opCreateSeq,
                                                               ref oInfobar);

                pBegTransDate = opBegTransDate;
                pEndTransDate = opEndTransDate;
                pAchCoId1 = opAchCoId1;
                pAchCoId5 = opAchCoId5;
                pAchOname = opAchOname;
                pFileName = opFileName;
                pDuplicateTape = opDuplicateTape;
                pCreateDate = opCreateDate;
                pCreateSeq = opCreateSeq;
                Infobar = oInfobar;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DepDelSp(DateTime? ExEndTransDate,
		                    [Optional, DefaultParameterValue((byte)0)] byte? ExOptdfDeleteTape,
		string ExOptdfEmplType,
		ref string Infobar,
		[Optional] short? EndTransDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDepDelExt = new DepDelFactory().Create(appDb);
				
				var result = iDepDelExt.DepDelSp(ExEndTransDate,
				                                 ExOptdfDeleteTape,
				                                 ExOptdfEmplType,
				                                 Infobar,
				                                 EndTransDateOffset);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
