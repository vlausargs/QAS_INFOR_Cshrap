using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public class InterceptConfiguration : IInterceptConfiguration 
    {
        /// <summary>
        /// this method is still used on CollectionLoad/delete/insert/update part. 
        /// It would make MG handle collectio CRUD.
        /// </summary>
        /// <param name="ido"></param>
        /// <returns></returns>
        public bool InterceptEnabled(string ido)
        {
            return false;
        }

        public bool InterceptEnabled(string ido, string method)
        {
            return false;
        }
    }
}
