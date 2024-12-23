namespace PortalWebApps.WebApp.Data.Models
{
    public class SystemSettingHistory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string OldValue { get; set; } = string.Empty;
        public string NewValue { get; set; } = string.Empty;
        public DateTime ChangeDate { get; set; } = DateTime.Now;
        public int UserId { get; set; } = 0;

        public User User { get; set; } = null!;
    }
}
