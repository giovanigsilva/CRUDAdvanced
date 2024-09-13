using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.CrudAdvanced.Infrastructure.Command
{
    public class DeletePersonCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }

}
