using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.CrudAdvanced.Application.Command
{
    public class DeleteProductCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}

}
