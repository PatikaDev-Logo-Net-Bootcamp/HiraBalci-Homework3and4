namespace First.App.Business.DTOs
{
    public class TokenDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; } //tokenın belli bir süresi olucak.sonrasında yenilencek genelde 20 dk'dır.güvenliği bunla sağlamam önemli
    }
}
