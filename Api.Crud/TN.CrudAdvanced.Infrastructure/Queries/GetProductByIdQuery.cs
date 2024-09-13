using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TN.CrudAdvanced.Domain.Entities;

namespace TN.CrudAdvanced.Infrastructure.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public Guid Id { get; set; }
    }
}
