using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TN.CrudAdvanced.Domain.Entities;
using TN.CrudAdvanced.Domain.Interfaces.Repositories;

namespace TN.CrudAdvanced.Infrastructure.Queries
{
    public class GetAllPersonsQuery : IRequest<IEnumerable<Person>>
    {
    }
}
