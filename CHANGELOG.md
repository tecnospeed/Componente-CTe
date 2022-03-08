## [12.1.60.5253]
**Novidades**

DCIT-1056 - Nova propriedade UseSecureBlackBox para envio de e-mail com SBB.

DCIT-888 - Adicionadas as propriedades CnpjSoftwareHouse, TokenSoftwareHouse. Adicionada a propriedade DiagnosticMode no arquivo ini.

## [12.1.60.5253]

             
**Correções**
  DCIT-929  - corrigido Erro na impressão de unidade de medida na DACTE.
  
  DCIT-1002 - correção na propriedade ModeloRetrato/ModeloPaisagem quando caminho informado é o mesmo do DiretorioTemplates

**Novidades**
  
  DCIT-954 - Alterar forma de configurar o modo SVC, agora é necessário informar se é SVCRS ou SVCSP.
             Para informações sobre envio com SVC acesse https://atendimento.tecnospeed.com.br/hc/pt-br/articles/360017029413
			 
  DCIT-992 - Adicionado campos LITRAGEM e MMBTU nos DACTE (Retrato.rtm/RetratoA5.rtm/Paisagem.rtm)
  
  DCIT-1005 - Alterar forma de configurar o modo EPEC para utilizar os ini's: cteServidoresProd.ini e cteServidoresHom.ini.
  
  DCIT-954  - Alterar forma de configurar o modo SVC, agora é necessário informar se é SVCRS ou SVCSP.
  
              Para informações sobre envio com SVC acesse https://atendimento.tecnospeed.com.br/hc/pt-br/articles/360017029413

## [12.1.60.5246]
**Correções**

  DCIT-839 - corrigido Codificação XML retorno do método TratarXMLRetornoDFe para UTF8

## [12.1.60.5245]
**Novidades**
  DCIT-778 - Novo license TecnoAccount

**Correções**
  DCIT-906 - Correção da Impressão DACTe diferente entre VersaoManual 3.00 e 3.00a
  
## [12.1.60.5243]
**Correções**
  DC-3719  - Evento de Cancelamento Comprovante de Entrega: A Sefaz de SP não aceita namespace no nó evCancCECTe.
  DC-3734  - Correção na impressão em lote, para exibir a informação da tarja cancelada para o cte correto
  DCIT-759 - Correção na impressão referente a tag qCarga para unidade Litros (Paisagem/Retrato/RetratoA5)
  
**Novidades**
  DCIT-704 - Compatibilizando o componente CTe para o Delphi 11 Alexandria.
LEIAME VS 12.1.60.5224 
**Correções**
  DC-3398 - Evento de Comprovante de Entrega para SP: remoção do namespace da tag evCECTe para evitar rejeição do evento.
  DC-3055 - No evento de Prestação de desacordo, a Sefaz de SP não aceita namespace no nó evPrestDesacordo. 

## [12.1.60.5222]
**Novidades**
  DC-1854 - Implementado tarja para indicar CTe cancelado na impressão do DACTE.

**Correções**
  DC-1154 - Alterar funções que estavam sem retorno padrão.
