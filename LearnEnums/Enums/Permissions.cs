namespace LearnEnums.Enums
{
    [Flags]
    public enum Permissions
    {
        None = 0,
        Read = 1,
        Write = 2,
        Delete = 4,
        Admin = 8,

        // Kombinasi Umum
        ReadWrite = Read | Write,
        All = Read | Write | Delete | Admin,
    }
}