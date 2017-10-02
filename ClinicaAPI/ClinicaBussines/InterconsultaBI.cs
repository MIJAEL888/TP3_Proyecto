using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaBussines
{
    public class InterconsultaBI
    {

        private static volatile InterconsultaBI _instance;
        private static readonly object SyncRoot = new Object();

        private InterconsultaBI() { }

        public static InterconsultaBI Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new InterconsultaBI();
                    }
                }
                return _instance;
            }
        }
    }
}
