namespace MVC_Challenge.Models.Enums
{
    public class TypeAlert
    {
        public const string Success = "success";
        public const string Danger = "danger";
        public const string Warning = "warning";
        public const string Info = "info";

        public static string[] Alertas
        {
            get { return new[] { Success, Danger, Info, Warning }; }
        }

    }
}
