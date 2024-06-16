using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetProjectComments
{
    public class ProjectCommentsViewModel
    {
        public ProjectCommentsViewModel(string content, DateTime createdAt)
        {
            Content = content;
            CreatedAt = createdAt;
        }

        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
