using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.CrudAdvanced.Infrastructure.Command
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }

}
