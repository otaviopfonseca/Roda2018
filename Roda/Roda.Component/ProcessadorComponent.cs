using Roda.Business;
using Roda.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roda.Component
{
    public class ProcessadorComponent
    {
        private ProcessadorBusiness _processadorBusiness;
        private ProcessadorBusiness ProcessadorBusiness
        {
            get
            {
                if (_processadorBusiness == null)
                    _processadorBusiness = new ProcessadorBusiness();
                return _processadorBusiness;
            }
        }

        private ProcessadorComponent() { }

        public static ProcessadorComponent Get()
        {
            return new ProcessadorComponent();
        }

        public List<ProcessadorEntity> ListarProcessadoresCadastrados()
        {
            return ProcessadorBusiness.listarProcessadoresCadastrados();
        }
    }
}
