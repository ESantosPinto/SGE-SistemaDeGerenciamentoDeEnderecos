Aplicação Web de Gerenciamento de Endereços

Este projeto consiste em uma aplicação web desenvolvida em C# que permite aos usuários realizar o login e gerenciar um CRUD de endereços. 
A aplicação oferece a possibilidade de inserir os endereços manualmente ou buscar os dados automaticamente através da integração com a API do ViaCEP.

## Funcionalidades
- **Login de Usuário**: Permite ao usuário autenticar-se na aplicação.
- **Cadastro de Endereços**: O usuário pode inserir endereços manualmente ou utilizar o CEP para que a aplicação busque automaticamente os dados do endereço através da API do ViaCEP(https://viacep.com.br/).
- **Visualizar Endereços Salvos**: O usuário pode visualizar os endereços que já foram cadastrados.
- **Exportar Endereços para CSV**: O usuário tem a opção de exportar seus endereços salvos para um arquivo CSV.

## Como Usar

1. **Instalação**: 
   - Clone este repositório:
     ```bash
     git clone https://github.com/seu-usuario/seu-repositorio.git
     ```
   - Abra o projeto no Visual Studio 2022.  
   - Execute a aplicação.

2. **Login**: Ao acessar a aplicação, insira suas credenciais para realizar o login.

3. **Gerenciar Endereços**:
   - **Adicionar Endereço Manualmente**: Preencha os campos do formulário com o endereço completo.
   - **Buscar Endereço pelo CEP**: Insira o CEP e a aplicação preencherá automaticamente os campos do endereço com base nas informações da API do ViaCEP.

4. **Exportar Endereços para CSV**: Na tela de visualização de endereços, clique no botão "Exportar" para gerar um arquivo CSV contendo todos os endereços salvos.

## Tecnologias Utilizadas

- **C#**
- **ASP.NET Core**
- **ViaCEP API** (para busca de endereços pelo CEP)
- **CSV** (para exportação de dados)


## Licença

Este projeto está licenciado sob a [Licença MIT](LICENSE).
