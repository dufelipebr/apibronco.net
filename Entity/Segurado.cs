using apibronco.bronco.com.br.DTOs;

namespace apibronco.bronco.com.br.Entity
{
    public class Cliente_Segurado : Entidade
    {
        public Cliente_Segurado(RegisterInfo info) 
        {
            this.Nome = info.nome;
            this.Sobrenome = info.sobre_nome;
            
            if (info.nome_social.Trim() != "")
                this.Nome_Social = info.nome_social;

            this.Renda = info.option_renda;
            this.Data_Nascimento = info.data_nascimento;
            this.Genero = info.genero;
            this.RG = info.rg;
            this.Celular = info.telefone;
            this.CPF_CNPJ = info.cpf;
            this.Tipo_Segurado = 'F';
            this.Email = info.email;
            //this.Endereco_Segurado = endSegurado;
        }

        public string Identificador_Usuario { get; set; }
        public string Nome { get; set; }

        public string Sobrenome { get; set; }
        
        public string? Nome_Social { get; set; }
        public char Genero { get; set; }

        public DateTime Nascimento { get; set; }

        public string Email { get; set; }
        
        public string Profissao{ get; set; }

        public int Renda { get; set; }

        public string CPF_CNPJ{ get; set; }
        public char Tipo_Segurado { get; set; } // J - Juridica P- Fisica 
        public string RG{ get; set; }

        public DateTime Data_Nascimento { get; set; }
        public Endereco Endereco_Segurado { get; set; }
        //public string Telefone_Comercial { get; set; }

        //public string Telefone_Residencial { get; set; }

        public string Celular { get; set; }

        //public string Telefones { get
        //    {
        //        return $"Celular:{Celular} / Res:{Telefone_Residencial} / Com:{Telefone_Comercial}";
        //    } 
        //}

        public string Telefones
        {
            get
            {
                return $"Tel. Contato:{Celular}";
            }
        }

        public char GetTipoSegurado() {
            return 'P';
        
        }
    }
}
