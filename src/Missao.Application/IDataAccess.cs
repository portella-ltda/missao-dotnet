using System;
using System.Collections.Generic;

namespace Missaol.Application
{
    public interface IDataAccess
    {
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        ICollection<Qualidade> Qualidades { get; set; }
        public ICollection<Atendimento> Atendimentos { get; set; }
        public ICollection<Ambiente> Ambientes { get; set; }

        public class Cliente
        {
            public Guid? Code { get; set; }
        }
        public class Produto
        {
            public Guid? Code { get; set; }
        }

        public class Qualidade
        {
            public Produto Produto { get; set; }
            public decimal? Minima { get; set;}
        }
        public class Atendimento
        {
            public Guid? Code { get; set; }
        }
        public class Ambiente
        {
            public Guid? Code { get; set; }
        }
    }
}
