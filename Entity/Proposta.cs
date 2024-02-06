﻿namespace apibronco.bronco.com.br.Entity
{
    public class Proposta : Entidade
    {
        public Proposta(PropostaDTO prop)
        {
            this.Id_Status_Proposta = prop.Id_Status_Proposta;
            
        }
        //public StatusProposta StatusProposta { get; set; }
        public int Id_Status_Proposta { get; set; }
        public string Codigo_Interno { get; }
        //public Ramo Ramo { get; set; }

        //public IList<Cobertura> Coberturas { get; set; } // lista de coberturas coberta na apolice/proposta
        //public string Codigo_Empresa { get; set; }

        //public string Codigo_Apolice { get; set; }

        public string Nome_Segurado { get; set; }
        public string CPF_CNPJ_Segurado { get; set; }
        public char Tipo_Segurado { get; set; } // J - Juridica P- Fisica 
        public string RG_Segurado { get; set; }

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


        public int Id_Condicao_Pagamento { get; set; } // 1-DebitoEmConta, 2-Boleto, 3-Credito 

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
            return true;
        }

    }
}
