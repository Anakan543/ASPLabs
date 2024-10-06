using System.Text;
using System.Xml.Linq;

namespace Laborotorna4.service
{
    public class ProfileService
    {
        public List<Profile> profiles { get; set;}

        public ProfileService( IConfiguration configuration)
        {
            profiles = configuration.GetSection("profiles").Get<List<Profile>>() ?? new List<Profile>();
        }

        public override string ToString()
        {
            StringBuilder infoProfiles = new StringBuilder();
            foreach (var item in profiles)
            {
                infoProfiles.Append(item.ToString());
            }
            return infoProfiles.ToString();
        }

        public string NonID()
        {
            return $"\nInfo about Profile:\nId - 22210911\nName - Ivan\nMembership - Standert\n";
        }
        public string FindById(int id)
        {
            StringBuilder user = new StringBuilder($"\nInfo about Profile:\nId - 22210911\n" +
                $"Name - Ivan\nMembership - Standert\n");
            foreach (var item in profiles)
            {
                if(item.Id == id)
                {
                    user.Clear().Append(item.ToString());
                    break;
                }
            }
            return "User за вказаним ID:"+user.ToString();
        }
    }

    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Membership { get; set; } = "";

        public override string ToString()
        {
            return $"\nInfo about Profile:\nId - {Id}\n" +
                $"Name - {Name}\nMembership - {Membership}\n";
        }
    }
}
