namespace Client.Models.AuthenticationVMs
{
    public class LoginResponseVM
    {
        public string Email { get; set; }
        public bool Success { get; set; } = true;
        public string Token { get; set; }
        public string Id { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; }

    }
}
