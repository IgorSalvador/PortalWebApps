namespace PortalWebApps.WebApp.Models.Utils
{
    public static class Enums
    {
        public enum Profiles
        {
            General,
            Administrator
        }

        public static List<Profiles> GetProfiles()
        {
            return Enum.GetValues(typeof(Profiles)).Cast<Profiles>().ToList();
        }
    }
}
