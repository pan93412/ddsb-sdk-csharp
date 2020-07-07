namespace ddsb_sdk
{
    public class DDSBInfo
    {
        /// <summary>
        /// dd.sb 產生的短連結唯一識別碼
        /// </summary>
        public string ShortenId { get; set; }
        /// <summary>
        /// 存取此 dd.sb 短連結所需的密碼。
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 取得 dd.sb 短連結網址。
        /// </summary>
        public string ShortenUrl => $"https://dd.sb/{ShortenId}";
        /// <summary>
        /// 取得 dd.sb 短連結統計。
        /// </summary>
        public string StatsUrl => $"https://dd.sb/stats.php?id={ShortenId}";
    }
}
