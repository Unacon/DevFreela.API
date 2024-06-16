namespace DevFreela.Core.Entities
{
    public class UserOwendProject
    {
        public UserOwendProject(int idUser, int idProject)
        {
            IdUser = idUser;
            IdProject = idProject;
        }
        public  int IdUser {  get; set; }
        public  int IdProject {  get; set; }
    }
}
