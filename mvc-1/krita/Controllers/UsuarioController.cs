namespace krita.Controllers;

[Route("usuario")]
public class UsuarioController : AuthenticatedController
{
    [HttpGet("buscar")]
    public IActionResult BuscarUsuario()
    {
        return View("Index");
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> Cadastrar(CadastroDto CadastroDto)
    {
        CadastroDto.Senha = "111111";
        CadastroDto.IdUsuarioCadastro = UsuarioLogado.IdUsuario;
        ApiServices client = new ApiServices($"/usuario/cadastrar", UsuarioLogado.Token);
        HttpResponseMessage response = await client.Client.PostAsJsonAsync(client.Url, CadastroDto);

        ViewBag.MensagemTeste = "Testedeviewbag";
        if (response.IsSuccessStatusCode)
            return Ok("Usuario cadastrado com sucesso");

        var mensagem = await response?.Content.ReadAsStringAsync();
        return BadRequest(mensagem);

    }
}
