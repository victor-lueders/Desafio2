namespace MoutsWebSemEF.Models
{
    public class Pessoa
    {
        public string Name { get; set; }
        public string Endereco { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }
        private string Cpf;

        public string cpf
        {
            get { return Cpf; }
            set
            {
                if (value.Length != 11)
                {
                    throw new ArgumentException("CPF Inválido.");
                }
                else
                {
                    Cpf = value;
                }
            }
        }

        public Pessoa()
        {

        }

        public Pessoa(string name, string endereco, string fone, string cpf, string email)
        {
            this.Name = name;
            this.Endereco = endereco;
            this.Fone = fone;
            this.Cpf = cpf;
            this.Email = email;
        }
    }
}
