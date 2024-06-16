using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetProjectComments
{
    public class GetProjectCommentsQuery : IRequest<List<ProjectComment>>
    {
        public GetProjectCommentsQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
