## [13.1.74.62]

**Correções**

* 25.04.22 |DSML-1671 - Alterando o link de QR-Code para o estado de Minas Gerais

## [13.1.73.61]

25.04.01 | DSML-1670 - BUG - [Pugstorage] - [CTE] - [Externo] - [data e hora do CTE saindo em padrão americando]

## [13.1.72.59]

**Correções**

* DSML-1593 - Comp. CTe - Ajuste classe spdINI.pas componentes oAuth
* DSML-1438 - Análise/Ajuste - Componente - CTe - Validação excessiva tecnoaccount CTe
* DSML-1085 - Correção do preenchimento das propriedades de último log de envio/retorno


## [13.1.71.56]

**Novidade**

* DSP4G-1658 - Compatibilizado componente para o novo método de validação OAuth

## [13.1.69.54]

**Novidades**

* DSML-1517 - Atualizado URL's de produção para versão Simplificada.

## [13.1.68.52]

**Correções**

* 24.12.04 | DSML-1476 - correção do erro "arquivo XSD não encontrado" ao utilizar o CTeDataSetX via dll na versão simplificada.


## [13.1.69.48]

**Novidades**

* DSML-1236 - Compatibilização com a Nota Técnica 2024.002 – [CT-e Simplificado](https://blog.tecnospeed.com.br/ct-e-nota-tecnica-2024-002-ct-e-simplificado/)

**Correções**

* DSML-1351 - Cancelamento de Desacordo gerando xml com UF incorreta.



## [13.1.68.40]

 **Correções**

* DSML-1218 - DSP4G-1218 - Corrigido mapeamento dos campos do dataset para o vICMSDeson_530 e campo cBenef_531
* DSML-835 - Centralização da remoção dos namespaces em eventos que utilizam a SVSP

## [13.1.67.39]

**Novidades**

* DSML-1211 - habilitado envio EPEC para versão de manual 4.00;

**Correção**

* DSP4G-1505 - Movido validação do license do get da propriedade ambiente para a função que busca a url do webservice, pois só deve validar o license quando for comunicar com sefaz

## [13.1.66.36]

**Novidades**

- DSML-1014 - Compatibilizado intalador para o Delphi 12 Athenas

- DSML-1106 - Compatibilização com a [Nota Técnica 2024.001](https://blog.tecnospeed.com.br/ct-e-e-ct-e-os-nota-tecnica-2024-001-novos-campos-e-alteracao-das-regras-de-validacao/?asl_highlight=Nota+T%C3%A9cnica+2024.001&p_asid=1)

## [13.1.65.32]

**Novidade**

DSP4G-773 - integração por arquivo no formato JSON pelo novo metodo [GerarXMLPorJson](https://atendimento.tecnospeed.com.br/hc/pt-br/articles/20797383530263)

**Correções**

DSML-1088 - Implementado nova funcionalidade de [`Cancelamento do Evento Prestação do Serviço em Desacordo`](https://atendimento.tecnospeed.com.br/hc/pt-br/articles/20950465752855) na versão v4.00


## [13.1.64.27]

**Correções**

**DSML-890** - Ajustada a regra para gerar a tag IE vazia no grupo emiDocAnt apenas quando não houver valor no campo IE_286 e o campo UF_287 possuir valor.

**DSML-1030** - Correção da impressão do DACTE na versão 4.00 para imprimir a(s) chave(s) do CT-e complementado.

## [13.1.63.24]

**Correções**

**DSML-1006 - HOTFIX** - Correção do erro ao tentar cancelar um CTe com protocolo maior do que 15 caracteres. 

## [13.1.63.22]

DSML-900 - Atualizado Major version do produto.

## [12.1.63.20]

**Correção**

* DSML-809 - Melhorias no código de barras do Retrato.rtm da versão de manual 4.00
* DSML-815 - Correção do erro "The 'xmlns' attribute should not be specified" para o evento de Insucesso de Entrega/Cancelamento de Insucesso de Entrega no estado de São Paulo.
* DSML-832 - remoção do namespace para eventos que utilizam a Sefaz Virtual de São Paulo: AP, PE, RR; 

## [12.1.62.16]

**Novidades**

* DSML-696 -  Compatibilizado nova versão 4.00, cuja maior impacto foi a eliminação do modelo de envio assíncrono, confira todas as alterações:
https://blog.tecnospeed.com.br/ct-e-e-ct-e-os-manual-de-orientacoes-ao-contribuinte-versao-4-00/

## [12.1.61.2]

**Novidades**
* DSML-600 - implementação da nota técnica 2023.001

## [12.1.60.5317]

**Correções**
* DSML-484 - Dependências - Nome do produto após instalação.

## [12.1.60.5315]

#leiame

**Novidades**
* DSP4G-786 - Compatibilizado com atualizações do componente indy

**Correções**
* DSML-374 - correção do congelamento da aplicação ao imprimir uma nota utilizando a impressora, Microsoft Print to PDF, com C#.
* DSML-438 - Correção no modelo retrato.rtm e paisagem.rtm da versão 3.00 e 3.00a
* DSML-449 - CTe O arquivo de servidores informado não existe:C:\nodejs\xteServidoresProd.ini

## [12.1.60.5307]

**Correções**
- DSML-163 -  movendo  a chamada do método AtualizaDadosCTeEventos para os eventos
- DSML-358 - Impressão e exportação de CTE cancelado

## [12.1.60.5305]

- DSP4G-452 - adicionado propriedade CaracteresRemoverAcentos. Para mais detalhes acesse: https://atendimento.tecnospeed.com.br/hc/pt-br/articles/360006200994


## [12.1.60.5300]
**Novidades**
* DSP4G-66 - Adicionado método TestarEmailConfig para validar as configurações de email, para mais informações acesse: https://atendimento.tecnospeed.com.br/hc/pt-br/articles/8047751646487
* DSP4G-394 - Adicionado ao pacote de instalação do componente o arquivo "IDs_LIBs_CTe.ini" contendo os ID´s das OCXs.
* DSP4G-220 - Migrando os arquivos de templates para implementação "hardcoded".

**Correções:**
* DSP4G-345 - Implementado recurso de validação das chaves de NFe´s transportadas. O recurso funciona ao ativar a propriedade "ValidarEsquemaAntesEnvio".
* DSP4G-143 - Adicionado no menu do Windows a opção de desinstalação do pacote de dependências.

## [12.1.60.5296]
**Correções**
 - DSML-210 : Erro ao cancelar CTe com Tecnoaccount

## [12.1.60.5292]
**Correções**
 * DSML-126 - Método ConfigurarSoftwareHouse no envio do desacordo.

**Novidades**
 * DSP4G-49 Componente - CTe - NT 2022.001 v. 1.00 e 1.01 - 06/22

## [12.1.60.5285]
**Correções**
 * DSML-43 - Correção da exceção: 'Unable to create directory' ao utilizar componente dropando.

## [12.1.60.5282]
**Novidades**
 * DCIT-1061 - Adicionadas as propriedades de E-mail: QtdeTentativasEmail e UseTLS.

## [12.1.60.5261]
**Novidades**
* DCIT-1056 - Nova propriedade UseSecureBlackBox para envio de e-mail com SBB.

* DCIT-888 - Adicionadas as propriedades CnpjSoftwareHouse, TokenSoftwareHouse. Adicionada a propriedade DiagnosticMode no arquivo ini.

## [12.1.60.5253]        
**Correções**
*  DCIT-929  - corrigido Erro na impressão de unidade de medida na DACTE.
  
*  DCIT-1002 - correção na propriedade ModeloRetrato/ModeloPaisagem quando caminho informado é o mesmo do DiretorioTemplates

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























