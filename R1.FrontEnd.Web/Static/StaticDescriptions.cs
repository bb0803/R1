namespace R1.FrontEnd.Web.Static
{
    public class StaticDescriptions
    {
        public static string CarAPIBase { get; set; }
        public static string DevelopmentAPIBase { get; set; }
        public static string DriverAPIBase { get; set; }
        public static string ResultAPIBase { get; set; }
        public static string SessionAPIBase { get; set; }
        public static string TeamAPIBase { get; set; }
        public static string AuthAPIBase { get; set; }
        
        public const string RoleAdmin = "ADMIN";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public const string Status_Pending = "Pending";
        public const string Status_Approved = "Approved";
        public const string Status_ReadyForPickup = "ReadyForPickup";
        public const string Status_Completed = "Completed";
        public const string Status_Refunded = "Refunded";
        public const string Status_Cancelled = "Cancelled";

        public enum ContentType
        {
            Json,
            MultipartFormData,
        }
    }
}
