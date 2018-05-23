using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleDeProvas
{
    class Questoes
    {
        private int _nObjetivas;
        private int _nDiscursivas;
        private int _totalQuestao;


        public int nObjetivas
        {
            get { return this._nObjetivas; }
            set { this._nObjetivas = value; }
        }

        public int nDiscursivas
        {
            get { return this._nDiscursivas; }
            set { this._nDiscursivas = value; }
        }

        public int totalQuestao
        {
            get { return (this.nDiscursivas + this.nObjetivas); }
        }
    }
}
