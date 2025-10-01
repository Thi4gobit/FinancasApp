using FinancasApp.Domain.Entities;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Mappings
{
    public static class MovimentacaoMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Movimentacao>(map =>
            {
                map.AutoMap();

                //Nome da collection no banco de dados
                map.SetDiscriminator("movimentacoes");

                //Chave primária
                map.MapIdMember(m => m.Id)
                    .SetIdGenerator(GuidGenerator.Instance);
            });
        }
    }
}



