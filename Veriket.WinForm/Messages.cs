using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veriket.WinForm
{
    public static class Messages
    {
        public static string FileNotFoundText (string msj) => $"'{msj}' böyle bir dosya bulunamadı.";
        public static string FileNotFoundHeader = "Dosya bulunamadı.";

        public static string DirectoryNotFoundText(string msj) => $"'{msj}' böyle bir dizin bulunamadı.";
        public static string DirectoryNotFoundHeader = "Dizin bulunamadı.";

        public static string AnErrorText(string msj) => $"Hata Mesajı :\n {msj}";
        public static string AnErrorHeader = "Bir hata oluştu.";
    }
}
