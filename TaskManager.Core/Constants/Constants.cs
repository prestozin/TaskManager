namespace TaskManager.Core.Constants;

public static class Constants
{
    public const string EmailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    public const string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,100}$";

    public const int EmailMaxLength = 255;

    public const int NameMaxLength = 100;
    public const int NameMinLength = 3;

    public const int TaskDescriptionMinLength = 10;
    public const int TaskDescriptionMaxLength = 500;

    public const int TaskTitleMinLength = 3;
    public const int TaskTitleMaxLength = 100;

}
