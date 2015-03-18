$(document).ready(function()
{
	$('.botao').click(function()
	{
		$("#slide").children('img').attr('src', $(this).attr('src'));
		$("#slide").children('img').attr('alt', $(this).attr('alt'));
		document.getElementById('descricaoSlide').innerHTML = $(this).attr('alt');
	});
	
	$('#mascara').click(function()
	{
		fecharModal()
	});
});

function abrirModal()
{
	$('#mascara').css('visibility', 'visible');
	$('#modal').css('visibility', 'visible');
}

function fecharModal()
{
	$('#mascara').css('visibility', 'hidden');
	$('#modal').css('visibility', 'hidden');
	$('#modal').html('');
}

function criarGrafo()
{
	abrirModal();
	var html = "";
	html += '<form action="javascript:ws_criarGrafo();">';
	html += 'Nome do Grafo<br/> <input type="text" name="nomeGrafo" id="nomeGrafo"><br>';
	html += '<input type="submit" value="Criar">';
	html += '</form>';
	$('#modal').html(html);
}

function abrirGrafo()
{
	abrirModal();
	var html = "";
	html += '<form action="javascript:ws_abrirGrafo();">';
	html += 'Nome do Grafo<br/> <input type="text" name="nomeGrafo" id="nomeGrafo"><br>';
	html += '<input type="submit" value="abrir">';
	html += '</form>';
	$('#modal').html(html);
}

function desenharVertice(idVertice, valorVertice, posX, posY, cor)
{
	posX -= 15;
	posY -= 15;
	var vertice = $('#vertices').html() + '<circle cx="' + posX + '" cy="' + posY + '" r="10" stroke="black" stroke-width="2" fill="white" />'
	$('#vertices').html(vertice);
}