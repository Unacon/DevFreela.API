namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime bithDate, string password, string role)
        {
            FullName = fullName;
            Email = email;
            BithDate = bithDate;
            Password = password;
            Role = role;
            CreatedAt = DateTime.Now;
            Active = true;
            Skills = new List<UserSkill>();
            OwendProjects = new List<Project>();
            FreelanceProjects = new List<Project>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BithDate { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public bool Active { get; private set; }

        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwendProjects { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }
        public List<ProjectComment> Comments { get; private set; }

        public void Update(string fullName, string email, DateTime bithDate)
        {
            FullName = fullName;
            Email = email;
            BithDate = bithDate;
        }

        public void ActiveUser(bool active)
        {
            Active = active;
        }
    }
}
