using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.Application.Queries.GetByIdProjects
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string title, string description, decimal totalCost, DateTime? startedAt, DateTime? finishAt, string clienteFullName, string freelancerFullName)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            StartedAt = startedAt;
            FinishAt = finishAt;
            ClienteFullName = clienteFullName;
            FreelancerFullName = freelancerFullName;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishAt { get; private set; }
        public string ClienteFullName { get; private set; }
        public string FreelancerFullName { get; private set; }

    }
}
