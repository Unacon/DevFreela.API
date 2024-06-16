namespace DevFreela.Application.Queries.GetUser
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email, DateTime bithDate)
        {
            FullName = fullName;
            Email = email;
            BithDate = bithDate;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BithDate { get; private set; }
    }
}
