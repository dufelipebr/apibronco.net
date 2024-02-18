namespace apibronco.bronco.com.br.Entity
{
    public class Proposta : Entidade
    {
        public Proposta()
        {
            //this.Id_Status_Proposta = prop.Id_Status_Proposta;
            
        }
        //public StatusProposta StatusProposta { get; set; }

        public string Codigo_Usuario { get; set; }

        public EnStatusProposta Status_Proposta { get; set; }
        public string Codigo_Interno { get; set; }
        
        public string Codigo_Empresa { get; set; }
        public string Codigo_Grupo_Ramo { get; set; }

        public Cobertura[] Coberturas { get; set; } // lista de coberturas coberta na apolice/proposta

        //public string Codigo_Apolice { get; set; }

        //public string Nome_Segurado { get; set; }
        //public string CPF_CNPJ_Segurado { get; set; }
        //public char Tipo_Segurado { get; set; } // J - Juridica P- Fisica 
        //public string RG_Segurado { get; set; }

        //public DateTime Data_Nascimento_Segurado { get; set; }
        //public string Endereco_Segurado_Logradouro { get; set; }
        //public string Endereco_Segurado_Numero { get; set; }
        //public string Endereco_Segurado_Compl { get; set; }
        //public string Endereco_Segurado_CEP { get; set; }
        //public string Endereco_Segurado_Bairro { get; set; }
        //public string Endereco_Segurado_UF { get; set; } // dois digitos - SP, MG
        //public string Endereco_Segurado_Pais { get; set; }

        //public string Telefone_Comercial_Segurado { get; set; }

        //public string Telefone_Residencial_Segurado { get; set; }

        //public string Celular_Segurado { get; set; }


        public string Codigo_Condicao_Pagto { get; set; } // 1-DebitoEmConta, 2-Boleto, 3-Credito 

        public DateTime Data_Emissao { get; set; }

        public DateTime Data_Inicio_Vigencia { get; set; }

        public DateTime Data_Fim_Vigencia { get; set; }

        public DateTime Data_Assinatura_Proposta { get; set; }

        public string Moeda { get; set; } // Default BRL 
        
        public string Codigo_Produto { get; set; } // codigo produto do seguro por exemplo VIDA01 
        
        public string UF_Risco_Principal { get; set; } // provalmente vai seguir endereço do segurado

        /// <summary>
        /// public string Codigo_Interno_Susep { get; set; } // vai g
        /// </summary>

        //public decimal Valor_LMG { get; set; }




        public bool IsValid()
        {
            AssertionConcern.AssertArgumentLength(Codigo_Interno, 50, "Codigo_Interno must have max 50 digits");
            AssertionConcern.AssertArgumentLength(Codigo_Empresa, 10, "Codigo_Empresa must have max 10 digits");
            AssertionConcern.AssertArgumentLength(Moeda, 3, "Moeda must have max 3 digits");
            AssertionConcern.AssertArgumentLength(UF_Risco_Principal, 2, "UF_Risco_Principal must have max 2 digits");

            AssertionConcern.AssertArgumentNotEmpty(UF_Risco_Principal, "UF_Risco_Principal is empty");
            AssertionConcern.AssertArgumentNotEmpty(Codigo_Produto, "Codigo_Produto is empty");
            AssertionConcern.AssertArgumentNotEmpty(Moeda, "Moeda is empty");
            AssertionConcern.AssertArgumentNotEmpty(Codigo_Condicao_Pagto, "Codigo_Condicao_Pagto is empty");
            AssertionConcern.AssertArgumentNotEmpty(Codigo_Grupo_Ramo, "Codigo_Grupo_Ramo is empty");
            AssertionConcern.AssertArgumentNotEmpty(Codigo_Empresa, "Codigo_Grupo_Ramo is empty");
            AssertionConcern.AssertArgumentNotEmpty(Codigo_Interno, "Codigo_Interno is empty");

            AssertionConcern.AssertArgumentTrue(StatusProposta.IsValid(Status_Proposta), "Status_Proposta invalid");



            //AssertionConcern.AssertArgument(Codigo_Empresa, 10, "Codigo_Empresa must have max 50 digits");

            return true;
            
        }

    }
}
