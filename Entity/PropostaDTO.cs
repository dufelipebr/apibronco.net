namespace apibronco.bronco.com.br.Entity
{
    public abstract class PropostaDTO_Depreceated
    {
        //public StatusProposta StatusProposta { get; set; }
        public int Id_Status_Proposta { get; set; }
        public string Codigo_Interno { get; }
        //public Ramo Ramo { get; set; }

        //public IList<Cobertura> Coberturas { get; set; } // lista de coberturas coberta na apolice/proposta
        //public string Codigo_Empresa { get; set; }

        //public string Codigo_Apolice { get; set; }

        public string Nome_Segurado { get; set; }

        public string Nome_Social_Segurado { get; set; }

        public int Sexo { get; set; } // 1- Masc, 2-Fem, 3-Outros
        public string CPF_CNPJ_Segurado { get; set; }
        public char Tipo_Segurado { get; set; } // J - Juridica P- Fisica 
        public string RG_Segurado { get; set; }
        public DateTime Data_Emissao_RG { get; set; }

        public string Profissao_Segurado { get; set; }

        public decimal Renda_Mensal_Segurado{ get; set; }


        public DateTime Data_Nascimento_Segurado { get; set; }
        public string Endereco_Segurado_Logradouro { get; set; }
        public string Endereco_Segurado_Numero { get; set; }
        public string Endereco_Segurado_Compl { get; set; }
        public string Endereco_Segurado_CEP { get; set; }
        public string Endereco_Segurado_Bairro { get; set; }
        public string Endereco_Segurado_UF { get; set; } // dois digitos - SP, MG
        public string Endereco_Segurado_Pais { get; set; }

        public string Telefone_Comercial_Segurado { get; set; }

        public string Telefone_Residencial_Segurado { get; set; }

        public string Celular_Segurado { get; set; }


        public int Forma_Pagamento { get; set; } // 0-DebitoEmConta, 1-Boleto, 2-Credito 

        public int Parcela { get; set; }

        public DateTime Data_Emissao { get; set; }

        public DateTime Data_Inicio_Vigencia { get; set; }

        public DateTime Data_Fim_Vigencia { get; set; }

        public DateTime Data_Assinatura_Proposta { get; set; }

        //public string Moeda { get; set; } // Default BRL 

        public int Id_Ramo_Principal { get; set; } // id do ramo principal susep -- fixo 
        public string Codigo_Produto { get; set; } // codigo produto do seguro por exemplo VIDA01 
        
        public string UF_Risco_Principal { get; set; } // provalmente vai seguir endereço do segurado

        public decimal Valor_Premio { get; set; }

        public decimal Valor_Total_Segurado { get; set; }

        /// <summary>
        /// public string Codigo_Interno_Susep { get; set; } // vai g
        /// </summary>

        //public decimal Valor_LMG { get; set; }




        public bool IsValid()
        {
            return true;
        }

    }
}
