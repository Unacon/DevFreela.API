using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Queries.GetUser
{
    public class GetUserQuery : IRequest<User>
    {
        public GetUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
