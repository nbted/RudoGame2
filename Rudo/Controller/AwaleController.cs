using Rudo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rudo.Controller
{
    class AwaleController
    {
        public  AwaleGame awaleGameInstance;
        private static AwaleController instance;
        public static AwaleController Instance
        {
            get
            {
                if (instance == null)
                    instance = new AwaleController();
                return instance;
            }
            set
            {
                instance = value;
            }

        }

        public AwaleController()
        {
            this.awaleGameInstance = new AwaleGame();
        }

    }
}
