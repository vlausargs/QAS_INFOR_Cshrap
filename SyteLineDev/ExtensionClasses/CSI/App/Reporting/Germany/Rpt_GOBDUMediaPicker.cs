using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Reporting.Germany
{
    public class Rpt_GOBDUMediaPicker : IRpt_GOBDUMediaService
    {
        readonly Rpt_GOBDUMediaDecider decider;
        readonly Func<GOBDUMediaServiceEnum, IRpt_GOBDUMediaService> lookup;

        public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_GetBDTransferData(string ProgramName, DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID)
        {
            GOBDUMediaServiceEnum t = decider.DecideWhichMedia(ProgramName); //decide the algorithm to use
            return lookup(t).Rpt_GetBDTransferData(ProgramName, TransDateBeg, TransDateEnd, SiteID); //lookup the appropriate instance and use it
        }


        public Rpt_GOBDUMediaPicker(Rpt_GOBDUMediaDecider decider, Func<GOBDUMediaServiceEnum, IRpt_GOBDUMediaService> lookup)
        {
            this.decider = decider;
            this.lookup = lookup;
        }
    }

    public class Rpt_GOBDUMediaDecider
    {
        public GOBDUMediaServiceEnum DecideWhichMedia(string ProgramName)
        {
            if (Enum.TryParse<GOBDUMediaServiceEnum>(ProgramName.EndsWith("Sp")? ProgramName.Substring(0, ProgramName.Length - 2): ProgramName, out GOBDUMediaServiceEnum gOBDUMedia))
                return gOBDUMedia;
            return GOBDUMediaServiceEnum.None;
        }
    }

}
