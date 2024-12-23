namespace PortalWebApps.WebApp.Models.Utils
{
    public static class Enums
    {
        public enum Profiles
        {
            Guest,
            General,
            Administrator,
            
        }

        public static List<Profiles> GetProfiles()
        {
            return Enum.GetValues(typeof(Profiles)).Cast<Profiles>().ToList();
        }

        public static string GetProfileName(int profile)
        {
            string profileName = string.Empty;

            profileName = profile switch
            {
                (int)Profiles.Guest => "Guest",
                (int)Profiles.General => "General",
                (int)Profiles.Administrator => "Administrator",
                _ => "Guest",
            };

            return profileName;
        }
    }
}
