namespace OsDsII.api.Dto.Builder
{
    public class CustomerDtoBuilder
    {
        private readonly CustomerDto _customerDto;

        public CustomerDtoBuilder WithName(string name)
        {
            _customerDto.Name = name;
            return this;
        }

        public CustomerDtoBuilder WithEmail(string email)
        {
            _customerDto.Email = email;
            return this;
        }

        public CustomerDtoBuilder WithPhone(string phone)
        {
            _customerDto.Phone = phone;
            return this;
        }

        public CustomerDto Build() 
        { 
            return _customerDto; 
        }
    }
}
