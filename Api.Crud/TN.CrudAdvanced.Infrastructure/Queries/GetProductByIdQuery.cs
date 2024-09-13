using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TN.CrudAdvanced.Domain.Entities;

namespace TN.CrudAdvanced.Infrastructure.Queries
{
    public class GetPersonByIdQuery : IRequest<Person>
    {
        public Guid Id { get; set; }
    }
}
