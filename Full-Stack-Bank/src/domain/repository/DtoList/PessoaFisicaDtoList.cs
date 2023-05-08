using FullStackBank.Domain.Dto.PessoaFisica;

namespace FullStackBank.Domain.Repository.DtoList;

public class PessoaFisicaDtoList
{
    public static List<PessoaFisicaCriarDto> InitialDB = new List<PessoaFisicaCriarDto> 
    {
      new PessoaFisicaCriarDto("206.685.389-53", 
        new DateTime(1966,05,05), 
        "Anthony Noah Nogueira",
        "anthony.noah.nogueira@orthoi.com.br",
        "(89) 3652-7893",
        "Rua Santa Filomena, 163, Canto da Varzea - Picos - PI",
        "64600" ),

      new PessoaFisicaCriarDto("715.761.009-44", 
        new DateTime(1948,04,01), 
        "Heitor Benedito Bernardo da Mota",
        "heitor.benedito.damota@engemed.com",
        "(71) 3783-6755",
        "Via O-22, 378, São Cristóvão - Salvador - BA",
        "41510" ),

      new PessoaFisicaCriarDto("630.571.529-70", 
        new DateTime(1998,05,06), 
        "Emily Isabella Kamilly Ribeiro",
        "emilyisabellaribeiro@gracomonline.com.br",
        "(89) 3652-7893",
        "Praça Thomázia de Moura Santos, 829, Odilon José Carneiro - Araxá - MG",
        "38182" ),
    };
}
