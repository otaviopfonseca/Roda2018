using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roda.Entities;
using Roda.DataAccess;
using Roda.Business.Conversor;

namespace Roda.Business
{
    public class ProcessadorBusiness
    {
        private ProcessadorDataAccess _processadorDataAccess;
        private ProcessadorDataAccess ProcessadorDataAccess
        {
            get
            {
                if (_processadorDataAccess == null)
                    _processadorDataAccess = new ProcessadorDataAccess();
                return _processadorDataAccess;
            }
        }
        
        public List<ProcessadorEntity> listarProcessadoresCadastrados()
        {
            List<Roda.DataAccess.Processador> processadores = ProcessadorDataAccess.ListaProcessadores();
            return ConversorModelEntity.ConverterProcessadorModelParaProcessadorEntity(processadores);
        }

        internal bool VerificarSeProcessadorEhMelhorOuEquivalente(int iDProcessador, Processador processador)
        {
            Processador processadorUsuario = ProcessadorDataAccess.ObterProcessador(iDProcessador);
            return processadorUsuario.ID == processador.IDProcessadorEquivalente || processadorUsuario.Potencia >= processador.Potencia;
        }
    }
}
