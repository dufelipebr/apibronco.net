namespace apibronco.bronco.com.br.Entity
{
    public class Cliente_Segurado : Entidade
    {
        public Cliente_Segurado(Endereco endSegurado) 
        {
            //this.Nome = dto.Segurado_Nome;
            //this.CPF_CNPJ = dto.Segurado_CPF_CNPJ;
            //this.Tipo_Segurado = GetTipoSegurado();
            //this.RG = dto.Segurado_RG;
            //this.Data_Nascimento = dto.Segurado_Data_Nascimento;
            this.Endereco_Segurado = endSegurado;
            //this.Telefone_Residencial = dto.Segurado_Tel_Residencial;
            //this.Telefone_Comercial = dto.Segurado_Tel_Comercial;
            //this.Celular = dto.Segurado_Tel_Celular;
        }

        public string Nome { get; set; }
        public string CPF_CNPJ{ get; set; }
        public char Tipo_Segurado { get; set; } // J - Juridica P- Fisica 
        public string RG{ get; set; }

        public DateTime Data_Nascimento { get; set; }
        public Endereco Endereco_Segurado { get; set; }
        public string Telefone_Comercial { get; set; }

        public string Telefone_Residencial { get; set; }

        public string Celular { get; set; }

        public string Telefones { get
            {
                return $"Celular:{Celular} / Res:{Telefone_Residencial} / Com:{Telefone_Comercial}";
            } 
        }

        public char GetTipoSegurado() {
            return 'P';
        
        }
    }
}
