namespace LoginSystemApi.DTO
{
    public class UserUpdateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        public bool? IsActive { get; set; }

    }
}
