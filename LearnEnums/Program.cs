using LearnEnums.Enums;

namespace LearnEnums
{
    class Program
    {
        public static void Main(string[] args)
        {
            // For handle print out enum
            string HandlePrintRole(string str)
            {
                // if str, containing spatator "_"... remove sparator
                if (str.Contains("_"))
                {
                    string[] breakStr = str.Split("_");
                    string cleanStr = string.Join(" ", breakStr);

                    return cleanStr;
                }
                else
                {
                    return str;
                }
            }

            // Implementation enum
            Roles roleMalfin = Roles.Super_Admin;
            Console.WriteLine($"Jabatan Malfin adalah {HandlePrintRole(roleMalfin.ToString())}");
            // Output: Jabatan Malfin adalah Super Admin

            Roles roleVenrir = Roles.Owner;
            Console.WriteLine($"Jabatan Venrir adalah {HandlePrintRole(roleVenrir.ToString())}");
            // Output: Jabatan Venrir adalah Owner

            Roles roleBule = Roles.Admin;
            Console.WriteLine($"Jabatan Bule adalah {HandlePrintRole(roleBule.ToString())}");
            // Output: Jabatan Bule adalah Admin

            // FLAG ENUMS
            // Kombinasi Permission
            Permissions userPerm = Permissions.Read | Permissions.Write;
            Console.WriteLine(userPerm);
            // Output: ReadWrite

            // Check apakah mempunya permisian tertentu
            if ((userPerm & Permissions.Read) != Permissions.None) Console.WriteLine("Can Read!");
            // Output: Can Read!

            // Tambah Permission
            userPerm |= Permissions.Delete;
            Console.WriteLine(userPerm);
            // Output: ReadWrite, Delete

            // Hapus Permission
            userPerm &= ~Permissions.Write;
            Console.WriteLine(userPerm);
            // Output: Read, Delete

            // Toggle Permission
            userPerm ^= Permissions.Read;
            Console.WriteLine(userPerm); // "Delete" (Read ditoggle off, Write dihapus)
                                         // Output: Delete

            // TYPE SAFETY ISSUE
            // selalu check enums biar safety
            // void Draw(BorderSide borderSide) // <-- Aslinya ini yang strict
            void Draw<T>(T borderSide) // <-- Generivc Cuma untuk mencoba agar bisa dimasuki selain enum 
            {
                try
                {
                    if (!Enum.IsDefined(typeof(BorderSide), borderSide!))
                    {
                        throw new ArgumentException($"Invalide Border Side: {borderSide}");
                    }

                    Console.WriteLine(borderSide);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Draw(BorderSide.Right);
            // Output: Right

            string Invalid = "Invalid";
            Draw(Invalid);
            // Output: Invalide Border Side: Invalid
        }
    }
}