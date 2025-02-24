﻿using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {
        public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost)
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            TotalCost = totalCost;
            CreatedAt = DateTime.Now;
            IdFreelancer = idFreelancer;
            Status = ProjectStatusEnum.Created;
            Comments = new List<ProjectComment>();
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public User Client { get; private set; }
        public int IdFreelancer { get; private set; }
        public User Freelancer { get; private set; }

        public decimal TotalCost { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public List<ProjectComment> Comments { get; private set; }

        public void Cancel()
        {
            if (Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.InProgress)
            {
                Status = ProjectStatusEnum.Cancelled;
            };
        }

        public void Start()
        {
            if (Status == ProjectStatusEnum.Created || Status == ProjectStatusEnum.Suspended)
            {
                Status = ProjectStatusEnum.InProgress;
                StartedAt = DateTime.Now;
            };
        }

        public void Finish()
        {
            if (Status == ProjectStatusEnum.PaymentPendent)
            {
                Status = ProjectStatusEnum.Finished;
                FinishedAt = DateTime.Now;
            };
        }

        public void PaymentPendent()
        {
            Status = ProjectStatusEnum.PaymentPendent;
        }

        public void Update(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }

        public void UpdateFreelancer(int idFreelancer)
        {
            IdFreelancer = idFreelancer;
        }
    }
}
