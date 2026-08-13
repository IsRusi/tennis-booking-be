namespace TennisCourt.Infrastructure.Constants;
public class CourtMessages: CommonMessages
{
    public const string IsNull = "Court is null";
    public static string IsEmpty<T>(T courtsField)
    => $"{nameof(courtsField)} is empty";
}