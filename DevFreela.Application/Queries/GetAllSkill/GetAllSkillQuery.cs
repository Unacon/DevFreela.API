using DevFreela.Core.DTOs;
using MediatR;

namespace DevFreela.Application.Queries.GetAllSkill
{
    public class GetAllSkillQuery : IRequest<List<SkillDTO>>
    {
    }
}
